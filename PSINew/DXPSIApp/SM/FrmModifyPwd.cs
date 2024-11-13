using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSINew.BLL;
using DXPSIApp.FModels;
using PSINew.UModels;
using Common.Encrypt;

namespace DXPSIApp.SM
{
    public partial class FrmModifyPwd : DevExpress.XtraEditors.XtraForm
    {
        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        PwdData fModel = null;
        UserBLL userBLL = new UserBLL();
        ModifyPwdModel fVModel = null;
        string msgTitle = "密码修改";
        private void FrmModifyPwd_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new ModifyPwdModel();
                //接收传值
                if (this.Tag != null)
                    fModel = this.Tag as PwdData;
                //显示账号信息
                if (fModel != null)
                {
                    fVModel.UserName = fModel.UName;
                }
                BindInfo();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "加载修改用户密码信息异常！");
        }

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        private void BindInfo()
        {
            if (fVModel != null)
            {
                txtOldPwd.DataBind(fVModel, "OldPwd");
                txtNewPwd.DataBind(fVModel, "NewPwd");
                txtConPwd.DataBind(fVModel, "ConPwd");
            }
        }

        private void RegisterEvents()
        {
            btnCancel.Click += BtnCancel_Click;
            btnOK.Click += BtnOK_Click;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //判断  空  正确  新密码是否与原始密码一 致   两次密码输入是否一致   
                bool blCheck = CheckPwdInfo();
                if (!blCheck) return;
                //加密处理
                string enNewPwd = MD5Encrypt.Encrypt(fVModel.NewPwd);
                //密码提交 
                bool bl = userBLL.UpdateUserPwd(fModel.UName, enNewPwd);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow("密码修改", "登录密码修改成功！请重新登录！");
                    //重新登录的处理
                    this.Close();
                    fModel.FMain.Hide();
                    fModel.FLogin.Show();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "用户密码修改失败！");
                    return;
                }
            };
            act.TryCatch("密码修改", "修改用户密码提交异常！");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 检查密码输入
        /// </summary>
        private bool CheckPwdInfo()
        {
            if (string.IsNullOrEmpty(fVModel.OldPwd))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请输入原始密码！");
                txtOldPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(fVModel.NewPwd))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请输入新密码！");
                txtNewPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(fVModel.ConPwd))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请输入确认密码！");
                txtConPwd.Focus();
                return false;
            }
            //加密后的密码
            string loginPwd = userBLL.GetOldPwd(fModel.UName);
            string enoldPwd = MD5Encrypt.Encrypt(fVModel.OldPwd);
            if (!string.IsNullOrEmpty(loginPwd))
            {
                if (loginPwd != enoldPwd)//判断原始密码正确性
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "输入的原始密码有误,请输入正确的原始密码！");
                    txtOldPwd.Focus();
                    return false;
                }
            }
            if (fVModel.OldPwd == fVModel.NewPwd)//检查新密码是否与原始密码相同（不同才对）
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "输入的新密码与原始密码不能相同！");
                txtNewPwd.Focus();
                return false;
            }
            if (fVModel.ConPwd != fVModel.NewPwd)//新密码与确认密码是否一致（相同，不同就错了）
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "两次密码输入不一致！");
                txtNewPwd.Focus();
                return false;
            }
            return true;
        }
    }
}