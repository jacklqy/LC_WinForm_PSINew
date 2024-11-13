using PSINew.UModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXPSIApp.FModels
{
    public  class StockSetMoreData
    {
        public List<GoodsStockUpDownModel> StoreUpDownList { get; set; }
        //选择的仓库
        public string StoreName { get; set; }
    }
}
