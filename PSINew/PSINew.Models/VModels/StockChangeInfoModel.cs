using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 库存变动明细实体
    /// </summary>
    public class StockChangeInfoModel
    {
        //Id
        public int Id { get; set; }
        //单据Id
        public int SheetId { get; set; }
        //单据编号
        public string SheetNo { get; set; }
        //类型
        public int ShType { get; set; }
        //类型名称
        public string ShTypeName { get; set; }
        //审核状态
        public int IsChecked { get; set; }
        //单核状态值说明
        public string CheckState { get; set; }
        //制单时间
        public DateTime CreateTime { get; set; }
        //仓库编号
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int GoodsId { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GUnit { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int InCount { get; set; }
        public int OutCount { get; set; }
        public decimal StAmount { get; set; }
        public decimal StPrice { get; set; }
        public int CurCount { get; set; }
        //经手人
        public string DealPerson { get; set; }
        //制单人
        public string Creator { get; set; }
        //审核人
        public string CheckPerson { get; set; }
        //审核时间
        public DateTime CheckTime { get; set; }

    }
}
