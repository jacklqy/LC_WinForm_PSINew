using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustomAttributes;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 商品信息实体
    /// </summary>
    [Table("GoodsInfos")]
    [Serializable]
    [PrimaryKey("GoodsId")]
    public class GoodsInfoModel
    {
        /// <summary>
		/// GoodsId
        /// </summary>		
        public int GoodsId { get; set; }
        /// <summary>
        /// GoodsNo
        /// </summary>		
        public string GoodsNo { get; set; }
        /// <summary>
        /// GoodsName
        /// </summary>		
        public string GoodsName { get; set; }
        /// <summary>
        /// GoodsPYNo
        /// </summary>		
        public string GoodsPYNo { get; set; }
        /// <summary>
        /// GoodsSName
        /// </summary>		
        public string GoodsSName { get; set; }
        /// <summary>
        /// GoodsTXNo
        /// </summary>		
        public string GoodsTXNo { get; set; }
        /// <summary>
        /// GUnit
        /// </summary>		
        public string GUnit { get; set; }
        /// <summary>
        /// GTypeId
        /// </summary>		
        public int GTypeId { get; set; }
        /// <summary>
        /// GProperties
        /// </summary>		
        public string GProperties { get; set; }
        /// <summary>
        /// IsStopped
        /// </summary>		
        public int IsStopped { get; set; }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// LowPrice
        /// </summary>		
        public decimal LowPrice { get; set; }
        /// <summary>
        /// PrePrice
        /// </summary>		
        public decimal PrePrice { get; set; }
        /// <summary>
        /// Discount
        /// </summary>		
        public int Discount { get; set; }
        /// <summary>
        /// BidPrice
        /// </summary>		
        public decimal BidPrice { get; set; }
        /// <summary>
        /// Actor
        /// </summary>		
        public string Remark { get; set; }
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
        /// <summary>
        /// GoodsPic
        /// </summary>		
        public string GoodsPic { get; set; }
    }
}
