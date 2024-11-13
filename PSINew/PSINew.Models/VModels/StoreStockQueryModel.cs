using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 仓库库存查询数据实体
    /// </summary>
    public class StoreStockQueryModel
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GUnit { get; set; }
        public int GTypeId { get; set; }
        public string GTypeName { get; set; }
        public int StCount { get; set; }
        public decimal StPrice { get; set; }
        public decimal StAmount { get; set; }
        public int CurCount { get; set; }
        public decimal StockAmount { get; set; }

    }
}
