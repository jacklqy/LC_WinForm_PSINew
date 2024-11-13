using Common;
using PSINew.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class SysBLL
    {
        SysDAL sysDAL = new SysDAL();

        /// <summary>
        /// 获取系统开账状态
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public bool GetOpenState(int sysId)
        {
            int isOpened = sysDAL.GetSysOpenState(sysId);
            if (isOpened == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 备份数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool BackupData(string path)
        {
            bool bl = false;
            string dbName = ConfigurationManager.AppSettings["DbName"].ToString();
            string backupName = dbName + DateTime.Today.ToString("yyyyMMdd");
            int reVal = sysDAL.BackupData(path, dbName, backupName);
            bl = reVal == 1 ? true : false;
            return bl;
        }

        /// <summary>
        /// 期初开账
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public bool OpenSys(int sysId)
        {
            return sysDAL.OpenSys(sysId);
        }

        /// <summary>
        /// 反开账
        /// </summary>
        /// <param name="sysId"></param>
        /// <returns></returns>
        public bool UnOpenedSys(int sysId)
        {
            return sysDAL.UnOpenSys(sysId);
        }

        /// <summary>
        /// 获取所有已审核单据数
        /// </summary>
        /// <returns></returns>
        public int GetAllCheckedCount()
        {
            DataSet ds = sysDAL.GetAllCheckedCount();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    int perCount = ds.Tables[0].Rows[0][0].ToString().GetInt();
                    int saleCount = ds.Tables[1].Rows[0][0].ToString().GetInt();
                    return perCount + saleCount;
                }
            }
            return 0;
        }
    }
}
