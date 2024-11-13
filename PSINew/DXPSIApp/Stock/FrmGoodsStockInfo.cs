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
using PSINew.BLL;
using PSINew.UModels;

namespace DXPSIApp.Stock
{
    public partial class FrmGoodsStockInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmGoodsStockInfo()
        {
            InitializeComponent();
        }
        StockBLL stockBLL = new StockBLL();
        public StoreInfoModel storeInfo = null;//传过来的仓库条件
        private StockQGoodsModel goodsStockInfo = null;//商品的库存数据
        private GoodsDistributeViewModel fVModel = null;

        private void FrmGoodsStockInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new GoodsDistributeViewModel();
                if (this.Tag != null)
                    goodsStockInfo = this.Tag as StockQGoodsModel;
                if (goodsStockInfo != null)
                {
                    initGoodsInfo();//初始化商品信息
                    LoadGoodsStockData();//加载商品的仓库分布数据
                }
            };
            act.TryCatch("商品库存分布","加载商品库存查询异常！");
        }

        private void LoadGoodsStockData()
        {
            if(fVModel!=null)
            {
                lblGoodsName.DataBind(fVModel, "GoodsName");
                lblGUnit.DataBind(fVModel, "GUnit");
                lblTotalCount.DataBind(fVModel, "TotalCount");
                lblTotalStockAmount.DataBind(fVModel, "TotalAmount");
                gcGoodsStockList.DataBind(fVModel, "DataSource", "StoreList");
            }
        }

        private void initGoodsInfo()
        {
            fVModel.StockQModel = goodsStockInfo;
            if (storeInfo != null)
            {
                fVModel.StoreInfo = storeInfo;
            }
            fVModel.GetGoodsStoreList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}