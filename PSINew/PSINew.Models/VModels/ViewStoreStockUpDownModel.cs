using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// ViewStoreStockUpDown视图实体
    /// </summary>
    [Table("ViewStoreStockUpDownInfos")]
    [PrimaryKey("StoreGoodsId")]
    public class ViewStoreStockUpDownModel
    {
        public int Id { get; set; }
        public int StoreGoodsId { get; set; }
        public int GoodsId { get; set; }
        public int StoreId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GoodsTXNo { get; set; }
        public string GUnit { get; set; }
        public int? StockUp { get; set; }
        public int StockDown { get; set; }
    }
}
