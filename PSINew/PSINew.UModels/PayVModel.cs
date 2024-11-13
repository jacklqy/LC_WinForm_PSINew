using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class PayVModel:BaseModel
    {
        public PayVModel()
        {
            payinfo = new PayInfoModel();
        }
        private PayInfoModel payinfo;
        public PayInfoModel PayInfo
        {
            get => payinfo;
            set
            {
                payinfo = value;
                OnPropertyChanged();
            }
        }
        public int PayId {
            get => payinfo.PayId;
            set
            {
                payinfo.PayId = value;
                OnPropertyChanged();
            }
        }
        public string PayName
        {
            get => payinfo.PayName;
            set
            {
                payinfo.PayName = value;
                OnPropertyChanged();
            }
        }

        public decimal PayMoney
        {
            get => payinfo.PayMoney;
            set
            {
                payinfo.PayMoney = value;
                OnPropertyChanged();
            }
        }
        public string PayType
        {
            get => payinfo.PayType;
            set
            {
                payinfo.PayType = value;
                OnPropertyChanged();
            }
        }
    }
}
