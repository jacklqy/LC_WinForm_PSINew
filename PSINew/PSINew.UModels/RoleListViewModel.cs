using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class RoleListViewModel:BaseModel
    {
        RoleBLL roleBLL = new RoleBLL();
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value; OnPropertyChanged(); } }
        /// <summary>
        /// 角色列表
        /// </summary>
        private BindingList<RoleModel> roleList = new BindingList<RoleModel>();
        public BindingList<RoleModel> RoleList
        {
            get
            {
               GetRoleList();
                return roleList;
            }
            set
            {
                roleList = value;
                OnPropertyChanged();
            }
        }

        public void GetRoleList()
        {
            List<RoleInfoModel> list = roleBLL.GetAllRoleList(isShowDel);
            roleList = new BindingList<RoleModel>();
            list.ForEach(r => roleList.Add(new RoleModel()
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName,
                Remark = r.Remark
            }));
          
        }
    }
}
