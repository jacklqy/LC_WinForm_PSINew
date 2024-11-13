using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
       public class ViewGoodsDAL:BQuery<ViewGoodsInfoModel>
        {
                /// <summary>
                /// 条件查询商品信息
                /// </summary>
                /// <param name="stypeId"></param>
                /// <param name="keywords"></param>
                /// <returns></returns>
                public List<ViewGoodsInfoModel> GetGoodsList(int stypeId, string keywords)
                {
                        string cols = "GoodsId,GoodsNo,GoodsName,GTypeId,GTypeName,GUnit,RetailPrice,IsStopped,GoodsPYNo,Remark";
                        string strWhere = "IsDeleted=0 and IsStopped=0";
                        if (stypeId > 0)
                                strWhere += " and (GTypeId in (select GTypeId from GoodsTypeInfos where  GTypeId=@gtypeId  or ParentId in (select GTypeId from GoodsTypeInfos  where ParentId=@gtypeId or GTypeId=@gtypeId)))";
                        if (!string.IsNullOrEmpty(keywords))
                                strWhere += " and (GoodsNo like @keywords or GoodsName like @keywords or GoodsPYNo like @keywords)";
                        SqlParameter[] paras =
                        {
                                new SqlParameter("@gtypeId",stypeId),
                                new SqlParameter("@keywords",$"%{keywords}%")
                        };

                        return GetModelList(strWhere, cols, paras);
                }
        }
}
