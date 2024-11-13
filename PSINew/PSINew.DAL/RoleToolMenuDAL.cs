using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    /// <summary>
    /// 角色菜单关系 数据访问类
    /// </summary>
    public class RoleToolMenuDAL:BaseDAL<RoleTMenuInfoModel>
    {
        /// <summary>
        /// 获取指定角色的工具栏菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleTMenuInfoModel> GetRoleTMenuIds(int roleId)
        {
            string strWhere = $"RoleId={roleId} and IsDeleted=0";
            return GetModelList(strWhere, "TMenuId");
        }
    }
}
