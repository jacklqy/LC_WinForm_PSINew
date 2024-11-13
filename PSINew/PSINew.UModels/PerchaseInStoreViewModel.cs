using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class PerchaseInStoreViewModel : BaseModel
    {
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        UnitBLL unitBLL = new UnitBLL();
        StoreBLL storeBLL = new StoreBLL();
        public PerchaseInStoreViewModel()
        {
            perchaseInfo = new PerchaseInStoreInfoModel();
            perGoodsList = new BindingList<PerGoodsModel>();
         
        }
        /// <summary>
        /// 开账状态
        /// </summary>
        private bool isOpened = false;
        public bool IsOpened
        {
            get => isOpened;
            set
            {
                isOpened = value;
                OnPropertyChanged();
            }
        }

        public bool IsShowUnOpenInfo
        {
            get
            {
                return !isOpened;
            }
        }

        public int PerId
        {
            get => perchaseInfo.PerId;
            set
            {
                perchaseInfo.PerId = value;
                OnPropertyChanged();
            }
        }

        private PerchaseInStoreInfoModel perchaseInfo;
        public PerchaseInStoreInfoModel PerchaseInfo
        {
            get
            {
                return perchaseInfo;
            }
            set
            {
                perchaseInfo = value;
                OnPropertyChanged();
            }
        }

        public string PerchaseNo
        {
            get => perchaseInfo.PerchaseNo;
            set
            {
                perchaseInfo.PerchaseNo = value;
                OnPropertyChanged();
            }
        }

        public int UnitId
        {
            get
            {
               return perchaseInfo.UnitId;
            }
            set
            {
                perchaseInfo.UnitId = value;
                OnPropertyChanged();
            }
        }

        private string  unitName;
        public string UnitName
        {
            get
            {
                return unitName;
            }
            set
            {
                unitName = value;
                OnPropertyChanged();
            }
        }

        public int StoreId
        {
            get => perchaseInfo.StoreId;
            set
            {
                perchaseInfo.StoreId = value;
                OnPropertyChanged();
            }
        }

        private string storeName;
        public string StoreName
        {
            get
            {
                return storeName;
            }
            set
            {
                storeName = value;
                OnPropertyChanged();
            }
        }

        public string DealPerson
        {
            get => perchaseInfo.DealPerson;
            set
            {
                perchaseInfo.DealPerson = value;
                OnPropertyChanged();
            }
        }

        public string PayDesp
        {
            get => perchaseInfo.PayDesp;
            set
            {
                perchaseInfo.PayDesp = value;
                OnPropertyChanged();
            }
        }

        public decimal ThisAmount
        {
            get => perchaseInfo.ThisAmount;
            set
            {
                perchaseInfo.ThisAmount = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => perchaseInfo.Remark;
            set
            {
                perchaseInfo.Remark = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get => perchaseInfo.TotalAmount;
            set
            {
                perchaseInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal YHAmount
        {
            get => perchaseInfo.YHAmount;
            set
            {
                perchaseInfo.YHAmount = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => perchaseInfo.Creator;
            set
            {
                perchaseInfo.Creator = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreateTime
        {
            get {
                if (perchaseInfo.PerId == 0)
                {
                    perchaseInfo.CreateTime = DateTime.Today;
                    return perchaseInfo.CreateTime;
                }
                    
                else 
                  return perchaseInfo.CreateTime; }
            set
            {
                perchaseInfo.CreateTime = value;
                OnPropertyChanged();
            }
        }

        public int IsChecked
        {
            get => perchaseInfo.IsChecked;
            set
            {
                perchaseInfo.IsChecked = value;
                OnPropertyChanged();
            }
        }

        private string checkState = "待审核";
        public string CheckState
        {
            get
            {
                GetCheckState();
                return checkState;
            }
        }

        public int IsPayed
        {
            get => perchaseInfo.IsPayed;
            set
            {
                perchaseInfo.IsPayed = value;
                OnPropertyChanged();
            }
        }

        public int IsPayFull
        {
            get => perchaseInfo.IsPayFull;
            set
            {
                perchaseInfo.IsPayFull = value;
                OnPropertyChanged();
            }
        }

        public string CheckPerson
        {
            get => perchaseInfo.CheckPerson;
            set
            {
                perchaseInfo.CheckPerson = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CheckTime
        {
            get
            {
               return perchaseInfo.CheckTime;
            }
            set
            {
                perchaseInfo.CheckTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime? PayTime
        {
            get => perchaseInfo.PayTime;
            set
            {
                perchaseInfo.PayTime = value;
                OnPropertyChanged();
            }
        }

        private BindingList<PerGoodsModel> perGoodsList;
        public BindingList<PerGoodsModel> PerGoodsList
        {
            get
            {
                return perGoodsList;
            }
            set
            {
                perGoodsList = value;
                OnPropertyChanged();
            }
        }

        private int totalCount = 0;
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
                OnPropertyChanged();
            }
        }

        public string TotalPageInfo
        {
            get
            {
                return $"共{perGoodsList.Count}条明细";
            }
        }


        public void GetPerGoodsList()
        {
            perGoodsList = new BindingList<PerGoodsModel>();
            if (this.PerId>0)
            {
                List<ViewPerGoodsInfoModel> perGoods = perBLL.GetPerGoodsList(this.PerId);
                perGoods.ForEach(g => perGoodsList.Add(new PerGoodsModel()
                {
                    PerGoodsInfo = g
                }));
                SumTotalInfo();
            }
        }

        public void SumTotalInfo()
        {
             if(PerGoodsList!=null)
            {
                totalCount = perGoodsList.Sum(g => g.PerCount);
                this.TotalAmount = perGoodsList.Sum(g => g.PerAmount);
                this.YHAmount = this.TotalAmount;
            }
        }

        public void GetCheckState()
        {
            switch (this.IsChecked)
            {
                case 0:
                    checkState = "待审核";
                    break;
                case 1:
                    checkState = "已审核";
                    break;
                case 2:
                    checkState = "已作废";//未审核作废
                    break;
                case 3:
                    checkState = "已红冲";//已审核作废称红冲
                    break;
            }
        }

        public void GetPerchaseInfo()
        {
            if (this.PerId > 0)
            {
                perchaseInfo = perBLL.GetPerchaseInfo(this.PerId);
            }
            if(perchaseInfo!=null)
            {
                if (perchaseInfo.UnitId > 0)
                    GetSupplierName();
                if (perchaseInfo.StoreId > 0)
                    GetStoreName();
            }
        }

        private void GetSupplierName()
        {
            if (perchaseInfo.UnitId > 0)
            {
                UnitInfoModel unit = unitBLL.GetUnitInfo(perchaseInfo.UnitId);
                if (unit != null)
                {
                    unitName = unit.UnitName;
                }
            }
        }

        private void GetStoreName()
        {
            if (perchaseInfo.StoreId > 0)
            {
                StoreInfoModel storeInfo = storeBLL.GetStoreInfo(perchaseInfo.StoreId);
                if (storeInfo != null)
                {
                    storeName = storeInfo.StoreName;
                }
            }
        }
    }
}
