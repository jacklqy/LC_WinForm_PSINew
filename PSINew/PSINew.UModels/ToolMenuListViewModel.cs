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
    public class ToolMenuListViewModel:BaseModel
    {
        ToolMenuBLL tmenuBLL = new ToolMenuBLL();
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
        /// 工具菜单列表
        /// </summary>
        private BindingList<ToolMenuModel> toolMenuList = new BindingList<ToolMenuModel>();
        public BindingList<ToolMenuModel> ToolMenuList
        {
            get
            {
                 GetToolMenuList();
                return toolMenuList;
            }
            set
            {
                toolMenuList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 获取工具菜单列表
        /// </summary>
        public void GetToolMenuList()
        {
            List<ViewToolMenuInfoModel> list = tmenuBLL.GetToolMenuInfosNew(keywords, isShowDel);
            toolMenuList = new BindingList<ToolMenuModel>();
            list.ForEach(m => toolMenuList.Add(new ToolMenuModel()
            {
                TMenuId=m.TMenuId,
                TMName=m.TMenuName,
                TGroupId=m.TGroupId,
                TGroupName=m.TGroupName,
                TMPic=m.TMPic,
                TMUrl=m.TMUrl,
                TMOrder =m.TMOrder
            }));
        }
    }
}
