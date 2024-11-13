using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GoodsStockUpDownModel:BaseModel
    {
        public GoodsStockUpDownModel()
        {
            storeUpDown = new ViewStoreStockUpDownModel();
        }

        private ViewStoreStockUpDownModel storeUpDown;
        public ViewStoreStockUpDownModel StoreUpDown
        {
            get => storeUpDown;
            set
            {
                storeUpDown = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => storeUpDown.Id;
            set
            {
                storeUpDown.Id = value;
                OnPropertyChanged();
            }
        }
        public int StoreGoodsId
        {
            get => storeUpDown.StoreGoodsId;
            set
            {
                storeUpDown.StoreGoodsId = value;
                OnPropertyChanged();
            }
        }
        public int GoodsId
        {
            get => storeUpDown.GoodsId;
            set
            {
                storeUpDown.GoodsId = value;
                OnPropertyChanged();
            }
        }
        public int StoreId
        {
            get => storeUpDown.StoreId;
            set
            {
                storeUpDown.StoreId = value;
                OnPropertyChanged();
            }
        }
        public string GoodsNo
        {
            get => storeUpDown.GoodsNo;
            set
            {
                storeUpDown.GoodsNo = value;
                OnPropertyChanged();
            }
        }
        public string GoodsName
        {
            get => storeUpDown.GoodsName;
            set
            {
                storeUpDown.GoodsName = value;
                OnPropertyChanged();
            }
        }
        public string GoodsTXNo
        {
            get => storeUpDown.GoodsTXNo;
            set
            {
                storeUpDown.GoodsTXNo = value;
                OnPropertyChanged();
            }
        }
        public string GUnit
        {
            get => storeUpDown.GUnit;
            set
            {
                storeUpDown.GUnit = value;
                OnPropertyChanged();
            }
        }
        public int? StockUp
        {
            get => storeUpDown.StockUp;
            set
            {
                storeUpDown.StockUp = value;
                OnPropertyChanged();
            }
        }
        public int StockDown
        {
            get => storeUpDown.StockDown;
            set
            {
                storeUpDown.StockDown = value;
                OnPropertyChanged();
            }
        }
    }
}
