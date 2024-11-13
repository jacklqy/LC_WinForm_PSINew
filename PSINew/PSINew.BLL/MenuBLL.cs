using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class MenuBLL : BaseBLL<MenuInfoModel>
    {
        MenuDAL menuDAL = new MenuDAL();
        RoleMenuDAL rmDAL = new RoleMenuDAL();
        ViewMenuDAL vmDAL = new ViewMenuDAL();
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetMenuList(List<int> roleIds)
        {
            string ids = string.Join(",", roleIds);
            return menuDAL.GetMenuList(ids);
        }

        /// <summary>
        /// 获取指定角色的菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<int> GetRoleMenuIds(int roleId)
        {
            List<RoleMenuInfoModel> list = rmDAL.GetRoleMenuIds(roleId);
            return list.Select(m => m.MId).ToList();
        }


        /// <summary>
        /// 关键字查询菜单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
       //old
        //public List<MenuInfoModel> GetMenuListByKeyWords(string keywords)
        //{
        //    return menuDAL.GetMenuListByKeyWords(keywords);
        //}

        public List<ViewMenuInfoModel> GetMenuListByKeyWordsNew(string keywords,bool isShowDel)
        {
            int isDeleted = isShowDel ? 1 : 0;
            List<ViewMenuInfoModel> list = vmDAL.GetMenuListByKeyWordsNew(keywords,isDeleted);
            return list;
        }

        /// <summary>
        /// 获取所有菜单信息（编号，名称） 用于下拉框或列表的绑定
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenus()
        {
         // return  GetModelList("MId,MName");
            return menuDAL.GetAllMenus();
        }

        /// <summary>
        /// 获取所有菜单列表（绑定TreeView）
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetTvMenus()
        {
            return menuDAL.GetTvMenus();
        }

        /// <summary>
        /// 获取指定的菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public MenuInfoModel GetMenuInfo(int menuId)
        {
            return menuDAL.GetMenuInfo(menuId);
        }

       

        /// <summary>
        /// 判断菜单名称是否已存在
        /// </summary>
        /// <param name="mName"></param>
        /// <returns></returns>
        public bool ExistMenu(string mName)
        {
            return menuDAL.ExistMenu(mName);
        }

        /// <summary>
        /// 新增菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
            return menuDAL.AddMenuInfo(menuInfo);
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <param name="blUpdate"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoModel menuInfo)
        {
            return menuDAL.UpdateMenuInfo(menuInfo);
        }

        /// <summary>
        /// 删除菜单信息(逻辑删除)
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool LogicDeleteMenu(List<int> menuIds)
        {
            return menuDAL.DeleteMenuInfo(menuIds, 0, 1);
        }

        public bool LogicDeleteMenu(int menuId)
        {
            List<int> menuIds = new List<int>();
            menuIds.Add(menuId);
            return LogicDeleteMenu(menuIds);
        }

        /// <summary>
        /// 恢复菜单信息(逻辑删除后恢复)
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool RecoverMenu(List<int> menuIds)
        {
            return menuDAL.DeleteMenuInfo(menuIds, 0, 0);
        }

        public bool RecoverMenu(int menuId)
        {
            List<int> menuIds = new List<int>();
            menuIds.Add(menuId);
            return RecoverMenu(menuIds);
        }

        /// <summary>
        /// 移除菜单信息(逻辑删除后永久删除，不能恢复)
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool RemoveMenu(List<int> menuIds)
        {
            return menuDAL.DeleteMenuInfo(menuIds, 1, 2);
        }

        public bool RemoveMenu(int menuId)
        {
            List<int> menuIds = new List<int>();
            menuIds.Add(menuId);
            return RemoveMenu(menuIds);
        }
    }
}
