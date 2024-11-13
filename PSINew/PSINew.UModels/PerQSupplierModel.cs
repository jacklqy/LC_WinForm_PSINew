using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class PerQSupplierModel:BaseModel
    {
        public PerQSupplierModel()
        {
            perSupplierInfo = new PerQuerySupplierModel();
        }
        public int Id
        {
            get => perSupplierInfo.Id;
            set
            {
                perSupplierInfo.Id = value;
                OnPropertyChanged();
            }
        }
        public int UnitId
        {
            get => perSupplierInfo.UnitId;
            set
            {
                perSupplierInfo.UnitId = value;
                OnPropertyChanged();
            }
        }
        public string UnitName
        {
            get => perSupplierInfo.UnitName;
            set
            {
                perSupplierInfo.UnitName = value;
                OnPropertyChanged();
            }
        }
        public int TotalCount
        {
            get => perSupplierInfo.TotalCount;
            set
            {
                perSupplierInfo.TotalCount = value;
                OnPropertyChanged();
            }
        }
        public decimal AvgPrice
        {
            get => perSupplierInfo.AvgPrice;
            set
            {
                perSupplierInfo.AvgPrice = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalAmount
        {
            get => perSupplierInfo.TotalAmount;
            set
            {
                perSupplierInfo.TotalAmount = value;
                OnPropertyChanged();
            }
        }
        public decimal TotalYHAmount
        {
            get => perSupplierInfo.TotalYHAmount;
            set
            {
                perSupplierInfo.TotalYHAmount = value;
                OnPropertyChanged();
            }
        }

        private PerQuerySupplierModel perSupplierInfo;
        public PerQuerySupplierModel PerSupplierInfo
        {
            get
            {
                return perSupplierInfo;
            }
            set
            {
                perSupplierInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
