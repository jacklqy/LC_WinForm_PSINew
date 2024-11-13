using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
       public  class ViewStoreStockUpDownDAL:BQuery<ViewStoreStockUpDownModel>
        {
                /// <summary>
                /// 获取商品上下限列表
                /// </summary>
                /// <param name="gTypeId"></param>
                /// <param name="storeId"></param>
                /// <returns></returns>
             public   List<ViewStoreStockUpDownModel> GetGoodsStockUpDownList(int gTypeId,int storeId)
                {
                        string cols = "StoreGoodsId,GoodsId,GoodsNo,GoodsName,GoodsTXNo,GUnit,StockUp,StockDown,StoreId";
                        string strWhere = "1=1";
                        strWhere += $" and StoreId={storeId}";
                        if(gTypeId >0)
                        {
                                strWhere += $" and GTypeId in (select GTypeId from GoodsTypeInfos where  GTypeId={gTypeId}  or ParentId in (select GTypeId from GoodsTypeInfos  where ParentId={gTypeId} or GTypeId={gTypeId}))";
                        }
                       return   GetRowsModelList(strWhere, cols);
                }

        }
}
