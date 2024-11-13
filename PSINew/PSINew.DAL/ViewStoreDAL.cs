using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public  class ViewStoreDAL:BQuery<ViewStoreInfoModel>
        {
                /// <summary>
                /// 条件查询仓库列表
                /// </summary>
                /// <param name="sTypeId"></param>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<ViewStoreInfoModel> LoadStoreList(int sTypeId, string keywords, int isDeleted)
                {
                        string cols = "StoreId,StoreNo,StoreName,STypeId,STypeName,StorePYNo,StoreOrder,StoreRemark";
                        SqlParameter paraKeywords  = new SqlParameter("@keywords", $"%{keywords}%");
                        string strWhere = $"IsDeleted={isDeleted}";
                        if (sTypeId > 0)
                                strWhere += $" and STypeId={sTypeId}";
                        if (!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (StoreName like @keywords or StoreNo like @keywords or StorePYNo like @keywords)";
                           
                        } 
                        strWhere += " order by StoreOrder";

                     return    GetModelList(strWhere, cols, paraKeywords);
                }
        }
}
