using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class SaleQGoodsModel:BaseModel
    {
        public SaleQGoodsModel()
        {
            saleGoodsInfo = new SaleQueryGoodsModel();
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
        public string GoodsNo
        {
            get => saleGoodsInfo.GoodsNo;
            set
            {
                saleGoodsInfo.GoodsNo = value;
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
        public string GUnit
        {
            get => saleGoodsInfo.GUnit;
            set
            {
                saleGoodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => saleGoodsInfo.TotalCount;
            set
            {
                saleGoodsInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
      
        public decimal TotalAmount
        {
            get => saleGoodsInfo.TotalAmount;
            set
            {
                saleGoodsInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalStAmount
        {
            get => saleGoodsInfo.TotalStAmount;
            set
            {
                saleGoodsInfo.TotalStAmount = value;
                OnPropertyChanged();
            }
        }

        private SaleQueryGoodsModel saleGoodsInfo;
        public SaleQueryGoodsModel SaleGoodsInfo
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
