using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class PerQStoreModel:BaseModel
    {
        public PerQStoreModel()
        {
            perStoreInfo = new PerQueryStoreModel();
        }
        public int Id
        {
            get => perStoreInfo.Id;
            set
            {
                perStoreInfo.Id = value;
                OnPropertyChanged();
            }
        }
        public int StoreId
        {
            get => perStoreInfo.StoreId;
            set
            {
                perStoreInfo.StoreId = value;
                OnPropertyChanged();
            }
        }
        public string StoreName
        {
            get => perStoreInfo.StoreName;
            set
            {
                perStoreInfo.StoreName = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => perStoreInfo.TotalCount;
            set
            {
                perStoreInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalAmount
        {
            get => perStoreInfo.TotalAmount;
            set
            {
                perStoreInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        private PerQueryStoreModel perStoreInfo;
        public PerQueryStoreModel PerStoreInfo
        {
            get
            {
                return perStoreInfo;
            }
            set
            {
                perStoreInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
