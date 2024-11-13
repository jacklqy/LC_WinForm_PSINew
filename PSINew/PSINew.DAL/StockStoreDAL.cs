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
    public class StockStoreDAL : BaseDAL<StockStoreInfoModel>
    {
        StStockGoodsDAL sgDAL = new StStockGoodsDAL();
        ViewStStockGoodsDAL vssgDAL = new ViewStStockGoodsDAL();
        /// <summary>
        /// 获取未审核的期初入库单
        /// </summary>
        /// <returns></returns>
        public int GetUnCheckedStartStock()
        {
            string sql = "select count(1) from StockStoreInfos where IsChecked=0";
            object oCount = SqlHelper.ExecuteScalar(sql, 1);
            if (oCount != null && oCount.ToString() != "")
                return oCount.GetInt();
            else
                return 0;
        }

        /// <summary>
        ///    获取指定的入库单信息
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public StockStoreInfoModel GetStockInfo(int stockId)
        {
            string cols = "StockId,StockNo,StoreId,DealPerson,Creator,CreateTime,IsChecked,Remark";
            return GetById(stockId, cols);
        }

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="stockInfo"></param>
        /// <param name="stockGoodsList"></param>
        /// <returns>入库单编号 与 入库单号</returns>
        public string AddStockInfo(StockStoreInfoModel stockInfo, List<StStockGoodsInfoModel> stockGoodsList)
        {
            //入库单表的列名
            string cols = "StoreId,DealPerson,Remark,StockNo,Creator,CreateTime";
            //插入期初库存商品列表的列名
            string sgCols = "StockId,GoodsId,StCount,StPrice,StAmount,Remark";
            //生成入库单号---保存入库单信息--保存入库商品明细列表
            return SqlHelper.ExecuteTrans<string>(cmd =>
            {
                try
                {
                    //获取生成的入库单号
                    cmd.CommandText = "makeStockNo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    object stockNo = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (stockNo != null && stockNo.ToString() != "")
                    {
                        //保存入库单
                        stockInfo.StockNo = stockNo.ToString();
                        SqlModel inStock = CreateSql.GetInsertSqlAndParas<StockStoreInfoModel>(stockInfo, cols, 1);
                        cmd.CommandText = inStock.Sql;
                        foreach (var p in inStock.SqlParaArray)
                        {
                            cmd.Parameters.Add(p);
                        }
                        cmd.CommandType = CommandType.Text;
                        object oStockId = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();

                        if (oStockId != null && oStockId.GetInt() > 0)
                        {
                            //入库商品明细保存
                            foreach (StStockGoodsInfoModel si in stockGoodsList)
                            {
                                si.StockId = oStockId.GetInt();
                                SqlModel inStockGoods = CreateSql.GetInsertSqlAndParas<StStockGoodsInfoModel>(si, sgCols, 0);
                                cmd.CommandText = inStockGoods.Sql;
                                cmd.CommandType = CommandType.Text;
                                foreach (var p in inStockGoods.SqlParaArray)
                                {
                                    cmd.Parameters.Add(p);
                                }
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                        }
                        cmd.Transaction.Commit();
                        return oStockId.ToString() + "," + stockNo.ToString();
                    }
                    return "";
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception("执行添加入库单异常！", ex);
                }

            });
        }

        /// <summary>
        /// 更新入库单信息
        /// </summary>
        /// <param name="stockInfo"></param>
        /// <param name="stockGoodsList"></param>
        /// <returns></returns>
        public bool UpdateStockInfo(StockStoreInfoModel stockInfo, List<StStockGoodsInfoModel> stockGoodsList)
        {
            string cols = "StockId,StoreId,DealPerson,Remark";
            string sgCols = "StockId,GoodsId,StCount,StPrice,StAmount,Remark";
            List<CommandInfo> comList = new List<CommandInfo>();
            SqlModel upStock = CreateSql.GetUpdateSqlAndParas<StockStoreInfoModel>(stockInfo, cols, "");
            //修改入库单信息
            comList.Add(new CommandInfo()
            {
                CommandText = upStock.Sql,
                IsProc = false,
                Paras = upStock.SqlParaArray
            });
            //删除已移除的商品明细数据

            //商品明细编号集合字符串
            string goodsIds = string.Join(",", stockGoodsList.Select(g => g.GoodsId));
            comList.Add(new CommandInfo()
            {
                CommandText = $"delete from StStockGoodsInfos where StockId ={stockInfo.StockId} and GoodsId not in ({goodsIds})",
                IsProc = false
            });

            //明细商品列表保存：修改、添加 两种
            foreach (StStockGoodsInfoModel sg in stockGoodsList)
            {
                if (sgDAL.ExistsGoods(stockInfo.StockId, sg.GoodsId))
                {
                    string upSql = "update StStockGoodsInfos set StCount=@count,StPrice=@stPrice,StAmount=@stAmount,Remark=@remark where StockId=@stockId and GoodsId=@goodsId";
                    SqlParameter[] paras =
                    {
                                                new SqlParameter("@stockId",stockInfo.StockId),
                                                new SqlParameter("@goodsId",sg.GoodsId),
                                                new SqlParameter("@count",sg.StCount),
                                                new SqlParameter("@stPrice",sg.StPrice),
                                                new SqlParameter("@remark",sg.Remark),
                                                new SqlParameter("@stAmount",sg.StAmount)
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
                    sg.StockId = stockInfo.StockId;
                    SqlModel inStStockGoods = CreateSql.GetInsertSqlAndParas<StStockGoodsInfoModel>(sg, sgCols, 0);
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
        /// 审核、作废、红冲 入库单
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="checkPerson"></param>
        /// <param name="storeId"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public bool CheckStockInfo(int stockId, string checkPerson, int storeId, int isChecked)
        {
            string sqlUpCheck = "update StockStoreInfos set IsChecked=@isChecked";
            if (isChecked == 1)//审核单据：已审核
                sqlUpCheck += ",CheckPerson=@checkPerson,CheckTime=@checkTime";
            sqlUpCheck += " where StockId=@stockId";
            SqlParameter[] paras =
            {
                                new SqlParameter("@isChecked",isChecked),
                                new SqlParameter("@checkPerson",checkPerson),
                                new SqlParameter("@checkTime",DateTime.Now),
                                new SqlParameter("@stockId",stockId)
                        };
            //已审核、红冲   影响库存数量   isChecked 2:作废，不影响库存
            List<ViewStStockGoodsInfoModel> stockGoodsList = null;//入库商品明细列表
            if (isChecked != 2)
            {
                stockGoodsList = vssgDAL.GetStockGoodsList(stockId);
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
                                cmd = CreateCmd(cmd, stockGoodsList, storeId, isChecked);
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
        /// 修改库存
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="stockGoodsList"></param>
        /// <param name="storeId"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        private IDbCommand CreateCmd(IDbCommand cmd, List<ViewStStockGoodsInfoModel> stockGoodsList, int storeId, int isChecked)
        {
            //isChecked  加或减  仓库量
            string strChar = "+";
            if (isChecked == 3)
                strChar = "-";

            //期初入库了多次，红冲当前单据中的数量  处理： StCount  StAmount  拿出来，StCount-@StCount=0,StPrice=0
            string selStock = "select StCount,StAmount from  StoreGoodsStockInfos  where StoreId=@storeId and GoodsId=@goodsId";

            string upStock = "update StoreGoodsStockInfos";
            upStock += $" set StCount=StCount{strChar}@stCount,StAmount=StAmount{strChar}@stAmount,";
            upStock += $"CurCount=CurCount{strChar}@stCount,StockAmount=StockAmount{strChar}@stAmount";
            string strWhere = " where StoreId=@storeId and GoodsId=@goodsId";
            string upAllStock = "update StoreGoodsStockInfos";
            upAllStock += $" set  CurCount=CurCount{strChar}@stCount,StockAmount=StockAmount{strChar}@stAmount  where StoreId=0 and GoodsId=@goodsId";
            //库存变动记录 
            string upStockChange = "insert into StockChangeInfos (CheckShId,ShType,StoreId,GoodsId,InCount,CurCount) values(@stockId,@shType,@storeId,@goodsId,@inCount,@curCountTotal)";
            foreach (var sg in stockGoodsList)
            {
                cmd.CommandText = selStock;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                IDataReader dr = cmd.ExecuteReader();
                int stCount = 0;
                decimal stAmount = 0;
                decimal stPrice = 0;
                if (dr.Read())
                {
                    stCount = (int)dr["StCount"];
                    stAmount = (decimal)dr["StAmount"];
                }
                dr.Close();
                cmd.Parameters.Clear();
                //获取当前的期初数量与金额
                if (stCount == sg.StCount)
                    stPrice = 0;
                else
                    stPrice = (stAmount - sg.StAmount) / (stCount - sg.StCount);

                string upStock0 = upStock;
                upStock0 += ",StPrice=@stPrice" + strWhere;
                cmd.CommandText = upStock0;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@stCount", sg.StCount));
                cmd.Parameters.Add(new SqlParameter("@stPrice", stPrice));
                cmd.Parameters.Add(new SqlParameter("@stAmount", sg.StAmount));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = upAllStock;
                cmd.Parameters.Add(new SqlParameter("@stCount", sg.StCount));
                cmd.Parameters.Add(new SqlParameter("@stAmount", sg.StAmount));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //添加库存变动明细
                int inCount = sg.StCount;
                if (isChecked == 3)//红冲
                    inCount = -sg.StCount;
                int curCount = 0;
                cmd.CommandText = "select CurCount from StoreGoodsStockInfos where GoodsId=@goodsId and StoreId=@storeId";
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                object ototalCount = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if (ototalCount != null)
                {
                    curCount = ototalCount.GetInt();
                }
                cmd.CommandText = upStockChange;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@stockId", sg.StockId));
                cmd.Parameters.Add(new SqlParameter("@shType", 3));
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
