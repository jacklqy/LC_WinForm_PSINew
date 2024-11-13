using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    [Table("ViewStStockGoodsInfos")]
    [PrimaryKey("StStockId")]
    public class ViewStStockGoodsInfoModel
    {
        public int Id { get; set; }
        public int StStockId { get; set; }
        public int StockId { get; set; }
        public int GoodsId { get; set; }
        public int StoreId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GoodsTXNo { get; set; }
        public string GUnit { get; set; }
        public int StCount { get; set; }
        public decimal StPrice { get; set; }
        public decimal StAmount { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public int IsDeleted { get; set; }
    }
}
