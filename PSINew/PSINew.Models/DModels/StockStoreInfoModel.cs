using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 库存仓库信息实体
    /// </summary>
    [Serializable]
    [Table("StockStoreInfos")]
    [PrimaryKey("StockId")]
    public class StockStoreInfoModel
    {
        /// <summary>
        /// StockId
        /// </summary>		
        public int StockId { get; set; }
        /// <summary>
        /// StockNo
        /// </summary>		
        public string StockNo { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// DealPerson
        /// </summary>		
        public string DealPerson { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// IsChecked
        /// </summary>		
        public int IsChecked { get; set; }
        /// <summary>
        /// CheckPerson
        /// </summary>		
        public string CheckPerson { get; set; }
        /// <summary>
        /// CheckTime
        /// </summary>		
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
       
    }
}
