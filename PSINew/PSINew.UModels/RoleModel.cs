using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class RoleModel:BaseModel
    {
        RoleBLL roleBLL = new RoleBLL();
        private int roleId;
        private string roleName;
        private string remark;
        public int RoleId
        {
            get => roleId;
            set
            {
                roleId = value;
                OnPropertyChanged();
            }
        }
        public string RoleName
        {
            get => roleName;
            set
            {
                roleName = value;
                OnPropertyChanged();
            }
        }
        public string Remark
        {
            get => remark;
            set
            {
                remark = value;
                OnPropertyChanged();
            }
        }

        public void GetRoleInfo()
        {
            RoleInfoModel roleInfo = roleBLL.GetRole(this.roleId);
            if (roleInfo != null)
            {
                RoleName = roleInfo.RoleName;
                Remark = roleInfo.Remark;
            }
        }
    }
}
