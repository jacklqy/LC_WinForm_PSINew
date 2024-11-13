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
using PSINew.Models.DModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using Common;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.BM
{
    public partial class FrmUnitTypeList : DevExpress.XtraEditors.XtraForm
    {
        public FrmUnitTypeList()
        {
            InitializeComponent();
        }
        string uName = "";
        UnitTypeBLL utBLL = new UnitTypeBLL();
        string oldName = "";//修改前的类别名称
        public event Action ReloadTVUnitTypes;//刷新单位类别TreeList
        private UTypeListViewModel fVModel = null;
        private UTypeModel curType = null;
        int isLoad = 0;
        private string msgTitle = "往来单位类别管理";
        private void FrmUnitTypeList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                gbInfo.Visible = false;
                fVModel = new UTypeListViewModel();
                fVModel.IsShowDel = false;
                LoadUTypeList();
                SetDgvCols();
                InitCboParents();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "商品类别列表加载异常！");
        }

        private void LoadUTypeList()
        {
            chkShowDel.DataBindings.Add("Checked", fVModel, "IsShowDel", false, DataSourceUpdateMode.OnPropertyChanged);
            txtKeywords.DataBindings.Add("Text", fVModel, "KeyWords");
            gvUnitTypeList.OptionsBehavior.AutoPopulateColumns = false;
            gcUnitTypeList.DataBindings.Add("DataSource", fVModel, "UTypeList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvUnitTypeList.ShowOrHideNormalCols(fVModel.IsShowDel);
            gvUnitTypeList.ShowOrHideCol("colAddChild", !fVModel.IsShowDel);
        }

        private void InitCboParents()
        {
            List<UnitTypeInfoModel> types = utBLL.LoadAllDrpUnitTypes();
            foreach (UnitTypeInfoModel type in types)
            {
                ComboBoxItem item = new ComboBoxItem(type.UTypeName, type.UTypeId);
                cboParents.Properties.Items.Add(item);
            }
            cboParents.Properties.Items.Insert(0, new ComboBoxItem("请选择", 0));
            cboParents.SelectedIndex = 0;
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
            gvUnitTypeList.RowCellClick += GvUnitTypeList_RowCellClick;
            txtTypeName.TextChanged += TxtTypeName_TextChanged;
            btnFind.Click += BtnFind_Click;
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            curType = new UTypeModel();
            gbInfo.Visible = true;
            InitUTypeInfo(1);
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            if (gvUnitTypeList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvUnitTypeList.GetFocusedDataSourceRowIndex();
                UTypeModel type = fVModel.UTypeList[index] as UTypeModel;
                curType = type;
                InitUTypeInfo(2);
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要修改的类别信息！");
                return;
            }
        }

        private void InitUTypeInfo(int isAdd)
        {
            txtTypeName.DataBindings.Clear();
            txtPYNo.DataBindings.Clear();
            spinOrder.DataBindings.Clear();
            txtTypeNo.DataBindings.Clear();
            cboParents.DataBindings.Clear();
            txtTypeName.DataBindings.Add("Text", curType, "UTypeName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTypeNo.DataBindings.Add("Text", curType, "UTypeNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPYNo.DataBindings.Add("Text", curType, "UTPYNo", false, DataSourceUpdateMode.OnPropertyChanged);
            spinOrder.DataBindings.Add("Value", curType, "UTOrder", false, DataSourceUpdateMode.OnPropertyChanged);
            cboParents.SetCboValue(curType.ParentId == null ? 0 : curType.ParentId.Value);
            string btnText = isAdd == 1 ? "添加" : "修改";
            btnAdd.Text = btnText;
            if (curType.UTypeId > 0)
                oldName = curType.UTypeName;
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string errTitle = "删除往来单位类别";
            if (gvUnitTypeList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(errTitle, "请选择要删除的往来单位类别！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(errTitle, "您确定要删除选择的往来单位类别信息吗？") == DialogResult.Yes)
            {
                List<int> gIds = new List<int>();
                string hasChildsNames = "";
                string hasAddUnitsNames = "";
                foreach (int index in gvUnitTypeList.GetSelectedRows())
                {
                    UTypeModel type = fVModel.UTypeList[index];
                    //如果该类别添加了商品，不允许删除
                    bool hasAddUnits= utBLL.IsAddUnits(type.UTypeId);
                    //如果该类别添加了子类别，不允许删除
                    bool hasChilds = utBLL.IsAddChilds(type.UTypeId);
                    if (!hasAddUnits && !hasChilds)
                    {
                        gIds.Add(type.UTypeId);
                    }
                    else if (hasAddUnits)
                    {
                        if (hasAddUnitsNames.Length > 0) hasAddUnitsNames += ",";
                        hasAddUnitsNames += type.UTypeName;
                    }
                    else if (hasChilds)
                    {
                        if (hasChildsNames.Length > 0) hasChildsNames += ",";
                        hasChildsNames += type.UTypeName;
                    }
                }
                if (gIds.Count > 0)
                {
                    bool bl =utBLL.LogicDeleteList(gIds);//执行批量删除
                    string sucMsg = bl ? "成功" : "失败";
                    string msg = $"选择的往来单位类别信息中符合删除要求的信息 删除 {sucMsg}!";
                    if (bl)
                    {
                        if (!string.IsNullOrEmpty(hasChildsNames))
                            msg += $" {hasChildsNames} 已经添加了子类别，不能删除！";
                        if (!string.IsNullOrEmpty(hasAddUnitsNames))
                            msg += $" {hasAddUnitsNames} 已经添加了单位，不能删除！";
                        MsgBoxHelper.MsgBoxShow(errTitle, msg);
                        FindUTypeList();
                        ReloadCboParents(gIds);
                    }
                    else
                        MsgBoxHelper.MsgErrorShow(errTitle, msg);
                }
                else
                    MsgBoxHelper.MsgErrorShow(errTitle, "没有符合删除要求的往来单位类别信息！");
            }
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            FindUTypeList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.ReloadTVUnitTypes?.Invoke();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //信息获取
                int parentId = cboParents.GetCboValue();
                string parentName = parentId == 0 ? null : cboParents.EditValue.ToString();
                curType.ParentId = parentId;
                curType.ParentName = parentName;
                //判空处理
                if (string.IsNullOrEmpty(curType.UTypeName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "请输入往来类别名称！");
                    txtTypeName.Focus();
                    return;
                }
                //判断已存在
                if (curType.UTypeId == 0 || (!string.IsNullOrEmpty(oldName) && oldName != curType.UTypeName))
                {
                    if (utBLL.ExistsUnitType(curType.UTypeName))
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle, "该类别名称已存在！");
                        txtTypeName.Focus();
                        return;
                    }
                }

                //信息封装
                UnitTypeInfoModel utInfo = new UnitTypeInfoModel()
                {
                    UTypeId = curType.UTypeId,
                    UTypeName = curType.UTypeName,
                    UTypeNo = curType.UTypeNo,
                    UTPYNo = curType.UTPYNo,
                    UTOrder = curType.UTOrder,
                    ParentId = parentId,
                    ParentName = parentName,
                    Creator = uName
                };
                string actType = curType.UTypeId == 0 ? "添加" : "修改";
                //方法执行
                bool bl = false;
                int uTypeIdNew = 0;
                if (curType.UTypeId == 0)
                {
                    uTypeIdNew = utBLL.AddUnitType(utInfo);
                    if (uTypeIdNew > 0)
                    {
                        bl = true;
                        curType.UTypeId = uTypeIdNew;
                    }
                }
                else
                {
                    bl = utBLL.UpdateUnitType(utInfo, oldName);
                }
             
                string sucType = bl ? "成功" : "失败";
                string actMsg = $"商品类别信息:{curType.UTypeName} {actType} {sucType}";

                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, actMsg);
                    FindUTypeList();
                    ReloadCboParents(curType, false, 0);//刷新下拉框
                    oldName = curType.UTypeName;
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, actMsg);
                    return;
                }
            };
            act.TryCatch(msgTitle, "保存类别信息异常！");
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindUTypeList();
        }

        private void GvUnitTypeList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            UTypeModel type = fVModel.UTypeList[index];
            switch (col.Name)
            {
                case "colAddChild":
                    gbInfo.Visible = true;
                    curType = new UTypeModel();
                    curType.ParentId = type.UTypeId;
                    cboParents.Enabled = false;
                    InitUTypeInfo(1);
                    break;
                case "colEdit":
                    gbInfo.Visible = true;
                    curType = type;
                    InitUTypeInfo(2);
                    oldName = curType.UTypeName;
                    cboParents.Enabled = true;
                    break;
                case "colDelete":
                    DeleteUType(type, 1);
                    break;
                case "colRecover":
                    DeleteUType(type, 0);
                    break;
                case "colRemove":
                    DeleteUType(type, 2);
                    break;
                default: break;
            }
        }

        private void TxtTypeName_TextChanged(object sender, EventArgs e)
        {
            curType.UTPYNo = PingYinHelper.GetFirstSpell(curType.UTypeName);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindUTypeList();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void FindUTypeList()
        {
            fVModel.GetUTypeList();
            SetDgvCols();
            if (isLoad == 1)
                gcUnitTypeList.ReLoadData();
        }

        /// <summary>
        /// 移除下拉框中已删除的项
        /// </summary>
        /// <param name="typeIds"></param>
        private void ReloadCboParents(List<int> typeIds)
        {
            List<ComboBoxItem> delList = new List<ComboBoxItem>();
            foreach (ComboBoxItem item in cboParents.Properties.Items)
            {
                if (typeIds.Contains(item.Value))
                    delList.Add(item);
            }
            delList.ForEach(i => cboParents.Properties.Items.Remove(i));
        }

        private void DeleteUType(UTypeModel ut, int isDeleted)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(isDeleted);
            string errTitle = $"往来单位类别{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该单位类别？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (isDeleted)
                {
                    case 1://删除
                           //如果该类别添加了商品，不允许删除
                        bool hasAddUnits = utBLL.IsAddUnits(ut.UTypeId);
                        //如果该类别添加了子类别，不允许删除
                        bool hasChilds = utBLL.IsAddChilds(ut.UTypeId);
                        if (!hasAddUnits && !hasChilds)
                        {
                            bl = utBLL.LogicDelete(ut.UTypeId);
                        }
                        else if (hasAddUnits)
                        {
                            MsgBoxHelper.MsgErrorShow(errTitle, $"该类别:{ut.UTypeName} 已经添加了单位，不能删除！");
                            return;
                        }
                        else if (hasChilds)
                        {
                            MsgBoxHelper.MsgErrorShow(errTitle, $"该类别:{ut.UTypeName} 已经添加了子类别，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = utBLL.Recover(ut.UTypeId);
                        break;
                    case 2://移除
                        bl = utBLL.Delete(ut.UTypeId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"单位类别:{ut.UTypeName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(errTitle, delMsg);
                    FindUTypeList();
                    if (isDeleted != 2)
                    {
                        ReloadCboParents(ut, true, isDeleted);
                    }
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(errTitle, delMsg);
                    return;
                }
            }
        }
        /// <summary>
        /// 刷新下拉框
        /// </summary>
        /// <param name="gt"></param>
        private void ReloadCboParents(UTypeModel ut, bool isDel, int isDeleted)
        {

            if (!isDel)
            {
                if (curType.UTypeId > 0 && oldName != ut.UTypeName)//修改提交时，类别名称信息发生改变
                {
                    foreach (ComboBoxItem item in cboParents.Properties.Items)
                    {
                        if (item.Value == ut.UTypeId)
                        {
                            item.Text = ut.UTypeName;
                            break;
                        }
                    }
                }
                else if (curType.UTypeId == 0) //新增或添加子类别
                {
                    cboParents.Properties.Items.Add(new ComboBoxItem(ut.UTypeName, ut.UTypeId));
                }
            }
            else
            {
                if (isDeleted == 1)
                    cboParents.Properties.Items.Remove(new ComboBoxItem(ut.UTypeName, ut.UTypeId));
                else
                    cboParents.Properties.Items.Add(new ComboBoxItem(ut.UTypeName, ut.UTypeId));
            }
            cboParents.SetCboValue(ut.ParentId == null ? 0 : ut.ParentId.Value);
        }
    }
}