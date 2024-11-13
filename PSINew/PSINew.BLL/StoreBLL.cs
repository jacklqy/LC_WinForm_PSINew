using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
        public  class StoreBLL
        {
                StoreDAL storeDAL = new StoreDAL();
                ViewStoreDAL vsDAL = new ViewStoreDAL();
                StoreGoodsStockDAL sgsDAL = new StoreGoodsStockDAL();
                GoodsDAL goodsDAL = new GoodsDAL();
                /// <summary>
                /// 条件查询仓库列表
                /// </summary>
                /// <param name="sTypeId"></param>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<ViewStoreInfoModel> LoadStoreList(int sTypeId, string keywords, bool isShowDel)
                {
                        int isDeleted = isShowDel ? 1 : 0;
                        return vsDAL.LoadStoreList(sTypeId, keywords, isDeleted);
                }

                public List<StoreInfoModel> LoadAllStores()
                {
                        return storeDAL.GetAllStores();
                }

                /// <summary>
                /// 检查仓库是否在使用中
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool CheckStoreUse(int storeId)
                {
                        return storeDAL.CheckStoreUse(storeId);
                }

                /// <summary>
                /// 获取指定的仓库信息
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public StoreInfoModel GetStoreInfo(int storeId)
                {
                        return storeDAL.GetStoreInfo(storeId);
                }

                /// <summary>
                /// 单个仓库的删除 
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool DeleteStoreInfo(int storeId)
                {
                        List<int> storeIds = new List<int>() { storeId };
                        return storeDAL.DeleteStoreInfos(storeIds, 0, 1, "");
                }

                /// <summary>
                /// 批量仓库的删除 
                /// </summary>
                /// <param name="storeIds"></param>
                /// <returns></returns>
                public bool DeleteStoreInfos(List<int> storeIds)
                {
                        return storeDAL.DeleteStoreInfos(storeIds, 0, 1, "");
                }


                /// <summary>
                /// 批量恢复仓库信息
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="uName"></param>
                /// <returns></returns>
                public bool RecoverStoreInfos(List<int> storeIds, string uName)
                {
                        return storeDAL.DeleteStoreInfos(storeIds, 0, 0, uName);
                }

                /// <summary>
                /// 单个仓库的恢复
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool RecoverStoreInfo(int storeId, string uName)
                {
                        List<int> storeIds = new List<int>() { storeId };
                        return storeDAL.DeleteStoreInfos(storeIds, 0, 0, uName);
                }

                /// <summary>
                /// 批量移除仓库信息
                /// </summary>
                /// <param name="storeIds"></param>
                /// <returns></returns>
                public bool RemoveStoreInfos(List<int> storeIds)
                {
                        return storeDAL.DeleteStoreInfos(storeIds, 1, 2, "");
                }

                /// <summary>
                /// 单个仓库的移除
                /// </summary>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool RemoveStoreInfo(int storeId)
                {
                        List<int> storeIds = new List<int>() { storeId };
                        return storeDAL.DeleteStoreInfos(storeIds, 1, 2, "");
                }

                /// <summary>
                /// 判断仓库是否已存在（同一类别下不能重名）
                /// </summary>
                /// <param name="storeName"></param>
                /// <param name="sTypeId"></param>
                /// <returns></returns>
                public bool ExistsStore(string storeName, int sTypeId)
                {
                        return storeDAL.ExistsStore(storeName, sTypeId);
                }

                /// <summary>
                /// 修改仓库信息
                /// </summary>
                /// <param name="storeInfo"></param>
                /// <returns></returns>
                public bool UpdateStoreInfo(StoreInfoModel storeInfo)
                {
                        return storeDAL.UpdateStoreInfo(storeInfo);
                }

                /// <summary>
                /// 添加仓库信息
                /// </summary>
                /// <param name="storeInfo"></param>
                /// <param name="goodsIds">所有商品的编号集合</param>
                /// <returns></returns>
                public bool AddStoreInfo(StoreInfoModel storeInfo)
                {
                        //获取所有的商品编号集合
                        List<int> goodsIds = goodsDAL.GetAllGoodsIds();
                        return storeDAL.AddStoreInfo(storeInfo, goodsIds);
                }
        }
}
