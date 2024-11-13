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
    public class GoodsUnitDAL:BaseDAL<GoodsUnitInfoModel>
    {
        /// <summary>
        /// 获取所有的单位列表
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<GoodsUnitInfoModel> GetAllUnits(int isDeleted)
        {
            string strWhere = $"IsDeleted={isDeleted} order by GUnitOrder";
           return GetModelList(strWhere, "GUnitId,GUnitName,GUnitPYNo,GUnitOrder");
        }
        /// <summary>
        /// 判断单位名称是否已存在
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool ExistName(string unitName)
        {
            return ExistsByName("GUnitName", unitName);
        }

        /// <summary>
        /// 检查是否有商品已应用该单位
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public int GetGoodsUnitUse(string unitName)
        {
            string sql = "select count(1) from GoodsInfos where IsDeleted=0 and GUnit=@GUnit";
            SqlParameter paraUName = new SqlParameter("@GUnit", unitName);
            object oCount = SqlHelper.ExecuteScalar(sql, 1, paraUName);
            if (oCount != null && oCount.ToString() != "")
                return oCount.GetInt();
            return 0;
        }

        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="guInfo"></param>
        /// <returns></returns>
        public bool AddGoodsUnit(GoodsUnitInfoModel guInfo)
        {
            return Add(guInfo, "GUnitName,GUnitPYNo,GUnitOrder,Creator", 0)>0;
        }

        /// <summary>
        /// 修改单位信息 isUpdateName:单位名称是否修改
        /// </summary>
        /// <param name="guInfo"></param>
        /// <returns></returns>
        public bool UpdatGoodsUnit(GoodsUnitInfoModel guInfo,bool isUpdateName,string oldName)
        {
            string cols = "GUnitId,GUnitName,GUnitPYNo,GUnitOrder";
            if (!isUpdateName)
              return Update(guInfo,cols, "");
            else
            {
                List<CommandInfo> list = new List<CommandInfo>();
                SqlModel upModel = CreateSql.GetUpdateSqlAndParas(guInfo, cols, "");
                SqlParameter[] paras =
                {
                    new SqlParameter("@GUnit",guInfo.GUnitName),
                     new SqlParameter("@OldGUnit",oldName),
                };
                list.Add(new CommandInfo()
                {
                    CommandText = upModel.Sql,
                    IsProc = false,
                    Paras = upModel.SqlParaArray
                });
                list.Add(new CommandInfo()
                {
                    CommandText = "update GoodsInfos set GUnit=@GUnit where GUnit=@OldGUnit",
                    IsProc=false,
                    Paras=paras
                });
                return SqlHelper.ExecuteTrans(list);
            }
        }
    }
}
