using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class StockGoodsModel:BaseModel
    {
        public StockGoodsModel()
        {
            stockGoodsInfo = new ViewStStockGoodsInfoModel();
        }
        public int StockId
        {
            get => stockGoodsInfo.StockId;
            set
            {
                stockGoodsInfo.StockId = value;
                OnPropertyChanged();
            }
        }
        public string GoodsName
        {
            get => stockGoodsInfo.GoodsName;
            set
            {
                stockGoodsInfo.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GoodsNo
        {
            get => stockGoodsInfo.GoodsNo;
            set
            {
                stockGoodsInfo.GoodsNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsTXNo
        {
            get => stockGoodsInfo.GoodsTXNo;
            set
            {
                stockGoodsInfo.GoodsTXNo = value;
                OnPropertyChanged();
            }
        }

        public string GUnit
        {
            get => stockGoodsInfo.GUnit;
            set
            {
                stockGoodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => stockGoodsInfo.Id;
            set
            {
                stockGoodsInfo.Id = value;
                OnPropertyChanged();
            }
        }

        public int GoodsId
        {
            get => stockGoodsInfo.GoodsId;
            set
            {
                stockGoodsInfo.GoodsId = value;
                OnPropertyChanged();
            }
        }

        public int StCount
        {
            get => stockGoodsInfo.StCount;
            set
            {
                stockGoodsInfo.StCount = value;
                OnPropertyChanged();
            }
        }

        public decimal StPrice
        {
            get => stockGoodsInfo.StPrice;
            set
            {
                stockGoodsInfo.StPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal StAmount
        {
            get => stockGoodsInfo.StAmount;
            set
            {
                stockGoodsInfo.StAmount = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => stockGoodsInfo.Remark;
            set
            {
                stockGoodsInfo.Remark = value;
                OnPropertyChanged();
            }
        }


        private ViewStStockGoodsInfoModel stockGoodsInfo;
        public ViewStStockGoodsInfoModel StockGoodsInfo
        {
            get
            {
                return stockGoodsInfo;
            }
            set
            {
                stockGoodsInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
