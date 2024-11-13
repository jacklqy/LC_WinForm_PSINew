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
using PSINew.Models.DModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.BM
{
    public partial class FrmUnitList : DevExpress.XtraEditors.XtraForm
    {
        public FrmUnitList()
        {
            InitializeComponent();
        }
        private string uName = "";//账号
        UnitBLL unitBLL = new UnitBLL();
        UnitTypeBLL utBLL = new UnitTypeBLL();
        private UnitListViewModel fVModel = null;
        int isLoad = 0;//是否已初始化Dgv
        private void FrmUnitList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    uName = this.Tag.ToString();
                }
                fVModel = new UnitListViewModel();
                RegisterEvents();
                LoadTVUnitTypes();
                fVModel.UTypeId = 0;
                fVModel.UTypeName = "往来单位类别";
                LoadUnitList();//加载所有单位信息
                SetDgvCols();
            };
            act.TryCatch("往来单位管理", "单位信息加载异常！");
        }

     
        private void LoadTVUnitTypes()
        {
            tlUnitTypes.Nodes.Clear();
            tlUnitTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlUnitTypes.DataSource = fVModel.UTypeList;
            tlUnitTypes.KeyFieldName = "UTypeId";
            tlUnitTypes.ParentFieldName = "ParentId";
            tlUnitTypes.SelectNode(tlUnitTypes.Nodes[0]);
            tlUnitTypes.ExpandAll();
        }

        private void RegisterEvents()
        {
            listTool1.CloseClick += ListTool1_CloseClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.InfoClick += ListTool1_InfoClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.TypeClick += ListTool1_TypeClick;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            tlUnitTypes.FocusedNodeChanged += TlUnitTypes_FocusedNodeChanged;
            ucPager1.BindSource += UcPager1_BindSource;
            gvUnitList.RowCellClick += GvUnitList_RowCellClick;
            btnFind.Click += BtnFind_Click;
        }

     

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            ShowUnitInfoPage(1, 0);
        }

        private void ListTool1_TypeClick(object sender, ItemClickEventArgs e)
        {
            FrmUnitTypeList fUnitTypeList = new FrmUnitTypeList();
            fUnitTypeList.Tag = uName;
            fUnitTypeList.ReloadTVUnitTypes += LoadTVUnitTypes;//刷新类别节点树
            fUnitTypeList.ShowDialogNew();
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindUnitList();
        }

        private void TlUnitTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            FindUnitList();
        }

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            FindUnitList();
        }

        private void GvUnitList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            UnitModel info = fVModel.UnitList[index];
            switch (col.Name)
            {
                case "colEdit":
                    ShowUnitInfoPage(2, info.UnitId);
                    break;
                case "colDelete":
                    DeleteUnit(info, 1);
                    break;
                case "colRecover":
                    DeleteUnit(info, 0);
                    break;
                case "colRemove":
                    DeleteUnit(info, 2);
                    break;
                default: break;
            }
        }
        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            fVModel.UTypeId = 0;
            FindUnitList();
        }

        private void ListTool1_InfoClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            if (gvUnitList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow("删除单位", "请选择要删除的单位信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm("删除单位", "您确定要删除选择的单位信息吗？") == DialogResult.Yes)
            {
                List<int> unitIds = new List<int>();
                string IsUseUnitNames = "";
                foreach (int index in gvUnitList.GetSelectedRows())
                {
                    UnitModel uInfo = fVModel.UnitList[index];
                    //如果该类别添加了商品，不允许删除
                    bool isUnitUse = unitBLL.CheckUnitUse(uInfo.UnitId);
                    if (!isUnitUse)
                    {
                        unitIds.Add(uInfo.UnitId);
                    }
                    else
                    {
                        if (IsUseUnitNames.Length > 0) IsUseUnitNames += ",";
                        IsUseUnitNames += uInfo.UnitName;
                    }
                }
                if (unitIds.Count > 0)
                {
                    bool bl = unitBLL.LogicDeleteList(unitIds);//执行批量删除
                    string sucMsg = bl ? "成功" : "失败";
                    string msg = $"选择的单位信息中符合删除要求的信息 删除 {sucMsg}!";

                    if (bl)
                    {
                        if (!string.IsNullOrEmpty(IsUseUnitNames))
                            msg += $"  {IsUseUnitNames} 已经使用，不能删除！";
                        MsgBoxHelper.MsgBoxShow("删除单位", msg);
                        FindUnitList();
                    }
                    else
                        MsgBoxHelper.MsgErrorShow("删除单位",msg);
                }
                else
                    MsgBoxHelper.MsgErrorShow("删除单位","没有符合删除要求的单位信息！");
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindUnitList();
        }

        private void SetDgvCols()
        {
            gvUnitList.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        private void LoadUnitList()
        {
            ClearDataBindings();
            if (fVModel != null)
            {
                txtKeywords.DataBindings.Add("Text", fVModel, "KeyWords", false, DataSourceUpdateMode.OnPropertyChanged);
                chkShowDel.DataBindings.Add("Checked", fVModel, "IsShowDel", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("StartRecord", fVModel, "StartIndex", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("PageSize", fVModel, "PageSize", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("Record", fVModel, "TotalCount", false, DataSourceUpdateMode.OnPropertyChanged);
                tlUnitTypes.SetFocusedValue(fVModel.UTypeName);
                gcUnitList.DataBindings.Add("DataSource", fVModel, "UnitList");
                isLoad = 1;
            }
        }

        private void ClearDataBindings()
        {
            txtKeywords.DataBindings.Clear();
            chkShowDel.DataBindings.Clear();
            tlUnitTypes.DataBindings.Clear();
            gcUnitList.DataBindings.Clear();
            ucPager1.DataBindings.Clear();
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        private void FindUnitList()
        {
            UnitTypeInfoModel selType = tlUnitTypes.GetDataRecordByNode(tlUnitTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            fVModel.GetUnitList();
            SetDgvCols();
            if (isLoad == 1)
            {
                gcUnitList.ReLoadData();
            }

        }

        /// <summary>
        /// 显示单位信息页面（新增、修改、详情）
        /// </summary>
        /// <param name="actType">1  add  2 edit  4 info</param>
        /// <param name="unitId"></param>
        private void ShowUnitInfoPage(int actType, int unitId)
        {
            FrmUnitInfo fUnitInfo = new FrmUnitInfo();
            fUnitInfo.Tag = new FInfoData()
            {
                ActType = actType,
                FId = unitId,
                UName = uName
            };
            if (actType <4)
                fUnitInfo.ReLoadHandler += LoadUnitList;//订阅 
            fUnitInfo.ShowDialogNew();
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvUnitList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvUnitList.GetFocusedDataSourceRowIndex();
                UnitModel unit = fVModel.UnitList[index] as UnitModel;
                ShowUnitInfoPage(actType, unit.UnitId);
            }
            else
            {
                string title = "查看单位", errMsg = "请选择你要查看的单位信息";
                if (actType == 2)
                {
                    title = "修改单位";
                    errMsg = "请选择你要修改的单位信息";
                }
                MsgBoxHelper.MsgErrorShow(title, errMsg);
                return;
            }
        }

        /// <summary>
        /// 删除单位信息（删除、恢复、移除）
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="unitInfo"></param>
        private void DeleteUnit( UnitModel unitInfo, int isDeleted)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(isDeleted);
            string msgTitle = $"单位信息{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该单位信息？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (isDeleted)
                {
                    case 1://删除
                           //如果单位在使用中，不允许删除
                        bool isUnitUse = unitBLL.CheckUnitUse(unitInfo.UnitId);
                        if (!isUnitUse)
                        {
                            bl = unitBLL.LogicDelete(unitInfo.UnitId);
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(msgTitle,$"该单位:{unitInfo.UnitName} 在使用中，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = unitBLL.Recover(unitInfo.UnitId);
                        break;
                    case 2://移除
                        bl = unitBLL.Delete(unitInfo.UnitId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"单位信息:{unitInfo.UnitName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, delMsg);
                    FindUnitList();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,delMsg);
                    return;
                }
            }
        }
    }
}