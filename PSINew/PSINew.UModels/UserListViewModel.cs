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
    public class UserListViewModel : BaseModel
    {
        UserBLL userBLL = new UserBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords;
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value; OnPropertyChanged(); } }

        /// <summary>
        /// 是否启用
        /// </summary>
        private bool isEnabled;
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged(); } }

        /// <summary>
        /// 用户列表
        /// </summary>
        private BindingList<UserModel> userList = new BindingList<UserModel>();
        public BindingList<UserModel> UserList
        {
            get
            {
                GetUserList();
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 根据条件查询用户列表
        /// </summary>
        public void GetUserList()
        {
            List<UserInfoModel> list = userBLL.GetUserList(keywords, isShowDel,isEnabled);
            userList = new BindingList<UserModel>();
            list.ForEach(m => userList.Add(new UserModel()
            {
                UserInfo = m
            }));
        }
    }
}
