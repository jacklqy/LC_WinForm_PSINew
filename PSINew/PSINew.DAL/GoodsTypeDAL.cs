using Common;
using DbUtility;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public class GoodsTypeDAL : BaseDAL<GoodsTypeInfoModel>
        {
                /// <summary>
                /// 加载商品类别信息（模糊查询）
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<GoodsTypeInfoModel> LoadAllGoodsTypeList(string keywords, int isDeleted)
                {
                        List<GoodsTypeInfoModel> list = new List<GoodsTypeInfoModel>();
                        string strWhere = "1=1";
                        string cols = "GTypeId,GTypeName,ParentId,ParentName,GTypeNo,GTPYNo,GTOrder";
                        strWhere += $" and IsDeleted={isDeleted}";
                        if (!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (GTypename like @keywords or ParentName like @keywords or GTypeNo like @keywords or GTPYNo like @keywords)";
                                SqlParameter para = new SqlParameter("@keywords", $"%{keywords}%");
                                list = GetModelList(strWhere, cols, para);
                        }
                        else
                                list = GetModelList(strWhere, cols);
                        return list;
                }

                /// <summary>
                /// 加载所有的商品类别（绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<GoodsTypeInfoModel> LoadAllGoodsTypes()
                {
                        List<GoodsTypeInfoModel> list = new List<GoodsTypeInfoModel>();
                        string strWhere = "IsDeleted=0 order by ParentId,GTOrder";
                        string cols = "GTypeId,GTypeName,ParentId";
                        list = GetModelList(strWhere, cols);
                        return list;
                }

                /// <summary>
                /// 获取指定商品类别信息
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public GoodsTypeInfoModel GetGoodsType(int typeId)
                {
                        return GetById(typeId, "GTypeId,GTypeName,ParentId,GTypeNo,GTPYNo,GTOrder");
                }

                /// <summary>
                /// 检查该商品类别是否已添加商品
                /// </summary>
                /// <param name="gtypeId"></param>
                /// <returns></returns>
                public int CheckIsAddGoods(int gtypeId)
                {
                        string sql = $"select count(1) from GoodsInfos where GTypeId={gtypeId}";
                        object oCount = SqlHelper.ExecuteScalar(sql, 1);
                        if (oCount != null && oCount.ToString() != "")
                                return oCount.GetInt();
                        return 0;
                }

                /// <summary>
                /// 获取指定类别的子类别列表
                /// </summary>
                /// <param name="gTypeId"></param>
                /// <returns></returns>
                public List<GoodsTypeInfoModel> GetChildTypes(int gTypeId)
                {
                        return GetModelList($"ParentId={gTypeId} and IsDeleted=0", "GTypeId,GTypeName");
                }

                /// <summary>
                /// 检查类别名称是否已存在
                /// </summary>
                /// <param name="gtypeName"></param>
                /// <returns></returns>
                public bool ExistName(string gtypeName)
                {
                        return ExistsByName("GTypeName", gtypeName);
                }

                /// <summary>
                /// 添加商品类别
                /// </summary>
                /// <param name="gtInfo"></param>
                /// <returns></returns>
                public int AddGoodsType(GoodsTypeInfoModel gtInfo)
                {
                        return Add(gtInfo, "GTypeName,ParentId,ParentName,GTypeNo,GTPYNo,GTOrder,Creator", 1);
                }




                /// <summary>
                /// 更新商品类别信息
                /// </summary>
                /// <param name="gtInfo"></param>
                /// <param name="blUpdate"></param>
                /// <returns></returns>
                public bool UpdateGoodsType(GoodsTypeInfoModel gtInfo, bool blUpdate)
                {
                        List<CommandInfo> list = new List<CommandInfo>();
                        string cols = "GTypeId,GTypeName,ParentId,ParentName,GTypeNo,GTPYNo,GTOrder";
                        SqlModel upModel = CreateSql.GetUpdateSqlAndParas(gtInfo, cols, "");
                        list.Add(new CommandInfo()
                        {
                                CommandText = upModel.Sql,
                                IsProc = false,
                                Paras = upModel.SqlParaArray
                        });
                        if (blUpdate)
                        {

                                SqlParameter[] paras =
                                {
                    new SqlParameter("@ParentName",gtInfo.GTypeName),
                    new SqlParameter("@ParentId",gtInfo.GTypeId)
                };
                                list.Add(new CommandInfo()
                                {
                                        CommandText = "update GoodsTypeInfos set ParentName=@ParentName where ParentId=@ParentId",
                                        IsProc = false,
                                        Paras = paras
                                });
                        }
                        return SqlHelper.ExecuteTrans(list);
                }
        }
}
