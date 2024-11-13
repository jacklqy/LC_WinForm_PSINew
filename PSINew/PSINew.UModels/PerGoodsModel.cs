using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class PerGoodsModel:BaseModel
    {
        public PerGoodsModel()
        {
            perGoodsInfo = new ViewPerGoodsInfoModel();
        }
        public int PerId
        {
            get => perGoodsInfo.PerId;
            set
            {
                perGoodsInfo.PerId = value;
                OnPropertyChanged();
            }
        }
        public string GoodsName
        {
            get => perGoodsInfo.GoodsName;
            set
            {
                perGoodsInfo.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GoodsNo
        {
            get => perGoodsInfo.GoodsNo;
            set
            {
                perGoodsInfo.GoodsNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsTXNo
        {
            get => perGoodsInfo.GoodsTXNo;
            set
            {
                perGoodsInfo.GoodsTXNo = value;
                OnPropertyChanged();
            }
        }

        public string GUnit
        {
            get => perGoodsInfo.GUnit;
            set
            {
                perGoodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => perGoodsInfo.Id;
            set
            {
                perGoodsInfo.Id = value;
                OnPropertyChanged();
            }
        }

        public int GoodsId
        {
            get => perGoodsInfo.GoodsId;
            set
            {
                perGoodsInfo.GoodsId = value;
                OnPropertyChanged();
            }
        }

        public int PerCount
        {
            get => perGoodsInfo.Count;
            set
            {
                perGoodsInfo.Count = value;
                OnPropertyChanged();
            }
        }

        public decimal PerPrice
        {
            get => perGoodsInfo.PerPrice;
            set
            {
                perGoodsInfo.PerPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal PerAmount
        {
            get => perGoodsInfo.Amount;
            set
            {
                perGoodsInfo.Amount = value;
                OnPropertyChanged();
            }
        }

        public string PerRemark
        {
            get => perGoodsInfo.Remark;
            set
            {
                perGoodsInfo.Remark = value;
                OnPropertyChanged();
            }
        }


        private ViewPerGoodsInfoModel perGoodsInfo;
        public ViewPerGoodsInfoModel PerGoodsInfo
        {
            get
            {
                return perGoodsInfo;
            }
            set
            {
                perGoodsInfo = value;
                OnPropertyChanged();
            }
        }

       
    }
}
