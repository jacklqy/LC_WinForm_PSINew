using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;
using PSINew.Models.UIModels;
using System.Data.SqlTypes;
using DbUtility;

namespace PSINew.DAL
{
    public class BaseDAL<T>:BQuery<T> where T : class
    {

        #region 添加
        /// <summary>
        /// 添加实体信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="strCols">插入列名字符串，若为空，则全插入</param>
        /// <returns></returns>
        public int Add(T t, string strCols,int isReturn)
        {
            if (t == null)
                return 0;
            //获取生成的sql和参数列表
            SqlModel insert = CreateSql.GetInsertSqlAndParas<T>(t, strCols, isReturn);
            //执行sql命令
            if(isReturn==0)
            return SqlHelper.ExecuteNonQuery(insert.Sql, 1, insert.SqlParaArray);
            else
            {
                object oId= SqlHelper.ExecuteScalar(insert.Sql, 1, insert.SqlParaArray);
                if (oId != null && oId.ToString() != "")
                    return oId.GetInt();
                else
                    return 0;
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <param name="strCols"></param>
        /// <returns></returns>
        public bool AddList(List<T> list, string strCols)
        {
            if (list == null || list.Count == 0)
                return false;
            List<CommandInfo> comList = new List<CommandInfo>();
            foreach (T t in list)
            {
                SqlModel insert = CreateSql.GetInsertSqlAndParas<T>(t, strCols,0);
                CommandInfo com = new CommandInfo(insert.Sql, false, insert.SqlParaArray);
                comList.Add(com);
            }
            return SqlHelper.ExecuteTrans(comList);
        }
        #endregion

        #region 修改

        /// <summary>
        /// 修改实体  以主键为条件定位
        /// </summary>
        /// <param name="t"></param>
        /// <param name="strCols"></param>
        /// <returns></returns>
        public bool Update(T t, string strCols)
        {
            if (t == null)
                return false;
            else
                return Update(t, strCols, "");
        }

        /// <summary>
        /// 修改信息实体
        /// </summary>
        /// <param name="t"></param>
        /// <param name="strCols">要修改的列</param>
        /// <param name="strWhere">条件 </param>
        /// <returns></returns>
        public bool Update(T t, string strCols, string strWhere, params SqlParameter[] paras)
        {
            if (t == null)
                return false;
            //获取生成的sql和参数列表
            SqlModel update = CreateSql.GetUpdateSqlAndParas<T>(t, strCols, strWhere);
            List<SqlParameter> listParas = update.SqlParaArray.ToList();
            if (paras != null && paras.Length > 0)
                listParas.AddRange(paras);
            //执行sql命令
            return SqlHelper.ExecuteNonQuery(update.Sql, 1, listParas.ToArray()) > 0;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list"></param>
        /// <param name="strCols"></param>
        /// <returns></returns>
        public bool UpdateList(List<T> list, string strCols)
        {
            if (list == null || list.Count == 0)
                return false;
            List<CommandInfo> comList = new List<CommandInfo>();
            foreach (T t in list)
            {
                SqlModel update = CreateSql.GetUpdateSqlAndParas<T>(t, strCols, "");
                CommandInfo com = new CommandInfo(update.Sql, false, update.SqlParaArray);
                comList.Add(com);
            }
            return SqlHelper.ExecuteTrans(comList);

        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据Id删除  这里id是主键 delType=1 真删除  0 假删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id,int delType,int isDeleted)
        {
            Type type = typeof(T);
            
            string strWhere = $"[{type.GetPrimary()}]=@Id";
            SqlParameter[] paras =
            {
                new SqlParameter("@Id",id)
            };
            return Delete(delType, strWhere,isDeleted, paras);
        }

        /// <summary>
        /// 按条件删除数据(假删除，包含可以恢复)
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="paras">参数列表</param>
        /// <returns></returns>
        public bool Delete(int actType,string strWhere,int isDeleted, SqlParameter[] paras)
        {
            Type type = typeof(T);
            string delSql = "";
            if(actType ==1)
              delSql = CreateSql.CreateDeleteSql<T>(strWhere);
            else 
              delSql = $"update [{type.GetTName()}] set IsDeleted={isDeleted} where {strWhere}";
            List<CommandInfo> list = new List<CommandInfo>();
            list.Add(new CommandInfo()
            {
                CommandText = delSql,
                IsProc = false,
                Paras = paras
            });
            return SqlHelper.ExecuteTrans(list);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public bool DeleteList(List<int> idList,int actType,int isDeleted)
        {
            Type type = typeof(T);
            List<CommandInfo> comList = new List<CommandInfo>();
            foreach (int id in idList)
            {
                string strWhere = $"[{type.GetPrimary()}]=@Id";
                string delSql = "";
                if(actType ==1)
                   delSql = CreateSql.CreateDeleteSql<T>(strWhere);
                else
                    delSql = $"update [{type.GetTName()}] set IsDeleted={isDeleted} where {strWhere}";
                SqlParameter[] paras ={
                                          new SqlParameter("@Id",id)
                                       };
                CommandInfo com = new CommandInfo(delSql, false, paras);
                comList.Add(com);
            }
            return SqlHelper.ExecuteTrans(comList);
        }
        #endregion

       
    }
}
