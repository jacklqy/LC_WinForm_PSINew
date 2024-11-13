using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class UnitModel:BaseModel
    {
        UnitBLL unitBLL = new UnitBLL();
        UnitTypeBLL utBLL = new UnitTypeBLL();
        RegionBLL regionBLL = new RegionBLL();
        private UnitInfoModel unitInfo;
        public UnitModel()
        {
            unitInfo = new UnitInfoModel();
        }
        public UnitInfoModel UnitInfo
        {
            get
            {
                return unitInfo;
            }
            set
            {
                unitInfo = value;
                OnPropertyChanged();
            }
        }

        public int UnitId
        {
            get => unitInfo.UnitId;
            set
            {
                unitInfo.UnitId = value;
              
                OnPropertyChanged();
            }
        }

        public string UnitName
        {
            get => unitInfo.UnitName;
            set
            {
                unitInfo.UnitName = value;
                OnPropertyChanged();
            }
        }

        public int UTypeId
        {
            get => unitInfo.UTypeId;
            set
            {
                unitInfo.UTypeId = value;
                GetUTypeName();
                OnPropertyChanged();
            }
        }

        private string uTypeName;
        public string  UTypeName
        {
            get => uTypeName;
            set
            {
                uTypeName = value;
                OnPropertyChanged();
            }
        }

        public string UnitProperties
        {
            get => unitInfo.UnitProperties;
            set
            {
                unitInfo.UnitProperties = value;
                OnPropertyChanged();
            }
        }

        public int RegionId
        {
            get => unitInfo.RegionId;
            set
            {
                unitInfo.RegionId = value;
                GetRegion();
                OnPropertyChanged();
            }
        }

        private int provinceId;
        public int ProvinceId
        {
            get {
                GetProvinceId();
                return provinceId;
            }
        }

        private int cityId;
        public int CityId
        {
            get
            {
                GetCityId();
                return cityId;
            }
        }

        private int countryId;
        public int CountryId
        {
            get
            {
                GetCountryId();
                return countryId;
            }
        }

        public string NationName
        {
            get
            {
                return regionBLL.GetRegion(1).RegionName;
            }
        }



        private RegionInfoModel regionInfo=new RegionInfoModel();
        public RegionInfoModel RegionInfo
        {
            get => regionInfo;
            set
            {
                regionInfo = value;
                OnPropertyChanged();
            }
        }

        public string UnitPYNo
        {
            get => unitInfo.UnitPYNo;
            set
            {
                unitInfo.UnitPYNo = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => unitInfo.Address;
            set
            {
                unitInfo.Address = value;
                OnPropertyChanged();
            }
        }

        public string UnitNo
        {
            get => unitInfo.UnitNo;
            set
            {
                unitInfo.UnitNo = value;
                OnPropertyChanged();
            }
        }

        public string Remark
        {
            get => unitInfo.Remark;
            set
            {
                unitInfo.Remark = value;
                OnPropertyChanged();
            }
        }

        public string ContactPerson
        {
            get => unitInfo.ContactPerson;
            set
            {
                unitInfo.ContactPerson = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => unitInfo.PhoneNumber;
            set
            {
                unitInfo.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get => unitInfo.Telephone;
            set
            {
                unitInfo.Telephone = value;
                OnPropertyChanged();
            }
        }

        public string Fax
        {
            get => unitInfo.Fax;
            set
            {
                unitInfo.Fax = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => unitInfo.Email;
            set
            {
                unitInfo.Email = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => unitInfo.PostalCode;
            set
            {
                unitInfo.PostalCode = value;
                OnPropertyChanged();
            }
        }

        public string FullAddress
        {
            get {
                return  unitInfo.FullAddress;
            }
            set
            {
                unitInfo.FullAddress = value;
                OnPropertyChanged();
            }
        }


        public string Creator
        {
            get => unitInfo.Creator;
            set
            {
                unitInfo.Creator = value;
                OnPropertyChanged();
            }
        }

        public int IsNoVail
        {
            get => unitInfo.IsNoVail;
            set
            {
                unitInfo.IsNoVail = value;
                OnPropertyChanged();
            }
        }
        public void GetRegion()
        {
            if (unitInfo.RegionId > 0)
            {
                regionInfo = regionBLL.GetRegion(unitInfo.RegionId);
            }
        }

        public void GetProvinceId()
        {
            if (unitInfo.RegionId > 0)
            {
                GetRegion();
                if (regionInfo != null && regionInfo.RegionId > 0)
                {
                    switch (regionInfo.RegionLevel)
                    {
                        case 1:
                            provinceId = regionInfo.RegionId;
                            break;
                        case 2:
                            provinceId = regionInfo.ParentId;
                            break;
                        case 3:
                            RegionInfoModel secInfo = regionBLL.GetRegion(regionInfo.ParentId);
                            if (secInfo != null)
                                provinceId = secInfo.ParentId;
                            break;
                    }
                }
            }
           
        }

        public void GetCityId()
        {
            if (unitInfo.RegionId > 0)
            {
                GetRegion();
                if (regionInfo != null && regionInfo.RegionId > 0)
                {
                    switch (regionInfo.RegionLevel)
                    {
                        case 1:
                            cityId = 0;
                            break;
                        case 2:
                            cityId = regionInfo.RegionId;
                            break;
                        case 3:
                            cityId = regionInfo.ParentId;
                            break;
                    }
                }
            }
        }

        public void GetCountryId()
        {
            if (unitInfo.RegionId > 0)
            {
                GetRegion();
                if (regionInfo != null && regionInfo.RegionId > 0)
                {
                    switch (regionInfo.RegionLevel)
                    {
                        case 1:
                        case 2:
                            countryId = 0;
                            break;
                        case 3:
                            countryId = regionInfo.RegionId;
                            break;
                    }
                }
            }
        }

        public void GetRegionAddress()
        {
             if(this.RegionId>0)
            {
                unitInfo.FullAddress = regionBLL.GetRegionAddress(this.RegionId)+Address;
            }
        }

        public void GetUTypeName()
        {
            if (this.UTypeId > 0)
            {
                UnitTypeInfoModel uType = utBLL.GetUnitType(this.UTypeId);
                if (uType != null)
                    uTypeName = uType.UTypeName;
            }
                
        }

        public void GetUnitInfo()
        {
            unitInfo = unitBLL.GetUnitInfo(unitInfo.UnitId);
            GetUTypeName();
        }
    }
}
