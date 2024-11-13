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
    public  class StockStoreViewModel:BaseModel
    {
        StoreBLL storeBLL = new StoreBLL();
        StockBLL stockBLL = new StockBLL();
        public StockStoreViewModel()
        {
            stockInfo = new StockStoreInfoModel();
            stockGoodsList = new BindingList<StockGoodsModel>();

        }
        /// <summary>
        /// 开账状态
        /// </summary>
        private bool isOpened = false;
        public bool IsOpened
        {
            get => isOpened;
            set
            {
                isOpened = value;
                OnPropertyChanged();
            }
        }

        public bool IsShowOpenInfo
        {
            get
            {
                return isOpened;
            }
        }

        public int StockId
        {
            get => stockInfo.StockId;
            set
            {
                stockInfo.StockId = value;
                OnPropertyChanged();
            }
        }

        private StockStoreInfoModel stockInfo;
        public StockStoreInfoModel StockInfo
        {
            get
            {
                return stockInfo;
            }
            set
            {
                stockInfo = value;
                OnPropertyChanged();
            }
        }

        public string StockNo
        {
            get => stockInfo.StockNo;
            set
            {
                stockInfo.StockNo = value;
                OnPropertyChanged();
            }
        }

        public int StoreId
        {
            get => stockInfo.StoreId;
            set
            {
                stockInfo.StoreId = value;
                OnPropertyChanged();
            }
        }

        private string storeName;
        public string StoreName
        {
            get
            {
                return storeName;
            }
            set
            {
                storeName = value;
                OnPropertyChanged();
            }
        }

        public string DealPerson
        {
            get => stockInfo.DealPerson;
            set
            {
                stockInfo.DealPerson = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => stockInfo.Remark;
            set
            {
                stockInfo.Remark = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => stockInfo.Creator;
            set
            {
                stockInfo.Creator = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (stockInfo.StockId == 0)
                {
                    stockInfo.CreateTime = DateTime.Today;
                    return stockInfo.CreateTime;
                }

                else
                    return stockInfo.CreateTime;
            }
            set
            {
                stockInfo.CreateTime = value;
                OnPropertyChanged();
            }
        }

        public int IsChecked
        {
            get => stockInfo.IsChecked;
            set
            {
                stockInfo.IsChecked = value;
                OnPropertyChanged();
            }
        }

        private string checkState = "待审核";
        public string CheckState
        {
            get
            {
                GetCheckState();
                return checkState;
            }
        }

       

        public string CheckPerson
        {
            get => stockInfo.CheckPerson;
            set
            {
                stockInfo.CheckPerson = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CheckTime
        {
            get
            {
                return stockInfo.CheckTime;
            }
            set
            {
                stockInfo.CheckTime = value;
                OnPropertyChanged();
            }
        }

        private BindingList<StockGoodsModel> stockGoodsList;
        public BindingList<StockGoodsModel> StockGoodsList
        {
            get
            {
                return stockGoodsList;
            }
            set
            {
                stockGoodsList = value;
                OnPropertyChanged();
            }
        }

        private int totalCount ;
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
                OnPropertyChanged();
            }
        }

        private decimal totalStAmount;
        public decimal TotalStAmount
        {
            get
            {
                return totalStAmount;
            }
            set
            {
                totalStAmount = value;
                OnPropertyChanged();
            }
        }

        public string TotalPageInfo
        {
            get
            {
                return $"共{stockGoodsList.Count}条明细";
            }
        }


        public void GetStockGoodsList()
        {
            stockGoodsList = new BindingList<StockGoodsModel>();
            if (this.StockId > 0)
            {
                List<ViewStStockGoodsInfoModel> stockGoods = stockBLL.GetStockGoodsList(this.StockId);
                stockGoods.ForEach(g => stockGoodsList.Add(new StockGoodsModel()
                {
                    StockGoodsInfo = g
                }));
                SumTotalInfo();
            }
        }

        public void SumTotalInfo()
        {
            if (stockGoodsList != null)
            {
                this.TotalCount = stockGoodsList.Sum(g => g.StCount);
                this.TotalStAmount  = stockGoodsList.Sum(g => g.StAmount);
            }
        }

        public void GetCheckState()
        {
            switch (this.IsChecked)
            {
                case 0:
                    checkState = "待审核";
                    break;
                case 1:
                    checkState = "已审核";
                    break;
                case 2:
                    checkState = "已作废";//未审核作废
                    break;
                case 3:
                    checkState = "已红冲";//已审核作废称红冲
                    break;
            }
        }

        public void GetStockInfo()
        {
            if (this.StockId > 0)
            {
                stockInfo = stockBLL.GetStockInfo(this.StockId);
            }
            if (stockInfo != null)
            {
                if (stockInfo.StoreId > 0)
                    GetStoreName();
            }
        }

        private void GetStoreName()
        {
            if (stockInfo.StoreId > 0)
            {
                StoreInfoModel storeInfo = storeBLL.GetStoreInfo(stockInfo.StoreId);
                if (storeInfo != null)
                {
                    storeName = storeInfo.StoreName;
                }
            }
        }
    }
}
