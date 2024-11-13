using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        /// <summary>
        /// 采购单相关商品明细数据查询处理类
        /// </summary>
        public  class ViewPerChaseGoodsDAL:BQuery<ViewPerGoodsInfoModel>
        {
                /// <summary>
                /// 获取指定单据的商品明细列表
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public List<ViewPerGoodsInfoModel> GetPerchaseGoodsList(int perId)
                {
                        string cols = "PerGoodsId,PerId,GoodsId,GoodsNo,GoodsTXNo,GoodsName,GUnit,Count,PerPrice,Amount,Remark";
                        return GetRowsModelList($"PerId={perId} and IsDeleted=0", cols);
                }
        }
}
