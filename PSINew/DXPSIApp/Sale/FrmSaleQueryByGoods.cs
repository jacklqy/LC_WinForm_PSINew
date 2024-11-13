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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using PSINew.Models.UIModels;
using DXPSIApp.QM;
using DXPSIApp.FModels;
using DevExpress.XtraTab;
using DXPSIApp.BM;
using PSINew.Models.VModels;

namespace DXPSIApp.Sale
{
    public partial class FrmSaleQueryByGoods : DevExpress.XtraEditors.XtraForm
    {
        public FrmSaleQueryByGoods()
        {
            InitializeComponent();
        }
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        public StoreModel store = null;
        public UnitModel unit = null;
        private SaleQueryGoodsViewModel fVModel = null;
        int isLoad = 0;
        private void FrmSaleQueryByGoods_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new SaleQueryGoodsViewModel();
                RegisterEvents();
                InitGoodsTypes();
                LoadSaleDataList();
            };
            act.TryCatch("采购统计", "按商品统计采购数据页面初始化异常！");
        }

        private void LoadSaleDataList()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                txtCustomer.DataBind(fVModel, "UnitName", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                ucPager1.DataBind(fVModel, "StartRecord", "StartIndex", true);
                ucPager1.DataBind(fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcSaleData.DataBind(fVModel, "DataSource", "SaleList", true);
                isLoad = 1;
            }
        }

        private void InitGoodsTypes()
        {
            tlGTypes.LoadTVGoodsTypes(fVModel.GTypeList);
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbStores.Click += PbStore_Click;
            pbCustomers.Click += PbCustomers_Click;
            tlGTypes.FocusedNodeChanged += TlGTypes_FocusedNodeChanged;
            gvGoodsList.RowClick += GvGoodsList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindSaleData();
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
            List<SaleQueryGoodsModel> saleData = saleBLL.GetSaleDataByGoods(paraModel, 1, 100000000).ReList;
            string fileName = "销售统计——按商品";
            FormUtility.DataToExcel<SaleQueryGoodsModel>(saleData, gvGoodsList.Columns, fileName + ".xls", fileName, fileName, "导出按商品统计销售数据");
        }

        private void PbStore_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Store-SaleQueryByGoods"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbCustomers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Customer-SaleQueryByGoods"
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void TlGTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            FindSaleData();
        }

        private void GvGoodsList_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    SaleQGoodsModel saleInfo = fVModel.SaleList[rowIndex];
                    if (saleInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType = 2,
                            TypeId = 3,
                            Id = saleInfo.GoodsId,
                            InfoName = saleInfo.GoodsName
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
            FindSaleData();
        }

        private void FindSaleData()
        {
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
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
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }
    }
}