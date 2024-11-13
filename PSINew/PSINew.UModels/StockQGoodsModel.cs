using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
     public class StockQGoodsModel:BaseModel
    {
        public StockQGoodsModel()
        {
            stockQModel = new StoreStockQueryModel();
        }
        private StoreStockQueryModel stockQModel;
        public StoreStockQueryModel StockQModel
        {
            get => stockQModel;
            set
            {
                stockQModel = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => stockQModel.Id;
            set
            {
                stockQModel.Id = value;
                OnPropertyChanged();
            }
        }

        public int GoodsId
        {
            get => stockQModel.GoodsId;
            set
            {
                stockQModel.GoodsId = value;
                OnPropertyChanged();
            }
        }

        public string GoodsNo
        {
            get => stockQModel.GoodsNo;
            set
            {
                stockQModel.GoodsNo = value;
                OnPropertyChanged();
            }
        }

        public string GoodsName
        {
            get => stockQModel.GoodsName;
            set
            {
                stockQModel.GoodsName = value;
                OnPropertyChanged();
            }
        }

        public string GUnit
        {
            get => stockQModel.GUnit;
            set
            {
                stockQModel.GUnit = value;
                OnPropertyChanged();
            }
        }

        public int GTypeId
        {
            get => stockQModel.GTypeId;
            set
            {
                stockQModel.GTypeId = value;
                OnPropertyChanged();
            }
        }

        public string GTypeName
        {
            get => stockQModel.GTypeName;
            set
            {
                stockQModel.GTypeName = value;
                OnPropertyChanged();
            }
        }

        public int StCount
        {
            get => stockQModel.StCount;
            set
            {
                stockQModel.StCount = value;
                OnPropertyChanged();
            }
        }

        public decimal StPrice
        {
            get => stockQModel.StPrice;
            set
            {
                stockQModel.StPrice = value;
                OnPropertyChanged();
            }
        }

        public decimal StAmount
        {
            get => stockQModel.StAmount;
            set
            {
                stockQModel.StAmount = value;
                OnPropertyChanged();
            }
        }

        public int CurCount
        {
            get => stockQModel.CurCount;
            set
            {
                stockQModel.CurCount = value;
                OnPropertyChanged();
            }
        }

        public decimal StockAmount
        {
            get => stockQModel.StockAmount;
            set
            {
                stockQModel.StockAmount = value;
                OnPropertyChanged();
            }
        }

        
    }
}
