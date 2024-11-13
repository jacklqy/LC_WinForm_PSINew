using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
        public class GoodsTypeBLL : BaseBLL<GoodsTypeInfoModel>
        {
                private GoodsTypeDAL gtDAL = new GoodsTypeDAL();
                /// <summary>
                /// 加载商品类别信息（模糊查询）
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<GoodsTypeInfoModel> LoadAllGoodsTypeList(string keywords, bool blShow)
                {
                        int isDeleted = blShow ? 1 : 0;
                        return gtDAL.LoadAllGoodsTypeList(keywords, isDeleted);
                }

                /// <summary>
                /// 加载所有的商品类别（绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<GoodsTypeInfoModel> LoadAllGoodsTypes()
                {
                        return gtDAL.LoadAllGoodsTypes();
                }

                /// <summary>
                /// 获取指定商品类别信息
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public GoodsTypeInfoModel GetGoodsType(int typeId)
                {
                        return gtDAL.GetGoodsType(typeId);
                }

                /// <summary>
                /// 检查该商品类别是否已添加商品
                /// </summary>
                /// <param name="gtypeId"></param>
                /// <returns></returns>
                public bool CheckIsAddGoods(int gtypeId)
                {
                        int count = gtDAL.CheckIsAddGoods(gtypeId);
                        bool bl = count > 0 ? true : false;
                        return bl;
                }

                /// <summary>
                /// 检查该商品类别是否已添加子类别
                /// </summary>
                /// <param name="gTypeId"></param>
                /// <returns></returns>
                public bool HasChildTypes(int gTypeId)
                {
                        List<GoodsTypeInfoModel> childs = gtDAL.GetChildTypes(gTypeId);
                        if (childs.Count > 0)
                                return true;
                        return false;
                }

                /// <summary>
                /// 检查类别名称是否已存在
                /// </summary>
                /// <param name="gtypeName"></param>
                /// <returns></returns>
                public bool ExistName(string gtypeName)
                {
                        return gtDAL.ExistName(gtypeName);
                }

                /// <summary>
                /// 添加商品类别
                /// </summary>
                /// <param name="gtInfo"></param>
                /// <returns></returns>
                public int AddGoodsType(GoodsTypeInfoModel gtInfo)
                {
                        return gtDAL.AddGoodsType(gtInfo);
                }

                /// <summary>
                /// 更新商品类别信息
                /// </summary>
                /// <param name="gtInfo"></param>
                /// <param name="blUpdate"></param>
                /// <returns></returns>
                public bool UpdateGoodsType(GoodsTypeInfoModel gtInfo, string oldName)
                {
                        bool blUpdate = gtInfo.GTypeName == oldName ? false : true;
                        return gtDAL.UpdateGoodsType(gtInfo, blUpdate);
                }
        }
}
