using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
      public   class ViewStStockGoodsDAL:BQuery<ViewStStockGoodsInfoModel>
        {
                /// <summary>
                /// 获取指定单据的商品明细列表
                /// </summary>
                /// <param name="stockId"></param>
                /// <returns></returns>
                public List<ViewStStockGoodsInfoModel> GetStockGoodsList(int stockId)
                {
                        string cols = "StStockId,StockId,GoodsId,GoodsNo,GoodsTXNo,GoodsName,GUnit,StCount,StPrice,StAmount,Remark";
                        return GetRowsModelList($"StockId={stockId} and IsDeleted=0", cols);
                }
        }
}
