using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class STypeModel:BaseModel
    {
        private StoreTypeBLL stBLL = new StoreTypeBLL();
        private StoreTypeInfoModel stmodel;
        public STypeModel()
        {
            stmodel = new StoreTypeInfoModel();
        }


        public StoreTypeInfoModel STypeInfo
        {
            get
            {
                return stmodel;
            }
            set
            {
                stmodel = value;
                OnPropertyChanged();
            }
        }

        public int STypeId
        {
            get { return stmodel.STypeId; }
            set
            {
                stmodel.STypeId = value;
                OnPropertyChanged();
            }
        }

        public string STypeName
        {
            get { return stmodel.STypeName; }
            set
            {
                stmodel.STypeName = value;
                OnPropertyChanged();
            }
        }

        public string STPYNo
        {
            get { return stmodel.STPYNo; }
            set
            {
                stmodel.STPYNo = value;
                OnPropertyChanged();
            }
        }

        public int STypeOrder
        {
            get { return stmodel.STypeOrder; }
            set
            {
                stmodel.STypeOrder = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get { return stmodel.Creator; }
            set
            {
                stmodel.Creator = value;
                OnPropertyChanged();
            }
        }
    }
}
