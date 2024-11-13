using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class SaleGoodsModel:BaseModel
    {
        public SaleGoodsModel()
        {
            saleGoodsInfo = new ViewSaleGoodsInfoModel();
        }
        public int SaleId
        {
            get => saleGoodsInfo.SaleId;
            set
            {
                saleGoodsInfo.SaleId = value;
                OnPropertyChanged();
            }
        }
        public string GoodsName
        {
            get => saleGoodsInfo.GoodsName;
            set
            {
                saleGoodsInfo.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GoodsNo
        {
            get => saleGoodsInfo.GoodsNo;
            set
            {
                saleGoodsInfo.GoodsNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsTXNo
        {
            get => saleGoodsInfo.GoodsTXNo;
            set
            {
                saleGoodsInfo.GoodsTXNo = value;
                OnPropertyChanged();
            }
        }

        public string GUnit
        {
            get => saleGoodsInfo.GUnit;
            set
            {
                saleGoodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => saleGoodsInfo.Id;
            set
            {
                saleGoodsInfo.Id = value;
                OnPropertyChanged();
            }
        }

        public int GoodsId
        {
            get => saleGoodsInfo.GoodsId;
            set
            {
                saleGoodsInfo.GoodsId = value;
                OnPropertyChanged();
            }
        }

        public int SaleCount
        {
            get => saleGoodsInfo.Count;
            set
            {
                saleGoodsInfo.Count = value;
                OnPropertyChanged();
            }
        }

        public decimal SalePrice
        {
            get => saleGoodsInfo.SalePrice;
            set
            {
                saleGoodsInfo.SalePrice = value;
                OnPropertyChanged();
            }
        }

        public decimal SaleAmount
        {
            get => saleGoodsInfo.Amount;
            set
            {
                saleGoodsInfo.Amount = value;
                OnPropertyChanged();
            }
        }

        public string SaleRemark
        {
            get => saleGoodsInfo.Remark;
            set
            {
                saleGoodsInfo.Remark = value;
                OnPropertyChanged();
            }
        }


        private ViewSaleGoodsInfoModel saleGoodsInfo;
        public ViewSaleGoodsInfoModel SaleGoodsInfo
        {
            get
            {
                return saleGoodsInfo;
            }
            set
            {
                saleGoodsInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
