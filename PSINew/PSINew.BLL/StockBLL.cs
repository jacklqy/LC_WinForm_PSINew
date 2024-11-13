using Common;
using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class StockBLL
    {
        private GoodsDAL goodsDAL = new GoodsDAL();
        private ViewStoreStockUpDownDAL vsudDAL = new ViewStoreStockUpDownDAL();
        private StoreGoodsStockDAL sgsDAL = new StoreGoodsStockDAL();
        private StockStoreDAL stockstoreDAL = new StockStoreDAL();
        private ViewStStockGoodsDAL vsgDAL = new ViewStStockGoodsDAL();
        StockChangeDAL sgDAL = new StockChangeDAL();
        #region 期初库存

        /// <summary>
        /// 检查是否存在未审核的期初入库单据
        /// </summary>
        /// <returns></returns>
        public bool HasUnCheckedStartStock()
        {
            int count = stockstoreDAL.GetUnCheckedStartStock();
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取指定的入库单信息
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public StockStoreInfoModel GetStockInfo(int stockId)
        {
            return stockstoreDAL.GetStockInfo(stockId);
        }

        /// <summary>
        /// 获取指定库存单的入库商品列表
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public List<ViewStStockGoodsInfoModel> GetStockGoodsList(int stockId)
        {
            return vsgDAL.GetStockGoodsList(stockId);
        }

        /// <summary>
        /// 添加期初录入单
        /// </summary>
        /// <param name="stockInfo"></param>
        /// <param name="stockGoods"></param>
        /// <returns></returns>
        public string AddStartStockInfo(StockStoreInfoModel stockInfo, List<StStockGoodsInfoModel> stockGoods)
        {
            return stockstoreDAL.AddStockInfo(stockInfo, stockGoods);
        }

        /// <summary>
        /// 修改入库单
        /// </summary>
        /// <param name="perInfo"></param>
        /// <param name="perGoods"></param>
        /// <param name="blChanged"></param>
        /// <returns></returns>
        public bool UpdateStartStockInfo(StockStoreInfoModel stockInfo, List<StStockGoodsInfoModel> stockGoods)
        {
            return stockstoreDAL.UpdateStockInfo(stockInfo, stockGoods);
        }

        /// <summary>
        /// 审核指定的期初入库单
        /// </summary>
        /// <param name="perId"></param>
        /// <param name="checkPerson"></param>
        /// <returns></returns>
        public bool CheckStartStock(int stockId, string checkPerson, int storeId)
        {
            return stockstoreDAL.CheckStockInfo(stockId, checkPerson, storeId, 1);
        }

        /// <summary>
        /// 未审核期初入库单作废
        /// </summary>
        /// <param name="perId"></param>
        /// <returns></returns>
        public bool NoUseStartStock(int stockId)
        {
            return stockstoreDAL.CheckStockInfo(stockId, "", 2, 0);
        }

        /// <summary>
        /// 红冲期初入库单
        /// </summary>
        /// <param name="saleId"></param>
        /// <returns></returns>
        public bool RedCheckedStartStock(int stockId, int storeId)
        {
            return stockstoreDAL.CheckStockInfo(stockId, "", storeId, 3);
        }

        private StStockGoodsInfoModel ViewToStStockGoodsInfoModel(ViewStStockGoodsInfoModel vModel)
        {
            StStockGoodsInfoModel sg = new StStockGoodsInfoModel()
            {
                StockId = vModel.StockId,
                GoodsId = vModel.GoodsId,
                StCount = vModel.StCount,
                StPrice = vModel.StPrice,
                StAmount = vModel.StAmount,
                Remark = vModel.Remark
            };
            return sg;
        }

        private List<StStockGoodsInfoModel> ViewToStStockGoodsInfoModelList(List<ViewStStockGoodsInfoModel> vList)
        {
            List<StStockGoodsInfoModel> list = new List<StStockGoodsInfoModel>();
            foreach (var vsg in vList)
            {
                list.Add(ViewToStStockGoodsInfoModel(vsg));
            }
            return list;
        }

        #endregion

        #region 库存查询统计

        /// <summary>
        /// 获取商品库存统计数据
        /// </summary>
        /// <param name="qModel"></param>
        /// <returns></returns>
        public List<StoreStockQueryModel> GetStoreStockData(StockQueryParaModel qModel)
        {
            DataTable dt = sgsDAL.GetStoreStockData(qModel);
            List<StoreStockQueryModel> list = new List<StoreStockQueryModel>();
            if (dt.Rows.Count > 0)
            {
                list = DbConvert.DataTableToList<StoreStockQueryModel>(dt, "");
            }
            return list;
        }

        /// <summary>
        /// 获取指定商品的库存分布
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="storeId"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public List<GoodsStoreStockModel> GetGoodsStoreStock(int goodsId, int storeId, string storeName)
        {
            DataTable dt = sgsDAL.GetGoodsStoreStockData(goodsId, storeId, storeName);
            List<GoodsStoreStockModel> list = new List<GoodsStoreStockModel>();
            if (dt.Rows.Count > 0)
            {

                list = DbConvert.DataTableToList<GoodsStoreStockModel>(dt, "Id,StoreId,StoreName,CurCount,StPrice,StockAmount");
                foreach (GoodsStoreStockModel gs in list)
                {
                    if(gs.CurCount >0 && gs.StPrice==0&&gs.StockAmount>0)
                    {
                        gs.StPrice =decimal.Parse( (gs.StockAmount / gs.CurCount).ToString("0.00"));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定商品的库存变动明细
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="storeId"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public List<StockChangeInfoModel> GetGoodsStockChangeList(int goodsId, int storeId, string storeName)
        {
            List<StockChangeInfoModel> list = sgDAL.GetGoodsStockChangeList(goodsId, storeId, storeName);
            if (list.Count > 0)
            {
                foreach (var sc in list)
                {
                    sc.ShTypeName = GetShTypeName(sc.ShType);
                    sc.CheckState = GetCheckState(sc.IsChecked);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定商品编号列表、指定仓库的商品库存数
        /// </summary>
        /// <param name="GoodsIds"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<GoodsStoreStockModel> GetGoodsStoreStockCount(List<int> GoodsIds, int storeId)
        {

            List<GoodsStoreStockModel> list = sgsDAL.GetGoodsStoreStockCountList(GoodsIds, storeId);
            return list;
        }
        #endregion

        #region 库存上下限设置

        /// <summary>
        /// 获取商品上下限列表
        /// </summary>
        /// <param name="gTypeId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<ViewStoreStockUpDownModel> GetGoodsStockUpDownList(int gTypeId, int storeId)
        {
            return vsudDAL.GetGoodsStockUpDownList(gTypeId, storeId);
        }

        /// <summary>
        /// 保存库存上下限
        /// </summary>
        /// <param name="goodsStockUpdownList"></param>
        /// <returns></returns>
        public bool SetGoodsStockUpDown(List<ViewStoreStockUpDownModel> goodsStockUpdownList)
        {
            List<StoreGoodsStockInfoModel> list = ChangeViewToStoreGoodsStockInfoModelList(goodsStockUpdownList);
            return sgsDAL.SetGoodsStockUpDown(list);
        }

        /// <summary>
        /// 批量保存库存上下限设置（设置统一的上限下限）
        /// </summary>
        /// <param name="goodsStockUpdownList"></param>
        /// <param name="up"></param>
        /// <param name="down"></param>
        /// <returns></returns>
        public bool SetMoreGoodsStockUpDown(List<ViewStoreStockUpDownModel> goodsStockUpdownList, int up, int down)
        {
            List<StoreGoodsStockInfoModel> list = ChangeViewToStoreGoodsStockInfoModelList(goodsStockUpdownList);
            foreach (var gupdown in list)
            {
                gupdown.StockUp = up;
                gupdown.StockDown = down;
            }
            return sgsDAL.SetGoodsStockUpDown(list);
        }


        /// <summary>
        /// 将List<ViewStoreStockUpDownModel>转换成List<StoreGoodsStockInfoModel>
        /// </summary>
        /// <param name="goodsStockUpdownList"></param>
        /// <returns></returns>
        private List<StoreGoodsStockInfoModel> ChangeViewToStoreGoodsStockInfoModelList(List<ViewStoreStockUpDownModel> goodsStockUpdownList)
        {
            List<StoreGoodsStockInfoModel> list = new List<StoreGoodsStockInfoModel>();
            foreach (var vInfo in goodsStockUpdownList)
            {
                list.Add(new StoreGoodsStockInfoModel()
                {
                    StoreGoodsId = vInfo.StoreGoodsId,
                    StoreId = vInfo.StoreId,
                    GoodsId = vInfo.GoodsId,
                    StockUp = vInfo.StockUp,
                    StockDown = vInfo.StockDown
                });
            }
            return list;
        }

        #endregion

        /// <summary>
        /// 获取审核状态说明
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        private string GetCheckState(int isChecked)
        {
            string cState = "";
            switch (isChecked)
            {
                case 0:
                    cState = "待审核";
                    break;
                case 1:
                    cState = "已审核";
                    break;
                case 2:
                    cState = "已作废";
                    break;
                case 3:
                    cState = "已红冲";
                    break;
            }
            return cState;
        }

        /// <summary>
        /// 获取单据类型说明
        /// </summary>
        /// <param name="shType"></param>
        /// <returns></returns>
        private string GetShTypeName(int shType)
        {
            string shTypeName = "";
            switch (shType)
            {
                case 1:
                    shTypeName = "采购入库单";
                    break;
                case 2:
                    shTypeName = "销售出库单";
                    break;
                case 3:
                    shTypeName = "期初入库单";
                    break;
            }
            return shTypeName;
        }
    }
}
