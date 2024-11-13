using Common;
using DbUtility;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
       public  class GoodsDAL:BaseDAL<GoodsInfoModel>
        {
                StoreGoodsStockDAL sgsDAL = new StoreGoodsStockDAL();
                /// <summary>
                /// 分页条件查询商品列表
                /// </summary>
                /// <param name="gTypeId"></param>
                /// <param name="keywords"></param>
                /// <param name="isStopped"></param>
                /// <param name="isDeleted"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<ViewGoodsInfoModel> LoadGoodsList(int gTypeId, string keywords, int isStopped, int isDeleted, int startIndex, int pageSize)
                {
                        //存储过程  返回两个结果   总记录数    当前页数据列表
                        string cols = "GoodsId,GoodsNo,GoodsName,GoodsPYNo,GoodsTXNo,GUnit,GTypeId,GTypeName,GProperties,IsStopped,RetailPrice,Remark";
                        string strWhere = "1=1";
                        strWhere += $" and IsStopped={isStopped} and IsDeleted={isDeleted}";
                        //总记录数    当前页数据列表
                        DataSet ds =  GetPageDs<ViewGoodsInfoModel>(strWhere, gTypeId, keywords, cols, "proc_GetGoodsPage", startIndex, pageSize);
                        return DsToPageModel<ViewGoodsInfoModel>(ds, cols);
                }

                /// <summary>
                /// 获取指定的商品信息
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public GoodsInfoModel GetGoodsInfo(int goodsId)
                {
                        string cols = "GoodsId,GoodsName,GoodsNo,GoodsPYNo,GoodsSName,GoodsTXNo,GUnit,GTypeId,GProperties,IsStopped,RetailPrice,LowPrice,PrePrice,DisCount,BidPrice,Remark,GoodsPic";
                        return GetById(goodsId, cols);
                }

                /// <summary>
                /// 删除商品信息
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="delType">0 LogicDel   1 Delete</param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public bool DeleteGoodsInfos(List<int> goodsIds,int delType, int isDeleted,string uName)
                {
                        List<string> listSql = new List<string>();
                        //返回生成的批量sql语句
                        foreach(int gId in goodsIds)
                        {
                                string delGoodsInfo = "";
                                string delStockInfo = "";
                                if(delType ==0)
                                {
                                        delGoodsInfo = $"update GoodsInfos set IsDeleted={isDeleted} where GoodsId={gId}";
                                        delStockInfo = $"update StoreGoodsStockInfos set IsDeleted={isDeleted} where GoodsId={gId}";
                                        if (isDeleted == 0)//恢复已删除商品
                                        {
                                                //获取要恢复的商品没有库存记录的仓库编号
                                                List<int> storeIds = sgsDAL.GetHasNoStockStoreIds(gId);
                                                if (storeIds.Count > 0)
                                                {
                                                        foreach (int storeId in storeIds)
                                                        {
                                                                //添加这些仓库的库存记录
                                                                string inSql = $"insert into StoreGoodsStockInfos(StoreId,GoodsId,Creator) values ({storeId},{gId},'{uName}')";
                                                                listSql.Add(inSql);

                                                        }
                                                }
                                        }
                                }
                                else
                                {
                                        delGoodsInfo = $"delete from GoodsInfos  where GoodsId={gId}";
                                        delStockInfo = $"delete from  StoreGoodsStockInfos  where GoodsId={gId}";
                                }
                                listSql.Add(delGoodsInfo);
                                listSql.Add(delStockInfo);
                        }
                      return  SqlHelper.ExecuteTrans(listSql);
                }

                /// <summary>
                /// 判断指定商品是否在使用中
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool CheckIsGoodsUse(int goodsId)
                {
                        string sql1 = $"select count(1) from PerchaseGoodsInfos where GoodsId={goodsId} and IsDeleted=0";
                        string sql2 = $"select count(1) from SaleGoodsInfos where GoodsId={goodsId} and IsDeleted=0";
                        string sql3 = $"select count(1) from StoreGoodsStockInfos where GoodsId={goodsId} and (CurCount>0 or StCount>0) and IsDeleted=0";
                        string sql4 = $"select count(1) from StStockGoodsInfos where GoodsId={goodsId} and IsDeleted=0" ;
                        SqlParameter paraId = new SqlParameter("@goodsId", goodsId);
                        DataSet ds = GetDs($"{sql1};{sql2};{sql3};{sql4}", 1, paraId);
                        if(ds!=null)
                        {
                                int count1 = ds.Tables[0].Rows[0][0].ToString().GetInt();
                                int count2 = ds.Tables[1].Rows[0][0].ToString().GetInt();
                                int count3 = ds.Tables[2].Rows[0][0].ToString().GetInt();
                                int count4 = ds.Tables[3].Rows[0][0].ToString().GetInt();
                                if (count1 > 0 || count2 > 0 || count3 > 0 || count4 > 0)
                                        return true;
                        }
                        return false;
                }

                /// <summary>
                /// 添加商品
                /// </summary>
                /// <param name="goodsInfo"></param>
                /// <returns></returns>
                public bool AddGoodsInfo(GoodsInfoModel goodsInfo)
                {
                        string cols = "GoodsName,GoodsNo,GoodsPYNo,GoodsSName,GoodsTXNo,GUnit,GTypeId,GProperties,IsStopped,RetailPrice,LowPrice,PrePrice,DisCount,BidPrice,Remark,GoodsPic,Creator";
                       SqlModel insert =   CreateSql.GetInsertSqlAndParas<GoodsInfoModel>(goodsInfo, cols, 1);
                        StoreDAL storeDAL = new StoreDAL();
                        List<int> storeIds = storeDAL.GetAllStoreIds();
                       return   SqlHelper.ExecuteTrans<bool>(cmd =>
                        {
                                try
                                {
                                        cmd.CommandText = insert.Sql;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.Clear();
                                        foreach (var p in insert.SqlParaArray)
                                        {
                                                cmd.Parameters.Add(p);
                                        }
                                        object oId = cmd.ExecuteScalar();
                                        cmd.Parameters.Clear();
                                        if(oId!=null&&oId.ToString()!="")
                                        {
                                                int goodsId = oId.GetInt();
                                               //商品库存记录
                                                string sql = "insert into StoreGoodsStockInfos (StoreId,GoodsId,Creator) values(@storeId,@goodsId,@creator)";
                                                foreach (int storeId in storeIds)
                                                {
                                                        cmd.CommandText = sql;
                                                        cmd.CommandType = CommandType.Text;
                                                        cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                                                        cmd.Parameters.Add(new SqlParameter("@goodsId", goodsId));
                                                        cmd.Parameters.Add(new SqlParameter("@creator", goodsInfo.Creator));
                                                        cmd.ExecuteNonQuery();
                                                        cmd.Parameters.Clear();
                                                }
                                                //添加总库存记录
                                                cmd.CommandText = sql;
                                                cmd.CommandType = CommandType.Text;
                                                int sId = 0;
                                                cmd.Parameters.Add(new SqlParameter("@storeId", sId));
                                                cmd.Parameters.Add(new SqlParameter("@goodsId", goodsId));
                                                cmd.Parameters.Add(new SqlParameter("@creator", goodsInfo.Creator));
                                                cmd.ExecuteNonQuery();
                                                cmd.Parameters.Clear();
                                        }
                                        cmd.Transaction.Commit();
                                        return true;
                                }
                                catch(Exception ex)
                                {
                                        cmd.Transaction.Rollback();
                                        throw new Exception("添加商品执行异常！", ex);
                                }
                             
                        });
                }

                /// <summary>
                /// 修改商品信息
                /// </summary>
                /// <param name="goodsInfo"></param>
                /// <returns></returns>
                public bool UpdateGoodsInfo(GoodsInfoModel goodsInfo)
                {
                        string cols = "GoodsId,GoodsName,GoodsNo,GoodsPYNo,GoodsSName,GoodsTXNo,GUnit,GTypeId,GProperties,IsStopped,RetailPrice,LowPrice,PrePrice,DisCount,BidPrice,Remark,GoodsPic";
                       return  Update(goodsInfo, cols);
                }

                /// <summary>
                /// 判断商品名称是否已存在
                /// </summary>
                /// <param name="goodsName"></param>
                /// <returns></returns>
                public bool ExistGoodsName(string goodsName)
                {
                        return ExistsByName("GoodsName", goodsName);
                }

                /// <summary>
                /// 获取所有的商品编号集合
                /// </summary>
                /// <returns></returns>
                public List<int> GetAllGoodsIds()
                {
                        List<int> goodsIds = new List<int>();
                        List<GoodsInfoModel> goodsList = GetModelList("IsDeleted=0", "GoodsId");
                        if (goodsList.Count > 0)
                                goodsIds = goodsList.Select(g => g.GoodsId).ToList();
                        return goodsIds;
                }

           

                /// <summary>
                /// 关键词获取商品信息
                /// </summary>
                /// <param name="keywords"></param>
                /// <returns></returns>
                public GoodsInfoModel GetGoodsInfoByKeywords(string keywords)
                {
                        string strWhere = " GoodsName like @keywords or GoodsNo like @keywords or GoodsPYNo like @keywords";
                        SqlParameter paraKeywords = new SqlParameter("@keywords", $"%{keywords}%");
                        return GetModel(strWhere, "", paraKeywords);
                }

                /// <summary>
                /// 根据类别获取商品列表
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public List<GoodsInfoModel> GetGoodsListByTypeId(int typeId)
                {
                        string strWhere = "IsDeleted=0";
                        if (typeId > 0)
                                strWhere += $" and GTypeId={typeId}";
                       return   GetModelList(strWhere, "GoodsId,GoodsNo,GoodsName,GoodsTXNo,GUnit,GTypeId");
                }
        }
}
