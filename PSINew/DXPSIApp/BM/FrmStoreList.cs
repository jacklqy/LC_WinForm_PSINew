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
using DevExpress.XtraTreeList;
using PSINew.Models.DModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.BM
{
    public partial class FrmStoreList : DevExpress.XtraEditors.XtraForm
    {
        public FrmStoreList()
        {
            InitializeComponent();
        }
        StoreBLL storeBLL = new StoreBLL();
        StoreTypeBLL stBLL = new StoreTypeBLL();
        string uName = "";//账号
        private StoreListViewModel fVModel = null;
        int isLoad = 0;
        private void FrmStoreList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new StoreListViewModel();
                if (this.Tag != null)
                {
                    uName = this.Tag.ToString();
                }
                LoadTVStoreTypes();//加载仓库类别节点树
                fVModel.STypeId = 0;
                LoadStoreList();//加载所有仓库信息
                SetDgvCols();
                RegisterEvents();
            };
            act.TryCatch("仓库管理", "仓库信息加载异常！");
        }

        private void LoadTVStoreTypes()
        {
            tlStoreTypes.LoadTLStoreTypes(fVModel.STypeList);
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
            tlStoreTypes.FocusedNodeChanged += TlStoreTypes_FocusedNodeChanged;
            gvStoreList.RowCellClick += GvStoreList_RowCellClick;
            btnFind.Click += BtnFind_Click;
        }

        private void GvStoreList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            StoreModel sInfo = fVModel.StoreList[index];
            switch (col.Name)
            {
                case "colEdit":
                    ShowStoreInfoPage(2, sInfo.StoreId);
                    break;
                case "colDelete":
                    DeleteStoreInfo(sInfo, 1);
                    break;
                case "colRecover":
                    DeleteStoreInfo(sInfo, 0);
                    break;
                case "colRemove":
                    DeleteStoreInfo(sInfo, 2);
                    break;
                default: break;
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindStoreList();
        }

        private void TlStoreTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindStoreList();
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindStoreList();
        }

        private void ListTool1_TypeClick(object sender, ItemClickEventArgs e)
        {
            FrmStoreTypeList fStoreTypeList = new FrmStoreTypeList();
            fStoreTypeList.Tag = uName;
            fStoreTypeList.TVStoreTypeReload +=LoadTVStoreTypes;//刷新类别节点树
            fStoreTypeList.ShowDialogNew();
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            ShowStoreInfoPage(1, 0);
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string title = "删除仓库信息";
            Action act = () =>
            {
                if (gvStoreList.SelectedRowsCount == 0)
                {
                    MsgBoxHelper.MsgErrorShow(title,"请选择要删除的仓库信息");
                    return;
                }
             
                if (MsgBoxHelper.MsgBoxConfirm(title, "您确定要删除选择的这些仓库信息吗？") == DialogResult.Yes)
                {
                    List<int> storeIds = new List<int>();
                    string IsUseStoreNames = "";
                    foreach (int index in gvStoreList.GetSelectedRows())
                    {
                        StoreModel sInfo = fVModel.StoreList[index];
                        //如果该类别添加了仓库，不允许删除
                        bool isStoreUsee = storeBLL.CheckStoreUse(sInfo.StoreId);
                        if (!isStoreUsee)
                        {
                            storeIds.Add(sInfo.StoreId);
                        }
                        else
                        {
                            if (IsUseStoreNames.Length > 0) IsUseStoreNames += ",";
                            IsUseStoreNames += sInfo.StoreName;
                        }
                    }
                    if (storeIds.Count > 0)
                    {
                        bool bl = storeBLL.DeleteStoreInfos(storeIds);//执行批量删除
                        string sucMsg = bl ? "成功" : "失败";
                        string msg = $"选择的仓库信息中符合删除要求的信息 删除 {sucMsg}!";
                        if (bl)
                        {
                            if (!string.IsNullOrEmpty(IsUseStoreNames))
                                msg += $" {IsUseStoreNames} 已经使用，不能删除！";
                            MsgBoxHelper.MsgBoxShow(title, msg);
                            LoadStoreList();
                        }
                        else
                            MsgBoxHelper.MsgErrorShow(title,msg);
                    }
                    else
                        MsgBoxHelper.MsgErrorShow(title,"没有符合删除要求的仓库信息！");
                }
            };
            act.TryCatch(title,"批量删除仓库信息异常！");
        }

        private void ListTool1_InfoClick(object sender, ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.IsShowDel = false;
            tlStoreTypes.SelectNode(tlStoreTypes.Nodes[0]);
            fVModel.KeyWords = "";
            FindStoreList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void SetDgvCols()
        {
            gvStoreList.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        private void LoadStoreList()
        {
            ClearDataBindings();
            if (fVModel != null)
            {
                txtKeywords.DataBindings.Add("Text", fVModel, "KeyWords", false, DataSourceUpdateMode.OnPropertyChanged);
                chkShowDel.DataBindings.Add("Checked", fVModel, "IsShowDel", false, DataSourceUpdateMode.OnPropertyChanged);
                gcStoreList.DataBindings.Add("DataSource", fVModel, "StoreList", false, DataSourceUpdateMode.OnPropertyChanged);
                isLoad = 1;
            }
        }

        private void ClearDataBindings()
        {
            txtKeywords.DataBindings.Clear();
            chkShowDel.DataBindings.Clear();
            gcStoreList.DataBindings.Clear();
        }

       

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        private void FindStoreList()
        {
            StoreTypeInfoModel selType = tlStoreTypes.GetDataRecordByNode(tlStoreTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            fVModel.GetStoreList();
            SetDgvCols();
            if (isLoad == 1)
            {
                gcStoreList.ReLoadData();
            }
        }

        /// <summary>
        /// 显示仓库信息页面（新增、修改、详情）
        /// </summary>
        /// <param name="actType">1  add  2 edit  4 info</param>
        /// <param name="unitId"></param>
        private void ShowStoreInfoPage(int actType, int storeId)
        {
            //另一种刷新：利用事件   为信息页面定义一个事件
            FrmStoreInfo fStoreInfo = new FrmStoreInfo();
            fStoreInfo.Tag = new FInfoData()
            {
                ActType = actType,
                FId = storeId,
                UName = uName
            };
            if (actType < 4)
                fStoreInfo.ReLoadHandler += LoadStoreList;//订阅
            fStoreInfo.ShowDialogNew();
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvStoreList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvStoreList.GetFocusedDataSourceRowIndex();
                StoreModel store = fVModel.StoreList[index];
                ShowStoreInfoPage(actType, store.StoreId);
            }
            else
            {
                string title = "查看仓库", errMsg = "请选择你要查看的仓库信息";
                if (actType == 2)
                {
                    title = "修改仓库";
                    errMsg = "请选择你要修改的仓库信息";
                }
                MsgBoxHelper.MsgErrorShow(title, errMsg);
                return;
            }
        }

        /// <summary>
        /// 仓库信息删除处理（删除、恢复、移除）
        /// </summary>
        /// <param name="v"></param>
        /// <param name="storeInfo"></param>
        private void DeleteStoreInfo( StoreModel storeInfo,int isDeleted)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(isDeleted);
            string msgTitle = $"仓库信息{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该仓库信息？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (isDeleted)
                {
                    case 1://删除
                           //如果仓库在使用中，不允许删除
                        bool isStoreUse = storeBLL.CheckStoreUse(storeInfo.StoreId);
                        if (!isStoreUse)
                        {
                            bl = storeBLL.DeleteStoreInfo(storeInfo.StoreId);
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(msgTitle,$"该仓库:{storeInfo.StoreName} 在使用中，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = storeBLL.RecoverStoreInfo(storeInfo.StoreId, uName);
                        break;
                    case 2://移除
                        bl = storeBLL.RemoveStoreInfo(storeInfo.StoreId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"仓库信息:{storeInfo.StoreName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, delMsg);
                    LoadStoreList();
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