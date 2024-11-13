using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class ChooseGoodsViewModel:BaseModel
    {
        GoodsBLL goodsBLL = new GoodsBLL();
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords = "";
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }

        /// <summary>
        /// 商品类别号
        /// </summary>
        private int gTypeId;
        public int GTypeId { get => gTypeId; set { gTypeId = value; OnPropertyChanged(); } }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        private string gTypeName;
        public string GTypeName { get => gTypeName; set { gTypeName = value; OnPropertyChanged(); } }
      
        /// <summary>
        /// 商品列表
        /// </summary>
        private BindingList<GoodsModel> goodsList = new BindingList<GoodsModel>();
        public BindingList<GoodsModel> GoodsList
        {
            get
            {
                GetGoodsList();
                return goodsList;
            }
            set
            {
                goodsList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// tlGoodsTypes数据源
        /// </summary>
        private List<GoodsTypeInfoModel> gTypeList;
        public List<GoodsTypeInfoModel> GTypeList
        {
            get
            {
                GetGTypeList();
                return gTypeList;
            }
            set
            {
                gTypeList = value;
                OnPropertyChanged();
            }
        }

        public void GetGTypeList()
        {
            gTypeList = gtBLL.LoadAllGoodsTypes();
            gTypeList.Insert(0, new GoodsTypeInfoModel()
            {
                GTypeId = 0,
                GTypeName = "商品类型"
            });
        }
        public void GetGoodsList()
        {
            List<ViewGoodsInfoModel> list = goodsBLL.GetGoodsList(gTypeId, keywords);
            goodsList = new BindingList<GoodsModel>();
            list.ForEach(g => goodsList.Add(new GoodsModel()
            {
                GoodsId = g.GoodsId,
                GoodsName = g.GoodsName,
                GoodsTXNo=g.GoodsTXNo,
                GoodsNo=g.GoodsNo,
                GUnit=g.GUnit,
                GoodsPYNo = g.GoodsPYNo,
                GTypeId = g.GTypeId,
                GTypeName = g.GTypeName,
                RetailPrice = g.RetailPrice,
                IsStopped = g.IsStopped,
                Remark = g.Remark
            }));
        }
    }
}
