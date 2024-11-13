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
    /// 销售单DAL处理类
    /// </summary>
    public class SaleOutStoreDAL : BaseDAL<SaleOutStoreInfoModel>
    {
        SaleGoodsDAL sgDAL = new SaleGoodsDAL();
        ViewSaleGoodsDAL vsgDAL = new ViewSaleGoodsDAL();

        /// <summary>
        /// 获取指定的销售单信息
        /// </summary>
        /// <param name="saleId"></param>
        /// <returns></returns>
        public SaleOutStoreInfoModel GetSaleOutStoreInfo(int saleId)
        {
            string cols = "SaleId,SaleOutNo,UnitId,StoreId,DealPerson,PayDesp,ThisAmount,YHAmount,Creator,CreateTime,IsChecked,Remark,TotalAmount,IsPayed,IsPayFull";
            return GetById(saleId, cols);
        }

        /// <summary>
        /// 添加销售单
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <param name="saleGoodsList"></param>
        /// <returns>销售单编号 与 销售单号</returns>
        public string AddSaleOutStoreInfo(SaleOutStoreInfoModel saleInfo, List<SaleGoodsInfoModel> saleGoodsList)
        {
            //销售单表的列名
            string cols = "UnitId,StoreId,DealPerson,PayDesp,ThisAmount,Remark,TotalAmount,YHAmount,SaleOutNo,Creator,CreateTime";
            if (saleInfo.PayTime != null)
                cols += ",PayTime,IsPayed,IsPayFull";
            //插入销售商品列表的列名
            string sgCols = "SaleId,GoodsId,GUnit,Count,SalePrice,Amount,Remark";
            //生成销售单号---保存销售单信息--保存销售商品明细列表
            return SqlHelper.ExecuteTrans<string>(cmd =>
            {
                try
                {
                                //获取生成的销售单号
                                cmd.CommandText = "makeSaleNo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    object saleNo = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (saleNo != null && saleNo.ToString() != "")
                    {
                                    //保存销售单
                                    saleInfo.SaleOutNo = saleNo.ToString();
                        SqlModel inStock = CreateSql.GetInsertSqlAndParas<SaleOutStoreInfoModel>(saleInfo, cols, 1);
                        cmd.CommandText = inStock.Sql;
                        foreach (var p in inStock.SqlParaArray)
                        {
                            cmd.Parameters.Add(p);
                        }
                        cmd.CommandType = CommandType.Text;
                        object oSaleId = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();

                        if (oSaleId != null && oSaleId.GetInt() > 0)
                        {
                                        //出库商品明细保存
                                        foreach (SaleGoodsInfoModel si in saleGoodsList)
                            {
                                si.SaleId = oSaleId.GetInt();
                                SqlModel inSaleGoods = CreateSql.GetInsertSqlAndParas<SaleGoodsInfoModel>(si, sgCols, 0);
                                cmd.CommandText = inSaleGoods.Sql;
                                cmd.CommandType = CommandType.Text;
                                foreach (var p in inSaleGoods.SqlParaArray)
                                {
                                    cmd.Parameters.Add(p);
                                }
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }

                        }
                        cmd.Transaction.Commit();
                        return oSaleId.ToString() + "," + saleNo.ToString();
                    }
                    return "";
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception("执行添加销售单异常！", ex);
                }

            });
        }

        /// <summary>
        /// 更新销售单信息
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <param name="saleGoodsList"></param>
        /// <returns></returns>
        public bool UpdateSaleOutStoreInfo(SaleOutStoreInfoModel saleInfo, List<SaleGoodsInfoModel> saleGoodsList)
        {
            string cols = "UnitId,StoreId,DealPerson,PayDesp,ThisAmount,Remark,TotalAmount,YHAmount,SaleId";
            if (saleInfo.PayTime != null)
                cols += ",PayTime,IsPayed";
            if (saleInfo.IsPayFull == 1)
                cols += ",IsPayFull";
            //插入销售商品列表的列名
            string pgCols = "SaleId,GoodsId,GUnit,Count,SalePrice,Amount,Remark";
            List<CommandInfo> comList = new List<CommandInfo>();
            SqlModel upSale = CreateSql.GetUpdateSqlAndParas(saleInfo, cols, "");
            //修改销售单信息
            comList.Add(new CommandInfo()
            {
                CommandText = upSale.Sql,
                IsProc = false,
                Paras = upSale.SqlParaArray
            });
            //删除已移除的商品明细数据

            //商品明细编号集合字符串
            string goodsIds = string.Join(",", saleGoodsList.Select(g => g.GoodsId));
            comList.Add(new CommandInfo()
            {
                CommandText = $"delete from SaleGoodsInfos where SaleId ={saleInfo.SaleId} and GoodsId not in ({goodsIds})",
                IsProc = false
            });

            //明细商品列表保存：修改、添加 两种
            foreach (SaleGoodsInfoModel sg in saleGoodsList)
            {
                if (sgDAL.ExistsGoods(saleInfo.SaleId, sg.GoodsId))
                {
                    string upSql = "update SaleGoodsInfos set Count=@count,SalePrice=@salePrice,Amount=@Amount,Remark=@remark where SaleId=@saleId and GoodsId=@goodsId";
                    SqlParameter[] paras =
                    {
                                                new SqlParameter("@saleId",saleInfo.SaleId),
                                                new SqlParameter("@goodsId",sg.GoodsId),
                                                new SqlParameter("@count",sg.Count),
                                                new SqlParameter("@salePrice",sg.SalePrice),
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
                    sg.SaleId = saleInfo.SaleId;
                    SqlModel inSaleGoods = CreateSql.GetInsertSqlAndParas(sg, pgCols, 0);
                    comList.Add(new CommandInfo()
                    {
                        CommandText = inSaleGoods.Sql,
                        IsProc = false,
                        Paras = inSaleGoods.SqlParaArray
                    });
                }
            }
            return SqlHelper.ExecuteTrans(comList);
        }

        /// <summary>
        ///销售单的审核处理   审核  作废   红冲
        /// </summary>
        /// <param name="saleId"></param>
        /// <param name="checkPerson"></param>
        /// <param name="storeId"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public bool CheckSaleInfo(int saleId, string checkPerson, int storeId, int isChecked)
        {
            string sqlUpCheck = "update SaleOutStoreInfos set IsChecked=@isChecked";
            if (isChecked == 1)//审核单据：已审核
                sqlUpCheck += ",CheckPerson=@checkPerson,CheckTime=@checkTime";
            sqlUpCheck += " where SaleId=@saleId";
            SqlParameter[] paras =
            {
                                new SqlParameter("@isChecked",isChecked),
                                new SqlParameter("@checkPerson",checkPerson),
                                new SqlParameter("@checkTime",DateTime.Now),
                                new SqlParameter("@saleId",saleId)
                        };
            //已审核、红冲   影响库存数量   isChecked 2:作废，不影响库存
            List<ViewSaleGoodsInfoModel> saleGoodsList = null;//销售商品明细列表
            if (isChecked != 2)
            {
                saleGoodsList = vsgDAL.GetSaleGoodsList(saleId);
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
                                            cmd = CreateCmd(cmd, saleGoodsList, storeId, isChecked);
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
        /// <param name="saleGoodsList"></param>
        /// <param name="storeId"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        private IDbCommand CreateCmd(IDbCommand cmd, List<ViewSaleGoodsInfoModel> saleGoodsList, int storeId, int isChecked)
        {
            //isChecked  加或减  仓库量
            string strChar = "-";
            if (isChecked == 3)
                strChar = "+";
            string upStock = "update StoreGoodsStockInfos";
            upStock += $" set CurCount=CurCount{strChar}@count,StockAmount=StockAmount{strChar}@stockAmount";
            upStock += " where StoreId=@storeId and GoodsId=@goodsId";
            string upAllStock = "update StoreGoodsStockInfos";
            upAllStock += $" set  CurCount=CurCount{strChar}@count,StockAmount=StockAmount{strChar}@stockAmount where StoreId=0 and GoodsId=@goodsId";
            //库存变动记录 
            string upStockChange = "insert into StockChangeInfos (CheckShId,ShType,StoreId,GoodsId,OutCount,CurCount) values(@saleId,@shType,@storeId,@goodsId,@outCount,@curCountTotal)";
            foreach (var sg in saleGoodsList)
            {
                cmd.CommandText = "select convert(decimal(18,2),(StockAmount/CurCount)) from StoreGoodsStockInfos where GoodsId=@goodsId and StoreId=@storeId";
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                object oStPrice = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                decimal price = 0;
                if (oStPrice != null && oStPrice.ToString().GetDecimal() > 0)
                {
                    price = oStPrice.ToString().GetDecimal();
                  
                }
              
                cmd.CommandText = upStock;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@count", sg.Count));
                cmd.Parameters.Add(new SqlParameter("@stockAmount", sg.Count * price));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = upAllStock;
                cmd.Parameters.Add(new SqlParameter("@count", sg.Count));
                //期初 没有成本价，销售审核，减去成本，应该有成本=采购时价格
                cmd.Parameters.Add(new SqlParameter("@stockAmount", sg.Count * price));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //添加库存变动明细
                int outCount = sg.Count;
                if (isChecked == 3)//红冲
                    outCount = -sg.Count;
                int curCount = 0;
                //获取当前的库存量
                cmd.CommandText = "select CurCount from StoreGoodsStockInfos where GoodsId=@goodsId and StoreId=@storeId";
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                object ototalCount = cmd.ExecuteScalar();//当前库存量=变动后的
                cmd.Parameters.Clear();
                if (ototalCount != null)
                {
                    curCount = ototalCount.GetInt();
                }
                //添加库存变动记录
                cmd.CommandText = upStockChange;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@saleId", sg.SaleId));
                cmd.Parameters.Add(new SqlParameter("@shType", 2));
                cmd.Parameters.Add(new SqlParameter("@storeId", storeId));
                cmd.Parameters.Add(new SqlParameter("@goodsId", sg.GoodsId));
                cmd.Parameters.Add(new SqlParameter("@outCount", outCount));
                cmd.Parameters.Add(new SqlParameter("@curCountTotal", curCount));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            return cmd;
        }
    }
}
