using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class LoginModel : BaseModel
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }
        private string userRealPwd;
        public string UserRealPwd
        {
            get
            {
                return userRealPwd;
            }
            set
            {
                userRealPwd = value;
                OnPropertyChanged();
            }
        }
        private bool isRemembered;
        public bool IsRememebered
        {
            get
            {
                return isRemembered;
            }
            set
            {
                isRemembered = value;
                OnPropertyChanged();
            }
        }
    }
}
