using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.UIModels
{
    /// <summary>
    /// 库存查询页面条件信息实体
    /// </summary>
    public class StockQueryParaModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int GTypeId { get; set; }
        public string GoodsName { get; set; }
    }
}
