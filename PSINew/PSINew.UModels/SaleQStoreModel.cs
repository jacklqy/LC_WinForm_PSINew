using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class SaleQStoreModel:BaseModel
    {
        public SaleQStoreModel()
        {
            saleStoreInfo = new SaleQueryStoreModel();
        }
        public int Id
        {
            get => saleStoreInfo.Id;
            set
            {
                saleStoreInfo.Id = value;
                OnPropertyChanged();
            }
        }
        public int StoreId
        {
            get => saleStoreInfo.StoreId;
            set
            {
                saleStoreInfo.StoreId = value;
                OnPropertyChanged();
            }
        }
        public string StoreName
        {
            get => saleStoreInfo.StoreName;
            set
            {
                saleStoreInfo.StoreName = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => saleStoreInfo.TotalCount;
            set
            {
                saleStoreInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalAmount
        {
            get => saleStoreInfo.TotalAmount;
            set
            {
                saleStoreInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalStAmount
        {
            get => saleStoreInfo.TotalStAmount;
            set
            {
                saleStoreInfo.TotalStAmount = value;
                OnPropertyChanged();
            }
        }

        private SaleQueryStoreModel saleStoreInfo;
        public SaleQueryStoreModel SaleStoreInfo
        {
            get
            {
                return saleStoreInfo;
            }
            set
            {
                saleStoreInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
