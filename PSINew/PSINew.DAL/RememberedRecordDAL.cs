using DbUtility;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
    public class RememberedRecordDAL:BaseDAL<RememberedRecordInfoModel>
    {
        public List<RememberedRecordInfoModel> GetRecordsByIp(string loginIP)
        {
            List<RememberedRecordInfoModel> list = new List<RememberedRecordInfoModel>();
           list =  GetModelList($"LoginIp='{loginIP}'", "Id,UserName,UserRealPwd");
            return list;
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool AddRememberedRecord(RememberedRecordInfoModel record)
        {
            if(record.Id ==0)
            {
                return Add(record, "LoginIP,UserName,UserRealPwd,ReOrder", 0) > 0;
            }
              
            else
            {
                return Update(record, "Id,LoginIP, UserName, UserRealPwd, ReOrder", "");
            }
        }

        /// <summary>
        /// 判断该记录是否已存在
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Exists(string ip,string userName)
        {
           return Exists($"LoginIP='{ip}' and UserName='{userName}'");
        }

        public bool DeleteRecord(string ip,string userName)
        {
            return Delete(1,$"LoginIP='{ip}' and UserName='{userName}'",2,null);
        }
        /// <summary>
        /// 获取指定用户的密码
        /// </summary>
        /// <param name="uName"></param>
        /// <returns></returns>
        public string  GetPwdByUserName(string uName,string ip)
        {
            RememberedRecordInfoModel model= GetModel($"UserName='{uName}' and LoginIP='{ip}' ", "UserRealPwd");
            if (model != null)
                return model.UserRealPwd;
            return "";
        }

        public int GetMaxReOrder(string Ip)
        {
            string sql = $"select max(ReOrder)+1 from RememberedRecords where LoginIP='{Ip}'";
          object oOrder=SqlHelper.ExecuteScalar(sql, 1);
            if (oOrder == null)
                return 1;
            else
                return (int)oOrder;
        }
    }
}
