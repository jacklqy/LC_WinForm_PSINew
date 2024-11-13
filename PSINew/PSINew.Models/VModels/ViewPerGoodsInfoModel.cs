using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    [Table("ViewPerGoodsInfos")]
    [PrimaryKey("PerGoodsId")]
    public class ViewPerGoodsInfoModel
    {
        public int Id { get; set; }
        public int PerGoodsId { get; set; }
        public int PerId { get; set; }
        public int GoodsId { get; set; }
        public string GUnit { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsTXNo { get; set; }
        public string GoodsName { get; set; }
        public int Count { get; set; }
        public decimal PerPrice { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public int IsDeleted { get; set; }
    }
}
