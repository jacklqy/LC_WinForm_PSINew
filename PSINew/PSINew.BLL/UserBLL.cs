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
    public class UserBLL:BaseBLL<UserInfoModel>
    {
        UserDAL userDAL = new UserDAL();
        ViewUserRoleDAL vurDAL = new ViewUserRoleDAL();
        RememberedRecordDAL rrDAL = new RememberedRecordDAL();
        /// <summary>
        /// 登录系统，返回用户角色列表
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <returns></returns>
        public List<ViewUserRoleModel> Login(string uName,string uPwd,string ip)
        {
            List<ViewUserRoleModel> roleList = new List<ViewUserRoleModel>();
            int userId = userDAL.Login(uName, uPwd,ip);
            if(userId>0)
            {
                //获取用户角色列表
                roleList = vurDAL.GetUserRoles(userId);
            }
            return roleList;
        }

        /// <summary>
        /// 条件查询用户列表
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        public List<UserInfoModel> GetUserList(string uName,bool isShowDel,bool isEnabled)
        {
            int isDeleted = isShowDel ? 1 : 0;
            int isenable = isEnabled ? 1 : 0;
            return userDAL.GetUserList(uName,isDeleted,isenable);
        }

        /// <summary>
        /// 判断用户是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ExistUser(string userName)
        {
            return userDAL.ExistsUser(userName);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool EnableUser(int userId)
        {
            return userDAL.UpdateUserState(userId, 1);
        }
        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool StopUser(int userId)
        {
            return userDAL.UpdateUserState(userId, 0);
        }

        /// <summary>
        /// 多用户停用
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool StopUsers(List<int> userIds)
        {
            return userDAL.UpdateUserSate(userIds, 0);
        }

        /// <summary>
        /// 多用户启用
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool EnableUsers(List<int> userIds)
        {
            return userDAL.UpdateUserSate(userIds, 1);
        }

        /// <summary>
        /// 删除用户信息(逻辑删除)
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool LogicDeleteUsers(List<int> userIds)
        {
            return userDAL.DeleteUserInfo(userIds, 0, 1);
        }

        public bool LogicDeleteUser(int userId)
        {
            List<int> userIds = new List<int>();
            userIds.Add(userId);
            return LogicDeleteUsers(userIds);
        }

        /// <summary>
        /// 恢复用户信息(逻辑删除后恢复)
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool RecoverUsers(List<int> userIds)
        {
            return userDAL.DeleteUserInfo(userIds, 0, 0);
        }

        public bool RecoverUser(int userId)
        {
            List<int> userIds = new List<int>();
            userIds.Add(userId);
            return RecoverUsers(userIds);
        }

        /// <summary>
        /// 移除用户信息(逻辑删除后永久删除，不能恢复)
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool RemoveUsers(List<int> userIds)
        {
            return userDAL.DeleteUserInfo(userIds, 1, 2);
        }

        public bool RemoveUser(int userId)
        {
            List<int> userIds = new List<int>();
            userIds.Add(userId);
            return RemoveUsers(userIds);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoModel GetUserInfo(int userId)
        {
            return userDAL.GetUserInfo(userId);
        }

        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleModel> GetUserRoleList(int userId)
        {
            return vurDAL.GetUserRoles(userId);
        }

        /// <summary>
        /// 添加用户 信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="urList"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList)
        {
            return userDAL.AddUserInfo(userInfo, urList);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="urList"></param>
        /// <param name="urListNew"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfoModel userInfo, List<UserRoleInfoModel> urList, List<UserRoleInfoModel> urListNew)
        {
            return userDAL.UpdateUserInfo(userInfo, urList, urListNew);
        }

        /// <summary>
        /// 获取用户原始密码
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        public string GetOldPwd(string uName)
        {
            return userDAL.GetOldPwd(uName);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="enNewPwd"></param>
        /// <returns></returns>
        public bool UpdateUserPwd(string uName, string enNewPwd)
        {
            return userDAL.UpdateUserPwd(uName, enNewPwd);
        }

        /// <summary>
        /// 获取当前ip所有已记住密码的用户列表
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public List<RememberedRecordInfoModel> GetRememberedList(string ip)
        {
            return rrDAL.GetRecordsByIp(ip);
        }

        public bool AddRememberedRecord(RememberedRecordInfoModel record)
        {
            return rrDAL.AddRememberedRecord(record);
        }

        public string GetPwdByName(string uName,string ip)
        {
            return rrDAL.GetPwdByUserName(uName,ip);
        }

        public int GetMaxOrder(string ip)
        {
            return rrDAL.GetMaxReOrder(ip);
        }

        public bool DeleteRecord(string ip,string userName)
        {
            return rrDAL.DeleteRecord(ip,userName);
        }

        public bool ExistsRecord(string ip, string userName)
        {
            return rrDAL.Exists(ip, userName);
        }
    }
}
