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
    public class StockUpDownSetViewModel:BaseModel
    {
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        StockBLL stockBLL = new StockBLL();
        public StockUpDownSetViewModel()
        {
            goodsUpDownList = new BindingList<GoodsStockUpDownModel>();
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

        /// <summary>
        /// 商品类别号
        /// </summary>
        private int gTypeId;
        public int GTypeId
        {
            get => gTypeId;
            set { gTypeId = value; OnPropertyChanged(); }
        }

        private bool isSetMore = false;
        public bool IsSetMore
        {
            get => isSetMore;
            set
            {
                isSetMore = value;
                OnPropertyChanged();
            }
        }

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
                GTypeName = "商品类别"
            });
        }

        private BindingList<GoodsStockUpDownModel> goodsUpDownList;
        public BindingList<GoodsStockUpDownModel> GoodsUpDownList
        {
            get
            {
                return goodsUpDownList;
            }
            set
            {
                goodsUpDownList = value;
                OnPropertyChanged();
            }
        }

        private List<ViewStoreStockUpDownModel> listStart;
        public List<ViewStoreStockUpDownModel> ListStart
        {
            get
            {
                return listStart;
            }
            set
            {
                listStart = value;
            }
        }

        public void GetGoodsUpDownList()
        {
            List<ViewStoreStockUpDownModel> list = stockBLL.GetGoodsStockUpDownList(gTypeId, storeId);
            goodsUpDownList = new BindingList<GoodsStockUpDownModel>();
            listStart = stockBLL.GetGoodsStockUpDownList(gTypeId, storeId); 
            list.ForEach(g =>
            {
                goodsUpDownList.Add(new GoodsStockUpDownModel()
                {
                    StoreUpDown = g
                });
            });
            isSetMore = list.Count > 0 ? true : false;
        }
    }
}
