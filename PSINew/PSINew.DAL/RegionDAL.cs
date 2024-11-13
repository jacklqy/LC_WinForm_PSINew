using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public class RegionDAL : BQuery<RegionInfoModel>
        {
                /// <summary>
                /// 获取指定的区域信息
                /// </summary>
                /// <param name="regionId"></param>
                /// <returns></returns>
                public RegionInfoModel GetRegion(int regionId)
                {
                        return GetById(regionId, "");
                }

                /// <summary>
                /// 根据父编号与等级获取区域列表
                /// </summary>
                /// <param name="parentId"></param>
                /// <param name="level"></param>
                /// <returns></returns>
                public List<RegionInfoModel> GetReginList(int parentId, int level)
                {
                        string cols = "RegionId,RegionName";
                        string strWhere = "1=1";
                        strWhere += $" and ParentId={parentId}";
                        strWhere += $" and RegionLevel={level}";
                        return GetModelList(strWhere, cols);
                }
        }
}
