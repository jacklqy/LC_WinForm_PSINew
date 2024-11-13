using Common;
using DbUtility;
using PSINew.Models.DModels;
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
       public  class StoreDAL:BaseDAL<StoreInfoModel>
        {
                StoreGoodsStockDAL sgsDAL = new StoreGoodsStockDAL();
                /// <summary>
                /// 获取指定类别的仓库列表
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public List<StoreInfoModel> GetStoresByTypeId(int typeId)
                {
                        List<StoreInfoModel> list =  GetModelList($"IsDeleted=0 and STypeId={typeId}", "StoreId,StoreName,StoreNo");
                        return list;
                }

                /// <summary>
                /// 获取所有的仓库列表（用于绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<StoreInfoModel> GetAllStores()
                {
                        return GetModelList("IsDeleted=0", "StoreId,StoreName");
                }
                /// <summary>
                /// 获取所有的仓库编号集合
                /// </summary>
                /// <returns></returns>
                public List<int> GetAllStoreIds()
                {
                        List<StoreInfoModel> stores = GetModelList("IsDeleted=0", "StoreId");
                        List<int> ids = new List<int>();
                        if (stores.Count > 0)
                                ids = stores.Select(s => s.StoreId).ToList();
                        return ids;
                }

                /// <summary>
                /// 检查仓库是否在使用中
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool CheckStoreUse(int storeId)
                {
                        string sql1 = $"select count(1) from PerchaseInStoreInfos where StoreId={storeId} and IsDeleted=0";
                        string sql2 = $"select count(1) from SaleOutStoreInfos where StoreId={storeId} and IsDeleted=0";
                        string sql3 = $"select count(1) from StoreGoodsStockInfos where StoreId={storeId} and (CurCount>0 or StCount>0) and IsDeleted=0";
                        string sql4 = $"select count(1) from StockStoreInfos where StoreId={storeId} and IsDeleted=0";
                        SqlParameter paraId = new SqlParameter("@storeId", storeId);
                        DataSet ds = GetDs($"{sql1};{sql2};{sql3};{sql4}", 1, paraId);
                        if (ds != null)
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
                /// 获取指定的仓库信息
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public StoreInfoModel GetStoreInfo(int storeId)
                {
                        string cols = "StoreId,StoreNo,StoreName,STypeId,StorePYNo,StoreOrder,StoreRemark";
                        return GetById(storeId, cols);
                }

                /// <summary>
                /// 删除仓库信息（删除、恢复、移除）
                /// </summary>
                /// <param name="storeIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <param name="uName"></param>
                /// <returns></returns>
                public bool DeleteStoreInfos(List<int> storeIds, int delType, int isDeleted,string uName)
                {
                        List<string> listSql = new List<string>();
                        //返回生成的批量sql语句
                        foreach (int storeId in storeIds)
                        {
                                string delStoreInfo = "";
                                string delStockInfo = "";
                                if (delType == 0)
                                {
                                        delStoreInfo = $"update StoreInfos set IsDeleted={isDeleted} where StoreId={storeId}";
                                        delStockInfo = $"update StoreGoodsStockInfos set IsDeleted={isDeleted} where StoreId={storeId}";
                                        if (isDeleted == 0)//恢复已删除仓库
                                        {
                                                //获取要恢复的仓库没有库存记录的商品编号（新增商品）
                                                List<int> goodsIds = sgsDAL.GetHasNoStockGoodsIds(storeId);
                                                if (goodsIds.Count > 0)
                                                {
                                                        foreach (int goodsId in goodsIds)
                                                        {
                                                                //添加这些商品的库存记录
                                                                string inSql = $"insert into StoreGoodsStockInfos(StoreId,GoodsId,Creator) values ({storeId},{goodsId},'{uName}')";
                                                                listSql.Add(inSql);
                                                        }
                                                }
                                        }
                                }
                                else
                                {
                                        delStoreInfo = $"delete from StoreInfos  where StoreId={storeId}";
                                        delStockInfo = $"delete from  StoreGoodsStockInfos  where StoreId={storeId}";
                                }
                                listSql.Add(delStoreInfo);
                                listSql.Add(delStockInfo);
                        }
                        return SqlHelper.ExecuteTrans(listSql);
                }

                /// <summary>
                /// 判断仓库是否已存在（同一类别下不能重名）
                /// </summary>
                /// <param name="storeName"></param>
                /// <param name="sTypeId"></param>
                /// <returns></returns>
                public bool ExistsStore(string storeName, int sTypeId)
                {
                        List<SqlParameter> listParas = new List<SqlParameter>();
                        string strWhere = "IsDeleted=0 and StoreName=@storeName";
                        if (sTypeId > 0)
                        {
                                strWhere += " and STypeId=@sTypeId";
                                listParas.Add(new SqlParameter("@sTypeId", sTypeId));
                        }
                        listParas.Add(new SqlParameter("@storeName", storeName));
                        return Exists(strWhere, listParas.ToArray());
                }

                /// <summary>
                /// 修改仓库信息
                /// </summary>
                /// <param name="storeInfo"></param>
                /// <returns></returns>
                public bool UpdateStoreInfo(StoreInfoModel storeInfo)
                {
                        string cols = "StoreId,StoreNo,StoreName,STypeId,StorePYNo,StoreOrder,StoreRemark";
                        return Update(storeInfo, cols);
                }

                /// <summary>
                /// 添加仓库信息
                /// </summary>
                /// <param name="storeInfo"></param>
                /// <param name="goodsIds">所有商品的编号集合</param>
                /// <returns></returns>
                public bool AddStoreInfo(StoreInfoModel storeInfo,List<int> goodsIds)
                {
                        string cols = "StoreNo,StoreName,STypeId,StorePYNo,StoreOrder,StoreRemark,Creator";
                        SqlModel insert = CreateSql.GetInsertSqlAndParas<StoreInfoModel>(storeInfo, cols, 1);
                        GoodsDAL goodsDAL = new GoodsDAL();
                        return SqlHelper.ExecuteTrans<bool>(cmd =>
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
                                        if (oId != null && oId.ToString() != "")
                                        {
                                                int storeId = oId.GetInt();
                                               //添加所有商品与该仓库的库存记录
                                                string sql = "insert into StoreGoodsStockInfos (StoreId,GoodsId,Creator) values(@storeId,@goodsId,@creator)";
                                                foreach (int goodsId in goodsIds)
                                                {
                                                        cmd.CommandText = sql;
                                                        cmd.CommandType = CommandType.Text;
                                                        cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                                                        cmd.Parameters.Add(new SqlParameter("@goodsId", goodsId));
                                                        cmd.Parameters.Add(new SqlParameter("@creator", storeInfo.Creator));
                                                        cmd.ExecuteNonQuery();
                                                        cmd.Parameters.Clear();
                                                }
                                              
                                        }
                                        cmd.Transaction.Commit();
                                        return true;
                                }
                                catch (Exception ex)
                                {
                                        cmd.Transaction.Rollback();
                                        throw new Exception("添加仓库执行异常！", ex);
                                }

                        });
                }
        }
}
