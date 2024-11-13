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
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using PSINew.UModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.SM
{
    public partial class FrmUserList : DevExpress.XtraEditors.XtraForm
    {
        public FrmUserList()
        {
            InitializeComponent();
        }
        string uName = "";
        UserBLL userBLL = new UserBLL();
        string msgTitle = "用户管理";
        UserListViewModel fVModel = null;//ViewModel
        int isLoad = 0;//是否已加载
        private void FrmUserList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                fVModel = new UserListViewModel();
                RegisterEvents();//事件订阅
                fVModel.IsShowDel = false;
                fVModel.IsEnabled = true;
                BindData();//绑定页面信息
                SetDgvCols();
            };
            act.TryCatch(msgTitle,"用户管理页面加载异常！");
        }

        private void RegisterEvents()
        {
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.InfoClick += ListTool1_InfoClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.CloseClick += ListTool1_CloseClick;
            btnFind.Click += BtnFind_Click;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            chkIsNormal.CheckedChanged += ChkIsNormal_CheckedChanged;
            gvUserList.RowCellClick += GvUserList_RowCellClick;
        }

       

        private void BindData()
        {
            txtKeyWords.DataBind(fVModel, "KeyWords", true);
            chkShowDel.DataBind(fVModel, "Checked", "IsShowDel", true);
            chkIsNormal.DataBind(fVModel, "Checked", "IsEnabled", true);
            gvUserList.OptionsBehavior.AutoPopulateColumns = false;
            gcUserList.DataBind(fVModel,"DataSource",  "UserList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvUserList.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            fVModel.IsEnabled = true;
            FindUserList();
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string msgTitle = "删除用户";
            if (gvUserList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要删除的用户信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, "您确定要删除选择的用户信息吗？删除用户会连同其用户角色关系数据一并删除？") == DialogResult.Yes)
            {
                List<int> userIds = new List<int>();
                foreach (int index in gvUserList.GetSelectedRows())
                {
                    UserModel user = fVModel.UserList[index];
                    userIds.Add(user.UserId);
                }
                bool bl = userBLL.LogicDeleteUsers(userIds);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, "选择的用户信息删除成功！");
                    gcUserList.ReLoadData();

                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "选择的用户信息删除失败！");
                    return;
                }
            }
        }

        private void ListTool1_InfoClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            ShowUserInfoPage(1, 0);
        }

        private void GvUserList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            UserModel user = fVModel.UserList[index];
            switch (col.Name)
            {
                case "colEdit":
                    ShowUserInfoPage( 2,user.UserId);
                    break;
                case "colDelete":
                    DeleteUser(user, 1);
                    break;
                case "colRecover":
                    DeleteUser(user, 0);
                    break;
                case "colRemove":
                    DeleteUser(user, 2);
                    break;
                default: break;
            }
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindUserList();
        }

        private void ChkIsNormal_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsEnabled = chkIsNormal.Checked;
            FindUserList();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindUserList();
        }

        /// <summary>
        /// 显示用户页面
        /// </summary>
        /// <param name="actType">1  add   2  edit  3  addchild  4 详情</param>
        /// <param name="userId"></param>
        private void ShowUserInfoPage(int actType, int userId)
        {
            FrmUserInfo fUser = new FrmUserInfo();
            fUser.Tag = new FInfoData()
            {
                ActType = actType,
                FId = userId,
                UName = uName
            };
            if (actType < 4)
                fUser.ReLoad += () => FindUserList();
            fUser.ShowDialogNew();
        }

        private void FindUserList()
        {
            fVModel.GetUserList();
            SetDgvCols();
            if (isLoad == 1)
                gcUserList.ReLoadData();
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvUserList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvUserList.GetFocusedDataSourceRowIndex();
                UserModel user = fVModel.UserList[index] as UserModel;
                ShowUserInfoPage(actType, user.UserId);
            }
            else
            {
                string title = "查看用户", errMsg = "请选择你要查看的用户信息";
                if (actType == 2)
                {
                    title = "修改用户";
                    errMsg = "请选择你要修改的用户信息";
                }
                MsgBoxHelper.MsgErrorShow(title, errMsg);
                return;
            }
        }
        /// <summary>
        /// 删除/恢复/移除工具菜单项
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="delType"></param>
        private void DeleteUser(UserModel user, int delType)
        {
            string delTypeName = "删除";
            switch (delType)
            {
                case 1: delTypeName = "删除"; break;
                case 0: delTypeName = "恢复"; break;
                case 2: delTypeName = "移除"; break;
            }
            string msgTitle = $"{delTypeName}用户";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该用户信息吗？{delTypeName}用户会连同用户及其用户角色关系数据一并{delTypeName}？") == DialogResult.Yes)
            {
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1: bl = userBLL.LogicDeleteUser(user.UserId); break;
                    case 0: bl = userBLL.RecoverUser(user.UserId); break;
                    case 2: bl = userBLL.RemoveUser(user.UserId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"用户：{user.UserName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, msg);
                    gcUserList.ReLoadData();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, msg);
                    return;
                }
            }
        }
    }
}