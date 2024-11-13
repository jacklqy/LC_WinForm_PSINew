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
    public  class UTypeListViewModel:BaseModel
    {
        UnitTypeBLL utBLL = new UnitTypeBLL();
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
        private BindingList<UTypeModel> uTypeList = new BindingList<UTypeModel>();
        public BindingList<UTypeModel> UTypeList
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
            List<UnitTypeInfoModel> list = utBLL.LoadUnitTypeList(keywords, isShowDel);
            uTypeList = new BindingList<UTypeModel>();
            list.ForEach(t => uTypeList.Add(new UTypeModel()
            {
                UTypeInfo = t
            }));
        }
    }
}
