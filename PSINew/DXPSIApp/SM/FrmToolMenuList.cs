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
using DevExpress.XtraBars;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.SM
{
    public partial class FrmToolMenuList : DevExpress.XtraEditors.XtraForm
    {
        public FrmToolMenuList()
        {
            InitializeComponent();
        }
        private string uName = "";
        private ToolMenuBLL tmBLL = new ToolMenuBLL();
        private ToolMenuListViewModel fVModel = null;
        int isLoad = 0;
        string msgTitle = "工具菜单管理";
        private void FrmToolMenuList_Load(object sender, EventArgs e)
        {
            Action act = () => {
                fVModel = new ToolMenuListViewModel();
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                fVModel.IsShowDel = false;
                RegisterEvents();//注册事件
                BindData();//绑定页面信息
                SetDgvCols();
            };
            act.TryCatch(msgTitle,"工具菜单列表加载异常");
        }

        private void RegisterEvents()
        {
            listTool1.TypeClick += ListTool1_TypeClick;
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.InfoClick += ListTool1_InfoClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.CloseClick += ListTool1_CloseClick;
            btnFind.Click += BtnFind_Click;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            gvTMenus.RowCellClick += GvTMenus_RowCellClick;
        }

        #region 工具栏按钮响应
        private void ListTool1_TypeClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmToolGroup fToolGroup = new FrmToolGroup();
            fToolGroup.Tag = uName;
            fToolGroup.ShowDialog();
        }
        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            ShowTMenuInfoPage(0, 1);
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        private void ListTool1_InfoClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            if (gvTMenus.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow("删除工具菜单", "请选择要删除的工具菜单信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm("删除工具菜单", "您确定要删除选择的工具菜单信息吗？删除工具菜单会连同工具菜单及其角色工具菜单关系数据一并删除？") == DialogResult.Yes)
            {
                List<int> menuIds = new List<int>();
                foreach (int index in gvTMenus.GetSelectedRows())
                {
                    ToolMenuModel menuInfo = fVModel.ToolMenuList[index];
                    menuIds.Add(menuInfo.TMenuId);
                }
                bool bl = tmBLL.DeleteToolMenusLogic(menuIds);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow("删除工具菜单", "选择的工具菜单信息删除成功！");
                    gcTMenuList.ReLoadData();

                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("删除工具菜单", "选择的工具菜单信息删除失败！");
                    return;
                }
            }
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            FindToolMenuList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }
        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindToolMenuList();
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindToolMenuList();
        }

        private void GvTMenus_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            ToolMenuModel menuInfo = fVModel.ToolMenuList[index];
            switch (col.Name)
            {
                case "colEdit":
                    ShowTMenuInfoPage(menuInfo.TMenuId,2);
                    break;
                case "colDelete":
                    DeleteToolMenu(menuInfo, 1);
                    break;
                case "colRecover":
                    DeleteToolMenu(menuInfo, 0);
                    break;
                case "colRemove":
                    DeleteToolMenu(menuInfo, 2);
                    break;
                default: break;
            }
        }


        private void BindData()
        {
            txtKeyWords.DataBind(fVModel, "KeyWords", true);
            chkShowDel.DataBind(fVModel, "Checked", "IsShowDel", true);
            gvTMenus.OptionsBehavior.AutoPopulateColumns = false;
            gcTMenuList.DataBindings.Add("DataSource", fVModel, "ToolMenuList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvTMenus.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        /// <summary>
        /// 查询工具菜单列表
        /// </summary>
        private void FindToolMenuList()
        {
            fVModel.GetToolMenuList();
            SetDgvCols();
            if (isLoad == 1)
                gcTMenuList.ReLoadData();
        }

        /// <summary>
        /// 显示工具菜单信息页面  新增  修改 详情
        /// </summary>
        /// <param name="tmenuId"></param>
        /// <param name="actType"></param>
        private void ShowTMenuInfoPage(int tmenuId, int actType)
        {
            FrmTMenuInfo fTMenuInfo = new FrmTMenuInfo();
            fTMenuInfo.Tag = new FInfoData()
            {
                FId = tmenuId,
                ActType = actType,
                UName = uName
            };
            if (actType < 4)
                fTMenuInfo.ReLoad += () => FindToolMenuList();
            fTMenuInfo.ShowDialogNew();
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvTMenus.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvTMenus.GetFocusedDataSourceRowIndex();
                ToolMenuModel menuInfo = fVModel.ToolMenuList[index] as ToolMenuModel;
                ShowTMenuInfoPage(actType, menuInfo.TMenuId);
            }
            else
            {
                string title = "查看工具菜单", errMsg = "请选择你要查看的工具菜单信息";
                if (actType == 2)
                {
                    title = "修改工具菜单";
                    errMsg = "请选择你要修改的工具菜单信息";
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
        private void DeleteToolMenu(ToolMenuModel menu, int delType)
        {
            string delTypeName = "删除";
            switch (delType)
            {
                case 1: delTypeName = "删除"; break;
                case 0: delTypeName = "恢复"; break;
                case 2: delTypeName = "移除"; break;
            }
            string msgTitle = $"{delTypeName}工具菜单";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该工具菜单信息吗？{delTypeName}工具菜单会连同工具菜单及其角色工具菜单关系数据一并{delTypeName}？") == DialogResult.Yes)
            {
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1: bl = tmBLL.DeleteToolMenuLogic(menu.TMenuId); break;
                    case 0: bl = tmBLL.RecoverToolMenu(menu.TMenuId); break;
                    case 2: bl = tmBLL.DeleteToolMenu(menu.TMenuId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"工具菜单：{menu.TMName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, msg);
                    gcTMenuList.ReLoadData();
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