using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
        public class UnitTypeBLL:BaseBLL<UnitTypeInfoModel>
        {
                private UnitTypeDAL utDAL = new UnitTypeDAL();
                private UnitDAL unitDAL = new UnitDAL();
                /// <summary>
                /// 获取所有的往来单位类别列表（绑定下拉框）
                /// </summary>
                /// <returns></returns>
                public List<UnitTypeInfoModel> LoadAllDrpUnitTypes()
                {
                        return utDAL.LoadAllDrpUnitTypes();
                }

                /// <summary>
                /// 获取所有的往来单位类别列表（绑定TreeView）
                /// </summary>
                /// <returns></returns>
                public List<UnitTypeInfoModel> LoadAllTVUnitTypes()
                {
                        return utDAL.LoadAllTVUnitTypes();
                }

                /// <summary>
                /// 获取指定的子类别列表
                /// </summary>
                /// <param name="typeName"></param>
                /// <returns></returns>
                public List<UnitTypeInfoModel> GetAllUnitTypes(string typeName)
                {
                        return utDAL.GetChildTypes(typeName);
                }

                /// <summary>
                /// 条件查询往来单位列表
                /// </summary>
                /// <param name="keywords"></param>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<UnitTypeInfoModel> LoadUnitTypeList(string keywords, bool blShowDel)
                {
                        int isDeleted = blShowDel ? 1 : 0;
                        if (string.IsNullOrEmpty(keywords))
                                return utDAL.LoadUnitTypeList(null, isDeleted);
                        else
                                return utDAL.LoadUnitTypeList(keywords, isDeleted);
                }

                /// <summary>
                /// 获取指定的类别信息实体
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public UnitTypeInfoModel GetUnitType(int typeId)
                {
                        return utDAL.GetUnitType(typeId);
                }

                /// <summary>
                /// 判断名称是否已存在
                /// </summary>
                /// <param name="typeName"></param>
                /// <returns></returns>
                public bool ExistsUnitType(string typeName)
                {
                        return utDAL.ExistsUnitType(typeName);
                }

                /// <summary>
                /// 添加往来单位类别信息
                /// </summary>
                /// <param name="utInfo"></param>
                /// <returns>类别编号</returns>
                public int AddUnitType(UnitTypeInfoModel utInfo)
                {
                        return utDAL.AddUnitType(utInfo);
                }

                /// <summary>
                /// 修改往来单位类别信息
                /// </summary>
                /// <param name="utInfo"></param>
                /// <param name="blUpdate"></param>
                /// <returns></returns>
                public bool UpdateUnitType(UnitTypeInfoModel utInfo,string oldName)
                {
                        bool blUpdate = oldName == utInfo.UTypeName ? false : true;
                        return utDAL.UpdateUnitType(utInfo, blUpdate);
                }

                /// <summary>
                /// 指定类别是否添加了子类别
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public bool IsAddChilds(int typeId)
                {
                        List<UnitTypeInfoModel> childs = utDAL.GetChildTypes(typeId);
                        if (childs.Count > 0)
                                return true;
                        else
                                return false;
                }

                /// <summary>
                /// 是否添加了单位信息
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public bool IsAddUnits(int typeId)
                {
                        List<UnitInfoModel> units = unitDAL.GetUnitInfosByTypeId(typeId);
                        if (units.Count > 0)
                                return true;
                        else
                                return false;
                }

                /// <summary>
                /// 关键词获取单位信息
                /// </summary>
                /// <param name="keywords"></param>
                /// <returns></returns>
                public string GetUTypeNameByKeywords(string keywords)
                {
                        UnitTypeInfoModel utInfo = utDAL.GetUnitTypeInfoByKeywords(keywords);
                        if (utInfo != null)
                                return utInfo.UTypeName;
                        return "";
                }
        }
}
