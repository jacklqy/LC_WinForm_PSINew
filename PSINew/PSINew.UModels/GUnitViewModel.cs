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
    public class GUnitViewModel:BaseModel
    {
        private GoodsUnitBLL guBLL = new GoodsUnitBLL();
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

        private BindingList<GUnitModel> gunitList = new BindingList<GUnitModel>();
        public BindingList<GUnitModel> GUnitList
        {
            get
            {
                GetGUnitList();
                return gunitList;
            }
            set
            {
                gunitList = value;
                OnPropertyChanged();
            }
        }

        public void GetGUnitList()
        {
            List<GoodsUnitInfoModel> list = guBLL.GetAllUnits(isShowDel);
            gunitList = new BindingList<GUnitModel>();
            list.ForEach(g => gunitList.Add(new GUnitModel()
            {
                GUnitInfo = g
            }));
        }
    }
}
