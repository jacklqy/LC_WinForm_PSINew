using PSINew.BLL;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class MenulListViewModel:BaseModel
    {
        MenuBLL menuBLL = new MenuBLL();
        public MenulListViewModel()
        {
           
        }
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords;
        public string KeyWords { get=>keywords; set { keywords = value;OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value;OnPropertyChanged(); } }
        /// <summary>
        /// 菜单列表
        /// </summary>
        private BindingList<MenuModel> menuList=new BindingList<MenuModel>();
        public BindingList<MenuModel> MenuList
        {
            get
            {
                menuList = GetMenuList();
                return menuList;
            }
            set
            {
                menuList = value;
                OnPropertyChanged();
            }
        }
        
        public void FindMenuListByKeyWords()
        {
            this.MenuList = GetMenuList();
        }

        /// <summary>
        /// 根据关键词获取菜单数据
        /// </summary>
        /// <returns></returns>
        private BindingList<MenuModel> GetMenuList()
        {
            List<ViewMenuInfoModel> list = menuBLL.GetMenuListByKeyWordsNew(keywords,isShowDel);
            BindingList<MenuModel> reList = new BindingList<MenuModel>();
            list.ForEach(m => reList.Add(new MenuModel()
            {
                MId = m.MId,
                MName = m.MName,
                ParentId = m.ParentId,
                ParentName = m.ParentName,
                MKey = m.MKey,
                MUrl = m.MUrl
            }));
            return reList;
        }
    }
}
