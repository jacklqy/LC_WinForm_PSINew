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
    public class SaleQueryStoreViewModel:BaseModel
    {
        StoreTypeBLL stBLL = new StoreTypeBLL();
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        public SaleQueryStoreViewModel()
        {
            saleList = new BindingList<SaleQStoreModel>();
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

        private int unitId;
        public int UnitId
        {
            get { return unitId; }
            set
            {
                unitId = value;
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

        private int sTypeId;
        public int STypeId
        {
            get { return sTypeId; }
            set
            {
                sTypeId = value;
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
        /// <summary>
        /// 采购统计列表
        /// </summary>
        private BindingList<SaleQStoreModel> saleList = new BindingList<SaleQStoreModel>();
        public BindingList<SaleQStoreModel> SaleList
        {
            get
            {
                GetSaleQueryList();
                return saleList;
            }
            set
            {
                saleList = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// tlStoreTypes数据源
        /// </summary>
        private List<StoreTypeInfoModel> sTypeList;
        public List<StoreTypeInfoModel> STypeList
        {
            get
            {
                GetSTypeList();
                return sTypeList;
            }
            set
            {
                sTypeList = value;
            }
        }

        private void GetSTypeList()
        {
            sTypeList = stBLL.LoadAllDrpStoreTypes();
            sTypeList.Insert(0, new StoreTypeInfoModel()
            {
                STypeId = 0,
                STypeName = "所有仓库"
            });
        }

        public QueryParaModel GetParaModel()
        {
            return new QueryParaModel()
            {
                UnitId = unitId,
                UnitName = unitName,
                StoreName = storeName,
                GoodsName = goodsName,
                DealPerson = dealPerson,
                STypeId = sTypeId
            };
        }

        public void GetSaleQueryList()
        {
            QueryParaModel pModel = GetParaModel();
            PageModel<SaleQueryStoreModel> list = saleBLL.GetSaleDataByStore(pModel, startIndex, pageSize);
            totalCount = list.TotalCount;
            saleList = new BindingList<SaleQStoreModel>();
            list.ReList.ForEach(g => saleList.Add(new SaleQStoreModel()
            {
                SaleStoreInfo = g
            }));
        }
    }
}
