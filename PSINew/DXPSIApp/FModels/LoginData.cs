using DXPSIApp;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPSI.FModels
{
    /// <summary>
    /// 用于登录页面向主页面传递参数的实体
    /// </summary>
    public class LoginData
    {
        public List<ViewUserRoleModel> URList { get; set; }
        public FrmLogin LoginForm { get; set; }
    }
}
