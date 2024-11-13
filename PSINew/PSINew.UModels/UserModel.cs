using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class UserModel : BaseModel
    {
        UserBLL userBLL = new UserBLL();
        RoleBLL roleBLL = new RoleBLL();
        private UserInfoModel userModel;
        public UserModel()
        {
            userModel = new UserInfoModel();
            if (this.UserId > 0)
                userModel = userBLL.GetUserInfo(this.UserId);
        }

        public UserInfoModel UserInfo
        {
            get
            {

                return userModel;
            }
            set
            {
                userModel = value;
            }
        }

        public int UserId
        {
            get => userModel.UserId;
            set
            {
                userModel.UserId = value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get => userModel.UserName;
            set
            {
                userModel.UserName = value;
                OnPropertyChanged();
            }
        }

        public string UserPwd
        {
            get => userModel.UserPwd;
            set
            {
                userModel.UserPwd = value;
                OnPropertyChanged();
            }
        }

        public string UserRealPwd
        {
            get => userModel.UserRealPwd;
            set
            {
                userModel.UserRealPwd = value;
                OnPropertyChanged();
            }
        }

     

        private bool isNormal;
        public bool IsNormal
        {
            get { isNormal= userModel.UserState == 1 ? true : false;
                return isNormal;
            }
            set
            {
                isNormal = value;
                userModel.UserState = isNormal?1:0;
                OnPropertyChanged();
            }
        }

        private bool isFrozen;
        public bool IsFrozen
        {
            get
            {
                isFrozen = userModel.UserState == 1 ? false : true;
                return isFrozen;
            }
            
        }

        public string LoginIp
        {
            get { return userModel.LoginIp; }
        }

        public DateTime? LastLoginTime
        {
            get
            {
                return userModel.LastLoginTime;
            }
        }
        public DateTime? CreateTime
        {
            get
            {
                return userModel.CreateTime;
            }
        }

        public int LoginCount
        {
            get => userModel.LoginCount;
        }

        public string Creator {
            get => userModel.Creator;
            set
            {
                userModel.Creator = value;
                OnPropertyChanged();
            }
        }


        public List<RoleInfoModel> GetRoleList()
        {
            return roleBLL.GetAllRoles();
        }

        public void GetUserInfo()
        {
            userModel = userBLL.GetUserInfo(this.UserId);
        }

        public List<ViewUserRoleModel> GetUserRoleList()
        {
            return userBLL.GetUserRoleList(this.UserId);
        }
    }
}
