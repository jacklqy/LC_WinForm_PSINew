using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.DModels
{
    /// <summary>
    /// 支付信息实体类
    /// </summary>
    [Serializable]
    [Table("PayInfos")]
    [PrimaryKey("PayId")]
    public class PayInfoModel
    {
        /// <summary>
        /// PayId
        /// </summary>		

        public int PayId { get; set; }
        /// <summary>
        /// PayName
        /// </summary>		
        public string PayName { get; set; }
        /// <summary>
        /// PayMoney
        /// </summary>		
        public decimal PayMoney { get; set; }
        /// <summary>
		/// PayType
        /// </summary>		
        public string PayType { get; set; }
        
    }
}
