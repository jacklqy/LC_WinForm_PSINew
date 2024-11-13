using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public  class StStockGoodsDAL:BaseDAL<StStockGoodsInfoModel>
        {
                /// <summary>
                /// 判断指定的入库单中是否已存在指定的商品
                /// </summary>
                /// <param name="stockId"></param>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool ExistsGoods(int stockId, int goodsId)
                {
                        string strWhere = $"StockId={stockId} and GoodsId={goodsId}";
                        return Exists(strWhere);
                }
        }
}
