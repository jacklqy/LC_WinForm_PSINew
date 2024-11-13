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
    public  class STypeListViewModel:BaseModel
    {
        private StoreTypeBLL stBLL = new StoreTypeBLL();
        private bool isShowDel;
        public bool IsShowDel
        {
            get { return isShowDel; }
            set
            {
                isShowDel = value;
                OnPropertyChanged();
            }
        }

        private BindingList<STypeModel> stypeList = new BindingList<STypeModel>();
        public BindingList<STypeModel> STypeList
        {
            get
            {
                GetSTypeList();
                return stypeList;
            }
            set
            {
                stypeList = value;
                OnPropertyChanged();
            }
        }

        public void GetSTypeList()
        {
            List<StoreTypeInfoModel> list = stBLL.LoadAllStoreTypes(isShowDel);
            stypeList = new BindingList<STypeModel>();
            list.ForEach(g => stypeList.Add(new STypeModel()
            {
                STypeInfo = g
            }));
        }
    }
}
