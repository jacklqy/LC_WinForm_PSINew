using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 仓库信息实体
    /// </summary>
    [Serializable]
    [Table("StoreInfos")]
    [PrimaryKey("StoreId")]
    public class StoreInfoModel
    {
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// StoreNo
        /// </summary>		
        public string StoreNo { get; set; }
        /// <summary>
        /// StoreName
        /// </summary>		
        public string StoreName { get; set; }
        /// <summary>
        /// STypeId
        /// </summary>		
        public int STypeId { get; set; }
        /// <summary>
        /// StorePYNo
        /// </summary>		
        public string StorePYNo { get; set; }
        /// <summary>
        /// StoreOrder
        /// </summary>		
        public int StoreOrder { get; set; }
        /// <summary>
        /// StoreRemark
        /// </summary>		
        public string StoreRemark { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
    }
}
