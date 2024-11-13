using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
     public class UnitListViewModel:BaseModel
    {
        UnitBLL unitBLL = new UnitBLL();
        UnitTypeBLL utBLL = new UnitTypeBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords = "";
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value; OnPropertyChanged(); } }

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
        /// 分页开始索引
        /// </summary>
        private int startIndex = 1;
        public int StartIndex { get => startIndex; set { startIndex = value; OnPropertyChanged(); } }
        /// <summary>
        /// 分页每页显示数
        /// </summary>
        private int pageSize = 10;
        public int PageSize { get => pageSize; set { pageSize = value; OnPropertyChanged(); } }

        /// <summary>
        /// 总记录数
        /// </summary>
        private int totalCount;
        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                OnPropertyChanged();
            }
        }
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
            PageModel<ViewUnitInfoModel> list = unitBLL.GetUnitList(uTypeId, keywords, isShowDel, startIndex, pageSize);
            totalCount = list.TotalCount;
            unitList = new BindingList<UnitModel>();
            list.ReList.ForEach(u => unitList.Add(new UnitModel()
            {
                UnitId = u.UnitId,
                UnitName = u.UnitName,
                UnitNo = u.UnitNo,
                UnitPYNo = u.UnitPYNo,
                RegionId = u.RegionId,
                UTypeId = u.UTypeId,
                UTypeName = u.UTypeName,
                UnitProperties = u.UnitProperties,
                ContactPerson = u.ContactPerson,
                IsNoVail = u.IsNoVail,
                Address=u.Address,
                FullAddress=u.FullAddress
            }));
        }
    }
}
