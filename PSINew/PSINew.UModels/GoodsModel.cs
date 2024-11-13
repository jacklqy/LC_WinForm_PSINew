using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GoodsModel : BaseModel
    {
        GoodsBLL goodsBLL = new GoodsBLL();
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        private GoodsInfoModel goodsInfo;
        public GoodsModel()
        {
            goodsInfo = new GoodsInfoModel();
        }
        public GoodsInfoModel GoodsInfo
        {
            get
            {
                return goodsInfo;
            }
            set
            {
                goodsInfo = value;
                OnPropertyChanged();
            }
        }

        public int GoodsId
        {
            get => goodsInfo.GoodsId;
            set
            {
                goodsInfo.GoodsId = value;
                OnPropertyChanged();
            }
        }

        public string GoodsName
        {
            get => goodsInfo.GoodsName;
            set
            {
                goodsInfo.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GoodsNo
        {
            get => goodsInfo.GoodsNo;
            set
            {
                goodsInfo.GoodsNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsSName
        {
            get => goodsInfo.GoodsSName;
            set
            {
                goodsInfo.GoodsSName = value;
                OnPropertyChanged();
            }
        }

        public string GoodsTXNo
        {
            get => goodsInfo.GoodsTXNo;
            set
            {
                goodsInfo.GoodsTXNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsPYNo
        {
            get => goodsInfo.GoodsPYNo;
            set
            {
                goodsInfo.GoodsPYNo = value;
                OnPropertyChanged();
            }
        }
        public string GUnit
        {
            get => goodsInfo.GUnit;
            set
            {
                goodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }
        public int GTypeId
        {
            get => goodsInfo.GTypeId;
            set
            {
                goodsInfo.GTypeId = value;
                OnPropertyChanged();
            }
        }
        private string gTypeName;
        public string GTypeName
        {
            get
            {
                if (goodsInfo.GTypeId == 0)
                    gTypeName = "商品类别";
                return gTypeName;
            }
            set
            {
                gTypeName = value;
                OnPropertyChanged();
            }
        }
        public string GProperties
        {
            get => goodsInfo.GProperties;
            set
            {
                goodsInfo.GProperties = value;
                OnPropertyChanged();
            }
        }
        public int IsStopped
        {
            get => goodsInfo.IsStopped;
            set
            {
                goodsInfo.IsStopped = value;
                OnPropertyChanged();
            }
        }

        public decimal RetailPrice
        {
            get => goodsInfo.RetailPrice;
            set
            {
                goodsInfo.RetailPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal LowPrice
        {
            get => goodsInfo.LowPrice;
            set
            {
                goodsInfo.LowPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal PrePrice
        {
            get => goodsInfo.PrePrice;
            set
            {
                goodsInfo.PrePrice = value;
                OnPropertyChanged();
            }
        }
        public int Discount
        {
            get => goodsInfo.Discount;
            set
            {
                goodsInfo.Discount = value;
                OnPropertyChanged();
            }
        }

        public decimal BidPrice
        {
            get => goodsInfo.BidPrice;
            set
            {
                goodsInfo.BidPrice = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => goodsInfo.Remark;
            set
            {
                goodsInfo.Remark = value;
                OnPropertyChanged();
            }
        }

        public string GoodsPic
        {
            get => goodsInfo.GoodsPic;
            set
            {
                goodsInfo.GoodsPic = value;
                OnPropertyChanged();
            }
        }

        private Image goodsImg;
        public Image GoodsImg { get => goodsImg; set { goodsImg = value; OnPropertyChanged(); } }

        public string Creator
        {
            get => goodsInfo.Creator;
            set
            {
                goodsInfo.Creator = value;
                OnPropertyChanged();
            }
        }
        public void GetGoodsInfo()
        {
            if (this.GoodsId > 0)
                goodsInfo = goodsBLL.GetGoodsInfo(this.GoodsId);
        }
    }
}
