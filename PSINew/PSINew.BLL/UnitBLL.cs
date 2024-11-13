using PSINew.DAL;
using PSINew.Models.DModels;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class UnitBLL : BaseBLL<UnitInfoModel>
    {
        private UnitDAL unitDAL = new UnitDAL();
        /// <summary>
        /// 条件查询单位信息列表（分页）
        /// </summary>
        /// <param name="uTypeId"></param>
        /// <param name="keywords"></param>
        /// <param name="isDeleted"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<ViewUnitInfoModel> GetUnitList(int uTypeId, string keywords, bool isShowDel, int startIndex, int pageSize)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return unitDAL.GetUnitList(uTypeId, keywords, isDeleted, startIndex, pageSize);
        }

        public List<UnitInfoModel> GetUnitList(int uTypeId, string utypeName, string keywords)
        {
            if (uTypeId == 0)
                utypeName = "";
            return unitDAL.GetUnitList(uTypeId, utypeName, keywords);
        }

        /// <summary>
        /// 检查单位是否在使用中
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public bool CheckUnitUse(int unitId)
        {
            return unitDAL.CheckUnitUse(unitId);
        }

        /// <summary>
        /// 获取指定的单位信息
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public UnitInfoModel GetUnitInfo(int unitId)
        {
            return unitDAL.GetUnitInfo(unitId);
        }

        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public bool AddUnitInfo(UnitInfoModel unitInfo)
        {
            return unitDAL.AddUnitInfo(unitInfo);
        }

        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// <param name="unitInfo"></param>
        /// <returns></returns>
        public bool UpdateUnitInfo(UnitInfoModel unitInfo)
        {
            return unitDAL.UpdateUnitInfo(unitInfo);
        }

        /// <summary>
        /// 判断单位是否已存在
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool ExistUnit(string unitName, int uTypeId)
        {
            return unitDAL.ExistUnit(unitName, uTypeId);
        }

        /// <summary>
        /// 关键词获取单位信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public string GetUnitNameByKeywords(string keywords)
        {
            UnitInfoModel unitInfo = unitDAL.GetUnitInfoByKeywords(keywords);
            if (unitInfo != null)
                return unitInfo.UnitName;
            return "";
        }
    }
}
