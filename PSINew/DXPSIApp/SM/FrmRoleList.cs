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
using PSINew.UModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.SM
{
    public partial class FrmRoleList : DevExpress.XtraEditors.XtraForm
    {
        public FrmRoleList()
        {
            InitializeComponent();
        }
        private RoleBLL roleBLL = new RoleBLL();
        string uName = "";//操作者账号
        RoleListViewModel fVModel = null;//页面数据源对象
        int isLoad = 0;
        private void FrmRoleList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new RoleListViewModel();
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                RegisterBtnsEvents();//注册事件
                LoadRoleList();//加载所有角色信息
                SetDgvCols();
            };
            act.TryCatch("角色管理", "角色管理页面加载异常！");
        }

        /// <summary>
        /// 初始化加载所有角色信息
        /// </summary>
        private void LoadRoleList()
        {
            chkShowDel.DataBind( fVModel, "Checked","IsShowDel",true);
            gvRoles.OptionsBehavior.AutoPopulateColumns = false;
            gcRoleList.DataBindings.Add("DataSource", fVModel, "RoleList");
            isLoad = 1;
        }

        private void RegisterBtnsEvents()
        {
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRight.Click += BtnRight_Click;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            gvRoles.RowCellClick += GvRoles_RowCellClick;
        }

        private void SetDgvCols()
        {
            gvRoles.ShowOrHideNormalCols(fVModel.IsShowDel);
            gvRoles.ShowOrHideCol("colRight", !fVModel.IsShowDel);
        }

        private void GvRoles_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            RoleModel roleInfo = fVModel.RoleList[index];
            switch (col.Name)
            {
                case "colRight":
                    ShowRightPage(roleInfo.RoleId);
                    break;
                case "colEdit":
                    ShowRoleInfoPage(2, roleInfo.RoleId);
                    break;
                case "colDelete":
                    DeleteRole(roleInfo, 1);
                    break;
                case "colRecover":
                    DeleteRole(roleInfo, 0);
                    break;
                case "colRemove":
                    DeleteRole(roleInfo, 2);
                    break;
                default: break;
            }
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            if (isLoad == 1)
            {
                FindRoleList();
            }
              
        }

        private void FindRoleList()
        {
            fVModel.GetRoleList();
            SetDgvCols();
            gcRoleList.ReLoadData();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            ShowRightPage(0);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string msgTitle = "删除角色";
            if (gvRoles.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要删除的角色信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, "您确定要删除选择的角色吗？会连同与角色相关的数据一并删除？") == DialogResult.Yes)
            {
                List<int> roleIds = new List<int>();
                foreach (int index in gvRoles.GetSelectedRows())
                {
                    RoleModel roleInfo = fVModel.RoleList[index];
                    roleIds.Add(roleInfo.RoleId);
                }
                bool bl = roleBLL.LogicDeleteRoles(roleIds);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, "选择的角色信息删除成功！");
                    gcRoleList.ReLoadData();

                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "选择的角色信息删除失败！");
                    return;
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowRoleInfoPage(1, 0);
        }

        /// <summary>
        /// 显示角色新增或修改页面
        /// </summary>
        /// <param name="actType"></param>
        /// <param name="roleId"></param>
        private void ShowRoleInfoPage(int actType, int roleId)
        {
            FrmRoleInfo fRole = new FrmRoleInfo();
            fRole.Tag = new FInfoData()
            {
                ActType = actType,
                FId = roleId,
                UName = uName
            };
            if (actType < 4)
            {
                fRole.Reload += () => FindRoleList();
            }
            fRole.ShowDialogNew();
        }

        /// <summary>
        /// 打开权限分配页面
        /// </summary>
        /// <param name="actType"></param>
        /// <param name="roleId"></param>
        private void ShowRightPage(int roleId)
        {
            FrmRight fRight = new FrmRight();
            fRight.Tag = new FRightData()
            {
                UName = uName,
                RoleId = roleId
            };
            fRight.ShowDialogNew();
        }

        /// <summary>
        /// 删除/恢复/移除角色
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="delType"></param>
        private void DeleteRole(RoleModel role, int delType)
        {
            string delTypeName = "删除";
            switch (delType)
            {
                case 1: delTypeName = "删除"; break;
                case 0: delTypeName = "恢复"; break;
                case 2: delTypeName = "移除"; break;
            }
            string msgTitle = $"{delTypeName}角色";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该角色信息吗？{delTypeName}角色会连同与角色相关的数据一并{delTypeName}？") == DialogResult.Yes)
            {
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1: bl = roleBLL.LogicDeleteRole(role.RoleId); break;
                    case 0: bl = roleBLL.RecoveryRole(role.RoleId); break;
                    case 2: bl = roleBLL.DeleteRole(role.RoleId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"角色：{role.RoleName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, msg);
                    gcRoleList.ReLoadData();
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