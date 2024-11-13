using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 采购入库信息实体
    /// </summary>
    [Serializable]
    [Table("PerchaseInStoreInfos")]
    [PrimaryKey("PerId")]
    public class PerchaseInStoreInfoModel
    {
        /// <summary>
		/// PerId
        /// </summary>		
        public int PerId { get; set; }
        /// <summary>
        /// PerchaseNo
        /// </summary>		
        public string PerchaseNo { get; set; }
        /// <summary>
        /// UnitId
        /// </summary>		
        public int UnitId { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// DealPerson
        /// </summary>		
        public string DealPerson { get; set; }
        /// <summary>
        /// PayType
        /// </summary>		
        public string PayDesp { get; set; }
        /// <summary>
        /// ThisAmount
        /// </summary>		
        public decimal ThisAmount { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// TotalAmount
        /// </summary>		
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// YHAmount
        /// </summary>		
        public decimal YHAmount { get; set; }
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
        /// IsPayed
        /// </summary>		
        public int IsPayed { get; set; }
        /// <summary>
        /// IsPayFull
        /// </summary>		
        public int IsPayFull { get; set; }
        /// <summary>
        /// CheckTime
        /// </summary>		
        public DateTime? CheckTime { get; set; }
        /// <summary>
        /// CheckPerson
        /// </summary>		
        public string CheckPerson { get; set; }
        /// <summary>
        /// PayTime
        /// </summary>		
        public DateTime? PayTime { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
    }
}
