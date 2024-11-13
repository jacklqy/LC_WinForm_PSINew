using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 按仓库采购统计数据实体
    /// </summary>
    public class PerQueryStoreModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
