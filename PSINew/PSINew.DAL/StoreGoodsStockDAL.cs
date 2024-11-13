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
        public class StoreGoodsStockDAL : BQuery<StoreGoodsStockInfoModel>
        {
                /// <summary>
                /// 获取指定商品没有添加库存记录的仓库编号集合
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public List<int> GetHasNoStockStoreIds(int goodsId)
                {
                        string sql = $"select StoreId from StoreInfos where IsDeleted=0 and StoreId not in (select StoreId  from StoreGoodsStockInfos where goodsId = {goodsId} and storeid> 0)";
                        DataTable dt = SqlHelper.GetDataTable(sql, 1);
                        List<int> reStoreIds = new List<int>();
                        foreach (DataRow dr in dt.Rows)
                        {
                                int storeId = dr["StoreId"].ToString().GetInt();
                                reStoreIds.Add(storeId);
                        }
                        return reStoreIds;
                }

                /// <summary>
                /// 指定仓库没有添加库存记录的商品编号集合
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public List<int> GetHasNoStockGoodsIds(int storeId)
                {
                        string sql = $"select GoodsId from GoodsInfos where IsDeleted=0 and GoodsId not in (select GoodsId  from StoreGoodsStockInfos where StoreId = {storeId} )";
                        DataTable dt = SqlHelper.GetDataTable(sql, 1);
                        List<int> reGoodsds = new List<int>();
                        foreach (DataRow dr in dt.Rows)
                        {
                                int goodsId = dr["GoodsId"].ToString().GetInt();
                                reGoodsds.Add(goodsId);
                        }
                        return reGoodsds;
                }

                /// <summary>
                /// 获取指定商品列表在指定仓库中的当前库存量
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public List<StoreGoodsStockInfoModel> GetGoodsCurCountList(List<int> goodsIds, int storeId)
                {
                        string cols = "StoreId,GoodsId,CurCount";
                        string strGoodsIds = string.Join(",", goodsIds);
                        string strWhere = $"IsDeleted=0 and StoreId={storeId} and GoodsId in ({strGoodsIds})";
                        return GetModelList(strWhere, cols);
                }

                /// <summary>
                /// 条件统计商品库存数据
                /// </summary>
                /// <param name="qModel"></param>
                /// <returns></returns>
                public DataTable GetStoreStockData(StockQueryParaModel qModel)
                {
                        string sql = "select row_number() over (order by GoodsId) Id,GoodsId,GoodsNo,GoodsName,GUnit,GTypeId,GTypeName from (select distinct GoodsId,GoodsNo,GoodsName,GUnit,GTypeId,GTypeName";
                        sql += " from ViewStockGoodsQuery where 1=1";
                        if (qModel != null)
                        {
                                if (qModel.StoreId > 0)
                                        sql += " and StoreId=@storeId";
                                else if (!string.IsNullOrEmpty(qModel.StoreName))
                                        sql += " and StoreName like @storeName";
                                if (qModel.GTypeId > 0)
                                        sql += " and (GTypeId in (select GTypeId from GoodsTypeInfos where  GTypeId=@gTypeId  or ParentId in (select GTypeId from GoodsTypeInfos  where ParentId=@gTypeId or GTypeId=@gTypeId)))";
                                if (!string.IsNullOrEmpty(qModel.GoodsName))
                                        sql += " and GoodsName like @goodsName";
                        }
                        sql += ") as temp";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@storeId",qModel.StoreId),
                                new SqlParameter("@storeName",$"%{qModel.StoreName}%"),
                                new SqlParameter("@goodsName",$"%{qModel.GoodsName}%"),
                                new SqlParameter("@gTypeId",qModel.GTypeId)
                       };
                        DataTable dtGoods = SqlHelper.GetDataTable(sql, 1, paras);
                        if (dtGoods.Rows.Count > 0)
                        {

                                dtGoods.Columns.Add("StCount", typeof(int));
                                dtGoods.Columns.Add("StPrice", typeof(decimal));
                                dtGoods.Columns.Add("StAmount", typeof(decimal));
                                dtGoods.Columns.Add("CurCount", typeof(int));
                                dtGoods.Columns.Add("StockAmount", typeof(decimal));
                                foreach (DataRow dr in dtGoods.Rows)
                                {
                                        int id = dr["GoodsId"].ToString().GetInt();
                                        //统计每个商品的库存数据
                                        DataTable dtStock = GetStockTotal(id, qModel.StoreId, qModel.StoreName);
                                        if (dtStock != null && dtStock.Rows.Count > 0)
                                        {
                                                DataRow drData = dtStock.Rows[0];
                                                dr["StCount"] = drData["StCount"];
                                                dr["StPrice"] = drData["StPrice"];
                                                dr["StAmount"] = drData["StAmount"];
                                                dr["CurCount"] = drData["CurCount"];
                                                dr["StockAmount"] = drData["StockAmount"];
                                        }
                                }
                        }
                        return dtGoods;
                }

                /// <summary>
                /// 获取指定商品的库存数据
                /// </summary>
                /// <param name="id"></param>
                /// <returns></returns>
                public DataTable GetStockTotal(int gId, int storeId, string storeName)
                {
                        string totalSql = "sum(StCount) StCount,convert(decimal(18,2),(sum(StockAmount)/sum(CurCount))) StPrice,sum(StAmount) StAmount,sum(CurCount) CurCount,sum(StockAmount) StockAmount";
                        string sql = $"select {totalSql}  from (select distinct StoreId,StCount,StAmount,CurCount,StockAmount from ViewStockGoodsQuery where GoodsId=@id and IsChecked=1";
                        if (storeId > 0)
                                sql += " and StoreId=@storeId";
                        else if (!string.IsNullOrEmpty(storeName))
                                sql += "  and StoreName like @storeName";
                        sql += ") as temp having sum(CurCount)>0";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@id", gId),
                                new SqlParameter("@storeId", storeId),
                                new SqlParameter("@storeName", $"%{storeName}%")
                        };
                        return SqlHelper.GetDataTable(sql, 1, paras);
                }

        /// <summary>
        /// 获取指定商品编号列表、指定仓库的商品库存数
        /// </summary>
        /// <param name="GoodsIds"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<GoodsStoreStockModel> GetGoodsStoreStockCountList(List<int> GoodsIds, int storeId)
        {
            DataTable dt = GetGoodsStockCount(GoodsIds, storeId);
            List<GoodsStoreStockModel> list = new List<GoodsStoreStockModel>();
            if (dt.Rows.Count > 0)
            {
                list = DbConvert.DataTableToList<GoodsStoreStockModel>(dt, "GoodsId,StoreId,CurCount");
            }
            return list;
        }

        /// <summary>
        /// 获取指定商品编号列表、指定仓库的商品库存 DataTable
        /// </summary>
        /// <param name="GoodsIds"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataTable GetGoodsStockCount(List<int> GoodsIds, int storeId)
        {
            string goodsIds = string.Join(",", GoodsIds);
            string sql = "select GoodsId,StoreId,CurCount " +
              "from StoreGoodsStockInfos sgs " +
              $"where sgs.StoreId ={storeId} and sgs.GoodsId in ({goodsIds})";
            return SqlHelper.GetDataTable(sql, 1);
        }

        /// <summary>
        /// 获取指定商品的库存分布
        /// </summary>
        /// <param name="gId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataTable GetGoodsStoreStockData(int gId, int storeId,string storeName)
                {
                        string sql = "select row_number() over (order by sgs.StoreId) Id,sgs.StoreId,s.StoreName,sum(CurCount) CurCount,convert(decimal(18,2),avg(StPrice)) StPrice,sum(StockAmount) StockAmount " +
                           "from StoreGoodsStockInfos sgs left join StoreInfos s on sgs.StoreId = s.StoreId " +
                           "where sgs.StoreId > 0 and sgs.GoodsId = @goodsId";
                        if (storeId > 0)
                                sql += " and sgs.StoreId=@storeId";
                        else if (!string.IsNullOrEmpty(storeName))
                                sql += "  and s.StoreName like @storeName";
                        sql += " group by sgs.StoreId,s.StoreName";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@goodsId",gId),
                                new SqlParameter("@storeId",storeId),
                                new SqlParameter("@storeName", $"%{storeName}%")
                        };
                        DataTable dt = SqlHelper.GetDataTable(sql, 1, paras);
                        return dt;
                }

                /// <summary>
                /// 保存上下限设置
                /// </summary>
                /// <param name="goodsStockList"></param>
                /// <returns></returns>
                public bool SetGoodsStockUpDown(List<StoreGoodsStockInfoModel> goodsStockList)
                {
                        string upCols = "StoreGoodsId,StockUp,StockDown";
                        List<CommandInfo> list = new List<CommandInfo>();
                        foreach(var gupdown in goodsStockList)
                        {
                                SqlModel sqlModel = CreateSql.GetUpdateSqlAndParas(gupdown, upCols, "");
                                list.Add(new CommandInfo()
                                {
                                        CommandText = sqlModel.Sql,
                                        IsProc = false,
                                        Paras = sqlModel.SqlParaArray
                                });
                        }
                        return SqlHelper.ExecuteTrans(list);
                }
        }
}
