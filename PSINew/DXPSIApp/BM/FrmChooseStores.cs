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
using DXPSIApp.FModels;
using DevExpress.XtraTreeList;
using PSINew.Models.DModels;
using DXPSIApp.Stock;
using DXPSIApp.Perchase;
using DXPSIApp.Sale;
using DXPSIApp.QM;

namespace DXPSIApp.BM
{
    public partial class FrmChooseStores : DevExpress.XtraEditors.XtraForm
    {
        public FrmChooseStores()
        {
            InitializeComponent();
        }
        StoreBLL storeBLL = new StoreBLL();
        StoreTypeBLL stBLL = new StoreTypeBLL();
        public event Action SetStore;//设置选择的仓库
        private string typeName = "";
        private string uName = "";
        ChooseTypeData cModel = null;//信息页面到选择仓库页面的实体
        private ChooseStoresViewModel fVModel = null;
        int isLoad = 0;
        private void FrmChooseStores_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    cModel = this.Tag as ChooseTypeData;
                    typeName = cModel.TypeCode;
                    uName = cModel.UName;
                }
                if (string.IsNullOrEmpty(uName))
                {
                    btnAdd.Enabled = false;
                }
                fVModel = new ChooseStoresViewModel();
                RegisterEvents();
                tlStoreTypes.LoadTLStoreTypes(fVModel.STypeList);//仓库类别信息 treeView
                LoadStoreList();//条件查询仓库列表
            };
            act.TryCatch("仓库选择","加载仓库信息出现异常");
        }

        private void RegisterEvents()
        {
            tlStoreTypes.FocusedNodeChanged += TlStoreTypes_FocusedNodeChanged;
            btnAdd.Click += BtnAdd_Click;
            btnChoose.Click += BtnChoose_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            StoreModel selInfo = null;
            if (gridView1.SelectedRowsCount==0)
            {
                selInfo = fVModel.StoreList[0];
            }
            else
            {
                int index = gridView1.GetFocusedDataSourceRowIndex();
                selInfo = fVModel.StoreList[index];
            }

            //typecode   区分要返回的页面
            switch (typeName)
            {
                case "Store-StartStock"://期初入库单页面
                    FrmStartStockInfo fStartStockInfo = cModel.FGet as FrmStartStockInfo;
                    fStartStockInfo.store = selInfo;
                    break;
                case "Store-PerchaseInStore"://采购单页面
                    FrmPerchaseInStore fPerchaseInStoreInfo = cModel.FGet as FrmPerchaseInStore;
                    fPerchaseInStoreInfo.store = selInfo;
                    break;
                case "Store-SaleOutStore"://销售单页面
                    FrmSaleOutStore fSaleOutStoreInfo = cModel.FGet as FrmSaleOutStore;
                    fSaleOutStoreInfo.store = selInfo;
                    break;
                case "Store-SheetQuery"://单据选择页面
                    FrmSheetQuery fSheetQuery = cModel.FGet as FrmSheetQuery;
                    fSheetQuery.store = selInfo;
                    break;
                case "Store-PerQueryBySupplier"://采购统计按供应商选择页面
                    FrmPerchaseQueryBySupplier fPerBySupplier = cModel.FGet as FrmPerchaseQueryBySupplier;
                    fPerBySupplier.store = selInfo;
                    break;
                case "Store-StockUpDownSet"://库存上下限设置页面
                    FrmStockUpDownSet fStockUpDown = cModel.FGet as FrmStockUpDownSet;
                    fStockUpDown.store = selInfo;
                    break;
                case "Store-PerQueryByGoods"://采购统计按商品选择页面
                    FrmPerchaseQueryByGoods fPerByGoods = cModel.FGet as FrmPerchaseQueryByGoods;
                    fPerByGoods.store = selInfo;
                    break;
                case "Store-SaleQueryByCustomer"://销售统计按客户选择页面
                    FrmSaleQueryByCustomer fSaleByCustomer = cModel.FGet as FrmSaleQueryByCustomer;
                    fSaleByCustomer.store = selInfo;
                    break;
                //case "Store-SaleQueryByStore"://销售统计按客户选择页面
                //    FrmSaleQueryByStore fSaleByStore = cModel.FGet as FrmSaleQueryByStore;
                //    fSaleByStore.store = selInfo;
                    //break;
                case "Store-SaleQueryByGoods"://销售统计按商品选择页面
                    FrmSaleQueryByGoods fSaleByGoods = cModel.FGet as FrmSaleQueryByGoods;
                    fSaleByGoods.store = selInfo;
                    break;
                case "Store-StoreStockQuery"://仓库库存查询页面
                    FrmStoreStockQuery fStoreStockQuery = cModel.FGet as FrmStoreStockQuery;
                    fStoreStockQuery.store = selInfo;
                    break;
            }
            this.SetStore?.Invoke();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmStoreInfo fStore = new FrmStoreInfo();
            fStore.Tag = new FInfoData()
            {
                ActType = 1,
                UName = uName,
                FId = 0
            };
            fStore.ReLoadHandler += FindStoreList;
            fStore.ShowDialog();
        }

        private void TlStoreTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindStoreList();
        }

        private void LoadStoreList()
        {
            if (fVModel != null)
            {
                txtKeywords.DataBind(fVModel, "KeyWords", true);
                gcStoreList.DataBind(fVModel, "DataSource", "StoreList", true);
                isLoad = 1;
            }
        }

        private void FindStoreList()
        {
            StoreTypeInfoModel selType = tlStoreTypes.GetDataRecordByNode(tlStoreTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            fVModel.GetStoreList();
            if (isLoad == 1)
            {
                gcStoreList.ReLoadData();
            }
        }
    }
}