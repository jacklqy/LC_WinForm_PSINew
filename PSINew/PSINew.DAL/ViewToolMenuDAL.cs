using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class ViewToolMenuDAL:BQuery<ViewToolMenuInfoModel>
    {
        /// <summary>
        /// 关键词查询工具菜单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public List<ViewToolMenuInfoModel> GetToolMenuListByKeyWords (string keywords, int isDeleted)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (TMenuName like @keywords or TGroupName like @keywords)";
            }
            strWhere += " order by TGroupId, TMOrder";
            SqlParameter paraKeyWords = new SqlParameter("@keywords", $"%{keywords}%");
            string cols = "TMenuId,TMenuName,TGroupId,TGroupName,TMPic,TMUrl,TMOrder";
            return GetModelList(strWhere, cols, paraKeyWords);
        }
    }
}
