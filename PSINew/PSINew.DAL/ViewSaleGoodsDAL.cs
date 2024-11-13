using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        /// <summary>
        /// ViewSaleGoodsInfos视图查询处理类
        /// </summary>
        public class ViewSaleGoodsDAL:BQuery<ViewSaleGoodsInfoModel>
        {
                /// <summary>
                /// 获取指定单据的商品明细列表
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public List<ViewSaleGoodsInfoModel> GetSaleGoodsList(int saleId)
                {
                        string cols = "SaleGoodsId,SaleId,GoodsId,GoodsNo,GoodsTXNo,GoodsName,GUnit,Count,SalePrice,Amount,Remark";
                        return GetRowsModelList($"SaleId={saleId} and IsDeleted=0", cols);
                }
        }
}
