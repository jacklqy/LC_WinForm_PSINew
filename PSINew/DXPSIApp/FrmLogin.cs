using Common;
using Common.Encrypt;
using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using PSINew.UModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using WinPSI.FModels;

namespace DXPSIApp
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        int isGetPwd = 0;
        LoginModel logUser = new LoginModel();//viewModel对象
        UserBLL userBLL = new UserBLL();
        string ip = "";
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //chkRemembered.Checked = false;
            //txtUName.Text = "";
            //txtUPwd.Text = "";
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
            ip = FormUtility.GetLocalIp();//ip
            //获取记住密码记录列表
            List<RememberedRecordInfoModel> recordList = userBLL.GetRememberedList(ip);
            if(recordList.Count >0)
            {
                logUser.UserName = recordList[0].UserName;
                logUser.UserRealPwd = recordList[0].UserRealPwd;
            }

            txtUName.DataBind( logUser, "UserName");
            txtUPwd.DataBind( logUser, "UserRealPwd");
            chkRemembered.DataBind(logUser,"Checked",  "IsRememebered");

            isGetPwd = 1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(logUser.UserName))
            {
                MsgBoxHelper.MsgBoxShow("登录提示", "请输入登录账号！");
                txtUName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(logUser.UserRealPwd))
            {
                MsgBoxHelper.MsgBoxShow("登录提示", "请输入登录密码！");
                txtUPwd.Focus();
                return;
            }

            Action act = () =>
            {
                //加密
                string enPwd = MD5Encrypt.Encrypt(logUser.UserRealPwd);
                //登录检查
                List<ViewUserRoleModel> urList = userBLL.Login(logUser.UserName, enPwd, ip);
                //判断结果
                if (urList.Count == 0)
                {
                    MsgBoxHelper.MsgErrorShow("登录失败", "账号或密码输入有误，请检查！");
                    return;
                }
                else
                {
                    Type tMain = typeof(FrmMain);
                    FrmMain fMain = null;
                    //转到主页面
                    if (!FormUtility.CheckOpenForm(tMain.Name))
                    {
                        fMain = new FrmMain();
                    }
                    else
                    {
                        //更换登录者时发生
                        fMain = (FrmMain)FormUtility.GetOpenForm(tMain.Name);
                    }
                    fMain.Tag = new LoginData()
                    {
                        URList = urList,
                        LoginForm = this
                    };
                    fMain.Show();
                    this.Hide();
                }
            };
            act.TryCatch("登录失败", "登录系统出现异常");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MsgBoxHelper.MsgBoxConfirm("退出系统", "你确定要退出系统吗？") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkRemembered_CheckedChanged(object sender, EventArgs e)
        {
            logUser.IsRememebered = chkRemembered.Checked;
            if (!string.IsNullOrEmpty(logUser.UserRealPwd) && !string.IsNullOrEmpty(logUser.UserName))
            {
                if (logUser.IsRememebered)
                {
                    if (!userBLL.ExistsRecord(ip, logUser.UserName))
                    {
                        userBLL.AddRememberedRecord(new RememberedRecordInfoModel()
                        {
                            LoginIP = ip,
                            UserName = logUser.UserName,
                            UserRealPwd = logUser.UserRealPwd,
                            ReOrder = userBLL.GetMaxOrder(ip)
                        });
                    }
                }
              
            }

        }

        private void txtUName_EditValueChanged(object sender, EventArgs e)
        {
            if(isGetPwd==1)
            {
                logUser.UserName = txtUName.Text;
                string pwd = userBLL.GetPwdByName(logUser.UserName,ip);
                logUser.UserRealPwd = pwd;
            }
       
        }
    }
}
