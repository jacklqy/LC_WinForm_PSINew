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
    public class SaleOutStoreViewModel:BaseModel
    {
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        UnitBLL unitBLL = new UnitBLL();
        StoreBLL storeBLL = new StoreBLL();
        public SaleOutStoreViewModel()
        {
            saleInfo = new SaleOutStoreInfoModel();
             saleGoodsList= new BindingList<SaleGoodsModel>();

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
            get => !isOpened;
        }

        public int SaleId
        {
            get => saleInfo.SaleId;
            set
            {
                saleInfo.SaleId = value;
                OnPropertyChanged();
            }
        }

        private SaleOutStoreInfoModel saleInfo;
        public SaleOutStoreInfoModel SaleInfo
        {
            get
            {
                return saleInfo;
            }
            set
            {
                saleInfo = value;
                OnPropertyChanged();
            }
        }

        public string SaleOutNo
        {
            get => saleInfo.SaleOutNo;
            set
            {
                saleInfo.SaleOutNo = value;
                OnPropertyChanged();
            }
        }

        public int UnitId
        {
            get
            {
                return saleInfo.UnitId;
            }
            set
            {
                saleInfo.UnitId = value;
                OnPropertyChanged();
            }
        }

        private string unitName;
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
            get => saleInfo.StoreId;
            set
            {
                saleInfo.StoreId = value;
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
            get => saleInfo.DealPerson;
            set
            {
                saleInfo.DealPerson = value;
                OnPropertyChanged();
            }
        }

        public string PayDesp
        {
            get => saleInfo.PayDesp;
            set
            {
                saleInfo.PayDesp = value;
                OnPropertyChanged();
            }
        }

        public decimal ThisAmount
        {
            get => saleInfo.ThisAmount;
            set
            {
                saleInfo.ThisAmount = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => saleInfo.Remark;
            set
            {
                saleInfo.Remark = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get => saleInfo.TotalAmount;
            set
            {
                saleInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal YHAmount
        {
            get => saleInfo.YHAmount;
            set
            {
                saleInfo.YHAmount = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => saleInfo.Creator;
            set
            {
                saleInfo.Creator = value;
                OnPropertyChanged();
            }
        }

        public DateTime CreateTime
        {
            get
            {
                if (saleInfo.SaleId == 0)
                {
                    saleInfo.CreateTime = DateTime.Today;
                    return saleInfo.CreateTime;
                }

                else
                    return saleInfo.CreateTime;
            }
            set
            {
                saleInfo.CreateTime = value;
                OnPropertyChanged();
            }
        }

        public int IsChecked
        {
            get => saleInfo.IsChecked;
            set
            {
                saleInfo.IsChecked = value;
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
            get => saleInfo.IsPayed;
            set
            {
                saleInfo.IsPayed = value;
                OnPropertyChanged();
            }
        }

        public int IsPayFull
        {
            get => saleInfo.IsPayFull;
            set
            {
                saleInfo.IsPayFull = value;
                OnPropertyChanged();
            }
        }

        public string CheckPerson
        {
            get => saleInfo.CheckPerson;
            set
            {
                saleInfo.CheckPerson = value;
                OnPropertyChanged();
            }
        }

        public DateTime? CheckTime
        {
            get
            {
                return saleInfo.CheckTime;
            }
            set
            {
                saleInfo.CheckTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime? PayTime
        {
            get => saleInfo.PayTime;
            set
            {
                saleInfo.PayTime = value;
                OnPropertyChanged();
            }
        }

        private BindingList<SaleGoodsModel> saleGoodsList;
        public BindingList<SaleGoodsModel> SaleGoodsList
        {
            get
            {
                return saleGoodsList;
            }
            set
            {
                saleGoodsList = value;
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
                return $"共{saleGoodsList.Count}条明细";
            }
        }


        public void GetSaleGoodsList()
        {
            saleGoodsList = new BindingList<SaleGoodsModel>();
            if (this.SaleId > 0)
            {
                List<ViewSaleGoodsInfoModel> saleGoods = saleBLL.GetSaleGoodsList(this.SaleId);
                saleGoods.ForEach(g => saleGoodsList.Add(new SaleGoodsModel()
                {
                    SaleGoodsInfo = g
                }));
                SumTotalInfo();
            }
        }

        public void SumTotalInfo()
        {
            if (saleGoodsList != null)
            {
                totalCount = saleGoodsList.Sum(g => g.SaleCount);
                this.TotalAmount = saleGoodsList.Sum(g => g.SaleAmount);
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

        public void GetsaleInfo()
        {
            if (this.SaleId > 0)
            {
                saleInfo = saleBLL.GetSaleInfo(this.SaleId);
            }
            if (saleInfo != null)
            {
                if (saleInfo.UnitId > 0)
                    GetCustomerName();
                if (saleInfo.StoreId > 0)
                    GetStoreName();
            }
        }

        private void GetCustomerName()
        {
            if (saleInfo.UnitId > 0)
            {
                UnitInfoModel unit = unitBLL.GetUnitInfo(saleInfo.UnitId);
                if (unit != null)
                {
                    unitName = unit.UnitName;
                }
            }
        }

        private void GetStoreName()
        {
            if (saleInfo.StoreId > 0)
            {
                StoreInfoModel storeInfo = storeBLL.GetStoreInfo(saleInfo.StoreId);
                if (storeInfo != null)
                {
                    storeName = storeInfo.StoreName;
                }
            }
        }
    }
}
