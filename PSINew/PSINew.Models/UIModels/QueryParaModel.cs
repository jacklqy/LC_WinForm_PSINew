using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.UIModels
{
        /// <summary>
        /// 用于查询页面封装参数的实体
        /// </summary>
        public class QueryParaModel
        {
                public int StoreId { get; set; }
                public string StoreName { get; set; }
                public string GoodsName { get; set; }
                public int GTypeId { get; set; }
                public int UnitId { get; set; }
                public string UnitName { get; set; }
                public string DealPerson { get; set; }
                public int UTypeId { get; set; }
                public int STypeId { get; set; }
        }
}
