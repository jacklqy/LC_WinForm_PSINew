using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 商品库存信息实体
    /// </summary>
    [Table("StStockGoodsInfos")]
    [PrimaryKey("StStockId")]
    public class StStockGoodsInfoModel
    {
        /// <summary>
        /// StStockId
        /// </summary>		
        public int StStockId { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StockId { get; set; }
        /// <summary>
        /// GoodsId
        /// </summary>		
        public int GoodsId { get; set; }
        /// <summary>
        /// StCount
        /// </summary>		
        public int StCount { get; set; }
        /// <summary>
        /// StAmount
        /// </summary>		
        public decimal StAmount { get; set; }
        /// <summary>
        /// StPrice
        /// </summary>		
        public decimal StPrice { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
    }
}
