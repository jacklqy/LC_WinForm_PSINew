using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 按商品采购统计数据实体
    /// </summary>
    public class PerQueryGoodsModel
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GUnit { get; set; }
        public int TotalCount { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
