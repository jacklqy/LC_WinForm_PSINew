using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 仓库类别信息实体
    /// </summary>
    [Serializable]
    [Table("StoreTypeInfos")]
    [PrimaryKey("STypeId")]
    public class StoreTypeInfoModel
    {
        /// <summary>
		/// STypeId
        /// </summary>		
        public int STypeId { get; set; }
        /// <summary>
        /// STypeName
        /// </summary>		
        public string STypeName { get; set; }
        /// <summary>
        /// STPYNo
        /// </summary>		
        public string STPYNo { get; set; }
        /// <summary>
        /// STypeOrder
        /// </summary>		
        public int STypeOrder { get; set; }
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

        public int ParentId { get; set; }
    }
}
