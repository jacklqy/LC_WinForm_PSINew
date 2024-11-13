using Common;
using DbUtility;
using PSINew.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class ViewSaleGoodsQueryDAL
    {
        /// <summary>
        /// 销售统计  分页
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="paraModel"></param>
        /// <returns></returns>
        public DataSet GetSaleData(int typeId, QueryParaModel paraModel, int startIndex, int pageSize)
        {
            string sql = " select row_number() over (order by ";
            string orColName = "";
            string selCols = "";
            switch (typeId)
            {
                case 1:
                    orColName = "UnitId";
                    selCols = "UnitId,UnitName";
                    break;
                case 2:
                    orColName = "StoreId";
                    selCols = "StoreId,StoreName";
                    break;
                case 3:
                    orColName = "GoodsId";
                    selCols = "GoodsId,GoodsName,GoodsNo,GUnit";
                    break;
                default: break;
            }
            sql += orColName + ") as Id," + selCols + " from (select distinct " + selCols + " from ViewSaleGoodsQuery  where 1=1";
            //条件拼接
            string strWhere = "";
            if (paraModel != null)
            {
                if (!string.IsNullOrEmpty(paraModel.GoodsName))
                {
                    strWhere += " and GoodsName like @goodsName";
                }
                if (paraModel.StoreId > 0)
                    strWhere += " and StoreId=@storeId";
                else if (!string.IsNullOrEmpty(paraModel.StoreName))
                {
                    strWhere += " and StoreName like @storeName";
                }
                if (paraModel.STypeId > 0)
                {
                    strWhere += " and STypeId=@sTypeId";
                }
                if (paraModel.GTypeId > 0)
                    strWhere += " and  (GTypeId in (select GTypeId from GoodsTypeInfos where  GTypeId=@gTypeId  or ParentId in (select GTypeId from GoodsTypeInfos  where ParentId=@gTypeId or GTypeId=@gTypeId)))";
                if (paraModel.UTypeId > 0)
                    strWhere += " and (UTypeId in (select UTypeId from UnitTypeInfos where  UTypeId=@uTypeId  or ParentId in (select UTypeId from UnitTypeInfos  where ParentId=@uTypeId or UTypeId=@uTypeId)))";
                if (paraModel.UnitId > 0)
                    strWhere += " and UnitId=@unitId";
                else if (!string.IsNullOrEmpty(paraModel.UnitName))
                    strWhere += " and UnitName like @unitName";
                if (!string.IsNullOrEmpty(paraModel.DealPerson))
                    strWhere += " and DealPerson like @dealPerson";
            }
            sql += strWhere;
            sql += ") as temp  ";
            string sql1 = $"select count(1) from ({sql}) as temp2";//获取总记录数
            string sql2 = $"{sql1};select * from ({sql}) as temp3 where Id between {startIndex} and {(startIndex + pageSize - 1)}";
            //参数提供
            SqlParameter[] paras =
              {
                                new SqlParameter("@goodsName",$"%{paraModel.GoodsName}%"),
                                new SqlParameter("@storeId",paraModel.StoreId),
                                 new SqlParameter("@sTypeId",paraModel.STypeId),
                                new SqlParameter("@storeName",$"%{paraModel.StoreName}%"),
                                new SqlParameter("@gTypeId",paraModel.GTypeId),
                                new SqlParameter("@uTypeId",paraModel.UTypeId),
                                new SqlParameter("@unitId",paraModel.UnitId),
                                new SqlParameter("@unitName",$"%{paraModel.UnitName}%"),
                                new SqlParameter("@dealPerson",$"%{paraModel.DealPerson}%"),
                            };
            DataSet ds = SqlHelper.GetDataSet(sql2, 1, paras);
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[1];
                //再次处理？？？---目前得到数据，没有进行销售统计
                dt.Columns.Add("TotalCount", typeof(int));
                dt.Columns.Add("TotalAmount", typeof(decimal));
                dt.Columns.Add("TotalStAmount", typeof(decimal));
                if (typeId == 1)
                    dt.Columns.Add("AvgPrice", typeof(decimal));
                if (typeId == 1)
                    dt.Columns.Add("TotalYHAmount", typeof(decimal));
                string totalCols = "sum(Count) TotalCount,sum(Amount) TotalAmount,sum(Count*StPrice) TotalStAmount";
                if (typeId == 1)
                    totalCols += ",convert(decimal(18,2),sum(Amount)/Sum(Count)) as AvgPrice";
                foreach (DataRow dr in dt.Rows)
                {
                    int id = dr[orColName].ToString().GetInt();
                    DataTable dtData = GetSaleTotal(id, typeId, totalCols, strWhere, paras);
                    if (dtData.Rows.Count > 0)
                    {
                        dr["TotalCount"] = dtData.Rows[0]["TotalCount"];
                        dr["TotalAmount"] = dtData.Rows[0]["TotalAmount"];
                        if (typeId == 1)
                        {
                            dr["AvgPrice"] = dtData.Rows[0]["AvgPrice"];
                            dr["TotalYHAmount"] = dtData.Rows[0]["TotalAmount"];
                        }
                        dr["TotalStAmount"] = dtData.Rows[0]["TotalStAmount"];
                    }
                }
            }
            return ds;
        }

        /// <summary>
        ///获取指定的销售数据
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="sqlTotal"></param>
        /// <returns></returns>
        private DataTable GetSaleTotal(int id, int typeId, string sqlTotal, string strWhere, SqlParameter[] paras)
        {
            string strName = "";
            switch (typeId)
            {
                case 1:
                    strName = "UnitId";
                    break;
                case 2:
                    strName = "StoreId";
                    break;
                case 3:
                    strName = "GoodsId";
                    break;
            }
            string sql = $"select {sqlTotal} from ViewSaleGoodsQuery where {strName}=@id and IsChecked=1" + strWhere;
            List<SqlParameter> listParas = new List<SqlParameter>();
            SqlParameter paraId = new SqlParameter("@id", id);
            listParas.Add(paraId);
            listParas.AddRange(paras);
            return SqlHelper.GetDataTable(sql, 1, listParas.ToArray());
        }
    }
}
