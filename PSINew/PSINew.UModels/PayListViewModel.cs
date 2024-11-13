using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class PayListViewModel:BaseModel
    {
        private PayBLL payBLL = new PayBLL();

        private string payType;
        public string PayType
        {
            get => payType;
            set
            {
                payType = value;
                OnPropertyChanged();
            }
        }

        private string strPayFor;
        public string StrPayFor
        {
            get => strPayFor;
            set
            {
                strPayFor = value;
                OnPropertyChanged();
            }
        }

        private BindingList<PayVModel> payList = new BindingList<PayVModel>();
        public BindingList<PayVModel> PayList
        {
            get
            {
                return payList;
            }
            set
            {
                payList = value;
                OnPropertyChanged();
            }
        }

        public void GetPayList()
        {
            List<PayInfoModel> list = payBLL.GetFirstPayInfos(payType, strPayFor);
            payList = new BindingList<PayVModel>();
            list.ForEach(p => payList.Add(new PayVModel()
            {
                PayInfo = p
            }));
        }
    }
}
