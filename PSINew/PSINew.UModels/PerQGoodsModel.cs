using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    /// <summary>
    /// 按商品统计采购数据
    /// </summary>
    public class PerQGoodsModel:BaseModel
    {
        public PerQGoodsModel()
        {
            perGoodsInfo = new PerQueryGoodsModel();
        }
        public int Id {
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
        public string GoodsNo
        {
            get => perGoodsInfo.GoodsNo;
            set
            {
                perGoodsInfo.GoodsNo = value;
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
        public string GUnit
        {
            get => perGoodsInfo.GUnit;
            set
            {
                perGoodsInfo.GUnit = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => perGoodsInfo.TotalCount;
            set
            {
                perGoodsInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
        public decimal AvgPrice
        {
            get => perGoodsInfo.AvgPrice;
            set
            {
                perGoodsInfo.AvgPrice = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalAmount
        {
            get => perGoodsInfo.TotalAmount;
            set
            {
                perGoodsInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        private PerQueryGoodsModel perGoodsInfo;
        public PerQueryGoodsModel PerGoodsInfo
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
