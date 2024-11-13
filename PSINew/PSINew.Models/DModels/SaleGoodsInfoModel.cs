using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 销售商品信息实体
    /// </summary>
    [Serializable]
    [Table("SaleGoodsInfos")]
    [PrimaryKey("SaleGoodsId")]
    public class SaleGoodsInfoModel
    {
        /// <summary>
		/// SaleGoodsId
        /// </summary>		
        public int SaleGoodsId { get; set; }
        /// <summary>
        /// SaleId
        /// </summary>		
        public int SaleId { get; set; }
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
        public decimal SalePrice { get; set; }
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
