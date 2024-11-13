using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class UTypeModel:BaseModel
    {
        private UnitTypeInfoModel uTypeInfo;
        public UTypeModel()
        {
            uTypeInfo = new UnitTypeInfoModel();
        }
        public UnitTypeInfoModel UTypeInfo
        {
            get => uTypeInfo;
            set
            {
                uTypeInfo = value;
                OnPropertyChanged();
            }
        }
        public int UTypeId
        {
            get => uTypeInfo.UTypeId;
            set
            {
                uTypeInfo.UTypeId = value;
                OnPropertyChanged();
            }
        }

        public string UTypeName
        {
            get => uTypeInfo.UTypeName;
            set
            {
                uTypeInfo.UTypeName = value;
                OnPropertyChanged();
            }
        }

        public int? ParentId
        {
            get => uTypeInfo.ParentId;
            set
            {
                uTypeInfo.ParentId = value;
                OnPropertyChanged();
            }
        }

        public string ParentName
        {
            get => uTypeInfo.ParentName;
            set
            {
                uTypeInfo.ParentName = value;
                OnPropertyChanged();
            }
        }

        public string UTypeNo
        {
            get => uTypeInfo.UTypeNo;
            set
            {
                uTypeInfo.UTypeNo = value;
                OnPropertyChanged();
            }
        }

        public string UTPYNo
        {
            get => uTypeInfo.UTPYNo;
            set
            {
                uTypeInfo.UTPYNo = value;
                OnPropertyChanged();
            }
        }

        public int UTOrder
        {
            get => uTypeInfo.UTOrder;
            set
            {
                uTypeInfo.UTOrder = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => uTypeInfo.Creator;
            set
            {
                uTypeInfo.Creator = value;
                OnPropertyChanged();
            }
        }
    }
}
