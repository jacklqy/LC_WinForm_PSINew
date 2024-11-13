using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 商品类别信息实体
    /// </summary>
    [Serializable]
    [Table("GoodsTypeInfos")]
    [PrimaryKey("GTypeId")]
    public class GoodsTypeInfoModel
    {
        /// <summary>
		/// GTypeId
        /// </summary>		
        public int GTypeId { get; set; }
        /// <summary>
        /// GTypeName
        /// </summary>		
        public string GTypeName { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>		
        public int? ParentId { get; set; }
        /// <summary>
        /// ParentName
        /// </summary>		
        public string ParentName { get; set; }
        /// <summary>
        /// GTypeNo
        /// </summary>		
        public string GTypeNo { get; set; }
        /// <summary>
        /// GTPYNo
        /// </summary>		
        public string GTPYNo { get; set; }
        /// <summary>
        /// GTOrder
        /// </summary>		
        public int GTOrder { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
    }
}
