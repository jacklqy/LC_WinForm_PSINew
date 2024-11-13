using Common;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class UnitDAL : BaseDAL<UnitInfoModel>
    {
        /// <summary>
        /// 获取指定类别的单位信息列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<UnitInfoModel> GetUnitInfosByTypeId(int typeId)
        {
            return GetModelList($"IsDeleted=0 and UTypeId={typeId}", "UnitId,UnitName,UnitNo");
        }

        /// <summary>
        /// 条件查询单位信息列表（分页）
        /// </summary>
        /// <param name="uTypeId"></param>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<ViewUnitInfoModel> GetUnitList(int uTypeId, string keywords, int isDeleted, int startIndex, int pageSize)
        {
            //存储过程  返回两个结果   总记录数    当前页数据列表
            string cols = "UnitId,UnitName,UnitPYNo,UTypeId,UTypeName,UnitProperties,RegionId,Address,FullAddress,UnitNo,IsNoVail,ContactPerson";
            string strWhere = "1=1";
            strWhere += $" and IsDeleted={isDeleted}";
            //总记录数    当前页数据列表
            DataSet ds = GetPageDs<ViewUnitInfoModel>(strWhere, uTypeId, keywords, cols, "proc_GetUnitPage", startIndex, pageSize);
            return DsToPageModel<ViewUnitInfoModel>(ds, cols);
        }

        /// <summary>
        /// 关键词模糊查询单位列表信息
        /// </summary>
        /// <param name="utypeId"></param>
        /// <param name="keywords"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public List<UnitInfoModel> GetUnitList(int utypeId, string utypeName, string keywords)
        {
            string cols = "UnitId,UnitName,UnitPYNo,ContactPerson,PhoneNumber,Telephone,FullAddress";
            string strWhere = "1=1";
            List<SqlParameter> list = new List<SqlParameter>();
            if (utypeId > 0)
            {
                strWhere += " and (UTypeId in (select UTypeId from UnitTypeInfos where UTypeId=@utypeId  or ParentId in (select UTypeId from UnitTypeInfos  where ParentId=@utypeId or UTypeId=@utypeId)))";
                list.Add(new SqlParameter("@utypeId", utypeId));
            }

            else if (!string.IsNullOrEmpty(utypeName))
            {
                strWhere += " and (UTypeId in (select UTypeId from UnitTypeInfos where UTypeName=@utypeName or  ParentId in (select UTypeId from UnitTypeInfos where UTypeName like @parentName)) or UnitProperties like @parentName)";
                list.Add(new SqlParameter("@utypeName", utypeName));
                list.Add(new SqlParameter("@parentName", $"%{utypeName}%"));
            }

            if (!string.IsNullOrEmpty(keywords))
            {
                strWhere += " and (UnitName like @keywords or UnitPYNo like @keywords)";
                list.Add(new SqlParameter("@keywords", $"%{keywords}%"));
            }

            return GetModelList(strWhere, cols, list.ToArray());
        }

        /// <summary>
        /// 检查单位是否在使用中
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public bool CheckUnitUse(int unitId)
        {
            string sql1 = $"select count(1) from PerchaseInStoreInfos where UnitId={unitId} and IsDeleted=0";
            string sql2 = $"select count(1) from SaleOutStoreInfos where UnitId={unitId} and IsDeleted=0";
            DataSet ds = GetDs($"{sql1};{sql2}", 1);
            if (ds != null && ds.Tables.Count > 0)
            {
                int count1 = ds.Tables[0].Rows[0][0].ToString().GetInt();
                int count2 = ds.Tables[1].Rows[0][0].ToString().GetInt();
                if (count1 > 0 || count2 > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取指定的单位信息
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public UnitInfoModel GetUnitInfo(int unitId)
        {
            string cols = "UnitId,UnitName,UnitPYNo,UTypeId,UnitProperties,RegionId,Address,FullAddress,UnitNo,ContactPerson,PhoneNumber,Telephone,Fax,Email,PostalCode,Remark,IsNoVail";
            return GetById(unitId, cols);
        }

        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public bool AddUnitInfo(UnitInfoModel unitInfo)
        {
            string cols = "UnitName,UnitPYNo,UTypeId,UnitProperties,RegionId,Address,FullAddress,UnitNo,ContactPerson,PhoneNumber,Telephone,Fax,Email,PostalCode,Remark,IsNoVail,Creator";
            return Add(unitInfo, cols, 0) > 0;
        }

        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public bool UpdateUnitInfo(UnitInfoModel unitInfo)
        {
            string cols = "UnitId,UnitName,UnitPYNo,UTypeId,UnitProperties,RegionId,Address,FullAddress,UnitNo,ContactPerson,PhoneNumber,Telephone,Fax,Email,PostalCode,Remark,IsNoVail";
            return Update(unitInfo, cols);
        }

        /// <summary>
        /// 判断单位是否已存在
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool ExistUnit(string unitName, int uTypeId)
        {
            List<SqlParameter> listParas = new List<SqlParameter>();
            string strWhere = "UnitName=@unitName and IsDeleted=0";
            if (uTypeId > 0)
            {
                strWhere += " and UTypeId=@uTypeId";
                listParas.Add(new SqlParameter("@uTypeId", uTypeId));
            }
            listParas.Add(new SqlParameter("@unitName", unitName));

            return Exists(strWhere, listParas.ToArray());
        }

        /// <summary>
        /// 关键词获取单位信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public UnitInfoModel GetUnitInfoByKeywords(string keywords)
        {
            string strWhere = " UnitName like @keywords or UnitNo like @keywords or UnitPYNo like @keywords";
            SqlParameter paraKeywords = new SqlParameter("@keywords", $"%{keywords}%");
            return GetModel(strWhere, "", paraKeywords);
        }
    }
}
