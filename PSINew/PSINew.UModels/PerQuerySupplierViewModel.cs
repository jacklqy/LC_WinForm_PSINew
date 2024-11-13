﻿using PSINew.BLL;
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
    public class PerQuerySupplierViewModel:BaseModel
    {
        UnitTypeBLL utBLL = new UnitTypeBLL();
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        public PerQuerySupplierViewModel()
        {
            perList = new BindingList<PerQSupplierModel>();
        }

        private string goodsName;

        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value;
                OnPropertyChanged();
            }
        }

        private int storeId;
        public int StoreId
        {
            get { return storeId; }
            set { storeId = value;
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

        private string gTypeName;
        public string GTypeName
        {
            get { return gTypeName; }
            set
            {
                gTypeName = value;
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

        private int uTypeId;
        public int UTypeId
        {
            get { return uTypeId; }
            set
            {
                uTypeId = value;
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
        private BindingList<PerQSupplierModel> perList = new BindingList<PerQSupplierModel>();
        public BindingList<PerQSupplierModel> PerList
        {
            get
            {
                GetPerQueryList();
                return perList;
            }
            set
            {
                perList = value;
                OnPropertyChanged();
            }
        }

      
        /// <summary>
        /// tlUnitTypes数据源
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
            }
        }

        private void GetUTypeList()
        {
            uTypeList = utBLL.GetAllUnitTypes("供应商");
            uTypeList.Insert(0, new UnitTypeInfoModel()
            {
                UTypeId = 0,
                UTypeName = "供应商"
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
                DealPerson = dealPerson,
                UTypeId = uTypeId
            };
        }

        public void GetPerQueryList()
        {
            QueryParaModel pModel = GetParaModel();
            PageModel<PerQuerySupplierModel> list = perBLL.GetPerDataBySupplier(pModel, startIndex, pageSize);
            totalCount = list.TotalCount;
            perList = new BindingList<PerQSupplierModel>();
            list.ReList.ForEach(g => perList.Add(new PerQSupplierModel()
            {
                PerSupplierInfo=g
            }));
        }

    }
}