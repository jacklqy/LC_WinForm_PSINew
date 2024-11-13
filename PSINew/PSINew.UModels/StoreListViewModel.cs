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
    public class StoreListViewModel : BaseModel
    {
        StoreTypeBLL stBLL = new StoreTypeBLL();
        StoreBLL storeBLL = new StoreBLL();
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
        /// 仓库类别号
        /// </summary>
        private int sTypeId;
        public int STypeId { get => sTypeId; set { sTypeId = value; OnPropertyChanged(); } }
        /// <summary>
        /// 菜单列表
        /// </summary>
        private BindingList<StoreModel> storeList = new BindingList<StoreModel>();
        public BindingList<StoreModel> StoreList
        {
            get
            {
                GetStoreList();
                return storeList;
            }
            set
            {
                storeList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// tlGoodsTypes数据源
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
                OnPropertyChanged();
            }
        }

        public void GetSTypeList()
        {
            sTypeList = stBLL.LoadAllDrpStoreTypes();
            sTypeList.ForEach(s => s.ParentId = 0);
            sTypeList.Insert(0, new StoreTypeInfoModel()
            {
                STypeId = 0,
                STypeName = "仓库类型"
            });
        }
        public void GetStoreList()
        {
            List<ViewStoreInfoModel> list = storeBLL.LoadStoreList(sTypeId, keywords, isShowDel);
            storeList = new BindingList<StoreModel>();
            list.ForEach(s => storeList.Add(new StoreModel()
            {
                StoreId = s.StoreId,
                StoreName = s.StoreName,
                StoreNo = s.StoreNo,
                StorePYNo = s.StorePYNo,
                STypeId = s.STypeId,
                STypeName = s.STypeName,
                StoreOrder = s.StoreOrder,
                StoreRemark = s.StoreRemark
            }));
        }
    }
}
