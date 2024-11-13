using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class ChooseUnitsViewModel:BaseModel
    {
        UnitBLL unitBLL = new UnitBLL();
        UnitTypeBLL utBLL = new UnitTypeBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords = "";
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }

        /// <summary>
        /// 单位类别号
        /// </summary>
        private int uTypeId;
        public int UTypeId { get => uTypeId; set { uTypeId = value; OnPropertyChanged(); } }

        /// <summary>
        /// 单位类别名称
        /// </summary>
        private string uTypeName;
        public string UTypeName { get => uTypeName; set { uTypeName = value; OnPropertyChanged(); } }
       
        /// <summary>
        /// 单位列表
        /// </summary>
        private BindingList<UnitModel> unitList = new BindingList<UnitModel>();
        public BindingList<UnitModel> UnitList
        {
            get
            {
                GetUnitList();
                return unitList;
            }
            set
            {
                unitList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// tlUnItTypes数据源
        /// </summary>
        private List<UnitTypeInfoModel> uTypeList;
        public List<UnitTypeInfoModel> UTypeList
        {
            get
            {
                GetUTypeList();
                return uTypeList;
            }
            set
            {
                uTypeList = value;
                OnPropertyChanged();
            }
        }

        public void GetUTypeList()
        {
            uTypeList = utBLL.LoadAllTVUnitTypes();
            uTypeList.Insert(0, new UnitTypeInfoModel()
            {
                UTypeId = 0,
                UTypeName = "往来单位类型"
            });
        }
        public void GetUnitList()
        {
            List<UnitInfoModel> list = unitBLL.GetUnitList(uTypeId,uTypeName,keywords);
            unitList = new BindingList<UnitModel>();
            list.ForEach(u => unitList.Add(new UnitModel()
            {
                UnitId = u.UnitId,
                UnitName = u.UnitName,
                UnitNo = u.UnitNo,
                UnitPYNo = u.UnitPYNo,
                UTypeId = u.UTypeId,
                ContactPerson = u.ContactPerson,
                PhoneNumber=u.PhoneNumber,
                Telephone = u.Telephone,
                FullAddress = u.FullAddress
            }));
        }
    }
}
