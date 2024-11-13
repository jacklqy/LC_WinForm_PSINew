using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class MenuModel:BaseModel
    {
        private int mId;
        private string mName;
        private int parentId;
        private string parentName;
        private string mKey;
        private string mUrl;
        public int MId { get => mId;set { mId = value;OnPropertyChanged(); } }
        public string MName { get => mName; set { mName = value; OnPropertyChanged(); } }
        public int ParentId { get => parentId; set { parentId = value; OnPropertyChanged(); } }
        public string ParentName { get => parentName; set { parentName = value; OnPropertyChanged(); } }
        public string MKey { get => mKey; set { mKey = value; OnPropertyChanged(); } }
        public string MUrl { get => mUrl; set { mUrl = value; OnPropertyChanged(); } }
    }
}
