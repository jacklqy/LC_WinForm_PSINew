using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// ViewGoodsInfos视图的实体类
    /// </summary>
    [Table("ViewGoodsInfos")]
    [PrimaryKey("GoodsId")]
    public class ViewGoodsInfoModel
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
        public string GoodsPYNo{ get; set; }
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
        /// GTypeName
        /// </summary>		
        public string GTypeName { get; set; }
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
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
    }
}
