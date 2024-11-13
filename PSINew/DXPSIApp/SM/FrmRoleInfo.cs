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
using DXPSIApp.FModels;
using PSINew.BLL;
using PSINew.UModels;
using PSINew.Models.DModels;

namespace DXPSIApp.SM
{
    public partial class FrmRoleInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmRoleInfo()
        {
            InitializeComponent();
        }
        public event Action Reload;//刷新角色列表
        FInfoData fModel = null;
        private RoleBLL roleBLL = new RoleBLL();
        private string oldName = "";//要修改的角色名称
        private string btnText = "";
        private RoleModel fVModel = null;//页面VM
        private void FrmRoleInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                    if (fModel != null)
                    {
                        InitRoleInfo();
                        RegisterEvents();
                    }
                }
            };
            act.TryCatch("角色信息","角色信息页面加载异常！");
        }

        private void RegisterEvents()
        {
            btnOK.Click += BtnOK_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void InitRoleInfo()
        {
            fVModel = new RoleModel();
            string addText = "——";
            if (fModel.FId == 0)
            {
                btnText = "新增";
            }
            else
            {
                fVModel.RoleId = fModel.FId;
                fVModel.GetRoleInfo();
                oldName = fVModel.RoleName;
                btnText = "修改";
            }
            BindInfo();
            addText += btnText;
            this.Text += addText;
            btnOK.Text = btnText;
        }

        /// <summary>
        /// 绑定信息
        /// </summary>
        private void BindInfo()
        {
            if(fVModel!=null)
            {
                txtRName.DataBindings.Add("Text", fVModel, "RoleName");
                txtRemark.DataBindings.Add("Text", fVModel, "Remark");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            string msgTitle = "保存角色信息";
            //判空处理 ---角色名称
            if (string.IsNullOrEmpty(fVModel.RoleName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "角色名称不能为空！");
                txtRName.Focus();
                return;
            }
            if (fModel.FId == 0 || (!string.IsNullOrEmpty(oldName) && oldName != fVModel.RoleName))
            {
                if (roleBLL.ExistRoleName(fVModel.RoleName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "角色名称已经存在！");
                    txtRName.Focus();
                    return;
                }
            }
            //封装
            RoleInfoModel roleInfo = new RoleInfoModel()
            {
                RoleId = fModel.FId,
                RoleName = fVModel.RoleName,
                Remark = fVModel.Remark,
                Creator = fModel.UName
            };
            //调用方法（add）  （update）
            bool bl = false;
            if (fModel.FId == 0)
            {
                bl = roleBLL.AddRoleInfo(roleInfo);
            }
            else if (fModel.FId > 0)
            {
                roleInfo.RoleId = fModel.FId;
                bl = roleBLL.UpdateRoleInfo(roleInfo);
            }
            //判断结果给出提示
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow($"{btnText}角色", $"角色：{fVModel.RoleName} 信息{btnText}成功！");
                //刷新列表页面数据
                this.Reload?.Invoke();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, $"角色：{fVModel.RoleName} 信息{btnText}失败！");
                return;
            }
        }

      
    }
}