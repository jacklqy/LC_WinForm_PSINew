using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class SetModelViewModel:BaseModel
    {
        private string storeName;
        public string StoreName
        {
            get => storeName;
            set
            {
                storeName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 批量设置上下限列表
        /// </summary>
        public List<GoodsStockUpDownModel> StoreUpDownList
        {
            get;set;
        }

        private bool isUp = false;
        public bool IsUp
        {
            get => isUp;
            set
            {
                isUp = value;
                OnPropertyChanged();
            }
        }

        private bool isDown = false;
        public bool IsDown
        {
            get => isDown;
            set
            {
                isDown = value;
                OnPropertyChanged();
            }
        }
        private bool isTxtUp= false;
        public bool IsTxtUpEnabled
        {
            get => isTxtUp;
            set
            {
                isTxtUp = value;
                OnPropertyChanged();
            }
        }

        private bool isTxtDown = false;
        public bool IsTxtDownEnabled
        {
            get => isTxtDown;
            set
            {
                isTxtDown = value;
                OnPropertyChanged();
            }
        }

        private int stockUp;
        public int StockUp
        {
            get => stockUp;
            set
            {
                stockUp = value;
                OnPropertyChanged();
            }
        }



        private int stockDown;
        public int StockDown
        {
            get => stockDown;
            set
            {
                stockDown = value;
                OnPropertyChanged();
            }
        }
    }
}
