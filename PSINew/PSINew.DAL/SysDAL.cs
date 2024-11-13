using Common;
using DbUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class SysDAL
    {
        /// <summary>
        /// 获取开账状态
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public int GetSysOpenState(int sysId)
        {
            string sql = "select IsOpened from SysInfos where SysId=@sysId";
            SqlParameter paraId = new SqlParameter("@sysId", sysId);
            object oIsOpened = SqlHelper.ExecuteScalar(sql, 1, paraId);
            if (oIsOpened != null && oIsOpened.ToString() != "")
                return oIsOpened.GetInt();
            else
                return 0;
        }

        /// <summary>
        /// 备份数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dbName"></param>
        /// <param name="backupName"></param>
        /// <returns></returns>
        public int BackupData(string path,string dbName,string backupName )
        {
            SqlParameter[] paras =
            {
                new SqlParameter("@savePath",path),
                new SqlParameter("@dbName",dbName),
                new SqlParameter("@bakName",backupName),
                new SqlParameter("@return",SqlDbType.Int,4)
            };
            paras[3].Direction = ParameterDirection.ReturnValue;//返回值参数
            SqlHelper.ExecuteNonQuery("sp_BackupDB", 2, paras);
            return paras[3].Value.GetInt();
        }

        /// <summary>
        /// 系统所有已审核单据统计
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllCheckedCount()
        {
            string sql1 = "select count(1) from PerchaseInStoreInfos where IsChecked=1";
            string sql2 = "select count(1) from SaleOutStoreInfos where IsChecked=1";
            string sql = $"{sql1};{sql2}";
            DataSet ds = SqlHelper.GetDataSet(sql, 1);
            return ds;
        }

        /// <summary>
        /// 期初开账
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public bool OpenSys(int sysId)
        {
            string sql = "update SysInfos set IsOpened=1,OpenTime=@openTime where SysId=@sysId";
            SqlParameter[] paras =
            {
                new SqlParameter("@sysId",sysId),
                new SqlParameter("@openTime",DateTime.Now)
            };
            return SqlHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }

        /// <summary>
        /// 反开账，即将IsOpened设置为0,
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public bool UnOpenSys(int sysId)
        {
            string sql = "update SysInfos set IsOpened=0,OpenTime=null where SysId=@sysId";
            SqlParameter[] paras =
            {
                new SqlParameter("@sysId",sysId)
            };
            return SqlHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }
    }
}
