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
using DevExpress.XtraGrid.Columns;
using PSINew.Models.DModels;

namespace DXPSIApp.SM
{
    public partial class FrmToolGroup : DevExpress.XtraEditors.XtraForm
    {
        public FrmToolGroup()
        {
            InitializeComponent();
        }
        string uName = "";
        ToolGroupBLL tgBLL = new ToolGroupBLL();
        ToolMenuBLL tmBLL = new ToolMenuBLL();
        string oldName = "";

        private ToolGroupViewModel fVModel = null;
        private ToolGroupModel curGroup = null;
        int isLoad = 0;
        private string msgTitle = "工具组管理";
        private void FrmToolGroup_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                panelInfo.Visible = false;
                fVModel = new ToolGroupViewModel();
                fVModel.IsShowDel = false;
                LoadToolGroups();
                SetDgvCols();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "工具组列表加载异常！");
        }

        private void RegisterEvents()
        {
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.CloseClick += ListTool1_CloseClick;
            btnAdd.Click += BtnAdd_Click;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            gvGroups.RowCellClick += GvGroups_RowCellClick;
        }
        #region 工具栏响应
        private void ListTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ListTool1_RefreshClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindToolGroups();
        }

        private void ListTool1_DeleteClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvGroups.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow("删除工具组", "请选择要删除的工具组！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm("删除工具菜单", "您确定要删除选择的工具菜单信息吗？") == DialogResult.Yes)
            {
                List<int> gIds = new List<int>();
                foreach (int index in gvGroups.GetSelectedRows())
                {
                    ToolGroupModel group = fVModel.TGroupList[index];
                    gIds.Add(group.TGroupId);
                }
                if (!tmBLL.HasToolMenus(gIds))
                {
                    bool bl = tgBLL.LogicDeleteToolGroups(gIds);
                    if (bl)
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "这些工具组删除成功！");
                        gcToolGroups.ReLoadData();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle, "这些工具组删除失败！");
                        return;
                    }
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, $"选择的工具组中有的已添加工具菜单项，不能删除！");
                    return;
                }
            }
        }

        private void ListTool1_EditClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvGroups.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvGroups.GetFocusedDataSourceRowIndex();
                ToolGroupModel group = fVModel.TGroupList[index] as ToolGroupModel;
                curGroup = group;
                txtGroupName.DataBindings.Clear();
                txtGroupName.DataBindings.Add("Text", curGroup, "TGroupName");
                btnAdd.Text = "修改";
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要修改的组名！");
                return;
            }
        }

        private void ListTool1_AddClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            curGroup = new ToolGroupModel();
            panelInfo.Visible = true;
            InitGroupInfo(1);
        }

        /// <summary>
        /// 加载组名信息框
        /// </summary>
        /// <param name="g"></param>
        /// <param name="isAdd"></param>
        private void InitGroupInfo(int isAdd)
        {
            txtGroupName.DataBindings.Clear();
            txtGroupName.DataBindings.Add("Text", curGroup, "TGroupName");
            string btnText = isAdd == 1 ? "添加" : "修改";
            btnAdd.Text = btnText;
        }
        #endregion

        private void GvGroups_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            ToolGroupModel group = fVModel.TGroupList[index];
            switch (col.Name)
            {
                case "colEdit":
                    panelInfo.Visible = true;
                    curGroup = group;
                    InitGroupInfo(2);
                    oldName = curGroup.TGroupName;
                    break;
                case "colDelete":
                    DeleteTGroupInfo(group, 1);
                    break;
                case "colRecover":
                    DeleteTGroupInfo(group, 0);
                    break;
                case "colRemove":
                    DeleteTGroupInfo(group, 2);
                    break;
                default: break;
            }
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindToolGroups();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string actMsg = "";
            actMsg = curGroup.TGroupId == 0 ? "添加" : "修改";
            string title = $"{actMsg}工具组";
            if (string.IsNullOrEmpty(curGroup.TGroupName))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入组名！");
                txtGroupName.Focus();
                return;
            }
            if (curGroup.TGroupId == 0 || (curGroup.TGroupId > 0 && oldName != curGroup.TGroupName))
            {
                if (tgBLL.ExistName(curGroup.TGroupName))
                {
                    MsgBoxHelper.MsgErrorShow(title, "该组名已存在，请重新输入组名！");
                    txtGroupName.Focus();
                    return;
                }
            }
            curGroup.Creator = uName;
            bool bl = false;
            bl = tgBLL.ConfirmToolGroup(curGroup.ToolGroupInfo);
      
         
            string sucMsg = bl ? "成功" : "失败";
            string msg = $"工具组：{curGroup.TGroupName} {actMsg} {sucMsg}！";
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow(msgTitle, msg);
                gcToolGroups.ReLoadData();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow("",msg);
                return;
            }
        }
    


        private void LoadToolGroups()
        {
            chkShowDel.DataBindings.Add("Checked", fVModel, "IsShowDel");
            gvGroups.OptionsBehavior.AutoPopulateColumns = false;
            gcToolGroups.DataBindings.Add("DataSource", fVModel, "TGroupList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvGroups.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void FindToolGroups()
        {
            fVModel.GetGroupList();
            SetDgvCols();
            if (isLoad == 1)
                gcToolGroups.ReLoadData();
        }

        /// <summary>
        /// 删除/恢复/移除
        /// </summary>
        /// <param name="group"></param>
        /// <param name="delType"></param>
        private void DeleteTGroupInfo(ToolGroupModel group,int delType)
        {
          
            string delTypeName = "删除";
            switch (delType)
            {
                case 1: delTypeName = "删除"; break;
                case 0: delTypeName = "恢复"; break;
                case 2: delTypeName = "移除"; break;
            }
            string title = $"{delTypeName}工具组";
            if (MsgBoxHelper.MsgBoxConfirm(title, $"您确定要{delTypeName}该工具组数据吗？") == DialogResult.Yes)
            {
                //先检查是否已添加工具菜单数据
                List<int> gIds = new List<int>();
                gIds.Add(group.TGroupId);
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1:
                        if (!tmBLL.HasToolMenus(gIds))
                        {
                            bl = tgBLL.LogicDeleteToolGroup(group.TGroupId);
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(title, $"工具组：{group.TGroupName} 已添加工具菜单项，不能删除！");
                            return;
                        }
                        break;
                    case 0: bl = tgBLL.RecoverToolGroup(group.TGroupId); break;
                    case 2: bl = tgBLL.DeleteToolGroup(group.TGroupId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"工具菜单：{group.TGroupName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(title, $"工具组：{group.TGroupName} {delTypeName} 成功！");
                    gcToolGroups.ReLoadData();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(title, $"工具组：{group.TGroupName} {delTypeName} 失败！");
                    return;
                }
            }
        }
    }
}