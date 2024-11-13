using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
     public class GoodsDistributeViewModel:BaseModel
    {
        private StockBLL stockBLL = new StockBLL();
        public GoodsDistributeViewModel()
        {
            stockQModel = new StockQGoodsModel();
        }

        private StockQGoodsModel stockQModel;
        public StockQGoodsModel StockQModel
        {
            get => stockQModel;
            set { stockQModel = value; }
        }
        public string GoodsName
        {
            get { return StockQModel.GoodsName; }
            set {
                StockQModel.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GUnit
        {
            get { return StockQModel.GUnit; }
            set
            {
                StockQModel.GUnit = value;
                OnPropertyChanged();
            }
        }

        public int TotalCount
        {
            get { return StockQModel.CurCount; }
            set
            {
                StockQModel.CurCount = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get { return StockQModel.StockAmount; }
            set
            {
                StockQModel.StockAmount = value;
                OnPropertyChanged();
            }
        }

        private StoreInfoModel storeInfo;
        public StoreInfoModel StoreInfo {
            get => storeInfo;
            set
            {
                storeInfo = value;
            }
        }

       private BindingList<GoodsStockStoreModel> storeList;

        public BindingList<GoodsStockStoreModel> StoreList
        {
            get {
                GetGoodsStoreList();
                return storeList; }
            set { storeList = value;
                OnPropertyChanged();
            }
        }

        public void GetGoodsStoreList()
        {
            List<GoodsStoreStockModel> list = stockBLL.GetGoodsStoreStock(this.stockQModel.GoodsId, this.storeInfo.StoreId, this.storeInfo.StoreName);
            storeList = new BindingList<GoodsStockStoreModel>();
            list.ForEach(g => storeList.Add(new GoodsStockStoreModel()
            {
                GoodsModel = g
            }));
        }
    }
}
