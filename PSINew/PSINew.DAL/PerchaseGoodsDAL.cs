using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public class PerchaseGoodsDAL:BaseDAL<PerchaseGoodsInfoModel>
        {
                /// <summary>
                /// 判断指定的采购单中是否已存在指定的商品
                /// </summary>
                /// <param name="perId"></param>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool ExistsGoods(int perId, int goodsId)
                {
                        string strWhere = $"PerId={perId} and GoodsId={goodsId}";
                        return Exists(strWhere);
                }
        }
}
