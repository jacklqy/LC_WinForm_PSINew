using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    [Serializable]
    [Table("UserRoleInfos")]
    [PrimaryKey("URId")]
    public class UserRoleInfoModel
    {
        /// <summary>
		/// URId
        /// </summary>		
        public int URId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>		
        public int RoleId { get; set; }
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
