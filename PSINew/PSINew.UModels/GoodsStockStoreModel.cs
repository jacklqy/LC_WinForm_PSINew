using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GoodsStockStoreModel:BaseModel
    {
        public GoodsStockStoreModel()
        {
            goodsModel = new GoodsStoreStockModel();
        }

        public int Id
        {
            get { return goodsModel.Id; }
            set { goodsModel.Id = value;
                OnPropertyChanged();
            }
        }
        public int StoreId
        {
            get { return goodsModel.StoreId; }
            set { goodsModel.StoreId = value;
                OnPropertyChanged();
            }
        }

        public string StoreName
        {
            get { return goodsModel.StoreName; }
            set { goodsModel.StoreName = value;
                OnPropertyChanged();
            }
        }

        public int CurCount
        {
            get { return goodsModel.CurCount; }
            set
            {
                goodsModel.CurCount = value;
                OnPropertyChanged();
            }
        }

        public decimal StPrice
        {
            get { return goodsModel.StPrice; }
            set
            {
                goodsModel.StPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal StockAmount
        {
            get { return goodsModel.StockAmount; }
            set
            {
                goodsModel.StockAmount = value;
                OnPropertyChanged();
            }
        }

        private GoodsStoreStockModel goodsModel;
        public GoodsStoreStockModel GoodsModel
        {
            get => goodsModel;
            set
            {
                goodsModel = value;
                OnPropertyChanged();
            }
        }
    }
}
