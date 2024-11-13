using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 区域信息实体
    /// </summary>
    [Serializable]
    [Table("RegionInfos")]
    [PrimaryKey("RegionId")]
    public class RegionInfoModel
    {
        /// <summary>
		/// RegionId
        /// </summary>		
        public int RegionId { get; set; }
        /// <summary>
        /// RegionName
        /// </summary>		
        public string RegionName { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>		
        public int ParentId { get; set; }
        /// <summary>
        /// ParentName
        /// </summary>		
        public string ParentName { get; set; }
        /// <summary>
        /// RegionPYNo
        /// </summary>		
        public string RegionPYNo { get; set; }
        /// <summary>
        /// RegionLevel
        /// </summary>		
        public int RegionLevel { get; set; }
    }
}
