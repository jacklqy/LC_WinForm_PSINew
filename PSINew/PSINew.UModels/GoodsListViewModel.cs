using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.UModels
{
    public class GoodsListViewModel:BaseModel
    {
        GoodsBLL goodsBLL = new GoodsBLL();
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        /// <summary>
        /// 查询关键词
        /// </summary>
        private string keywords="";
        public string KeyWords { get => keywords; set { keywords = value; OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已删除
        /// </summary>
        private bool isShowDel;
        public bool IsShowDel { get => isShowDel; set { isShowDel = value; OnPropertyChanged(); } }

        /// <summary>
        /// 商品类别号
        /// </summary>
        private int gTypeId;
        public int GTypeId { get => gTypeId; set { gTypeId = value;OnPropertyChanged(); } }

        /// <summary>
        /// 商品类别名称
        /// </summary>
        private string gTypeName;
        public string GTypeName { get => gTypeName; set { gTypeName = value; OnPropertyChanged(); } }
        /// <summary>
        /// 是否显示已停用
        /// </summary>
        private bool isStopped;
        public bool IsStopped { get => isStopped; set { isStopped = value; OnPropertyChanged(); } }
        /// <summary>
        /// 分页开始索引
        /// </summary>
        private int startIndex=1;
        public int StartIndex { get => startIndex; set { startIndex = value; OnPropertyChanged(); } }
        /// <summary>
        /// 分页每页显示数
        /// </summary>
        private int pageSize=10;
        public int PageSize { get => pageSize; set { pageSize = value; OnPropertyChanged(); } }

        /// <summary>
        /// 总记录数
        /// </summary>
        private int totalCount;
        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                OnPropertyChanged();
            }
        }
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
            PageModel<ViewGoodsInfoModel> list = goodsBLL.LoadGoodsList(gTypeId,keywords, isStopped,isShowDel,startIndex,pageSize);
            totalCount = list.TotalCount;
            goodsList = new BindingList<GoodsModel>();
            list.ReList.ForEach(g => goodsList.Add(new GoodsModel()
            {
                GoodsId=g.GoodsId,
                GoodsName=g.GoodsName,
                GoodsNo=g.GoodsNo,
                GoodsPYNo=g.GoodsPYNo,
                GoodsTXNo=g.GoodsTXNo,
                GTypeId=g.GTypeId,
                GTypeName =g.GTypeName,
                GUnit=g.GUnit,
                GProperties=g.GProperties,
                RetailPrice=g.RetailPrice,
                IsStopped=g.IsStopped,
                Remark =g.Remark
            }));
        }
    }
}
