using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public  class ToolGroupModel:BaseModel
    {
        ToolGroupBLL tgBLL = new ToolGroupBLL();
        private ToolGroupInfoModel tmodel;
        public ToolGroupModel()
        {
            GetToolGroupInfo();
        }

        private void GetToolGroupInfo()
        {
            tmodel = new ToolGroupInfoModel();
              if(this.TGroupId>0)
            {
                tmodel = tgBLL.GetToolGroupInfo(this.TGroupId);
            }
        }

        public ToolGroupInfoModel ToolGroupInfo
        {
            get
            {
                return tmodel;
            }
            set
            {
                tmodel = value;
            }
        }

        public int TGroupId
        {
            get { return tmodel.TGroupId; }
            set { tmodel.TGroupId = value;
                OnPropertyChanged();
            }
        }

        public string TGroupName
        {
            get { return tmodel.TGroupName; }
            set
            {
                tmodel.TGroupName = value;
                OnPropertyChanged();
            }
        }

        public string Creator
        {
            get { return tmodel.Creator; }
            set
            {
                tmodel.Creator = value;
                OnPropertyChanged();
            }
        }
    }
}
