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
    public class ToolGroupViewModel : BaseModel
    {

        ToolGroupBLL tgroupBLL = new ToolGroupBLL();
        private bool isShowDel;
        public bool IsShowDel
        {
            get { return isShowDel; }
            set
            {
                isShowDel = value;
                OnPropertyChanged();
            }
        }

        private BindingList<ToolGroupModel> tgroupList = new BindingList<ToolGroupModel>();
        public BindingList<ToolGroupModel> TGroupList
        {
            get
            {
                GetGroupList();
                return tgroupList;
            }
            set
            {
                tgroupList = value;
                OnPropertyChanged();
            }
        }

        public void GetGroupList()
        {
            List<ToolGroupInfoModel> list = tgroupBLL.GetToolGroups(isShowDel);
            tgroupList = new BindingList<ToolGroupModel>();
            list.ForEach(g => tgroupList.Add(new ToolGroupModel()
            {
                ToolGroupInfo = g
            })) ;
        }
    }
}
