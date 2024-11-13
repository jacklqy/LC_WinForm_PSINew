using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.UIModels
{
        /// <summary>
        /// 单据查询参数实体
        /// </summary>
        public class ShQueryParaModel
        {
                public int UnitId { get; set; }
                public string UnitName { get; set; }
                public string DealPerson { get; set; }
                public string GoodsName { get; set; }
                public string SheetNo { get; set; }
                public int IsChecked { get; set; }
                public string Creator { get; set; }
                public int StoreId { get; set; }
                public string StoreName { get; set; }
                public string CheckPerson { get; set; }
                public int ShType { get; set; }
        }
}
