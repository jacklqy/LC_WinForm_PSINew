using PSINew.BLL;
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
    public class SheetQueryViewModel : BaseModel
    {
        SheetQueryBLL sheetBLL = new SheetQueryBLL();
        public SheetQueryViewModel()
        {
            sheetList = new BindingList<SheetInfoModel>();
            GetCheckStates();
            GetShTypeList();
        }

        private int unitId;
        public int UnitId
        {
            get => unitId;
            set
            {
                unitId = value;
                OnPropertyChanged();
            }
        }
        private string goodsName;
        public string GoodsName
        {
            get { return goodsName; }
            set
            {
                goodsName = value;
                OnPropertyChanged();
            }
        }

        private int storeId;
        public int StoreId
        {
            get { return storeId; }
            set
            {
                storeId = value;
                OnPropertyChanged();
            }
        }

        private string storeName;
        public string StoreName
        {
            get { return storeName; }
            set
            {
                storeName = value;
                OnPropertyChanged();
            }
        }

        private string unitName;
        public string UnitName
        {
            get { return unitName; }
            set
            {
                unitName = value;
                OnPropertyChanged();
            }
        }

        private string dealPerson;
        public string DealPerson
        {
            get { return dealPerson; }
            set
            {
                dealPerson = value;
                OnPropertyChanged();
            }
        }

        private string sheetNo;
        public string SheetNo
        {
            get { return sheetNo; }
            set
            {
                sheetNo = value;
                OnPropertyChanged();
            }
        }
        private int isChecked=-1;
        public int IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }
        private string creator;
        public string Creator
        {
            get { return creator; }
            set
            {
                creator = value;
                OnPropertyChanged();
            }
        }
        private string checkPerson;
        public string CheckPerson
        {
            get { return checkPerson; }
            set
            {
                checkPerson = value;
                OnPropertyChanged();
            }
        }
        private int shType=1;
        public int ShType
        {
            get { return shType; }
            set
            {
                shType = value;
                OnPropertyChanged();
            }
        }

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

        private List<CheckModel> checkStateList;
        public List<CheckModel> CheckStateList
        {
            get => checkStateList;
        }

        private List<SheetModel> shTypeList;
        public List<SheetModel> ShTypeList
        {
            get => shTypeList;
        }

        private BindingList<SheetInfoModel> sheetList;
        public BindingList<SheetInfoModel> SheetList
        {
            get {
                GetSheetList();
                return sheetList;
            }
            set
            {
                sheetList = value;
                OnPropertyChanged();
            }
        }

        public void GetSheetList()
        {
            ShQueryParaModel paraModel = GetParaModel();
            PageModel<SheetInfoModel> list = sheetBLL.GetSheetList(paraModel, startIndex, pageSize);
            totalCount = list.TotalCount;
            sheetList = new BindingList<SheetInfoModel>();
            list.ReList.ForEach(s => sheetList.Add(s));
        }

        public ShQueryParaModel GetParaModel()
        {
            return new ShQueryParaModel()
            {
                SheetNo = sheetNo,
                UnitId = unitId,
                UnitName = unitName,
                StoreId = storeId,
                StoreName = storeName,
                ShType = shType,
                Creator = creator,
                CheckPerson = checkPerson,
                DealPerson = dealPerson,
                GoodsName = goodsName,
                IsChecked = isChecked
            };
        }

        private void GetCheckStates()
        {
            List<CheckModel> checkList = sheetBLL.GetCheckList();
            checkList.Insert(0, new CheckModel()
            {
                CheckId = -1,
                CheckState = "全部"
            });
            checkStateList = checkList;
        }

        private void GetShTypeList()
        {
            shTypeList = new List<SheetModel>()
            {
                new SheetModel(){ShTypeId=1,ShTypeName="采购入库单",ParentId=0},
                 new SheetModel(){ShTypeId=2,ShTypeName="销售出库单",ParentId=0},
                  new SheetModel(){ShTypeId=3,ShTypeName="期初入库单",ParentId=0}
            };
        }
    }
}
