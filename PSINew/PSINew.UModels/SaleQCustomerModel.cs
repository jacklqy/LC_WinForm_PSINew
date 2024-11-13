using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class SaleQCustomerModel : BaseModel
    {
        public SaleQCustomerModel()
        {
            saleCustInfo = new SaleQueryCustomerModel();
        }
        public int Id
        {
            get => saleCustInfo.Id;
            set
            {
                saleCustInfo.Id = value;
                OnPropertyChanged();
            }
        }
        public int UnitId
        {
            get => saleCustInfo.UnitId;
            set
            {
                saleCustInfo.UnitId = value;
                OnPropertyChanged();
            }
        }
        public string UnitName
        {
            get => saleCustInfo.UnitName;
            set
            {
                saleCustInfo.UnitName = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => saleCustInfo.TotalCount;
            set
            {
                saleCustInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
        public decimal AvgPrice
        {
            get => saleCustInfo.AvgPrice;
            set
            {
                saleCustInfo.AvgPrice = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalAmount
        {
            get => saleCustInfo.TotalAmount;
            set
            {
                saleCustInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalYHAmount
        {
            get => saleCustInfo.TotalYHAmount;
            set
            {
                saleCustInfo.TotalYHAmount = value;
                OnPropertyChanged();
            }
        }


        public decimal TotalStAmount
        {
            get => saleCustInfo.TotalStAmount;
            set
            {
                saleCustInfo.TotalStAmount = value;
                OnPropertyChanged();
            }
        }

        private SaleQueryCustomerModel saleCustInfo;
        public SaleQueryCustomerModel SaleCustInfo
        {
            get
            {
                return saleCustInfo;
            }
            set
            {
                saleCustInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
