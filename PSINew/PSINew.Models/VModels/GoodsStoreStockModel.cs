using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 商品库存分布信息实体
    /// </summary>
   public class GoodsStoreStockModel
    {
        public int Id { get; set; }

        public int GoodsId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int CurCount { get; set; }
        public decimal StPrice { get; set; }
        public decimal StockAmount { get; set; }
    }
}
