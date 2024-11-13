using Common;
using DbUtility;
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
        public  class SheetQueryDAL:BQuery<SheetInfoModel>
        {
                /// <summary>
                /// 条件查询单据列表
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public DataSet GetSheetListDs(ShQueryParaModel paraModel,int startIndex,int pageSize)
                {
                        string sql = "select ROW_NUMBER() over (order by SheetId) Id,* from ";
                        string sqlPer = "select distinct PerId SheetId, PerchaseNo SheetNo, 1 as ShType, IsChecked, CreateTime,UnitId, UnitName, YHAmount, DealPerson, Creator, CheckPerson, CheckTime,StoreId,StoreName from ViewPerGoodsQuery ";
                        string sqlSale = " select distinct SaleId SheetId, SaleOutNo SheetNo, 2 as ShType, IsChecked, CreateTime,UnitId, UnitName, YHAmount, DealPerson, Creator, CheckPerson, CheckTime,StoreId,StoreName from ViewSaleGoodsQuery";
                        string sqlStock = "select distinct StockId SheetId, StockNo SheetNo, 3 as ShType, IsChecked, CreateTime,null as UnitId, null as UnitName, null as YHAmount, DealPerson, Creator, CheckPerson, CheckTime,StoreId,StoreName  from ViewStockGoodsQuery";
                        //条件sql的处理
                        string strWhereGoods = "";
                        if (paraModel != null)
                        {
                                switch (paraModel.ShType)
                                {
                                        case 1:
                                                sql += $"({sqlPer}) ";
                                                strWhereGoods = "select PerId from PerchaseGoodsInfos";
                                                break;
                                        case 2:
                                                sql += $"({sqlSale}) ";
                                                strWhereGoods = "select SaleId from SaleGoodsInfos";
                                                break;
                                        case 3:
                                                sql += $"({sqlStock}) ";
                                                strWhereGoods = "select StockId from StStockGoodsInfos";
                                                break;
                                }
                                sql += "as temp where 1=1";
                                if (paraModel.UnitId > 0)
                                        sql += " and UnitId=@unitId";
                                else if(!string.IsNullOrEmpty(paraModel.UnitName))
                                        sql += " and UnitName like @unitName";
                                if (paraModel.StoreId > 0)
                                        sql += " and StoreId=@storeId";
                                else if (!string.IsNullOrEmpty(paraModel.StoreName))
                                        sql += " and StoreName like @storeName";
                                if (!string.IsNullOrEmpty(paraModel.CheckPerson))
                                        sql += " and CheckPerson like @checkPerson";
                                if (!string.IsNullOrEmpty(paraModel.Creator))
                                        sql += " and Creator like @creator";
                                if (!string.IsNullOrEmpty(paraModel.DealPerson))
                                        sql += " and DealPerson like @dealPerson";
                                if (!string.IsNullOrEmpty(paraModel.GoodsName))
                                {
                                        sql += " and SheetId in (" + strWhereGoods + " where GoodsId in (select GoodsId from GoodsInfos where GoodsName like @goodsName))";
                                }
                                if (paraModel.IsChecked >= 0 && paraModel.IsChecked <= 3)
                                        sql += " and IsChecked = @isChecked";
                                if (!string.IsNullOrEmpty(paraModel.SheetNo))
                                        sql += " and SheetNo like @sheetNo";
                        }
                        //参数的定义
                        SqlParameter[] paras =
                           {
                                new SqlParameter("@goodsName",$"%{paraModel.GoodsName}%"),
                                new SqlParameter("@storeId",paraModel.StoreId),
                                 new SqlParameter("@storeName",$"%{paraModel.StoreName}%"),
                                new SqlParameter("@unitId",paraModel.UnitId),
                                new SqlParameter("@unitName",$"%{paraModel.UnitName}%"),
                                new SqlParameter("@checkPerson",$"%{paraModel.CheckPerson}%"),
                                new SqlParameter("@creator",$"%{paraModel.Creator}%"),
                                new SqlParameter("@dealPerson",$"%{paraModel.DealPerson}%"),
                                new SqlParameter("@isChecked",paraModel.IsChecked),
                                new SqlParameter("@sheetNo",$"%{paraModel.SheetNo}%")
                            };
                        //sql  +条件拼接
                        string sqlCount = "select count(1) from (" + sql + ") as temp2";//返回总记录数
                        //最终要执行目标sql
                        string sql2 = sqlCount + ";select * from (" + sql + ") as temp3  where Id between " + startIndex + " and " + (startIndex +pageSize-1);
                        DataSet ds = SqlHelper.GetDataSet(sql2, 1, paras);
                        return ds;
                }

                /// <summary>
                /// 分页查询单据列表
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<SheetInfoModel> GetSheetList(ShQueryParaModel paraModel, int startIndex, int pageSize)
                {
                        DataSet ds = GetSheetListDs(paraModel, startIndex, pageSize);
                        string cols = "Id,SheetId,SheetNo,ShType,IsChecked,CreateTime,UnitId,UnitName,YHAmount,DealPerson,Creator,CheckPerson,CheckTime,StoreId";
                      PageModel<SheetInfoModel> pageModel =  DsToPageModel<SheetInfoModel>(ds, cols);
                        return pageModel;
                }

                /// <summary>
                /// 获取指定 供应商/客户 、 仓库 、商品的相关单据明细列表 DataTable
                /// </summary>
                /// <param name="shType"></param>
                /// <param name="typeId"></param>
                /// <param name="id"></param>
                /// <returns></returns>
                private DataTable  GetSheetGoodsInfoDt(int shType,int  typeId, int id)
                {
                        string sql = "select row_number() over (order by SheetId) Id,* from  (select ";
                        string str = "";
                        string viewName = "";
                        switch(shType)
                        {
                                case 1:
                                        str = "PerId SheetId,PerchaseNo SheetNo,1 as ShType,PerPrice Price";
                                        viewName = "ViewPerGoodsQuery";
                                        break;
                                case 2:
                                        str = "SaleId SheetId,SaleOutNo SheetNo,2 as ShType,SalePrice Price";
                                        viewName = "ViewSaleGoodsQuery";
                                        break;
                                case 3:
                                        str = "StockId SheetId,StockNo SheetNo,3 as ShType,StPrice Price";
                                        viewName = "ViewStockGoodsQuery";
                                        break;
                        }
                        sql += str;
                        if (shType == 3)
                                sql += ",null as UnitId,null as UnitName,StCount as Count,StAmount as Amount";
                        else
                                sql += ",UnitId,UnitName,[Count],Amount";
                        sql +=",Creator,CheckPerson,CheckTime,StoreId, StoreName,GoodsId,GoodsNo,GoodsName,GUnit,IsChecked,CreateTime,DealPerson";
                        sql += $" from {viewName} ) as temp  where IsChecked=1 ";
                        switch(typeId)
                        {
                                case 1:
                                        sql += $" and UnitId={id}";
                                        break;
                                case 2:
                                        sql += $" and StoreId={id}";
                                        break;
                                case 3:
                                        sql += $" and GoodsId={id}";
                                        break;
                        }
                        DataTable dt = SqlHelper.GetDataTable(sql, 1);
                        return dt;
                }

                /// <summary>
                /// 获取指定 供应商/客户 、 仓库 、商品的相关单据明细列表
                /// </summary>
                /// <param name="shType"></param>
                /// <param name="typeId"></param>
                /// <param name="id"></param>
                /// <returns></returns>
                public List<SheetGoodsInfoModel> GetSheetGoodsInfoList(int shType, int typeId, int id)
                {
                        DataTable dt = GetSheetGoodsInfoDt(shType, typeId, id);
                        string cols = "Id,SheetId,SheetNo,ShType,IsChecked,CreateTime,UnitId,UnitName,Count,Price,Amount,DealPerson,Creator,CheckPerson,CheckTime,StoreId,StoreName,GoodsId,GoodsNo,GoodsName,GUnit";
                        return DbConvert.DataTableToList<SheetGoodsInfoModel>(dt, cols);
                }
        }
}
