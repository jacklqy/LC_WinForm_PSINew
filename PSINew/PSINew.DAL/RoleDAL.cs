using Common;
using DbUtility;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class RoleDAL:BaseDAL<RoleInfoModel>
    {
        /// <summary>
        /// 获取所有角色列表（主要用于绑定下拉框或列表框）
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            string cols = "RoleId,RoleName";
            return GetModelList(cols);
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoleList(int isDeleted)
        {
            string cols = "RoleId,RoleName,Remark";
            return GetModelList($"IsDeleted={isDeleted}",cols);
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool ExistRoleName(string roleName)
        {
            return ExistsByName("RoleName", roleName);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            return Add(roleInfo, "RoleName,Remark,Creator", 0)>0;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            return Update(roleInfo, "RoleId,RoleName,Remark", "");
        }


        /// <summary>
        /// 获取指定的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRole(int roleId)
        {
            string cols = "RoleName,Remark,IsAdmin";
            return GetById(roleId, cols);
        }

        /// <summary>
        /// 删除单个角色信息
        /// </summary>
        /// <param name="roleId"></param>
        ///  <param name="delType">0 ---logic   1= real</param>
        /// <returns></returns>
        public bool  DeleteRole(int roleId,int delType,int isDeleted)
        {
            List<string> listSqls = new List<string>();
            listSqls = GetDeleteRoleSql(delType,roleId,isDeleted);
            return SqlHelper.ExecuteTrans(listSqls);
        }

        /// <summary>
        /// 删除多个角色信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="delType"></param>
        /// <returns></returns>
        public bool DeleteRoles(List<int> roleIds,int delType,int isDeleted)
        {
            List<string> listSqls = new List<string>();
            foreach(int roleId in roleIds)
            {
                listSqls.AddRange(GetDeleteRoleSql(delType, roleId,isDeleted));
            }
            return SqlHelper.ExecuteTrans(listSqls);
        }

        /// <summary>
        /// 生成删除角色信息的sql
        /// </summary>
        /// <param name="delType"></param>
        /// <param name="listSqls"></param>
        /// <returns></returns>
        private List<string> GetDeleteRoleSql(int delType,int   roleId,int isDeleted)
        {
            List<string> listSqls = new List<string>();
            string[] tables = { "RoleInfos", "UserRoleInfos", "RoleMenuInfos", "RoleTMenuInfos" };
            string strWhere = $"RoleId={roleId}";
            if (delType == 0)
            {
                foreach (string tName in tables)
                {
                    listSqls.Add($"update {tName} set IsDeleted = {isDeleted} where {strWhere}");
                }
            }
            else if (delType == 1)
            {
                foreach (string tName in tables)
                {
                    listSqls.Add($"delete from {tName}  where {strWhere}");
                }
            }
            return listSqls;
        }

        /// <summary>
        /// 保存权限数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rmList"></param>
        /// <param name="rtmList"></param>
        /// <returns></returns>
        public bool SetRoleRight(int roleId,List<RoleMenuInfoModel> rmList,List<RoleTMenuInfoModel> rtmList)
        {
            //先删除角色相关的权限数据  检查 ---是否存在这么一条关系数据，否---插入   不插入
            return SqlHelper.ExecuteTrans<bool>(cmd =>
            {
                try
                {
                    if(rmList.Count>0)
                    {
                        string noIds = string.Join(",", rmList.Select(rm => rm.MId));
                        cmd.CommandText = $"delete from RoleMenuInfos  where MId not in ({noIds}) and RoleId={roleId}  and IsDeleted=0";
                        cmd.ExecuteNonQuery();
                        foreach (var rm in rmList)
                        {
                            cmd.CommandText = $"select count(1) from RoleMenuInfos where RoleId={rm.RoleId} and MId = {rm.MId} and IsDeleted=0";
                           object oCount =  cmd.ExecuteScalar();
                            if (oCount != null && oCount.ToString() != "")
                            {
                                int count =oCount.GetInt();
                                if (count == 0)
                                {
                                    SqlModel insertModel = CreateSql.GetInsertSqlAndParas(rm, "MId,RoleId,Creator", 0);
                                    cmd.CommandText = insertModel.Sql;
                                    foreach (var p in insertModel.SqlParaArray)
                                    {
                                        cmd.Parameters.Add(p);
                                    }
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                                else
                                    continue;
                            }
                        }
                    }
                    if(rtmList.Count>0)
                    {
                        string noIds = string.Join(",", rtmList.Select(rtm => rtm.TMenuId));
                        cmd.CommandText = $"delete from RoleTMenuInfos  where TMenuId not in ({noIds}) and RoleId={roleId}  and IsDeleted=0";
                        cmd.ExecuteNonQuery();
                        foreach (var rtm in rtmList)
                        {
                            cmd.CommandText = $"select count(1) from RoleTMenuInfos where RoleId={rtm.RoleId} and TMenuId = {rtm.TMenuId} and IsDeleted=0";
                            object oCount = cmd.ExecuteScalar();
                            if (oCount != null && oCount.ToString() != "")
                            {
                                int count = oCount.GetInt();
                                if (count == 0)
                                {
                                    SqlModel insertModel = CreateSql.GetInsertSqlAndParas(rtm, "TMenuId,RoleId,Creator", 0);
                                    cmd.CommandText = insertModel.Sql;
                                    foreach (var p in insertModel.SqlParaArray)
                                    {
                                        cmd.Parameters.Add(p);
                                    }
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                                else
                                    continue;
                            }
                        }
                    }
                    cmd.Transaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception("保存权限数据，执行异常！", ex);
                }
            });
            //保存权限数据
        }
    }
}
