using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class ViewUserRoleDAL:BQuery<ViewUserRoleModel>
    {
        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ViewUserRoleModel> GetUserRoles(int userId)
        {
            string strWhere = "UserId=@UserId";
            SqlParameter paraId = new SqlParameter("@UserId", userId);
            return GetModelList(strWhere, "UserId,UserName,RoleId,RoleName,IsAdmin", paraId);
        }
    }
}
