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
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using PSINew.Models.UIModels;
using DXPSIApp.BM;
using DXPSIApp.FModels;
using PSINew.Models.VModels;
using DXPSIApp.QM;
using DevExpress.XtraTab;

namespace DXPSIApp.Sale
{
    public partial class FrmSaleQueryByCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FrmSaleQueryByCustomer()
        {
            InitializeComponent();
        }
        UnitTypeBLL utBLL = new UnitTypeBLL();
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        public StoreModel store = null;
        public UnitModel unit = null;
        public GoodsTypeInfoModel gtInfo = null;//选择的商品类别
        private SaleQueryCustomerViewModel fVModel = null;
        int isLoad = 0;

        private void FrmSaleQueryByCustomer_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new SaleQueryCustomerViewModel();
                RegisterEvents();
                InitUnitTypes();
                LoadSaleDataList();
            };
            act.TryCatch("销售统计", "按客户统计采购数据页面初始化异常！");
        }

        private void LoadSaleDataList()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                txtGoodsType.DataBind(fVModel, "GTypeName", true);
                txtCustomer.DataBind(fVModel, "UnitName", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                ucPager1.DataBind(fVModel, "StartRecord", "StartIndex", true);
                ucPager1.DataBind(fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcSaleData.DataBind(fVModel, "DataSource", "SaleList", true);
                isLoad = 1;
            }
        }

        private void InitUnitTypes()
        {
            tlUTypes.LoadTVUnitTypes(fVModel.UTypeList);
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbGTypes.Click += PbGTypes_Click;
            pbStores.Click += PbStores_Click;
            pbSuppliers.Click += PbSuppliers_Click;
            tlUTypes.FocusedNodeChanged += TlUTypes_FocusedNodeChanged;
            gvUnitList.RowClick += GvUnitList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
            txtGoodsType.KeyPress += TxtGoodsType_KeyPress;
        }

     

        private void TlUTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindSaleData();
        }

        private void PbSuppliers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Customer-SaleQueryByCustomer"
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
                TypeCode = "Store-SaleQueryByCustomer"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbGTypes_Click(object sender, EventArgs e)
        {
            FrmChooseTypes fCTypes = new FrmChooseTypes();
            fCTypes.Tag = new ChooseTypeData()
            {
                TypeCode = "Goods-SaleQueryByCustomer",
                FGet = this
            };
            fCTypes.SetType += () => {
                fVModel.GTypeName = gtInfo.GTypeName;
                fVModel.GTypeId = gtInfo.GTypeId;
            };
            fCTypes.ShowDialog();
        }

        private void QueryTool1_ExportClick(object sender, ItemClickEventArgs e)
        {
            //获取查询条件并封装
            QueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<SaleQueryCustomerModel> saleData = saleBLL.GetSaleDataByCustomer(paraModel, 1, 100000000).ReList;
            string fileName = "销售统计——按客户";
            FormUtility.DataToExcel<SaleQueryCustomerModel>(saleData, gvUnitList.Columns, fileName + ".xls", fileName, fileName, "导出按客户统计销售数据");
        }

        private void QueryTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindSaleData();
        }

        private void TxtGoodsType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindSaleData();
        }

        private void GvUnitList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    SaleQCustomerModel perInfo = fVModel.SaleList[rowIndex];
                    if (perInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType =2,
                            TypeId = 1,
                            Id = perInfo.UnitId,
                            InfoName = perInfo.UnitName
                        };
                        XtraTabControl tab = this.Parent.Parent as XtraTabControl;
                        int index = -1;
                        if (FormUtility.CheckOpenForm(fSheetInfo.Name))
                        {
                            XtraTabPage page = tab.TabPages.Where(p => p.Name == fSheetInfo.Name).FirstOrDefault();
                            index = tab.TabPages.IndexOf(page);
                            tab.TabPages.Remove(page);
                        }
                        tab.AddTabFormPage(fSheetInfo, index);
                    }
                }
            }
        }

        private QueryParaModel GetParaModel()
        {
            //条件获取与封装
            UnitTypeInfoModel selType = tlUTypes.GetDataRecordByNode(tlUTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }

        private void FindSaleData()
        {
            UnitTypeInfoModel selType = tlUTypes.GetDataRecordByNode(tlUTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            fVModel.GetSaleQueryList();
            if (isLoad == 1)
            {
                gcSaleData.ReLoadData();
            }
        }
    }
}