using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.Models.VModels
{
    /// <summary>
    /// 角色菜单视图模型
    /// </summary>
    public class ViewRoleMenuModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int MId { get; set; }
        public string MName { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string MKey { get; set; }
        public string MUrl { get; set; }
        public int MOrder { get; set; }
    }
}
