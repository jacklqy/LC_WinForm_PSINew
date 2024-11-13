using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
       public   class RegionBLL
        {
                private RegionDAL regionDAL = new RegionDAL();
                /// <summary>
                /// 根据区域编号获取区域完整信息
                /// </summary>
                /// <param name="regionId"></param>
                /// <returns></returns>
                public string GetRegionAddress(int regionId)
                {
                        string address = "";
                        RegionInfoModel region = regionDAL.GetRegion(regionId);
                        if(region!=null)
                        {
                                switch (region.RegionLevel)
                                {
                                        case 3:
                                                string addr = region.ParentName + region.RegionName;
                                                RegionInfoModel secRegion = regionDAL.GetRegion(region.ParentId);
                                                if (secRegion != null)
                                                {
                                                        if (secRegion.RegionLevel == 2)
                                                                address = secRegion.ParentName + addr;
                                                        else if (secRegion.RegionLevel == 1)
                                                                address = addr;
                                                }
                                                break;
                                        case 2:
                                                address= region.ParentName + region.RegionName;
                                                break;
                                        case 1:
                                                address = region.RegionName;
                                                break;
                                        default:break;
                                }
                        }

                        return address;
                }

                public RegionInfoModel GetRegion(int regionId)
                {
                        return regionDAL.GetRegion(regionId);
                }

                /// <summary>
                /// 获取省区域列表
                /// </summary>
                /// <returns></returns>
                public List<RegionInfoModel> GetProvinces()
                {
                        return regionDAL.GetReginList(1, 1);
                }

                /// <summary>
                /// 获取市区域列表
                /// </summary>
                /// <returns></returns>
                public List<RegionInfoModel> GetCities(int provinceId)
                {
                        return regionDAL.GetReginList(provinceId, 2);
                }

                /// <summary>
                /// 获取县/区 区域列表
                /// </summary>
                /// <returns></returns>
                public List<RegionInfoModel> GetCountries(int cityId)
                {
                        return regionDAL.GetReginList(cityId,3);
                }
        }
}
