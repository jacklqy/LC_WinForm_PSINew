using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class ToolGroupBLL:BaseBLL<ToolGroupInfoModel>
    {
        ToolGroupDAL tgDAL = new ToolGroupDAL();
        /// <summary>
        /// 获取所有的工具组（绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public List<ToolGroupInfoModel> GetToolGroups()
        {
            return tgDAL.GetToolGroups();
        }

        /// <summary>
        /// 加载所有的工具组数据（未删除 或 已删除）
        /// </summary>
        /// <param name="blShow"></param>
        /// <returns></returns>
        public List<ToolGroupInfoModel> GetToolGroups(bool blShow)
        {
            return tgDAL.GetToolGroups(blShow);
        }

        /// <summary>
        /// 检查组名是否已存在
        /// </summary>
        /// <param name="gName"></param>
        /// <returns></returns>
        public bool ExistName(string gName)
        {
            return tgDAL.ExistName(gName);
        }

        public ToolGroupInfoModel GetToolGroupInfo(int groupId)
        {
            return tgDAL.GetToolGroup(groupId);
        }

        /// <summary>
        /// 添加工具组
        /// </summary>
        /// <param name="tgInfo"></param>
        /// <returns></returns>
        public bool AddToolGroup(ToolGroupInfoModel tgInfo)
        {
            return tgDAL.AddToolGroup(tgInfo);
        }
        /// <summary>
        /// 修改工具组
        /// </summary>
        /// <param name="tgInfo"></param>
        /// <returns></returns>
        public bool UpdateToolGroup(ToolGroupInfoModel tgInfo)
        {
            return tgDAL.UpdateToolGroup(tgInfo);
        }

        public bool ConfirmToolGroup(ToolGroupInfoModel tgInfo)
        {
            if(tgInfo!=null)
            {
                if (tgInfo.TGroupId == 0)
                    return tgDAL.AddToolGroup(tgInfo);
                else
                    return tgDAL.UpdateToolGroup(tgInfo);
            }
            return false;
        }

        /// <summary>
        /// 删除工具组（多个）逻辑删除
        /// </summary>
        /// <param name="tgIds"></param>
        /// <returns></returns>
        public bool LogicDeleteToolGroups(List<int> tgIds)
        {
            //return tgDAL.UpdateToolGroupDeleteState(tgIds, 0, 1);
            return LogicDeleteList(tgIds);
        }

        /// <summary>
        /// 恢复工具组数据（多个）
        /// </summary>
        /// <param name="tgIds"></param>
        /// <returns></returns>
        public bool RecoverToolGroups(List<int> tgIds)
        {
            // return tgDAL.UpdateToolGroupDeleteState(tgIds, 0, 0);
            return RecoverList(tgIds);
        }

        /// <summary>
        /// 删除工具组（单个）逻辑删除
        /// </summary>
        /// <param name="tgId"></param>
        /// <returns></returns>
        public bool LogicDeleteToolGroup(int tgId)
        {
            //List<int> tgIds = new List<int>();
            //tgIds.Add(tgId);
            //return tgDAL.UpdateToolGroupDeleteState(tgIds, 0, 1);
           return LogicDelete(tgId);
        }

        /// <summary>
        /// 恢复工具组数据（单个）
        /// </summary>
        /// <param name="tgIds"></param>
        /// <returns></returns>
        public bool RecoverToolGroup(int tgId)
        {
            List<int> tgIds = new List<int>();
            tgIds.Add(tgId);
            // return tgDAL.UpdateToolGroupDeleteState(tgIds, 0, 0);
            return Recover(tgId);
        }

        /// <summary>
        /// 永久删除工具组(单个)
        /// </summary>
        /// <param name="tgId"></param>
        /// <returns></returns>
        public bool DeleteToolGroup(int tgId)
        {
            // return tgDAL.UpdateToolGroupDeleteState(tgIds, 1, 2);
            return Delete(tgId);
        }
    }
}
