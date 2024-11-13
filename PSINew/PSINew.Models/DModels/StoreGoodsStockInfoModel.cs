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
    [Table("StoreGoodsStockInfos")]
    [PrimaryKey("StoreGoodsId")]
    public class StoreGoodsStockInfoModel
    {
        /// <summary>
        /// StoreGoodsId
        /// </summary>		
        public int StoreGoodsId { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
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
        /// CurCount
        /// </summary>		
        public int CurCount { get; set; }
        /// <summary>
        /// StPrice
        /// </summary>		
        public decimal StPrice { get; set; }
        /// <summary>
        /// StockAmount
        /// </summary>		
        public decimal StockAmount { get; set; }
        /// <summary>
        /// StockUp
        /// </summary>		
        public int? StockUp { get; set; }
        /// <summary>
        /// StockDown
        /// </summary>		
        public int StockDown { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// EditTime
        /// </summary>		
        public DateTime CreateTime { get; set; }

    }
}
