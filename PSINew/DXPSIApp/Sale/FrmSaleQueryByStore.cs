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
using PSINew.Models.VModels;
using DXPSIApp.BM;
using DXPSIApp.FModels;
using DXPSIApp.QM;
using DevExpress.XtraTab;

namespace DXPSIApp.Sale
{
    public partial class FrmSaleQueryByStore : DevExpress.XtraEditors.XtraForm
    {
        public FrmSaleQueryByStore()
        {
            InitializeComponent();
        }
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        public UnitModel unit = null;
        private SaleQueryStoreViewModel fVModel = null;
        int isLoad = 0;
        private void FrmSaleQueryByStore_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new SaleQueryStoreViewModel();
                RegisterEvents();
                InitStoreypes();
                LoadSaleDataList();
            };
            act.TryCatch("采购统计", "按仓库统计销售数据页面初始化异常！");
        }

        private void LoadSaleDataList()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                txtSupplier.DataBind(fVModel, "UnitName", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                ucPager1.DataBind(fVModel, "StartRecord", "StartIndex", true);
                ucPager1.DataBind(fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcSaleData.DataBind(fVModel, "DataSource", "SaleList", true);
                isLoad = 1;
            }
        }

        private void InitStoreypes()
        {
            tlSTypes.LoadTLStoreTypes(fVModel.STypeList);
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbSuppliers.Click += PbSuppliers_Click;
            tlSTypes.FocusedNodeChanged += TlSTypes_FocusedNodeChanged;
            gvStoreList.RowClick += GvStoreList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
        }

        private void PbSuppliers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Customer-SaleQueryByStore"
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void GvStoreList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    SaleQStoreModel saleInfo = fVModel.SaleList[rowIndex];
                    if (saleInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType = 2,
                            TypeId = 2,
                            Id = saleInfo.StoreId,
                            InfoName = saleInfo.StoreName
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

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindSaleDataList();
        }

        private void TlSTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindSaleDataList();
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindSaleDataList();
        }

        private void QueryTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void QueryTool1_ExportClick(object sender, ItemClickEventArgs e)
        {
            //获取查询条件并封装
            QueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<SaleQueryStoreModel> saleData = saleBLL.GetSaleDataByStore(paraModel, 1, 100000000).ReList;
            string fileName = "销售统计——按仓库";
            FormUtility.DataToExcel<SaleQueryStoreModel>(saleData, gvStoreList.Columns, fileName + ".xls", fileName, fileName, "导出按仓库统计销售数据") ;
        }

        private void FindSaleDataList()
        {
            StoreTypeInfoModel selType = tlSTypes.GetDataRecordByNode(tlSTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            fVModel.GetSaleQueryList();
            if (isLoad == 1)
            {
                gcSaleData.ReLoadData();
            }
        }

        private QueryParaModel GetParaModel()
        {
            //条件获取与封装
            StoreTypeInfoModel selType = tlSTypes.GetDataRecordByNode(tlSTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }
    }
}