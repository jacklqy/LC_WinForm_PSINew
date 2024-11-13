using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 往来单位类别信息实体
    /// </summary>
    [Serializable]
    [Table("UnitTypeInfos")]
    [PrimaryKey("UTypeId")]
    public class UnitTypeInfoModel
    {
        /// <summary>
        /// UTypeId
        /// </summary>		
        public int UTypeId { get; set; }
        /// <summary>
        /// UTypeName
        /// </summary>		
        public string UTypeName { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>		
        public int? ParentId { get; set; }
        /// <summary>
        /// ParentName
        /// </summary>		
        public string ParentName { get; set; }
        /// <summary>
        /// UTypeNo
        /// </summary>		
        public string UTypeNo { get; set; }
        /// <summary>
        /// UTPYNo
        /// </summary>		
        public string UTPYNo { get; set; }
        /// <summary>
        /// UTOrder
        /// </summary>		
        public int UTOrder { get; set; }
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
