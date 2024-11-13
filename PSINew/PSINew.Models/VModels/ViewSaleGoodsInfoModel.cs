using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 销售商品实体
    /// </summary>
    [Table("ViewSaleGoodsInfos")]
    [PrimaryKey("SaleGoodsId")]
    public class ViewSaleGoodsInfoModel
    {
        public int Id { get; set; }
        public int SaleGoodsId { get; set; }
        public int SaleId { get; set; }
        public int GoodsId { get; set; }
        public string GUnit { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsTXNo { get; set; }
        public string GoodsName { get; set; }
        public int Count {get; set; }
        public decimal SalePrice { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public int IsDeleted { get; set; }
    }
}
