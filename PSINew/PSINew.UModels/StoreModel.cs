using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class StoreModel : BaseModel
    {
        StoreTypeBLL stBLL = new StoreTypeBLL();
        StoreBLL storeBLL = new StoreBLL();
        private StoreInfoModel storeInfo;
        public StoreModel()
        {
            storeInfo = new StoreInfoModel();

        }
        public StoreInfoModel StoreInfo
        {
            get
            {
                return storeInfo;
            }
            set
            {
                storeInfo = value;
                OnPropertyChanged();
            }
        }

        public int StoreId
        {
            get => storeInfo.StoreId;
            set
            {
                storeInfo.StoreId = value;
                OnPropertyChanged();
            }
        }

        public string StoreNo
        {
            get => storeInfo.StoreNo;
            set
            {
                storeInfo.StoreNo = value;
                OnPropertyChanged();
            }
        }

        public string StoreName
        {
            get => storeInfo.StoreName;
            set
            {
                storeInfo.StoreName = value;
                OnPropertyChanged();
            }
        }

        public int STypeId
        {
            get => storeInfo.STypeId;
            set
            {
                storeInfo.STypeId = value;
                OnPropertyChanged();
            }
        }

        private string sTypeName;
        public string STypeName
        {
            get
            {
                if (storeInfo.STypeId == 0)
                    sTypeName = "仓库类别";
                return sTypeName;
            }
            set
            {
                sTypeName = value;
                OnPropertyChanged();
            }
        }

        public string StorePYNo
        {
            get => storeInfo.StorePYNo;
            set
            {
                storeInfo.StorePYNo = value;
                OnPropertyChanged();
            }
        }

        public int StoreOrder
        {
            get => storeInfo.StoreOrder;
            set
            {
                storeInfo.StoreOrder = value;
                OnPropertyChanged();
            }
        }

        public string StoreRemark
        {
            get => storeInfo.StoreRemark;
            set
            {
                storeInfo.StoreRemark = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => storeInfo.Creator;
            set
            {
                storeInfo.Creator = value;
                OnPropertyChanged();
            }
        }

        public void GetStoreInfo()
        {
            if (this.StoreId > 0)
                storeInfo = storeBLL.GetStoreInfo(this.StoreId);
        }
    }
}
