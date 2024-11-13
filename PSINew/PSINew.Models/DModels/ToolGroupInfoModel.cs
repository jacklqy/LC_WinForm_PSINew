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
    [Table("ToolGroupInfos")]
    [PrimaryKey("TGroupId")]
    public class ToolGroupInfoModel
    {
        /// <summary>
        /// TGroupId
        /// </summary>		
        public int TGroupId { get; set; }
        /// <summary>
        /// TGroupName
        /// </summary>		
        public string TGroupName { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }

        public int IsDeleted { get; set; }
    }
}
