using PSINew.BLL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PSINew.UModels
{
    public class ToolMenuModel:BaseModel
    {
        ToolMenuBLL tmBLL = new ToolMenuBLL();
        private int tmenuId;
        private string tmName;
        private string tmPic;
        private int tGroupId;
        private string tGroupName;
        private string tmUrl;
        private int tmOrder;
        private string tmDesp;
        private bool isTop;
        private Image tmImg;
        public int TMenuId { get => tmenuId; set { tmenuId = value; OnPropertyChanged(); } }
        public string TMName { get => tmName; set { tmName = value; OnPropertyChanged(); } }
        public int TGroupId { get => tGroupId; set { tGroupId = value; OnPropertyChanged(); } }
        public string TGroupName { get => tGroupName; set { tGroupName = value; OnPropertyChanged(); } }
        public string TMPic { get => tmPic; set { tmPic = value; OnPropertyChanged(); } }
        public string TMUrl { get => tmUrl; set { tmUrl = value; OnPropertyChanged(); } }
        public int TMOrder { get => tmOrder; set { tmOrder = value; OnPropertyChanged(); } }
        public string TMDesp { get => tmDesp; set { tmDesp = value; OnPropertyChanged(); } }
        public bool IsTop { get => isTop; set { isTop = value; OnPropertyChanged(); } }
        public Image TMImg { get => tmImg; set { tmImg = value; OnPropertyChanged(); } }
        public void GetToolMenuInfo()
        {
            ToolMenuInfoModel tmenu = tmBLL.GetToolMenuInfo(tmenuId);
            if(tmenu!=null)
            {
                tmName = tmenu.TMenuName;
                tGroupId = tmenu.TGroupId;
                tmPic = tmenu.TMPic;
                tmOrder = tmenu.TMOrder;
                tmUrl = tmenu.TMUrl;
                isTop = tmenu.IsTop == 1 ? true:false;
                tmDesp = tmenu.TMDesp;
            }
        }
    }
}
