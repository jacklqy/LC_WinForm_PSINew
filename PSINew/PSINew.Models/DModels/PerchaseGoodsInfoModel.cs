using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 采购商品信息实体
    /// </summary>
    [Serializable]
    [Table("PerchaseGoodsInfos")]
    [PrimaryKey("PerGoodsId")]
    public class PerchaseGoodsInfoModel
    {
        /// <summary>
		/// PerGoodsId
        /// </summary>		
        public int PerGoodsId { get; set; }
        /// <summary>
        /// PerId
        /// </summary>		
        public int PerId { get; set; }
        /// <summary>
        /// GoodsId
        /// </summary>		
        public int GoodsId { get; set; }
        /// <summary>
        /// GUnit
        /// </summary>		
        public string GUnit { get; set; }
        /// <summary>
        /// Count
        /// </summary>		
        public int Count { get; set; }
        /// <summary>
        /// PerPrice
        /// </summary>		
        public decimal PerPrice { get; set; }
        /// <summary>
        /// Amount
        /// </summary>		
        public decimal Amount { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
        
    }
}
