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
        public  class PerchaseInStoreBLL
        {
                PerchaseInStoreDAL perchaseDAL = new PerchaseInStoreDAL();
                ViewPerChaseGoodsDAL vpgDAL = new ViewPerChaseGoodsDAL();


                /// <summary>
                /// 获取指定的采购单信息
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public PerchaseInStoreInfoModel GetPerchaseInfo(int perId)
                {
                        return perchaseDAL.GetPerchaseInStoreInfo(perId);
                }

                /// <summary>
                /// 获取指定单据的商品明细列表
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public List<ViewPerGoodsInfoModel> GetPerGoodsList(int perId)
                {
                        return vpgDAL.GetPerchaseGoodsList(perId);
                }

                /// <summary>
                /// 添加采购单
                /// </summary>
                /// <param name="perInfo"></param>
                /// <param name="perGoodsList"></param>
                /// <returns></returns>
                public string AddPerchaseInfo(PerchaseInStoreInfoModel perInfo, List<PerchaseGoodsInfoModel> perGoodsList)
                {
                        return perchaseDAL.AddPerchaseInfo(perInfo, perGoodsList);
                }

                /// <summary>
                /// 修改采购单
                /// </summary>
                /// <param name="perInfo"></param>
                /// <param name="perGoodsList"></param>
                /// <returns></returns>
                public bool UpdatePerchaseInfo(PerchaseInStoreInfoModel perInfo, List<PerchaseGoodsInfoModel> perGoodsList)
                {
                        return perchaseDAL.UpdatePerchaseInfo(perInfo, perGoodsList);
                }

                /// <summary>
                /// 审核指定的采购单
                /// </summary>
                /// <param name="perId"></param>
                /// <param name="checkPerson"></param>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool CheckPerchaseInfo(int perId, string checkPerson, int storeId)
                {
                        return perchaseDAL.CheckPerchaseInfo(perId, checkPerson, storeId, 1);
                }

                /// <summary>
                /// 作废采购单
                /// </summary>
                /// <param name="perId"></param>
                /// <returns></returns>
                public bool NoUsePerchaseInfo(int perId)
                {
                        return perchaseDAL.CheckPerchaseInfo(perId, "", 0, 2);
                }

                /// <summary>
                /// 红冲
                /// </summary>
                /// <param name="perId"></param>
                /// <param name="storeId"></param>
                /// <returns></returns>
                public bool RedCheckPerchaseInfo(int perId, int storeId)
                {
                        return perchaseDAL.CheckPerchaseInfo(perId, "", storeId, 3);
                }



                /// <summary>
                /// 将List<ViewPerGoodsInfoModel>转换为 List<PerchaseGoodsInfoModel>
                /// </summary>
                /// <param name="vList"></param>
                /// <returns></returns>
                private List<PerchaseGoodsInfoModel> ViewToPerGoodsInfoModelList(List<ViewPerGoodsInfoModel> vList)
                {
                        List<PerchaseGoodsInfoModel> list = new List<PerchaseGoodsInfoModel>();
                        foreach (var vsg in vList)
                        {
                                list.Add(ViewToPerchaseGoodsInfoModel(vsg));
                        }
                        return list;
                }

                /// <summary>
                /// ViewPerGoodsInfoModel 转换为 PerchaseGoodsInfoModel
                /// </summary>
                /// <param name="vsg"></param>
                /// <returns></returns>
                private PerchaseGoodsInfoModel ViewToPerchaseGoodsInfoModel(ViewPerGoodsInfoModel vModel)
                {
                        PerchaseGoodsInfoModel sg = new PerchaseGoodsInfoModel()
                        {
                                PerId = vModel.PerId,
                                GoodsId = vModel.GoodsId,
                                Count = vModel.Count,
                                GUnit =vModel.GUnit,
                                PerPrice = vModel.PerPrice,
                                Amount = vModel.Amount,
                                Remark = vModel.Remark
                        };
                        return sg;
                }

                #region 采购统计

                ViewPerchaseGoodsQueryDAL vpgqDAL = new ViewPerchaseGoodsQueryDAL();
                /// <summary>
                /// 按供应商统计采购数据
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                 public PageModel<PerQuerySupplierModel> GetPerDataBySupplier(QueryParaModel paraModel,int startIndex,int pageSize)
                {
                      //typeId  1 供应商  2 仓库   3  按商品
                        DataSet ds = vpgqDAL.GetPerData(1, paraModel,startIndex,pageSize);
                        BQuery<PerQuerySupplierModel> bq = new BQuery<PerQuerySupplierModel>();
                        PageModel<PerQuerySupplierModel> pageModel = bq.DsToPageModel<PerQuerySupplierModel>(ds, "");
                        return pageModel;
                }

                /// <summary>
                /// 按仓库统计采购数据
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<PerQueryStoreModel> GetPerDataByStore(QueryParaModel paraModel, int startIndex, int pageSize)
                {
                        DataSet ds = vpgqDAL.GetPerData(2, paraModel, startIndex, pageSize);
                        BQuery<PerQueryStoreModel> bq = new BQuery<PerQueryStoreModel>();
                        PageModel<PerQueryStoreModel> pageModel = bq.DsToPageModel<PerQueryStoreModel>(ds, "");
                        return pageModel;
                }

                /// <summary>
                /// 按商品统计采购数据
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<PerQueryGoodsModel> GetPerDataByGoods(QueryParaModel paraModel, int startIndex, int pageSize)
                {
                        DataSet ds = vpgqDAL.GetPerData(3, paraModel, startIndex, pageSize);
                        BQuery<PerQueryGoodsModel> bq = new BQuery<PerQueryGoodsModel>();
                        PageModel<PerQueryGoodsModel> pageModel = bq.DsToPageModel<PerQueryGoodsModel>(ds, "");
                        return pageModel;
                }
                #endregion
        }
}
