using Common;
using DbUtility;
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
    public class StockChangeDAL
    {
        /// <summary>
        /// 获取指定商品的变动记录DataTable
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="storeId"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public DataTable GetGoodsStockChangeDt(int goodsId, int storeId, string storeName)
        {
            string sql = "select row_number() over (order by StockChangeId) Id,StockChangeId,ShType,s.StoreId,GoodsId,InCount,OutCount,CurCount from StockChangeInfos sc left join StoreInfos s on sc.StoreId=s.StoreId where GoodsId=@goodsId";
            if (storeId > 0)
                sql += " and s.StoreId=@storeId";
            else if (!string.IsNullOrEmpty(storeName))
                sql += "  and s.StoreName like @storeName";
            SqlParameter[] paras =
            {
                                new SqlParameter("@goodsId",goodsId),
                                new SqlParameter("@storeId",storeId),
                                new SqlParameter("@storeName", $"%{storeName}%")
                         };
            DataTable dtChanges = SqlHelper.GetDataTable(sql, 1, paras);
            if (dtChanges.Rows.Count > 0)
            {
                //以下三种单据、ViewPerStockGoodsChangeInfos   ViewSaleStockGoodsChangeInfos  ViewStStockGoodsChangeInfos
                for (int i = 0; i < dtChanges.Rows.Count; i++)
                {
                    string sqlInfo = "select SheetId,SheetNo,StoreName,GoodsName,GoodsNo,GUnit,CheckPerson,CheckTime,IsChecked,DealPerson,Creator,CreateTime";
                    int changeId = dtChanges.Rows[i]["StockChangeId"].ToString().GetInt();
                    int shType = dtChanges.Rows[i]["ShType"].ToString().GetInt();
                    if (shType == 1)
                        sqlInfo += ",Price";
                    else if (shType == 2)
                        sqlInfo += ",Price,StPrice,StockAmount";
                    else if (shType == 3)
                        sqlInfo += ",StPrice";
                    sqlInfo += " from ";
                    switch (shType)
                    {
                        case 1:
                            sqlInfo += "ViewPerStockGoodsChangeInfos";
                            break;
                        case 2:
                            sqlInfo += "ViewSaleStockGoodsChangeInfos";
                            break;
                        case 3:
                            sqlInfo += "ViewStStockGoodsChangeInfos";
                            break;
                    }
                    sqlInfo += " where StockChangeId=" + changeId;
                    DataTable dtChangeInfos = SqlHelper.GetDataTable(sqlInfo, 1);
                    if (dtChangeInfos.Rows.Count > 0)
                    {
                        foreach (DataColumn dc in dtChangeInfos.Columns)
                        {
                            if (!dtChanges.Columns.Contains(dc.ColumnName))
                                dtChanges.Columns.Add(dc.ColumnName, dc.DataType);
                        }
                        foreach (DataColumn dc in dtChangeInfos.Columns)
                        {
                            dtChanges.Rows[i][dc.ColumnName] = dtChangeInfos.Rows[0][dc.ColumnName];
                        }
                        if (!dtChanges.Columns.Contains("StPrice"))
                            dtChanges.Columns.Add("StPrice", typeof(decimal));
                        if (!dtChanges.Columns.Contains("StAmount"))
                            dtChanges.Columns.Add("StAmount", typeof(decimal));
                        if (!dtChanges.Columns.Contains("Price"))
                            dtChanges.Columns.Add("Price", typeof(decimal));
                        if (!dtChanges.Columns.Contains("Amount"))
                            dtChanges.Columns.Add("Amount", typeof(decimal));
                        if (shType == 1)
                        {
                            dtChanges.Rows[i]["StPrice"] = dtChanges.Rows[i]["Price"];
                            int count = dtChanges.Rows[i]["InCount"].ToString().GetInt();
                            decimal price = dtChanges.Rows[i]["StPrice"].ToString().GetDecimal();
                            decimal amount = count * price;
                            if (dtChanges.Rows[i]["InCount"].ToString().GetInt() < 0)
                                dtChanges.Rows[i]["StAmount"] = -amount;
                            else
                                dtChanges.Rows[i]["StAmount"] = amount;
                            dtChanges.Rows[i]["Amount"] = dtChanges.Rows[i]["StAmount"];
                        }
                        else if (shType == 2)
                        {
                            int count = dtChanges.Rows[i]["OutCount"].ToString().GetInt();
                            int ab_Count = Math.Abs(count);
                            dtChanges.Rows[i]["Amount"] = ab_Count * dtChanges.Rows[i]["Price"].ToString().GetDecimal();
                            int curCount = dtChanges.Rows[i]["CurCount"].ToString().GetInt();
                            decimal price = decimal.Parse((dtChanges.Rows[i]["StockAmount"].ToString().GetDecimal() / curCount).ToString("0.00"));
                            dtChanges.Rows[i]["StPrice"] = price;
                            decimal stAmount = -count * price;
                            dtChanges.Rows[i]["StAmount"] = stAmount;
                        }
                        else if (shType == 3)
                        {
                            int count = dtChanges.Rows[i]["InCount"].ToString().GetInt();
                            decimal price = dtChanges.Rows[i]["StPrice"].ToString().GetDecimal();
                            dtChanges.Rows[i]["Price"] = price;
                            decimal stAmount = count * price;
                            if (count < 0)
                                stAmount = -stAmount;
                            dtChanges.Rows[i]["StAmount"] = stAmount;
                            dtChanges.Rows[i]["Amount"] = stAmount;
                        }
                    }
                }
            }
            return dtChanges;
        }

        /// <summary>
        /// 获取指定商品的变动记录List
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="storeId"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public List<StockChangeInfoModel> GetGoodsStockChangeList(int goodsId, int storeId, string storeName)
        {
            List<StockChangeInfoModel> list = new List<StockChangeInfoModel>();
            string cols = "Id,SheetId,SheetNo,ShType,IsChecked,CreateTime,Price,Amount,DealPerson,Creator,CheckPerson,CheckTime,StoreId,StoreName,GoodsId,GoodsNo,GoodsName,GUnit,InCount,OutCount,CurCount,StPrice,StAmount";
            DataTable dt = GetGoodsStockChangeDt(goodsId, storeId, storeName);
            if (dt.Rows.Count > 0)
            {
                list = DbConvert.DataTableToList<StockChangeInfoModel>(dt, cols);
            }
            return list;
        }
    }
}
