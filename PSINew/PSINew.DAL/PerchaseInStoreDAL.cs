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
        /// <summary>
        /// 关于采购单的处理类
        /// </summary>
       public  class PerchaseInStoreDAL:BaseDAL<PerchaseInStoreInfoModel>
        {
                PerchaseGoodsDAL pgDAL = new PerchaseGoodsDAL();
                ViewPerChaseGoodsDAL vpgDAL = new ViewPerChaseGoodsDAL();
                /// <summary>
                /// 添加采购单
                /// </summary>
                /// <param name="perchaseInfo"></param>
                /// <param name="perGoodsList"></param>
                /// <returns>采购单编号 与 采购单号</returns>
                public string AddPerchaseInfo(PerchaseInStoreInfoModel perchaseInfo, List<PerchaseGoodsInfoModel> perGoodsList)
                {
                        //采购单表的列名
                        string cols = "UnitId,StoreId,DealPerson,PayDesp,ThisAmount,Remark,TotalAmount,YHAmount,PerchaseNo,Creator,CreateTime";
                        if (perchaseInfo.PayTime != null)
                                cols += ",PayTime,IsPayed,IsPayFull";
                        //插入采购商品列表的列名
                        string sgCols = "PerId,GoodsId,GUnit,Count,PerPrice,Amount,Remark";
                        //生成采购单号---保存采购单信息--保存采购商品明细列表
                        return SqlHelper.ExecuteTrans<string>(cmd =>
                        {
                                try
                                {
                                        //获取生成的采购单号
                                        cmd.CommandText = "makePerNo";
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        object perNo = cmd.ExecuteScalar();
                                        cmd.Parameters.Clear();
                                        if (perNo != null && perNo.ToString() != "")
                                        {
                                                //保存入库单
                                                perchaseInfo.PerchaseNo = perNo.ToString();
                                                SqlModel inStock = CreateSql.GetInsertSqlAndParas<PerchaseInStoreInfoModel>(perchaseInfo, cols, 1);
                                                cmd.CommandText = inStock.Sql;
                                                foreach (var p in inStock.SqlParaArray)
                                                {
                                                        cmd.Parameters.Add(p);
                                                }
                                                cmd.CommandType = CommandType.Text;
                                                object oPerId = cmd.ExecuteScalar();
                                                cmd.Parameters.Clear();

                                                if (oPerId != null && oPerId.GetInt() > 0)
                                                {
                                                        //入库商品明细保存
                                                        foreach (PerchaseGoodsInfoModel si in perGoodsList)
                                                        {
                                                                si.PerId = oPerId.GetInt();
                                                                SqlModel inPerGoods = CreateSql.GetInsertSqlAndParas<PerchaseGoodsInfoModel>(si, sgCols, 0);
                                                                cmd.CommandText = inPerGoods.Sql;
                                                                cmd.CommandType = CommandType.Text;
                                                                foreach (var p in inPerGoods.SqlParaArray)
                                                                {
                                                                        cmd.Parameters.Add(p);
                                                                }
                                                                cmd.ExecuteNonQuery();
                                                                cmd.Parameters.Clear();
                                                        }

                                                }
                                                cmd.Transaction.Commit();
                                                return oPerId.ToString() + "," + perNo.ToString();
                                        }
                                        return "";
                                }
                                catch (Exception ex)
                                {
                                        cmd.Transaction.Rollback();
                                        throw new Exception("执行添加采购单异常！", ex);
                                }

                        });
                }

                /// <summary>
                /// 更新采购单信息
                /// </summary>
                /// <param name="perchaseInfo"></param>
                /// <param name="perGoodsList"></param>
                /// <returns></returns>
                public bool UpdatePerchaseInfo(PerchaseInStoreInfoModel perchaseInfo, List<PerchaseGoodsInfoModel> perGoodsList)
                {
                        string cols = "UnitId,StoreId,DealPerson,PayDesp,ThisAmount,Remark,TotalAmount,YHAmount,PerId";
                        if (perchaseInfo.PayTime != null)
                                cols += ",PayTime,IsPayed";
                        if (perchaseInfo.IsPayFull == 1)
                                cols += ",IsPayFull";
                        //插入采购商品列表的列名
                        string pgCols = "PerId,GoodsId,GUnit,Count,PerPrice,Amount,Remark";
                        List<CommandInfo> comList = new List<CommandInfo>();
                        SqlModel upStock = CreateSql.GetUpdateSqlAndParas(perchaseInfo, cols, "");
                        //修改采购单信息
                        comList.Add(new CommandInfo()
                        {
                                CommandText = upStock.Sql,
                                IsProc = false,
                                Paras = upStock.SqlParaArray
                        });
                        //删除已移除的商品明细数据

                        //商品明细编号集合字符串
                        string goodsIds = string.Join(",", perGoodsList.Select(g => g.GoodsId));
                        comList.Add(new CommandInfo()
                        {
                                CommandText = $"delete from PerchaseGoodsInfos where PerId ={perchaseInfo.PerId} and GoodsId not in ({goodsIds})",
                                IsProc = false
                        });

                        //明细商品列表保存：修改、添加 两种
                        foreach (PerchaseGoodsInfoModel sg in perGoodsList)
                        {
                                if (pgDAL.ExistsGoods(perchaseInfo.PerId, sg.GoodsId))
                                {
                                        string upSql = "update PerchaseGoodsInfos set Count=@count,PerPrice=@perPrice,Amount=@Amount,Remark=@remark where PerId=@perId and GoodsId=@goodsId";
                                        SqlParameter[] paras =
                                        {
                                                new SqlParameter("@perId",perchaseInfo.PerId),
                                                new SqlParameter("@goodsId",sg.GoodsId),
                                                new SqlParameter("@count",sg.Count),
                                                new SqlParameter("@perPrice",sg.PerPrice),
                                                new SqlParameter("@remark",sg.Remark),
                                                new SqlParameter("@Amount",sg.Amount)
                                    };
                                        comList.Add(new CommandInfo()
                                        {
                                                CommandText = upSql,
                                                IsProc = false,
                                                Paras = paras
                                        });
                                }
                                else//新增处理
                                {
                                        sg.PerId = perchaseInfo.PerId;
                                        SqlModel inStStockGoods = CreateSql.GetInsertSqlAndParas(sg, pgCols, 0);
                                        comList.Add(new CommandInfo()
                                        {
                                                CommandText = inStStockGoods.Sql,
                                                IsProc = false,
                                                Paras = inStStockGoods.SqlParaArray
                                        });
                                }
                        }
                        return SqlHelper.ExecuteTrans(comList);
                }

                /// <summary>
                /// 获取指定的采购单信息
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public PerchaseInStoreInfoModel GetPerchaseInStoreInfo(int perId)
                {
                        string cols = "PerId,PerchaseNo,UnitId,StoreId,DealPerson,PayDesp,ThisAmount,YHAmount,Creator,CreateTime,IsChecked,Remark,TotalAmount,IsPayed,IsPayFull";
                        return GetById(perId, cols);
                }

                /// <summary>
                /// 采购单的审核处理   审核  作废   红冲
                /// </summary>
                /// <param name="perId"></param>
                /// <param name="checkPerson"></param>
                /// <param name="storeId"></param>
                /// <param name="isChecked"></param>
                /// <returns></returns>
                public bool CheckPerchaseInfo(int perId,string checkPerson,int storeId,int isChecked)
                {
                        string sqlUpCheck = "update PerchaseInStoreInfos set IsChecked=@isChecked";
                        if (isChecked == 1)//审核单据：已审核
                                sqlUpCheck += ",CheckPerson=@checkPerson,CheckTime=@checkTime";
                        sqlUpCheck += " where PerId=@perId";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@isChecked",isChecked),
                                new SqlParameter("@checkPerson",checkPerson),
                                new SqlParameter("@checkTime",DateTime.Now),
                                new SqlParameter("@perId",perId)
                        };
                        //已审核、红冲   影响库存数量   isChecked 2:作废，不影响库存
                        List<ViewPerGoodsInfoModel> perGoodsList = null;//采购商品明细列表
                        if (isChecked != 2)
                        {
                                perGoodsList = vpgDAL.GetPerchaseGoodsList(perId);
                        }
                        //提交修改，修改商品的库存（如果是审核或红冲）
                        return SqlHelper.ExecuteTrans<bool>(cmd =>
                        {
                                try
                                {
                                        cmd.CommandText = sqlUpCheck;
                                        cmd.CommandType = CommandType.Text;
                                        foreach (SqlParameter para in paras)
                                        {
                                                cmd.Parameters.Add(para);
                                        }
                                        int count = cmd.ExecuteNonQuery();
                                        cmd.Parameters.Clear();
                                        if (count > 0)
                                        {
                                                //修改库存
                                                switch (isChecked)
                                                {
                                                        case 1://已审核 
                                                        case 3://红冲  
                                                                cmd = CreateCmd(cmd, perGoodsList, storeId, isChecked);
                                                                break;
                                                }
                                                cmd.Transaction.Commit();
                                                return true;
                                        }
                                        return false;
                                }
                                catch (Exception ex)
                                {
                                        cmd.Transaction.Rollback();
                                        throw new Exception("审核单据出现异常！", ex);
                                }

                        });
                }

                /// <summary>
                /// 构造IDBCommand要执行的操作并执行
                /// </summary>
                /// <param name="cmd"></param>
                /// <param name="perGoodsList"></param>
                /// <param name="storeId"></param>
                /// <param name="isChecked"></param>
                /// <returns></returns>
                private IDbCommand CreateCmd(IDbCommand cmd, List<ViewPerGoodsInfoModel> perGoodsList, int storeId, int isChecked)
                {
                        //isChecked  加或减  仓库量   审核 +   红冲 -
                        string strChar = "+";
                        if (isChecked == 3)
                                strChar = "-";
                        string upStock = "update StoreGoodsStockInfos";
                        upStock += $" set CurCount=CurCount{strChar}@count,StockAmount=StockAmount{strChar}@Amount";
                        upStock += " where StoreId=@storeId and GoodsId=@goodsId";
                        string upAllStock = "update StoreGoodsStockInfos";
                        upAllStock += $" set  CurCount=CurCount{strChar}@count,StockAmount=StockAmount{strChar}@Amount  where StoreId=0 and GoodsId=@goodsId";
                        //库存变动记录 
                        string upStockChange = "insert into StockChangeInfos (CheckShId,ShType,StoreId,GoodsId,InCount,CurCount) values(@perId,@shType,@storeId,@goodsId,@inCount,@curCountTotal)";
                        foreach (var sg in perGoodsList)
                        {
                                cmd.CommandText = upStock;
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add(new SqlParameter("@count", sg.Count));
                                cmd.Parameters.Add(new SqlParameter("@Amount", sg.Amount));
                                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                           
                                cmd.CommandText = upAllStock;
                                cmd.Parameters.Add(new SqlParameter("@count", sg.Count));
                                cmd.Parameters.Add(new SqlParameter("@Amount", sg.Amount));
                                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                //添加库存变动明细
                                int inCount = sg.Count;
                                if (isChecked == 3)//红冲
                                        inCount = -sg.Count;
                                int curCount = 0;
                                //获取当前的库存量
                                cmd.CommandText = "select CurCount from StoreGoodsStockInfos where GoodsId=@goodsId and StoreId=@storeId";
                                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                                object ototalCount = cmd.ExecuteScalar();
                                cmd.Parameters.Clear();
                                if (ototalCount != null)
                                {
                                        curCount = ototalCount.GetInt();
                                }
                                //添加库存变动记录
                                cmd.CommandText = upStockChange;
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add(new SqlParameter("@perId", sg.PerId));
                                cmd.Parameters.Add(new SqlParameter("@shType", 1));
                                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                                cmd.Parameters.Add(new SqlParameter("@inCount", inCount));
                                cmd.Parameters.Add(new SqlParameter("@curCountTotal", curCount));
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                        }
                        return cmd;
                }
        }
}
