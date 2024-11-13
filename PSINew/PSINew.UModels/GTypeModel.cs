using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GTypeModel : BaseModel
    {
        private GoodsTypeInfoModel gTypeInfo;
        public GTypeModel()
        {
            gTypeInfo = new GoodsTypeInfoModel();
        }
        public GoodsTypeInfoModel GTypeInfo
        {
            get => gTypeInfo;
            set
            {
                gTypeInfo = value;
                OnPropertyChanged();
            }
        }
        public int GTypeId
        {
            get => gTypeInfo.GTypeId;
            set
            {
                gTypeInfo.GTypeId = value;
                OnPropertyChanged();
            }
        }

        public string GTypeName
        {
            get => gTypeInfo.GTypeName;
            set
            {
                gTypeInfo.GTypeName = value;
                OnPropertyChanged();
            }
        }

        public int? ParentId
        {
            get => gTypeInfo.ParentId;
            set
            {
                gTypeInfo.ParentId = value;
                OnPropertyChanged();
            }
        }

        public string ParentName
        {
            get => gTypeInfo.ParentName;
            set
            {
                gTypeInfo.ParentName = value;
                OnPropertyChanged();
            }
        }

        public string GTypeNo
        {
            get => gTypeInfo.GTypeNo;
            set
            {
                gTypeInfo.GTypeNo = value;
                OnPropertyChanged();
            }
        }

        public string GTPYNo
        {
            get => gTypeInfo.GTPYNo;
            set
            {
                gTypeInfo.GTPYNo = value;
                OnPropertyChanged();
            }
        }

        public int GTOrder
        {
            get => gTypeInfo.GTOrder;
            set
            {
                gTypeInfo.GTOrder = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get => gTypeInfo.Creator;
            set
            {
                gTypeInfo.Creator = value;
                OnPropertyChanged();
            }
        }
    }
}
