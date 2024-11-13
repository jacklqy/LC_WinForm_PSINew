using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 按供应商销售统计数据实体
    /// </summary>
    public class SaleQueryCustomerModel
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int TotalCount { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalYHAmount { get; set; }
        public decimal TotalStAmount { get; set; }
    }
}
