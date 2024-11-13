using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GUnitModel:BaseModel
    {
        private GoodsUnitBLL guBLL = new GoodsUnitBLL();
        private GoodsUnitInfoModel gumodel;
        public GUnitModel()
        {
            gumodel = new GoodsUnitInfoModel();
        }

      
        public GoodsUnitInfoModel GUnitInfo
        {
            get
            {
                return gumodel;
            }
            set
            {
                gumodel = value;
                OnPropertyChanged();
            }
        }

        public int GUnitId
        {
            get { return gumodel.GUnitId; }
            set
            {
                gumodel.GUnitId = value;
                OnPropertyChanged();
            }
        }

        public string GUnitName
        {
            get { return gumodel.GUnitName; }
            set
            {
                gumodel.GUnitName = value;
                OnPropertyChanged();
            }
        }

        public string GUnitPYNo
        {
            get { return gumodel.GUnitPYNo; }
            set
            {
                gumodel.GUnitPYNo = value;
                OnPropertyChanged();
            }
        }

        public int GUnitOrder
        {
            get { return gumodel.GUnitOrder; }
            set
            {
                gumodel.GUnitOrder = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get { return gumodel.Creator; }
            set
            {
                gumodel.Creator = value;
                OnPropertyChanged();
            }
        }
    }
}
