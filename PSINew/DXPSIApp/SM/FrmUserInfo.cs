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
using PSINew.UModels;
using DXPSIApp.FModels;
using PSINew.Models.DModels;
using PSINew.BLL;
using Common.Encrypt;

namespace DXPSIApp.SM
{
    public partial class FrmUserInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }
        public event Action ReLoad;//刷新列表页的事件
        private UserBLL userBLL = new UserBLL();
        private UserModel fVModel = null;//ViewModel
        private string msgTitle = "用户信息";
        FInfoData fModel = null;
        private string oldName = "";//要修改的用户名称
        private string btnText = "";
        List<int> roleIds = new List<int>();
        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new UserModel();
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                    if (fModel != null)
                    {
                        fVModel.UserId = fModel.FId;
                        InitUserInfo();
                        RegisterEvents();
                    }
                }
            };
            act.TryCatch(msgTitle, "用户信息页面加载异常！");
        }

        private void RegisterEvents()
        {
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
        }

     

        private void InfoTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                bool blCheck = CheckUserInfo();
                if (!blCheck) return;

                if (fVModel.UserRealPwd != "")
                    fVModel.UserPwd = MD5Encrypt.Encrypt(fVModel.UserRealPwd);
                //封装信息实体
                UserInfoModel userInfo = new UserInfoModel()
                {
                    UserId =fVModel.UserId,
                    UserName = fVModel.UserName,
                    UserPwd = fVModel.UserPwd,
                    Creator = fModel.UName,
                    UserRealPwd=fVModel.UserRealPwd,
                    UserState = fVModel.UserInfo.UserState
                };
               
                //角色列表获取
                List<UserRoleInfoModel> urList = new List<UserRoleInfoModel>();
                List<RoleInfoModel> allRoles = lbRoleList.DataSource as List<RoleInfoModel>;
                for (int i = 0; i < lbRoleList.CheckedIndices.Count; i++)
                {
                    RoleInfoModel role = allRoles[lbRoleList.CheckedIndices[i]];
                    UserRoleInfoModel ur = new UserRoleInfoModel()
                    {
                        RoleId = role.RoleId,
                        UserId = fVModel.UserId,
                        Creator = fModel.UName
                    };
                    urList.Add(ur);
                }

                //提交操作
                if (fModel.ActType == 1)
                {
                    //提交新增
                    bool blAdd = userBLL.AddUserInfo(userInfo, urList);
                    if (blAdd)
                    {
                        MsgBoxHelper.MsgBoxShow("添加用户", $"用户:{fVModel.UserName} 添加成功！");
                        this.ReLoad?.Invoke();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle,$"用户:{fVModel.UserName} 添加失败！");
                        return;
                    }
                }
                else
                {
                    //筛选角色列表设置
                    List<UserRoleInfoModel> urListNew = new List<UserRoleInfoModel>();
                    foreach (var ur in urList)
                    {
                        if (!roleIds.Contains(ur.RoleId))
                            urListNew.Add(ur);
                    }
                    if (urList.Count == roleIds.Count && urListNew.Count == 0)
                    {
                        urList.RemoveRange(0, urList.Count);
                    }

                    //提交修改
                    bool blEdit = userBLL.UpdateUserInfo(userInfo, urList, urListNew);
                    if (blEdit)
                    {
                        MsgBoxHelper.MsgBoxShow("修改用户", $"用户:{fVModel.UserName} 修改成功！");
                        this.ReLoad?.Invoke();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle,$"用户:{fVModel.UserName} 修改失败！");
                        return;
                    }
                }
            };
            act.TryCatch(msgTitle,"提交用户信息异常！");
        }



        private void InfoTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void InfoTool1_ClearClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fModel.ActType==1)
            {
                foreach(Control c in this.Controls)
                {
                    c.DataBindings.Clear();
                }
                BindInfo();
            }
        }

        /// <summary>
        /// 初始化用户信息
        /// </summary>
        private void InitUserInfo()
        {
            fVModel = new UserModel();
            string addText = "——";
            if (fModel.FId == 0)
            {
                btnText = "新增";
            }
            else
            {
                fVModel.UserId = fModel.FId;
                fVModel.GetUserInfo();
                oldName = fVModel.UserName;
                btnText = "修改";
                infoTool1.IsClearEnable = false;
                if (fModel.ActType == 4)
                    infoTool1.IsSaveEnable = false;
            }
            BindInfo();//绑定页面信息
            LoadCheckedRoles();
            addText += btnText;
            this.Text += addText;
        }

        private void BindInfo()
        {
            if (fVModel != null)
            {
                txtUName.DataBind(fVModel, "UserName", true);
                txtUPwd.DataBind(fVModel, "UserRealPwd", true);
                chkNormal.DataBind(fVModel, "Checked", "IsNormal", true);
                chkFrozen.DataBind(fVModel, "Checked", "IsFrozen", true);
                lbRoleList.DataSource = fVModel.GetRoleList();
                lbRoleList.DisplayMember = "RoleName";
                lbRoleList.ValueMember = "RoleId";
            }
        }

        private void LoadCheckedRoles()
        {
            var userRoles = fVModel.GetUserRoleList();
            if(userRoles.Count >0)
            {
                List<RoleInfoModel> allRoles = lbRoleList.DataSource as List<RoleInfoModel>;
                foreach (var ur in userRoles)
                {
                    for (int i = 0; i < allRoles.Count; i++)
                    {
                        RoleInfoModel role =allRoles[i];
                        if (role.RoleId == ur.RoleId)
                        {
                            lbRoleList.SetItemChecked(i, true);
                            roleIds.Add(role.RoleId);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 检查用户信息
        /// </summary>
        /// <returns></returns>
        private bool CheckUserInfo()
        {
            //判断账号是否为空
            if (string.IsNullOrEmpty(fVModel.UserName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,"账号不能为空！");
                txtUName.Focus();
                return false;
            }
            else if (fVModel.UserId == 0 || (!string.IsNullOrEmpty(oldName) && oldName != fVModel.UserName))
            {
                //判断用户名是否已存在---存在---错误提示
                if(userBLL.ExistUser(fVModel.UserName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "该用户名已存在！");
                    txtUName.Focus();
                    return false;
                }
            }
            if (fVModel.UserId == 0 && string.IsNullOrEmpty(fVModel.UserRealPwd))
            {

                MsgBoxHelper.MsgErrorShow(msgTitle,"密码不能为空！");
                txtUPwd.Focus();
                return false;
            }
            return true;
        }
    }
}