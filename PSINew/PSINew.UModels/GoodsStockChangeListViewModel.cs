using PSINew.BLL;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GoodsStockChangeListViewModel:BaseModel
    {
        StockBLL stockBLL = new StockBLL();
        public GoodsStockChangeListViewModel()
        {
            stockChangeList = new List<StockChangeInfoModel>();
        }
        private int goodsId;
        public int GoodsId
        {
            get => goodsId;
            set
            {
                goodsId = value;
                OnPropertyChanged();
            }
        }
        private string goodsName;
        public string GoodsName
        {
            get => goodsName;
            set
            {
                goodsName = value;
                OnPropertyChanged();
            }
        }

        private int storeId;
        public int StoreId
        {
            get => storeId;
            set
            {
                storeId = value;
                OnPropertyChanged();
            }
        }


        private string storeName;
        public string StoreName
        {
            get => storeName;
            set
            {
                storeName = value;
                OnPropertyChanged();
            }
        }

        private List<StockChangeInfoModel> stockChangeList;
        public List<StockChangeInfoModel>  StockChangeList
        {
            get {
                GetStockChangeList();
               return stockChangeList; }
            set { stockChangeList = value;
                OnPropertyChanged();
            }
        }

        public void GetStockChangeList()
        {
            stockChangeList = stockBLL.GetGoodsStockChangeList(goodsId, storeId, storeName);
        }
    }
}
