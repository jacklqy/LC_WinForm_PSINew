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
    public partial class FrmGoodsStockChangeList : DevExpress.XtraEditors.XtraForm
    {
        public FrmGoodsStockChangeList()
        {
            InitializeComponent();
        }
        public StoreInfoModel storeInfo = null;//传过来的仓库条件
        StockBLL stockBLL = new StockBLL();
        private StockQGoodsModel goodsStockInfo = null;//商品库存数据
        //List<StockChangeInfoModel> stockChangeList = null;//商品库存变动记录
        private GoodsStockChangeListViewModel fVModel = null;
        private void FrmGoodsStockChangeList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new GoodsStockChangeListViewModel();
                if (this.Tag != null)
                    goodsStockInfo = this.Tag as StockQGoodsModel;
                if (goodsStockInfo != null)
                {
                    initGoodsInfo();//初始化商品信息
                    LoadGoodsStockChangeData();//加载商品的库存变动记录
                }
                RegisterEvents();
            };
            act.TryCatch("商品库存变动","加载商品库存查询异常！");
        }

        private void RegisterEvents()
        {
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
        }

        private void QueryTool1_ExportClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = $"{goodsStockInfo.GoodsName} 的库存变动明细列表";
            FormUtility.DataToExcel(fVModel.StockChangeList, gridView1.Columns, fileName + ".xls", fileName, fileName, "导出商品库存变动明细数据");
        }

        private void QueryTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void LoadGoodsStockChangeData()
        {
            if(fVModel!=null)
            {
                lblGoodsName.DataBind(fVModel, "GoodsName");
                lblStoreName.DataBind(fVModel, "StoreName");
                gcChangeList.DataBind(fVModel, "DataSource", "StockChangeList");
            }
        }

        private void initGoodsInfo()
        {
            fVModel.GoodsId = goodsStockInfo.GoodsId;
            fVModel.GoodsName  = goodsStockInfo.GoodsName;
            fVModel.StoreId = storeInfo.StoreId;
            fVModel.StoreName = storeInfo.StoreName;
            fVModel.GetStockChangeList();
        }
    }
}