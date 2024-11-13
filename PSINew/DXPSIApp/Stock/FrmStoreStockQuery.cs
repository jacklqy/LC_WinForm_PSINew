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
using DevExpress.XtraTab;

namespace DXPSIApp.Stock
{
    public partial class FrmStoreStockQuery : DevExpress.XtraEditors.XtraForm
    {
        public FrmStoreStockQuery()
        {
            InitializeComponent();
        }
        public StoreModel store = null;
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        StockBLL stockBLL = new StockBLL();
        private StockQueryViewModel fVModel = null;
        int isLoad = 0;

        private void FrmStoreStockQuery_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new StockQueryViewModel();
                RegisterEvents();
                LoadGoodsTypes();//加载商品类别节点树
                LoadGoodsStoreStockData();//加载商品库存数据
            };
            act.TryCatch("库存查询","加载商品库存查询异常！");
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            queryTool1.StockDistClick += QueryTool1_StockDistClick;
            pbStores.Click += PbStore_Click;
            tlGTypes.FocusedNodeChanged += TlGTypes_FocusedNodeChanged;
            gvList.RowClick += GvList_RowClick;
            txtStoreName.TextChanged += TxtStoreName_TextChanged;
        }

        private void TxtStoreName_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtStoreName.Text))
            {
                fVModel.StoreId = 0;
                fVModel.StoreName = "";
            }
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindStockList();
        }

        private void LoadGoodsStoreStockData()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                gcStockData.DataBind(fVModel, "DataSource", "StockList", true);
                queryTool1.DataBind(fVModel, "IsDistriEnabled", "IsDistribute", true);
                isLoad = 1;
            }
        }

        private void LoadGoodsTypes()
        {
            tlGTypes.LoadTVGoodsTypes(fVModel.GTypeList);
        }

        private StockQueryParaModel GetParaModel()
        {
            //条件获取与封装
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            //封装查询条件实体
            StockQueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }

        private void FindStockList()
        {
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            fVModel.GetStockQueryList();
            if (isLoad == 1)
            {
                gcStockData.ReLoadData();
            }
        }

        private void QueryTool1_StockDistClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                int index = gvList.GetFocusedDataSourceRowIndex();
                if (index >-1)
                {
                    StockQGoodsModel model = fVModel.StockList[index];
                    if (model != null)
                    {
                        FrmGoodsStockInfo fGoodsStock = new FrmGoodsStockInfo();
                        fGoodsStock.Tag = model;
                        fGoodsStock.storeInfo = new StoreInfoModel()
                        {
                            StoreId =fVModel.StoreId,
                            StoreName = fVModel.StoreName
                        };
                        fGoodsStock.ShowDialog();
                    }
                }
            };
            act.TryCatch("商品库存","查看商品仓库分布出现异常！");
        }

        private void GvList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks==2)
            {
                int index = e.RowHandle;
                if (index!=-1)
                {
                   StockQGoodsModel model= fVModel.StockList[index];
                    FrmGoodsStockChangeList fGoodsChangeList = new FrmGoodsStockChangeList();
                    fGoodsChangeList.Tag = model;
                    fGoodsChangeList.storeInfo = new StoreInfoModel()
                    {
                        StoreId = fVModel.StoreId,
                        StoreName = fVModel.StoreName
                    };
                    //打开方式
                    XtraTabControl tab = this.Parent.Parent as XtraTabControl;
                    int indexpage = -1;
                    if (FormUtility.CheckOpenForm(fGoodsChangeList.Name))
                    {
                        XtraTabPage page = tab.TabPages.Where(p => p.Name == fGoodsChangeList.Name).FirstOrDefault();
                        indexpage = tab.TabPages.IndexOf(page);
                        tab.TabPages.Remove(page);
                    }
                    tab.AddTabFormPage(fGoodsChangeList, indexpage);
                }
            }
           
        }

        private void TlGTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindStockList();
        }

        private void PbStore_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Store-StoreStockQuery"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void QueryTool1_ExportClick(object sender, ItemClickEventArgs e)
        {
            //获取所有数据
            List<StoreStockQueryModel> stockData = stockBLL.GetStoreStockData(GetParaModel());
            string fileName = "商品库存统计";
            FormUtility.DataToExcel(stockData, gvList.Columns, fileName + ".xls", fileName, fileName, "导出商品库存统计数据");
        }

        private void QueryTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

     
    }
}