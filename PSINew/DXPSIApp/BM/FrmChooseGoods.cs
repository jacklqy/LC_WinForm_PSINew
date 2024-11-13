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
using DXPSIApp.Stock;

namespace DXPSIApp.BM
{
    public partial class FrmChooseGoods : DevExpress.XtraEditors.XtraForm
    {
        public FrmChooseGoods()
        {
            InitializeComponent();
        }
        private GoodsBLL goodsBLL = new GoodsBLL();
        private GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        public event Action SetChooseGoods;
        private string typeName = "";
        private string uName = "";
        ChooseTypeData cModel = null;
        private ChooseGoodsViewModel fVModel = null;
        int isLoad = 0;
        private void FrmChooseGoods_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    cModel = this.Tag as ChooseTypeData;
                    typeName = cModel.TypeCode;
                    uName = cModel.UName;
                }
                fVModel = new ChooseGoodsViewModel();
                RegisterEvents();
                LoadTvGTypes();
                LoadGoodsList();
            };
            act.TryCatch("商品选择","加载商品信息出现异常");
        }

        private void RegisterEvents()
        {
            tlGoodsTypes.FocusedNodeChanged += TlGoodsTypes_FocusedNodeChanged;
            btnAdd.Click += BtnAdd_Click;
            btnChoose.Click += BtnChoose_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            List<GoodsModel> selInfos = new List<GoodsModel>();
            //获取选择的商品数据
            if (gridView1.SelectedRowsCount > 0)
            {
                foreach (int index in gridView1.GetSelectedRows())
                {
                    GoodsModel gInfo = fVModel.GoodsList[index];
                    selInfos.Add(gInfo);
                }
            }
            else
                selInfos.Add(fVModel.GoodsList[0]);
            Type typeForm = cModel.FGet.GetType();

            switch (typeName)
            {
                case "DgvGoods-PerchaseInStore"://采购单页面商品选择
                    FrmPerchaseInStore frmPerchase = cModel.FGet as FrmPerchaseInStore;
                    frmPerchase.chooseGoods = selInfos;
                    break;
                case "DgvGoods-SaleOutStore"://销售单页面商品选择
                    FrmSaleOutStore frmSale = cModel.FGet as FrmSaleOutStore;
                    frmSale.chooseGoods = selInfos;
                    break;
                case "DgvGoods-StartStock"://期初入库单商品选择
                    FrmStartStockInfo frm = cModel.FGet as FrmStartStockInfo;
                    frm.chooseGoods = selInfos;
                    break;
            }
            this.SetChooseGoods?.Invoke();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmGoodsInfo fGoods = new FrmGoodsInfo();
            fGoods.Tag = new FInfoData()
            {
                ActType = 1,
                UName = uName,
                FId = 0
            };
            fGoods.ReLoad += FindGoodsList;
            fGoods.ShowDialog();
        }


        private void TlGoodsTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindGoodsList();
        }

        private void LoadGoodsList()
        {
            if (fVModel != null)
            {
                txtKeywords.DataBind(fVModel, "KeyWords", true);
                tlGoodsTypes.SetFocusedValue(fVModel.GTypeName);
                gcGoodsList.DataBind(fVModel,"DataSource", "GoodsList",true);
                isLoad = 1;
            }
        }

        private void LoadTvGTypes()
        {
            tlGoodsTypes.LoadTVGoodsTypes(fVModel.GTypeList);
        }

        private void FindGoodsList()
        {
            GoodsTypeInfoModel selType = tlGoodsTypes.GetDataRecordByNode(tlGoodsTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            fVModel.GetGoodsList();
            if (isLoad == 1)
            {
                gcGoodsList.ReLoadData();
            }

        }
    }
}