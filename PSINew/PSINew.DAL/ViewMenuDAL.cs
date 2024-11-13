using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    /// <summary>
    /// 菜单视图查询类
    /// </summary>
    public class ViewMenuDAL:BQuery<ViewMenuInfoModel>
    {
        /// <summary>
        /// 关键词查询菜单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public List<ViewMenuInfoModel> GetMenuListByKeyWordsNew(string keywords,int isDeleted)
        {
            string strWhere = $"IsDeleted={isDeleted}";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (MName like @keywords or ParentName like @keywords)";
            }
            strWhere += " order by ParentId,MOrder";
            SqlParameter paraKeyWords = new SqlParameter("@keywords", $"%{keywords}%");
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl";
            return GetModelList(strWhere, cols, paraKeyWords);
        }
    }
}
