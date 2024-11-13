using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class ToolMenuBLL:BaseBLL<ToolMenuInfoModel>
    {
        ToolMenuDAL tmDAL = new ToolMenuDAL();
        RoleToolMenuDAL rtmDAL = new RoleToolMenuDAL();
        ViewToolMenuDAL vtmDAL = new ViewToolMenuDAL();
        /// <summary>
        /// 获取工具栏菜单项数据
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<ToolMenuInfoModel> GetToolMenuList(List<int> roleIds)
        {
            string ids = string.Join(",", roleIds);
            return tmDAL.GetToolMenuList(ids);
        }

        /// <summary>
        /// 获取所有的工具菜单项（绑定TreeView）
        /// </summary>
        /// <returns></returns>
        public List<ToolMenuInfoModel> GetToolMenuList()
        {
            return tmDAL.GetToolMenuList();
        }

       

        /// <summary>
        /// 获取指定角色的工具栏菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<int> GetRoleTMenuIds(int roleId)
        {
            List<RoleTMenuInfoModel> list = rtmDAL.GetRoleTMenuIds(roleId);
            return list.Select(m => m.TMenuId).ToList();
        }

        /// <summary>
        /// 关键字查询工具菜单项列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public List<ToolMenuInfoModel> GetToolMenuInfos(string keywords,bool blShow)
        {
            return tmDAL.GetToolMenuInfos(keywords,blShow);
        }

        public List<ViewToolMenuInfoModel> GetToolMenuInfosNew(string keywords, bool blShow)
        {
            int isDeleted = blShow ? 1 : 0;
            return vtmDAL.GetToolMenuListByKeyWords(keywords, isDeleted);
        }

        /// <summary>
        /// 删除工具菜单项（假删除）
        /// </summary>
        /// <param name="tmenuId"></param>
        /// <returns></returns>
        public bool DeleteToolMenuLogic(int tmenuId)
        {
            List<int> ids = new List<int>();
            ids.Add(tmenuId);
            return tmDAL.UpdateToolMenusDelState(ids, 0,1);
        }

        /// <summary>
        ///  删除工具菜单项（真删除）
        /// </summary>
        /// <param name="tmenuId"></param>
        /// <returns></returns>
        public bool DeleteToolMenu(int tmenuId)
        {
            List<int> ids = new List<int>();
            ids.Add(tmenuId);
            return tmDAL.UpdateToolMenusDelState(ids, 1,2);
        }

        /// <summary>
        ///  删除多个工具菜单项（真删除）
        /// </summary>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public bool DeleteToolMenus(List<int> delIds)
        {
            return tmDAL.UpdateToolMenusDelState(delIds, 1,2);
        }

        /// <summary>
        ///  删除多个工具菜单项（假删除）
        /// </summary>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public bool DeleteToolMenusLogic(List<int> delIds)
        {
            return tmDAL.UpdateToolMenusDelState(delIds, 0,1);
        }

        /// <summary>
        /// 工具菜单数据恢复  多条
        /// </summary>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public bool RecoverToolMenus(List<int> delIds)
        {
            return tmDAL.UpdateToolMenusDelState(delIds, 0, 0);
        }

        /// <summary>
        /// 工具菜单数据恢复 单条
        /// </summary>
        /// <param name="tmenuId"></param>
        /// <returns></returns>
        public bool RecoverToolMenu(int tmenuId)
        {
            List<int> ids = new List<int>();
            ids.Add(tmenuId);
            return tmDAL.UpdateToolMenusDelState(ids, 0, 0);
        }

        /// <summary>
        /// 判断指定工具组下是否已添加工具菜单项
        /// </summary>
        /// <param name="tgId"></param>
        /// <returns></returns>
        public bool HasToolMenus(List<int> tgIds)
        {
            return tmDAL.HasToolMenus(tgIds);
        }

        /// <summary>
        /// 获取指定的工具菜单信息
        /// </summary>
        /// <param name="tmenuId"></param>
        /// <returns></returns>
        public ToolMenuInfoModel GetToolMenuInfo(int tmenuId)
        {
            return tmDAL.GetToolMenuInfo(tmenuId);
        }

        /// <summary>
        /// 判断工具菜单名称是否已存在
        /// </summary>
        /// <param name="mName"></param>
        /// <returns></returns>
        public bool ExistToolMenu(string mName)
        {
            return tmDAL.ExistToolMenu(mName);
        }

        /// <summary>
        /// 新增工具菜单信息
        /// </summary>
        /// <param name="tmenuInfo"></param>
        /// <returns></returns>
        public bool AddToolMenuInfo(ToolMenuInfoModel tmenuInfo)
        {
            return tmDAL.AddToolMenuInfo(tmenuInfo);
        }

        /// <summary>
        /// 修改工具菜单信息
        /// </summary>
        /// <param name="tmenuInfo"></param>
        /// <returns></returns>
        public bool UpdateToolMenuInfo(ToolMenuInfoModel tmenuInfo)
        {
            return tmDAL.UpdateToolMenuInfo(tmenuInfo);
        }
    }
}
