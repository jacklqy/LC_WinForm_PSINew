using DbUtility;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class ToolGroupDAL:BaseDAL<ToolGroupInfoModel>
    {
        /// <summary>
        /// 获取所有的工具组（绑定下拉框或数据列表控件）
        /// </summary>
        /// <returns></returns>
        public List<ToolGroupInfoModel> GetToolGroups()
        {
            return GetModelList("TGroupId,TGroupName");
        }

        /// <summary>
        /// 加载所有的工具组数据（未删除 或已删除）
        /// </summary>
        /// <param name="blShow"></param>
        /// <returns></returns>
        public List<ToolGroupInfoModel> GetToolGroups(bool blShow)
        {
            string cols = "TGroupId,TGroupName";
            if (!blShow)
                return GetModelList(cols);
            else
                return GetDeletedModelList(cols);
        }

        /// <summary>
        /// 检查组名是否已存在
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public bool ExistName(string gName)
        {
            return ExistsByName("TGroupName", gName);
        }

        public ToolGroupInfoModel GetToolGroup(int groupId)
        {
            return GetById(groupId, "TGroupId,TGroupName");
        }

        /// <summary>
        /// 添加工具组
        /// </summary>
        /// <param name="tgInfo"></param>
        /// <returns></returns>
        public bool AddToolGroup(ToolGroupInfoModel tgInfo)
        {
            return Add(tgInfo, "TGroupName,Creator",0)>0;
        }
        /// <summary>
        /// 修改工具组
        /// </summary>
        /// <param name="tgInfo"></param>
        /// <returns></returns>
        public bool UpdateToolGroup(ToolGroupInfoModel tgInfo)
        {
            return Update(tgInfo, "TGroupId,TGroupName,Creator","");
        }

        /// <summary>
        /// 修改工具组数据的删除状态
        /// </summary>
        /// <param name="tgIds"></param>
        /// <param name="delType"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public bool UpdateToolGroupDeleteState(List<int> tgIds,int delType,int isDeleted)
        {
            string delSql = "";
            string ids = string.Join(",", tgIds);
            string strWhere = $" and  TGroupId in ({ids})";
            if (delType == 0)
                delSql = CreateSql.CreateLogicDeleteSql<ToolGroupInfoModel>(strWhere,isDeleted);
            else if(delType==1)
            {
                delSql = CreateSql.CreateDeleteSql<ToolGroupInfoModel>(strWhere);
            }
            List<string> list = new List<string>();
            list.Add(delSql);
            return SqlHelper.ExecuteTrans(list);
        }

       
    }
}
