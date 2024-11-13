using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 按仓库销售统计数据实体
    /// </summary>
    public class SaleQueryStoreModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int TotalCount { get; set; }
        //public decimal AvgPrice { get; set; }
        public decimal TotalAmount { get; set; }
        //public decimal AvgStPrice { get; set; }
        public decimal TotalStAmount { get; set; }
    }
}
