using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 角色菜单关系信息实体
    /// </summary>
    [Serializable]
    [Table("RoleMenuInfos")]
    [PrimaryKey("RMId")]
    public class RoleMenuInfoModel
    {
        /// <summary>
        /// RMId
        /// </summary>		
        public int RMId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>		
        public int RoleId { get; set; }
        /// <summary>
        /// MenuId
        /// </summary>		
        public int MId { get; set; }
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
