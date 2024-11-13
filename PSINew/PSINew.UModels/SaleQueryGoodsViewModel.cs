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
    public class SaleQueryGoodsViewModel:BaseModel
    {
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        public SaleQueryGoodsViewModel()
        {
            saleList = new BindingList<SaleQGoodsModel>();
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

        private int gTypeId;
        public int GTypeId
        {
            get { return gTypeId; }
            set
            {
                gTypeId = value;
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
        /// 商品列表
        /// </summary>
        private BindingList<SaleQGoodsModel> saleList = new BindingList<SaleQGoodsModel>();
        public BindingList<SaleQGoodsModel> SaleList
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
        /// tlGoodsTypes数据源
        /// </summary>
        private List<GoodsTypeInfoModel> gTypeList;
        public List<GoodsTypeInfoModel> GTypeList
        {
            get
            {
                GetGTypeList();
                return gTypeList;
            }
            set
            {
                gTypeList = value;
            }
        }

        private void GetGTypeList()
        {
            gTypeList = gtBLL.LoadAllGoodsTypes();
            gTypeList.Insert(0, new GoodsTypeInfoModel()
            {
                GTypeId = 0,
                GTypeName = "商品类型"
            });
        }

        public QueryParaModel GetParaModel()
        {
            return new QueryParaModel()
            {
                UnitId = unitId,
                UnitName = unitName,
                StoreId = storeId,
                StoreName = storeName,
                GTypeId = gTypeId,
                GoodsName = goodsName,
                DealPerson = dealPerson
            };
        }

        public void GetSaleQueryList()
        {
            QueryParaModel pModel = GetParaModel();
            PageModel<SaleQueryGoodsModel> list = saleBLL.GetSaleDataByGoods(pModel, startIndex, pageSize);
            totalCount = list.TotalCount;
            saleList = new BindingList<SaleQGoodsModel>();
            list.ReList.ForEach(g => saleList.Add(new SaleQGoodsModel()
            {
                SaleGoodsInfo = g
            }));
        }
    }
}
