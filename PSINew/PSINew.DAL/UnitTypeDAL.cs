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
        public class UnitTypeDAL:BaseDAL<UnitTypeInfoModel>
        {
                /// <summary>
                /// 获取所有的往来单位类别列表（绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<UnitTypeInfoModel>  LoadAllDrpUnitTypes()
                {
                        return GetModelList("IsDeleted=0 order by ParentId,UTOrder", "UTypeId,UTypeName");
                }

                /// <summary>
                /// 获取所有的往来单位类别列表（绑定TreeView）
                /// </summary>
                /// <returns></returns>
                public List<UnitTypeInfoModel> LoadAllTVUnitTypes()
                {
                        return GetModelList("IsDeleted=0", "UTypeId,UTypeName,ParentId");
                }

                /// <summary>
                /// 条件查询往来单位列表
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<UnitTypeInfoModel> LoadUnitTypeList(string keywords, int isDeleted)
                {
                        List<UnitTypeInfoModel> list = new List<UnitTypeInfoModel>();
                        string strWhere = "1=1";
                        List<SqlParameter> listParas = new List<SqlParameter>();
                        if(!string.IsNullOrEmpty(keywords))
                        {
                                strWhere += " and (UTypeName like @keywords or ParentName  like @keywords or UTypeNo  like @keywords or UTPYNo  like @keywords)";
                                listParas.Add(new SqlParameter("@keywords", $"%{keywords}%"));
                        }
                        strWhere += " and IsDeleted=@isDeleted";
                        strWhere += " order by ParentId";
                        listParas.Add(new SqlParameter("@isDeleted", isDeleted));
                        string cols = "UTypeId,UTypeName,ParentId,ParentName,UTypeNo,UTPYNo,UTOrder";
                        list = GetModelList(strWhere, cols, listParas.ToArray());
                        return list;
                }

                /// <summary>
                /// 获取指定的类别信息实体
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public UnitTypeInfoModel GetUnitType(int typeId)
                {
                        string cols = "UTypeId,UTypeName,ParentId,ParentName,UTypeNo,UTPYNo,UTOrder";
                        return GetById(typeId, cols);
                }

                /// <summary>
                /// 判断名称是否已存在
                /// </summary>
                /// <param name="typeName"></param>
                /// <returns></returns>
                public bool ExistsUnitType(string typeName)
                {
                        return ExistsByName("UTypeName", typeName);
                }

                /// <summary>
                /// 获取子类别列表
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public List<UnitTypeInfoModel> GetChildTypes(int typeId)
                {
                        return GetModelList($"IsDeleted=0 and ParentId={typeId}", "UTypeId,UTypeName");
                }

                /// <summary>
                /// 添加往来单位类别信息
                /// </summary>
                /// <param name="utInfo"></param>
                /// <returns>类别编号</returns>
                public int AddUnitType(UnitTypeInfoModel utInfo)
                {
                        string cols = "UTypeName,ParentId,ParentName,UTypeNo,UTPYNo,UTOrder,Creator";
                        return Add(utInfo, cols, 1);
                }

                /// <summary>
                /// 修改往来单位类别信息
                /// </summary>
                /// <param name="utInfo"></param>
                /// <param name="blUpdate"></param>
                /// <returns></returns>
                public bool UpdateUnitType(UnitTypeInfoModel utInfo,bool blUpdate)
                {
                        List<CommandInfo> list = new List<CommandInfo>();
                        string cols = "UTypeId,UTypeName,ParentId,ParentName,UTypeNo,UTPYNo,UTOrder";
                        SqlModel upModel = CreateSql.GetUpdateSqlAndParas(utInfo, cols, "");
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
                                        new SqlParameter("@ParentName",utInfo.UTypeName),
                                        new SqlParameter("@ParentId",utInfo.UTypeId)
                                };
                                list.Add(new CommandInfo()
                                {
                                        CommandText = "update UnitTypeInfos set ParentName=@ParentName where ParentId=@ParentId",
                                        IsProc = false,
                                        Paras = paras
                                });
                        }
                        return SqlHelper.ExecuteTrans(list);
                }

                /// <summary>
                /// 关键词获取单位类别信息
                /// </summary>
                /// <param name="keywords"></param>
                /// <returns></returns>
                public UnitTypeInfoModel GetUnitTypeInfoByKeywords(string keywords)
                {
                        string strWhere = " UTypeName like @keywords or UTypeNo like @keywords or UTPYNo like @keywords";
                        SqlParameter paraKeywords = new SqlParameter("@keywords", $"%{keywords}%");
                        return GetModel(strWhere, "", paraKeywords);
                }

                /// <summary>
                /// 获取指定类别名称的子类别
                /// </summary>
                /// <param name="parentName"></param>
                /// <returns></returns>
                public List<UnitTypeInfoModel> GetChildTypes(string parentName)
                {
                        return GetModelList($"IsDeleted=0 and ParentName='{parentName}'", "UTypeId,UTypeName");
                }
        }
}
