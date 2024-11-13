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
using DXPSIApp.FModels;
using PSINew.UModels;
using DevExpress.XtraTreeList;
using PSINew.Models.DModels;
using DXPSIApp.Perchase;
using DXPSIApp.Sale;
using DXPSIApp.QM;

namespace DXPSIApp.BM
{
    public partial class FrmChooseUnits : DevExpress.XtraEditors.XtraForm
    {
        public FrmChooseUnits()
        {
            InitializeComponent();
        }
        private UnitBLL unitBLL = new UnitBLL();
        private UnitTypeBLL utBLL = new UnitTypeBLL();
        public event Action SetUnit;//设置选择的单位信息
        private string typeName = "";
        private string uName = "";
        ChooseTypeData cModel = null;
        private ChooseUnitsViewModel fVModel = null;
        int isLoad = 0;
        private void FrmChooseUnits_Load(object sender, EventArgs e)
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
                    btnAdd.Enabled = false;
                //选择页面标题
                if (typeName.Contains("Supplier"))
                    this.Text = "选择供应商";
                else if (typeName.Contains("Customer"))
                    this.Text = "选择客户";
                else if (typeName.Contains("Unit"))
                    this.Text = "选择往来单位";
                fVModel = new ChooseUnitsViewModel();
                RegisterEvents();
                tlUnitTypes.LoadTVUnitTypes(fVModel.UTypeList);
                LoadUnitList();
            };
            act.TryCatch(this.Text,"加载单位信息出现异常");
        }

        private void RegisterEvents()
        {
            tlUnitTypes.FocusedNodeChanged += TlUnitTypes_FocusedNodeChanged;
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
            UnitModel selInfo = null;
            if (gridView1.SelectedRowsCount == 0)
            {
                selInfo = fVModel.UnitList[0];
            }
            else
            {
                int index = gridView1.GetFocusedDataSourceRowIndex();
                selInfo = fVModel.UnitList[index];
            }
            //将选择的单位信息赋值给要选择页面的selUnit公有变量
            switch (typeName)
            {
                case "Supplier-PerInStore"://采购单页面
                    FrmPerchaseInStore frmPerInStore = cModel.FGet as FrmPerchaseInStore;
                    frmPerInStore.unit = selInfo;
                    break;
                case "Customer-SaleOutStore"://销售单页面
                    FrmSaleOutStore frmSaleOutStore = cModel.FGet as FrmSaleOutStore;
                    frmSaleOutStore.unit = selInfo;
                    break;
                case "Unit-SheetQuery"://单据查询页面
                    FrmSheetQuery frmSheetQuery = cModel.FGet as FrmSheetQuery;
                    frmSheetQuery.unit = selInfo;
                    break;
                case "Supplier-PerQueryBySupplier"://采购统计按供应商页面
                    FrmPerchaseQueryBySupplier frmPerQueryBySupplier = cModel.FGet as FrmPerchaseQueryBySupplier;
                    frmPerQueryBySupplier.unit = selInfo;
                    break;
                case "Supplier-PerQueryByStore"://采购统计按仓库页面
                    FrmPerchaseQueryByStore frmPerQueryByStore = cModel.FGet as FrmPerchaseQueryByStore;
                    frmPerQueryByStore.unit = selInfo;
                    break;
                case "Supplier-PerQueryByGoods"://采购统计按商品页面
                    FrmPerchaseQueryByGoods frmPerQueryByGoods = cModel.FGet as FrmPerchaseQueryByGoods;
                    frmPerQueryByGoods.unit = selInfo;
                    break;
                case "Customer-SaleQueryByCustomer"://销售统计按客户页面
                    FrmSaleQueryByCustomer fSaleQueryCustomer = cModel.FGet as FrmSaleQueryByCustomer;
                    fSaleQueryCustomer.unit = selInfo;
                    break;
                case "Customer-SaleQueryByStore"://销售统计按仓库页面
                    FrmSaleQueryByStore fSaleQueryStore = cModel.FGet as FrmSaleQueryByStore;
                    fSaleQueryStore.unit = selInfo;
                    break;
                case "Customer-SaleQueryByGoods"://销售统计按仓库页面
                    FrmSaleQueryByGoods fSaleQueryGoods = cModel.FGet as FrmSaleQueryByGoods;
                    fSaleQueryGoods.unit = selInfo;
                    break;
            }
            this.SetUnit?.Invoke();//显示到文本框
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmUnitInfo fUnit = new FrmUnitInfo();
            fUnit.Tag = new FInfoData()
            {
                ActType = 1,
                UName = uName,
                FId = 0
            };
            fUnit.ReLoadHandler += FindUnitList;
            fUnit.ShowDialog();
        }

        private void TlUnitTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindUnitList();
        }

        private void LoadUnitList()
        {
            if (fVModel != null)
            {
                txtKeywords.DataBind(fVModel, "KeyWords", true);
                gcUnitList.DataBind(fVModel, "DataSource", "UnitList", true);
                isLoad = 1;
            }
        }

        private void FindUnitList()
        {
            UnitTypeInfoModel selType = tlUnitTypes.GetDataRecordByNode(tlUnitTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            fVModel.GetUTypeList();
            if (isLoad == 1)
            {
                gcUnitList.ReLoadData();
            }
        }
    }
}