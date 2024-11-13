using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 菜单信息实体
    /// </summary>
    [Serializable]
    [Table("MenuInfos")]
    [PrimaryKey("MId")]
    public class MenuInfoModel
    {
        /// <summary>
        /// MId
        /// </summary>		
        public int MId { get; set; }
        /// <summary>
        /// MName
        /// </summary>		
        public string MName { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>		
        public int ParentId { get; set; }
        /// <summary>
        /// MKey
        /// </summary>		
        public string MKey { get; set; }
        /// <summary>
        /// MUrl
        /// </summary>		
        public string MUrl { get; set; }
        /// <summary>
        /// IsTop
        /// </summary>		
        public int IsTop { get; set; }
        /// <summary>
        /// MOrder
        /// </summary>		
        public int MOrder { get; set; }
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
        public string MDesp { get; set; }

        public bool IsTopLevel { get; set; }
    }
}
