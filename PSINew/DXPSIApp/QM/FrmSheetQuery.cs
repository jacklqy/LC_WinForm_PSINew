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
using PSINew.Models.DModels;
using PSINew.UModels;
using PSINew.BLL;
using DXPSIApp.FModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using DXPSIApp.BM;
using DXPSIApp.UControls;
using DXPSIApp.Perchase;
using DXPSIApp.Sale;
using DXPSIApp.Stock;
using DevExpress.XtraTab;

namespace DXPSIApp.QM
{
    public partial class FrmSheetQuery : DevExpress.XtraEditors.XtraForm
    {
        public FrmSheetQuery()
        {
            InitializeComponent();
        }
        public StoreModel store = null;
        public UnitModel unit = null;
        GoodsBLL goodsBLL = new GoodsBLL();
        private string uName = "";//账号
        private SheetQueryViewModel fVModel = null;
        SheetQueryBLL sheetBLL = new SheetQueryBLL();
        int isLoad = 0;
        private void FrmSheetQuery_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new SheetQueryViewModel();
                if (this.Tag != null)
                {
                    Type tagType = this.Tag.GetType();
                    uName = this.Tag.ToString();
                }
                RegisterEvents();
                InitCboCheckState();
                InitTvSheetTypes();
                LoadSheetList();//条件查询单据列表
            };
            act.TryCatch("单据查询","采购单页面初始化异常！");
        }

        private void RegisterEvents()
        {
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            queryTool1.FindClick += QueryTool1_FindClick;
            pbStores.Click += PbStores_Click;
            pbUnits.Click += PbUnits_Click;
            tlShTypes.FocusedNodeChanged += TlShTypes_FocusedNodeChanged;
            cboChecked.SelectedIndexChanged += CboChecked_SelectedIndexChanged;
            txtGoodsName.KeyPress += TxtGoodsName_KeyPress;
            ucPager1.BindSource += UcPager1_BindSource;
            gvSheetList.RowClick += GvSheetList_RowClick;
        }

        private void QueryTool1_FindClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindSheetList();
        }

        private void GvSheetList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Action act = () =>
            {
                if(e.Clicks==2)
                {
                    if (e.RowHandle >= 0)
                    {
                        SheetInfoModel sheetInfo = fVModel.SheetList[e.RowHandle];
                        //行双击：打开单据编辑（查看）页面
                        //采购   销售   入库  shType 1  2  3
                        SheetFormParent frmInfo = null;//编辑页面
                        switch (sheetInfo.ShType)
                        {
                            case 1:
                                frmInfo = new FrmPerchaseInStore();
                                break;
                            case 2:
                                frmInfo = new FrmSaleOutStore();
                                break;
                            case 3:
                                frmInfo = new FrmStartStockInfo();
                                break;
                        }
                        frmInfo.Tag = new FInfoData()
                        {
                            ActType = 2,
                            UName = uName,
                            FId = sheetInfo.SheetId
                        };
                        frmInfo.ReloadList += FindSheetList;//订阅事件
                        XtraTabControl tab = this.Parent.Parent as XtraTabControl;
                        int index = -1;
                        if (FormUtility.CheckOpenForm(frmInfo.Name))
                        {
                            XtraTabPage page = tab.TabPages.Where(p => p.Name == frmInfo.Name).FirstOrDefault();
                            index = tab.TabPages.IndexOf(page);
                            tab.TabPages.Remove(page);
                        }
                        tab.AddTabFormPage(frmInfo, index);
                    }
                }
             
            };
            act.TryCatch("单据编辑","单据加载出现异常！");

        }

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindSheetList();
        }

        private void TxtGoodsName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//enter
            {
                string keywords = txtGoodsName.Text.Trim();
                string goodsName = goodsBLL.GetGoodsInfoByKeywords(keywords);
                if (!string.IsNullOrEmpty(goodsName))
                {
                    fVModel.GoodsName = goodsName;
                }
            }
        }

        private void CboChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoad == 1)
            {
                fVModel.IsChecked = cboChecked.GetCboValue();
                FindSheetList();
            }
        }

        private void TlShTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if(isLoad==1)
                 FindSheetList();
        }

        private void PbUnits_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Unit-SheetQuery",
                UName = uName
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void PbStores_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                UName = uName,
                TypeCode = "Store-SheetQuery"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void QueryTool1_ExportClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //获取查询条件并封装
            ShQueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<SheetInfoModel> sheetList = sheetBLL.GetSheetList(paraModel, 1, 100000000).ReList;
            string shTypeName = tlShTypes.FocusedValue.ToString();
            FormUtility.DataToExcel<SheetInfoModel>(sheetList, gvSheetList.Columns, shTypeName+ ".xls", shTypeName, shTypeName, "导出单据信息");
        }

        private ShQueryParaModel GetParaModel()
        {
            fVModel.IsChecked = cboChecked.GetCboValue();
            SheetModel selType = tlShTypes.GetDataRecordByNode(tlShTypes.FocusedNode) as SheetModel;
            if (selType != null)
            {
                fVModel.ShType = selType.ShTypeId;
            }
            ShQueryParaModel paraModel = fVModel.GetParaModel();
            return paraModel;
        }

        private void QueryTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void InitTvSheetTypes()
        {
            tlShTypes.Nodes.Clear();
            tlShTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlShTypes.DataSource = fVModel.ShTypeList;
            tlShTypes.KeyFieldName = "ShTypeId";
            tlShTypes.ParentFieldName = "ParentId";
            tlShTypes.SelectNode(tlShTypes.Nodes[0]);
            tlShTypes.ExpandAll();
        }

        private void LoadSheetList()
        {
            if(fVModel!=null)
            {
                txtCustomer.DataBind(fVModel, "UnitName",true);
                txtCreator.DataBind(fVModel, "Creator", true);
                txtCheckPerson.DataBind(fVModel, "CheckPerson", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtSheetNo.DataBind(fVModel, "SheetNo", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                cboChecked.SetCboValue(fVModel.IsChecked);
                ucPager1.DataBind(fVModel, "StartRecord", "StartIndex", true);
                ucPager1.DataBind(fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcSheetList.DataBind(fVModel, "DataSource", "SheetList", true);
                isLoad = 1;
            }
           
        }

        private void InitCboCheckState()
        {
            cboChecked.Properties.Items.Clear();
            fVModel.CheckStateList.ForEach(c => cboChecked.Properties.Items.Add(new ComboBoxItem(c.CheckState, c.CheckId)));
            cboChecked.SelectedIndex = 0;
        }

        private void FindSheetList()
        {
            fVModel.IsChecked = cboChecked.GetCboValue();
            SheetModel selType = tlShTypes.GetDataRecordByNode(tlShTypes.FocusedNode) as SheetModel;
            if (selType != null)
            {
                fVModel.ShType = selType.ShTypeId;
            }
            ShQueryParaModel paraModel = fVModel.GetParaModel();
            fVModel.GetSheetList();
            if (isLoad == 1)
                gcSheetList.ReLoadData();
        }
    }
}