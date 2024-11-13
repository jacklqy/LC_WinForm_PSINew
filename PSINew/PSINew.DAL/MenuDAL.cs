using DbUtility;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class MenuDAL : BaseDAL<MenuInfoModel>
    {
        /// <summary>
        /// 获取所有的菜单列表
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetMenuList()
        {
            string strWhere = " order by MOrder";
            string cols = "MId,MName,ParentId,MKey,MUrl,IsTop";
            return GetModelList(strWhere, cols);
        }

        /// <summary>
        /// 获取角色权限菜单列表
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetMenuList(string roleIds)
        {
            string strWhere = "1=1 and IsDeleted=0";
            string cols = "MId,MName,ParentId,MKey,MUrl,IsTop,MDesp";
            if (!string.IsNullOrEmpty(roleIds))
            {
                strWhere += $" and MId in (select MId from RoleMenuInfos where RoleId in ({roleIds})) ";
            }
            strWhere += " order by MOrder";
            return GetModelList(strWhere, cols);
        }

        /// <summary>
        /// 关键字查询菜单列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetMenuListByKeyWords(string keywords)
        {
            string strWhere = "IsDeleted=0";
            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (MName like @keywords or ParentName like @keywords)";
            }
            strWhere += " order by ParentId,MOrder";
            SqlParameter paraKeyWords = new SqlParameter("@keywords", $"%{keywords}%");
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl";
            return GetModelList(strWhere, cols, paraKeyWords);
        }

       

        /// <summary>
        /// 主要用于绑定列表或下拉框
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenus()
        {
            return GetModelList("MId,MName");
        }

        /// <summary>
        /// 获取所有菜单列表（绑定TreeView）
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetTvMenus()
        {
            return GetModelList("MId,MName,ParentId");
        }

        public MenuInfoModel GetMenuInfo(int menuId)
        {
            string cols = "MId,MName,ParentId,MKey,MUrl,MOrder,IsTop,MDesp";
            return GetById(menuId, cols);
        }

        /// <summary>
        /// 判断菜单名称是否已存在
        /// </summary>
        /// <param name="mName"></param>
        /// <returns></returns>
        public bool ExistMenu(string mName)
        {
            return ExistsByName("MName", mName);
        }

        /// <summary>
        /// 新增菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
            string cols = "MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,Creator,MDesp";
            return Add(menuInfo, cols, 0) > 0;
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoModel menuInfo)
        {
            List<CommandInfo> comList = new List<CommandInfo>();
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";
            SqlModel upModel = CreateSql.GetUpdateSqlAndParas(menuInfo, cols, "");
            //修改指定的菜单信息
            comList.Add(new CommandInfo()
            {
                CommandText = upModel.Sql,
                IsProc = false,
                Paras = upModel.SqlParaArray
            });
            //if (blUpdate)
            //{
            //    string sqlUpdateParentName = "update MenuInfos set ParentName=@parentName where ParentId=@menuId";
            //    SqlParameter[] paras =
            //    {
            //        new SqlParameter("@parentName",menuInfo.MName),
            //        new SqlParameter("@menuId",menuInfo.MId)
            //    };
            //    comList.Add(new CommandInfo()
            //    {
            //        CommandText = sqlUpdateParentName,
            //        IsProc = false,
            //        Paras = paras
            //    });
            //}
            return SqlHelper.ExecuteTrans(comList);
        }

        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="MenuIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool DeleteMenuInfo(List<int> MenuIds, int delType, int isDeleted)
        {
            List<string> sqlList = new List<string>();
            //获取要删除的菜单编号集合
            List<int> menuIds = new List<int>();
            foreach (int menuId in MenuIds)
            {
                if (!menuIds.Contains(menuId))
                    menuIds.Add(menuId);
                menuIds = GetChildMenuIds(menuIds, menuId);
            }
            string strIds = string.Join(",", menuIds);
            string strWhere = $"MId in ({strIds})";
            string delMenu = "";
            string delRoleMenu = "";
            if (delType == 1)
            {
                delMenu = "delete from MenuInfos where " + strWhere;
                delRoleMenu = "delete from RoleMenuInfos where " + strWhere;
            }
            else
            {
                delMenu = $"update MenuInfos set IsDeleted={isDeleted} where " + strWhere;
                delRoleMenu = $"update RoleMenuInfos  set IsDeleted={isDeleted} where " + strWhere;
            }
            sqlList.Add(delMenu);
            sqlList.Add(delRoleMenu);
            return SqlHelper.ExecuteTrans(sqlList);
        }

        /// <summary>
        /// 获取指定菜单的子菜单编号集合
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private List<int> GetChildMenuIds(List<int> menuIds,int parentId)
        {
           List<MenuInfoModel> list =  GetModelList($"ParentId={parentId} and IsDeleted=0", "MId");
            foreach(MenuInfoModel menu in list)
            {
                if (!menuIds.Contains(menu.MId))
                    menuIds.Add(menu.MId);
                GetChildMenuIds(menuIds, menu.MId);
            }
            return menuIds;
        }
    }
}
