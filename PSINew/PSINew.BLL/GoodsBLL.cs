using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
        public class GoodsBLL
        {
                GoodsDAL goodsDAL = new GoodsDAL();
                ViewGoodsDAL vgDAL = new ViewGoodsDAL();
                /// <summary>
                ///  分页条件查询商品列表
                /// </summary>
                /// <param name="gTypeId"></param>
                /// <param name="keywords"></param>
                /// <param name="isStopped"></param>
                /// <param name="isShowDel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<ViewGoodsInfoModel> LoadGoodsList(int gTypeId, string keywords, bool isStopped, bool isShowDel, int startIndex, int pageSize)
                {
                        int isStop = isStopped ? 1 : 0;
                        int isDeleted = isShowDel ? 1 : 0;
                        return goodsDAL.LoadGoodsList(gTypeId, keywords, isStop, isDeleted, startIndex, pageSize);
                }

                /// <summary>
                /// 条件获取商品信息
                /// </summary>
                /// <returns></returns>
                public List<ViewGoodsInfoModel> GetGoodsList(int gtypeId, string keywords)
                {
                        return vgDAL.GetGoodsList(gtypeId, keywords);
                }

                /// <summary>
                /// 获取指定的商品信息
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public GoodsInfoModel GetGoodsInfo(int goodsId)
                {
                        return goodsDAL.GetGoodsInfo(goodsId);
                }

                /// <summary>
                /// 批量逻辑删除商品信息
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <param name="uName"></param>
                /// <returns></returns>
                public bool DeleteGoodsInfos(List<int> goodsIds)
                {
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 0, 1, "");
                }

                /// <summary>
                /// 单个商品的删除 
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool DeleteGoodsInfo(int goodsId)
                {
                        List<int> goodsIds = new List<int>() { goodsId };
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 0, 1, "");
                }

                /// <summary>
                /// 批量恢复商品信息
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <param name="uName"></param>
                /// <returns></returns>
                public bool RecoverGoodsInfos(List<int> goodsIds, string uName)
                {
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 0, 0, uName);
                }

                /// <summary>
                /// 单个商品的恢复
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool RecoverGoodsInfo(int goodsId, string uName)
                {
                        List<int> goodsIds = new List<int>() { goodsId };
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 0, 0, uName);
                }

                /// <summary>
                /// 批量移除商品信息
                /// </summary>
                /// <param name="goodsIds"></param>
                /// <param name="delType"></param>
                /// <param name="isDeleted"></param>
                /// <param name="uName"></param>
                /// <returns></returns>
                public bool RemoveGoodsInfos(List<int> goodsIds)
                {
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 1, 2, "");
                }

                /// <summary>
                /// 单个商品的移除
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool RemoveGoodsInfo(int goodsId)
                {
                        List<int> goodsIds = new List<int>() { goodsId };
                        return goodsDAL.DeleteGoodsInfos(goodsIds, 1, 2, "");
                }

                /// <summary>
                /// 判断指定商品是否在使用中
                /// </summary>
                /// <param name="goodsId"></param>
                /// <returns></returns>
                public bool CheckIsGoodsUse(int goodsId)
                {
                        return goodsDAL.CheckIsGoodsUse(goodsId);
                }

                /// <summary>
                /// 添加商品
                /// </summary>
                /// <param name="goodsInfo"></param>
                /// <returns></returns>
                public bool AddGoodsInfo(GoodsInfoModel goodsInfo)
                {
                        if (goodsInfo != null)
                                return goodsDAL.AddGoodsInfo(goodsInfo);
                        throw new Exception("添加的商品信息不能为空！");
                }

                /// <summary>
                /// 修改商品信息
                /// </summary>
                /// <param name="goodsInfo"></param>
                /// <returns></returns>
                public bool UpdateGoodsInfo(GoodsInfoModel goodsInfo)
                {
                        if (goodsInfo != null)
                                return goodsDAL.UpdateGoodsInfo(goodsInfo);
                        throw new Exception("修改的商品信息不能为空！");
                }

                /// <summary>
                /// 判断商品名称是否已存在
                /// </summary>
                /// <param name="goodsName"></param>
                /// <returns></returns>
                public bool ExistGoodsName(string goodsName)
                {
                        return goodsDAL.ExistGoodsName(goodsName);
                }

                /// <summary>
                /// 关键词获取商品名称
                /// </summary>
                /// <param name="keywords"></param>
                /// <returns></returns>
                public string GetGoodsInfoByKeywords(string keywords)
                {
                        GoodsInfoModel goods = goodsDAL.GetGoodsInfoByKeywords(keywords);
                        if (goods != null)
                                return goods.GoodsName;
                        else
                                return "";
                }

                /// <summary>
                /// 根据类别获取商品列表
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public List<GoodsInfoModel> GetGoodsListByTypeId(int typeId)
                {
                        return goodsDAL.GetGoodsListByTypeId(typeId);
                }
        }
}
