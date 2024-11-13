using PSINew.BLL;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class SheetInfoViewModel:BaseModel
    {
        SheetQueryBLL sheetBLL = new SheetQueryBLL();
        public SheetInfoViewModel()
        {
            sheetList = new List<SheetGoodsInfoModel>();
        }

        private int sheetId;
        public int SheetId
        {
            get => sheetId;
            set { sheetId = value;
                OnPropertyChanged();
            }
        }

        private int shType;
        public int ShType
        {
            get => shType;
            set
            {
                shType = value;
                GetShTypeName();
                OnPropertyChanged();
            }
        }

        private string shTypeName = "";
        public string ShTypeName {
            get
            {
                return shTypeName;
            }
           
        }

        private int typeId;
        public int TypeId
        {
            get => typeId;
            set
            {
                typeId = value;
                GetInfoDesp();
                OnPropertyChanged();
            }
        }

        private string infoDesp;
        public string InfoDesp
        {
            get
            {
                return infoDesp;
            }
        }

        private string infoText;
        public string InfoText
        {
            get => infoText;
            set
            {
                infoText = value;
                OnPropertyChanged();
            }
        }

        private List<SheetGoodsInfoModel> sheetList;
        public List<SheetGoodsInfoModel> SheetList
        {
            get => sheetList;
            set
            {
                sheetList = value;
                OnPropertyChanged();
            }
        }

        private void GetInfoDesp()
        {
            if(typeId>0)
            {
                switch (typeId)
                {
                    case 1:
                        if (shType == 1) infoDesp = "供应商";
                        else infoDesp = "客户";
                        break;
                    case 2:
                        infoDesp = "仓库";
                        break;
                    case 3:
                        infoDesp = "商品";
                        break;
                }
            }
        }

        private void GetShTypeName()
        {
              if(shType>0)
            {
                switch(shType)
                {
                    case 1:
                        shTypeName = "采购入库单";
                        break;
                    case 2:
                        shTypeName = "销售出库单";
                        break;
                }
            }
        }

        public void GetSheetList()
        {
            List<SheetGoodsInfoModel> list = sheetBLL.GetSheetGoodsInfoList(shType, typeId, sheetId);
            sheetList = list;
        }
    }
}
