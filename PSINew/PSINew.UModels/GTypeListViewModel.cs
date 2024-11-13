using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GTypeListViewModel:BaseModel
    {
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords;
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value; OnPropertyChanged(); } }
        /// <summary>
        /// 菜单列表
        /// </summary>
        private BindingList<GTypeModel> gTypeList = new BindingList<GTypeModel>();
        public BindingList<GTypeModel> GTypeList
        {
            get
            {
                GetGTypeList();
                return gTypeList;
            }
            set
            {
                gTypeList = value;
                OnPropertyChanged();
            }
        }

        public void GetGTypeList()
        {
            List<GoodsTypeInfoModel> list = gtBLL.LoadAllGoodsTypeList(keywords, isShowDel);
            gTypeList = new BindingList<GTypeModel>();
            list.ForEach(t => gTypeList.Add(new GTypeModel()
            {
                GTypeInfo = t
            }));
        }
    }
}
