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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using PSINew.Models.DModels;
using Common;

namespace DXPSIApp.BM
{
    public partial class FrmGUnitList : DevExpress.XtraEditors.XtraForm
    {
        public FrmGUnitList()
        {
            InitializeComponent();
        }
        string uName = "";
        GoodsUnitBLL guBLL = new GoodsUnitBLL();
        string oldName = "";//修改前的单位名称
        public event Action GUnitsReLoad;//刷新单位下拉框
        private GUnitViewModel fVModel = null;
        private GUnitModel curUnit = null;
        int isLoad = 0;
        private string msgTitle = "计量单位管理";
        private void FrmGUnitList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                gbInfo.Visible = false;
                fVModel = new GUnitViewModel();
                fVModel.IsShowDel = false;
                LoadGUnitList();
                SetDgvCols();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "计量单位列表加载异常！");
        }

        private void LoadGUnitList()
        {
            chkShowDel.DataBind(fVModel,"Checked",  "IsShowDel",true);
            gvGUnits.OptionsBehavior.AutoPopulateColumns = false;
            gcGUnitList.DataBind( fVModel,"DataSource", "GUnitList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvGUnits.ShowOrHideNormalCols(fVModel.IsShowDel);
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
            gvGUnits.RowCellClick += GvGUnits_RowCellClick;
            txtGUnitName.TextChanged += TxtGUnitName_TextChanged;
            
        }

       

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            curUnit = new GUnitModel();
            gbInfo.Visible = true;
            InitGUnitInfo(1);
        }

        private void InitGUnitInfo(int isAdd)
        {
            txtGUnitName.DataBind(curUnit, "GUnitName",true);
            txtPYNo.DataBind(curUnit, "GUnitPYNo", true);
            spinOrder.DataBind(curUnit, "Value", "GUnitOrder",true);
            string btnText = isAdd == 1 ? "添加" : "修改";
            btnAdd.Text = btnText;
            if (curUnit.GUnitId > 0)
                oldName = curUnit.GUnitName;
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            if (gvGUnits.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvGUnits.GetFocusedDataSourceRowIndex();
                GUnitModel unit = fVModel.GUnitList[index] as GUnitModel;
                curUnit = unit;
                InitGUnitInfo(2);
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要修改的单位信息！");
                return;
            }
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string errTitle = "删除计量单位";
            if (gvGUnits.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(errTitle, "请选择要删除的计量单位！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(errTitle, "您确定要删除选择的计量单位信息吗？") == DialogResult.Yes)
            {
                List<int> gIds = new List<int>();
                foreach (int index in gvGUnits.GetSelectedRows())
                {
                    GUnitModel unit = fVModel.GUnitList[index];
                    if (guBLL.GetGoodsUnitUse(unit.GUnitName))
                    {
                        MsgBoxHelper.MsgErrorShow(errTitle, $"计量单位：{unit.GUnitName} 已经应用，不能删除！");
                        return;
                    }
                    gIds.Add(unit.GUnitId);
                }
                bool bl = guBLL.LogicDeleteList(gIds);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(errTitle, "这些计量单位删除成功！");
                    gcGUnitList.ReLoadData();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(errTitle, "这些计量单位删除失败！");
                    return;
                }
            }
        }
        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.IsShowDel = false;
            FindGUnitList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.GUnitsReLoad?.Invoke();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //判空处理
            if (string.IsNullOrEmpty(curUnit.GUnitName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,"单位名称不能为空！");
                txtGUnitName.Focus();
                return;
            }
            if (curUnit.GUnitId == 0 || (!string.IsNullOrEmpty(oldName) && curUnit.GUnitName != oldName))
            {
                if (guBLL.ExistName(curUnit.GUnitName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"单位名称已存在，请重新输入！");
                    txtGUnitName.Focus();
                    return;
                }
            }
            //封装信息
            GoodsUnitInfoModel guInfo = new GoodsUnitInfoModel()
            {
                GUnitId = curUnit.GUnitId,
                GUnitName = curUnit.GUnitName,
                GUnitPYNo = curUnit.GUnitPYNo,
                GUnitOrder = curUnit.GUnitOrder,
                Creator = uName
            };
            //提交执行
            bool bl = false;
            if (curUnit.GUnitId == 0)
            {
                bl = guBLL.AddGoodsUnit(guInfo);
            }
            else
            {
                bool blUpdateName = oldName == curUnit.GUnitName ? false : true;
                bl = guBLL.UpdatGoodsUnit(guInfo, blUpdateName, oldName);
            }
            //处理结果
            string actMsg = curUnit.GUnitId == 0 ? "添加" : "修改";
            string sucMsg = bl ? "成功" : "失败";
            string title = $"{actMsg}计量单位";
            string msg = $"计量单位：{curUnit.GUnitName} {actMsg}{sucMsg}";
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow(title, msg);
                FindGUnitList();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,msg);
                return;
            }
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindGUnitList();
        }

        private void GvGUnits_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            GUnitModel unit = fVModel.GUnitList[index];
            switch (col.Name)
            {
                case "colEdit":
                    gbInfo.Visible = true;
                    curUnit = unit;
                    InitGUnitInfo(2);
                    oldName = curUnit.GUnitName;
                    break;
                case "colDelete":
                    DeleteGUnit(unit, 1);
                    break;
                case "colRecover":
                    DeleteGUnit(unit, 0);
                    break;
                case "colRemove":
                    DeleteGUnit(unit, 2);
                    break;
                default: break;
            }
        }

        private void DeleteGUnit(GUnitModel unit, int delType)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(delType);
            string title = $"{delTypeName}计量单位";
            if (MsgBoxHelper.MsgBoxConfirm(title, $"您确定要{delTypeName}该计量单位数据吗？") == DialogResult.Yes)
            {
                List<int> gIds = new List<int>();
                gIds.Add(unit.GUnitId);
                //删除
                bool bl = false;
                switch (delType)
                {
                    case 1:
                        if (!guBLL.GetGoodsUnitUse(unit.GUnitName))
                            bl = guBLL.LogicDelete(unit.GUnitId);
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(title,$"计量单位：{unit.GUnitName} 已经应用，不能删除！");
                            return;
                        }
                        break;
                    case 0: bl = guBLL.Recover(unit.GUnitId); break;
                    case 2: bl = guBLL.Delete(unit.GUnitId); break;
                }
                string sucText = bl ? "成功" : "失败";
                string msg = $"计量单位：{unit.GUnitName} {delTypeName}{sucText}！";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(title, $"计量单位：{unit.GUnitName} {delTypeName} 成功！");
                    gcGUnitList.ReLoadData();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(title, $"计量单位：{unit.GUnitName} {delTypeName} 失败！");
                    return;
                }
            }
        }


        /// <summary>
        /// 刷新列表
        /// </summary>
        private void FindGUnitList()
        {
            fVModel.GetGUnitList();
            SetDgvCols();
            if (isLoad == 1)
                gcGUnitList.ReLoadData();
        }

        private void TxtGUnitName_TextChanged(object sender, EventArgs e)
        {
            curUnit.GUnitPYNo= PingYinHelper.GetFirstSpell(curUnit.GUnitName);
        }
    }
}