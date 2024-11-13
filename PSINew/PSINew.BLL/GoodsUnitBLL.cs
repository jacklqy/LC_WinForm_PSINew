using PSINew.BLL;
using PSINew.DAL;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
    public class GoodsUnitBLL:BaseBLL<GoodsUnitInfoModel>
    {
        private GoodsUnitDAL guDAL = new GoodsUnitDAL();
        /// <summary>
        ///  获取所有的单位列表
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public List<GoodsUnitInfoModel> GetAllUnits(bool isShowDel)
        {
            int isDeleted = isShowDel ? 1 : 0;
            return guDAL.GetAllUnits(isDeleted);
        }

        //删除（真假 多个 、单个）  恢复   省略不写

        /// <summary>
        /// 检查是否有商品已应用该单位
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool GetGoodsUnitUse(string unitName)
        {
            int count = guDAL.GetGoodsUnitUse(unitName);
            if (count == 0)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="guInfo"></param>
        /// <returns></returns>
        public bool AddGoodsUnit(GoodsUnitInfoModel guInfo)
        {
            return guDAL.AddGoodsUnit(guInfo);
        }

        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// <param name="guInfo"></param>
        /// <returns></returns>
        public bool UpdatGoodsUnit(GoodsUnitInfoModel guInfo,bool isUpdateName,string oldName)
        {
            return guDAL.UpdatGoodsUnit(guInfo,isUpdateName,oldName);
        }

        /// <summary>
        /// 判断单位名称是否已存在
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool ExistName(string unitName)
        {
            return guDAL.ExistName(unitName);
        }
    }
}
