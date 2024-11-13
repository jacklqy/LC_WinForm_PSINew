using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 单据商品明细信息实体
    /// </summary>
    public class SheetGoodsInfoModel
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
        /// <summary>
        /// 单位编号
        /// </summary>
        public int? UnitId { get; set; }
        //单位名称
        public string UnitName { get; set; }
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
