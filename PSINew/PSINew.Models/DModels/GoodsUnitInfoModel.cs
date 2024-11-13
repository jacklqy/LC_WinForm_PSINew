using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 商品单位信息实体
    /// </summary>
    [Serializable]
    [Table("GoodsUnitInfos")]
    [PrimaryKey("GUnitId")]
    public class GoodsUnitInfoModel
    {
        /// <summary>
		/// GUnitId
        /// </summary>		
        public int GUnitId { get; set; }
        /// <summary>
        /// GUnitName
        /// </summary>		
        public string GUnitName { get; set; }
        /// <summary>
        /// GUnitPYNo
        /// </summary>		
        public string GUnitPYNo { get; set; }
        /// <summary>
        /// GUnitOrder
        /// </summary>		
        public int GUnitOrder { get; set; }
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
