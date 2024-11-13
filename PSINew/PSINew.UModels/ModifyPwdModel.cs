using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class ModifyPwdModel : BaseModel
    {
        private string userName;
        private string oldPwd;
        private string newPwd;
        private string conPwd;

        public string UserName { get => userName; set{ userName = value; OnPropertyChanged(); } }
        public string OldPwd { get => oldPwd; set { oldPwd = value; OnPropertyChanged(); } }
        public string NewPwd { get => newPwd; set { newPwd = value; OnPropertyChanged(); } }
        public string ConPwd { get => conPwd; set { conPwd = value; OnPropertyChanged(); } }
    }
}
