using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class RoleBLL:BaseBLL<RoleInfoModel>
    {
        RoleDAL roleDAL = new RoleDAL();
        /// <summary>
        /// 获取绑定的角色列表（主要用于绑定下拉框或列表框）
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            return roleDAL.GetAllRoles();
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoleList(bool isShowDel)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return roleDAL.GetAllRoleList(isDeleted);
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool ExistRoleName(string roleName)
        {
            return roleDAL.ExistRoleName(roleName);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.AddRoleInfo(roleInfo);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.UpdateRoleInfo(roleInfo);
        }


        /// <summary>
        /// 获取指定的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRole(int roleId)
        {
            return roleDAL.GetRole(roleId);
        }

        /// <summary>
        /// 删除单个角色信息
        /// </summary>
        /// <param name="roleId"></param>
        ///  <param name="delType">0 ---logic   1= real</param>
        /// <returns></returns>
        public bool LogicDeleteRole(int roleId)
        {
            return roleDAL.DeleteRole(roleId, 0,1);
        }

        public bool RecoveryRole(int roleId)
        {
            return roleDAL.DeleteRole(roleId, 0, 0);
        }

        /// <summary>
        /// 删除角色信息（真删除）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteRole(int roleId)
        {
            return roleDAL.DeleteRole(roleId, 1,2);
        }

        /// <summary>
        /// 删除多个角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool DeleteRoles(List<int> roleIds)
        {
            return roleDAL.DeleteRoles(roleIds, 1,2);
        }

        public bool LogicDeleteRoles(List<int> roleIds)
        {
            return roleDAL.DeleteRoles(roleIds, 0, 1);
        }

        public bool RecoveryRoles(List<int> roleIds)
        {
            return roleDAL.DeleteRoles(roleIds, 0, 0);
        }

        /// <summary>
        /// 保存权限设置
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <param name="tmenuIds"></param>
        /// <param name="uName"></param>
        /// <returns></returns>
        public bool SetRoleRight(int roleId,List<int> menuIds,List<int> tmenuIds,string uName)
        {
            List<RoleMenuInfoModel> rmList = new List<RoleMenuInfoModel>();
            List<RoleTMenuInfoModel> rtmList = new List<RoleTMenuInfoModel>();
            //2.角色编号  菜单编号，工具栏菜单编号 建立关系--分别封装
            if (menuIds != null)
            {
                foreach (int menuId in menuIds)
                {
                    rmList.Add(new RoleMenuInfoModel()
                    {
                        MId = menuId,
                        RoleId = roleId,
                        Creator = uName
                    });
                }
            }
            if(tmenuIds!=null)
            {
                foreach (int tmenuId in tmenuIds)
                {
                    rtmList.Add(new RoleTMenuInfoModel()
                    {
                        TMenuId = tmenuId,
                        RoleId = roleId,
                        Creator = uName
                    });
                }
            }
            //3.存入数据表（角色菜单关系表 角色工具菜单关系表）
            return roleDAL.SetRoleRight(roleId, rmList, rtmList);
        }
    }
}
