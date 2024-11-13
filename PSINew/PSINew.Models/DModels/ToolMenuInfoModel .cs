using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 工具栏组信息实体
    /// </summary>
    [Serializable]
    [Table("ToolMenuInfos")]
    [PrimaryKey("TMenuId")]
    public class ToolMenuInfoModel
    {
        /// <summary>
        /// TMenuId
        /// </summary>		
        public int TMenuId { get; set; }
        /// <summary>
        /// TMenuName
        /// </summary>		
        public string TMenuName { get; set; }
        /// <summary>
        /// TMPic
        /// </summary>		
        public string TMPic { get; set; }
        /// <summary>
        /// TMOrder
        /// </summary>		
        public int TMOrder { get; set; }
        /// <summary>
        /// TMUrl
        /// </summary>		
        public string TMUrl { get; set; }
        /// <summary>
        /// IsTop
        /// </summary>		
        public int IsTop { get; set; }
        /// <summary>
        /// TGroupId
        /// </summary>		
        public int TGroupId { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
        public string TMDesp { get; set; }
    }
}
