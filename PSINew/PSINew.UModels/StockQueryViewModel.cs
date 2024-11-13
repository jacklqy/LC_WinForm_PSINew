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
    public class StockQueryViewModel : BaseModel
    {
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        StockBLL stockBLL = new StockBLL();
        public StockQueryViewModel()
        {
            stockList = new BindingList<StockQGoodsModel>();
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


        /// <summary>
        /// 商品类别号
        /// </summary>
        private int gTypeId;
        public int GTypeId
        {
            get => gTypeId;
            set { gTypeId = value; OnPropertyChanged(); }
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

        /// <summary>
        /// 商品列表
        /// </summary>
        private BindingList<StockQGoodsModel> stockList = new BindingList<StockQGoodsModel>();
        public BindingList<StockQGoodsModel> StockList
        {
            get
            {
                GetStockQueryList();
                return stockList;
            }
            set
            {
                stockList = value;
                OnPropertyChanged();
            }
        }

        private bool isDistribute = false;
        public bool IsDistribute
        {
            get
            {
                return isDistribute;
            }
            set
            {
                isDistribute = value;
                OnPropertyChanged();
            }
        }



        public void GetStockQueryList()
        {
            StockQueryParaModel pModel = GetParaModel();
            List<StoreStockQueryModel> list = stockBLL.GetStoreStockData(pModel);
            stockList = new BindingList<StockQGoodsModel>();
            list.ForEach(g => stockList.Add(new StockQGoodsModel()
            {
                StockQModel = g
            }));
            if (stockList.Count > 0)
            {
                isDistribute = true;
            }
            else
            {
                isDistribute = true;
            }
        }

        public StockQueryParaModel GetParaModel()
        {
            return new StockQueryParaModel()
            {
                StoreId = storeId,
                StoreName = storeName,
                GTypeId = gTypeId,
                GoodsName = goodsName,
            };
        }
    }
}
