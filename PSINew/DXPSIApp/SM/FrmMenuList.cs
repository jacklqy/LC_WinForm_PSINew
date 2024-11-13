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
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using PSINew.UModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.SM
{
    public partial class FrmMenuList : DevExpress.XtraEditors.XtraForm
    {
        public FrmMenuList()
        {
            InitializeComponent();
        }
        private MenuBLL menuBLL = new MenuBLL();
        string uName = "";//操作者账号
        MenulListViewModel fVModel = null;
        int isLoad = 0;//是否已初始化Dgv
        private void FrmMenuList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new MenulListViewModel();
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                RegisterToolEvents();//注册工具栏事件
                LoadMenuList();//加载所有菜单信息
                SetDgvCols();
            };
            act.TryCatch("菜单管理","菜单管理页面加载异常！");
        }

        private void RegisterToolEvents()
        {
            listTool1.AddClick += listTool1_AddClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.InfoClick += ListTool1_InfoClick;
            listTool1.DeleteClick += listTool1_DeleteClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.CloseClick += listTool1_CloseClick;
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTool1_AddClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowMenuInfoPage(1, 0);
        }

        private void ListTool1_RefreshClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            FindMenuList();
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListTool1_InfoClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_EditClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvMenuList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvMenuList.GetFocusedDataSourceRowIndex();
                MenuModel menuInfo = fVModel.MenuList[index] as MenuModel;
                ShowMenuInfoPage(actType, menuInfo.MId);
            }
            else
            {
                string title = "查看菜单",errMsg="请选择你要查看的菜单信息";
                if (actType == 2)
                {
                    title = "修改菜单";
                    errMsg = "请选择你要修改的菜单信息";
                }
                MsgBoxHelper.MsgErrorShow(title, errMsg);
                return;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTool1_DeleteClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvMenuList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow("删除菜单", "请选择要删除的菜单信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm("删除菜单", "您确定要删除选择的菜单信息吗？删除菜单会连同菜单及其角色菜单关系数据一并删除？") == DialogResult.Yes)
            {
                List<int> menuIds = new List<int>();
                foreach (int index in gvMenuList.GetSelectedRows())
                {
                    MenuModel menuInfo = fVModel.MenuList[index];
                    menuIds.Add(menuInfo.MId);
                }
                bool bl = menuBLL.LogicDeleteMenu(menuIds);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow("删除菜单", "选择的菜单信息删除成功！");
                    gcMenuList.ReLoadData();

                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("删除菜单", "选择的菜单信息删除失败！");
                    return;
                }
            }
        }


        private void LoadMenuList()
        {
            txtKeyWords.DataBind(fVModel, "KeyWords", true);
            chkShowDel.DataBind(fVModel, "Checked", "IsShowDel", true);
            gvMenuList.OptionsBehavior.AutoPopulateColumns = false;
            gcMenuList.DataBindings.Add("DataSource", fVModel, "MenuList");
            isLoad = 1;
        }



        /// <summary>
        /// 打开菜单信息页面（新增、修改、详情、添加子菜单）
        /// </summary>
        /// <param name="actType"></param>
        /// <param name="menuId"></param>
        private void ShowMenuInfoPage(int actType, int menuId)
        {
            FrmMenuInfo fMenu = new FrmMenuInfo();
            fMenu.Tag = new FInfoData()
            {
                ActType = actType,
                UName = uName,
                FId = menuId
            };
            if (actType < 4)
                fMenu.ReLoad += () => FindMenuList();
            fMenu.ShowDialogNew();

        }
      
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindMenuList();
        }

        private void FindMenuList()
        {
            fVModel.FindMenuListByKeyWords();
            if(isLoad==1)
                gcMenuList.ReLoadData();
            SetDgvCols();
        }

        private void SetDgvCols()
        {
            gvMenuList.ShowOrHideNormalCols(fVModel.IsShowDel);
            gvMenuList.ShowOrHideCol("colAddChild", !fVModel.IsShowDel);
        }

        private void chkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindMenuList();
        }

        private void gvMenuList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            MenuModel menuInfo = fVModel.MenuList[index];
            switch(col.Name)
            {
                case "colAddChild":
                    ShowMenuInfoPage(3, menuInfo.MId);
                    break;
                case "colEdit":
                    ShowMenuInfoPage(2, menuInfo.MId);
                    break;
                case "colDelete":
                    DeleteMenu(menuInfo,1);
                    break;
                case "colRecover":
                    DeleteMenu(menuInfo, 0);
                    break;
                case "colRemove":
                    DeleteMenu(menuInfo, 2);
                    break;
                default:break;
            }
        }

        /// <summary>
        /// 删除/恢复/移除菜单项
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="delType"></param>
        private void DeleteMenu(MenuModel menu,int delType)
        {
            string delTypeName = "删除";
            switch(delType)
            {
                case 1:delTypeName = "删除";break;
                case 0: delTypeName = "恢复"; break;
                case 2: delTypeName = "移除"; break;
            }
            string msgTitle = $"{delTypeName}菜单";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该菜单信息吗？{delTypeName}菜单会连同菜单及其角色菜单关系数据一并{delTypeName}？") == DialogResult.Yes)
            {
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1: bl = menuBLL.LogicDeleteMenu(menu.MId); break;
                    case 0: bl = menuBLL.RecoverMenu(menu.MId); break;
                    case 2: bl = menuBLL.RemoveMenu(menu.MId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"菜单：{menu.MName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, msg);
                    gcMenuList.ReLoadData();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,msg);
                    return;
                }
            }
        }
    }
}