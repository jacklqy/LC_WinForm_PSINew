using PSINew.DAL;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.BLL
{
       public  class SheetQueryBLL
        {
                SheetQueryDAL sheetDAL = new SheetQueryDAL();
                /// <summary>
                /// 分页查询单据列表
                /// </summary>
                /// <param name="paraModel"></param>
                /// <param name="startIndex"></param>
                /// <param name="pageSize"></param>
                /// <returns></returns>
                public PageModel<SheetInfoModel> GetSheetList(ShQueryParaModel paraModel, int startIndex, int pageSize)
                {
                        PageModel<SheetInfoModel> pageModel = sheetDAL.GetSheetList(paraModel, startIndex, pageSize);
                        foreach(SheetInfoModel s in pageModel.ReList)
                        {
                                s.CheckState = GetCheckState(s.IsChecked);
                                s.ShTypeName = GetShTypeName(s.ShType);
                        }
                        return pageModel;
                }

                /// <summary>
                /// 获取指定 供应商/客户 、 仓库 、商品的相关单据明细列表
                /// </summary>
                /// <param name="shType"></param>
                /// <param name="typeId"></param>
                /// <param name="id"></param>
                /// <returns></returns>
                public List<SheetGoodsInfoModel> GetSheetGoodsInfoList(int shType,int typeId,int id)
                {
                        List<SheetGoodsInfoModel> list = sheetDAL.GetSheetGoodsInfoList(shType, typeId, id);
                        if(list.Count >0)
                        {
                                foreach(var sh in list)
                                {
                                        sh.CheckState = GetCheckState(sh.IsChecked);
                                        sh.ShTypeName = GetShTypeName(sh.ShType);
                                        if(sh.ShType==1||sh.ShType==3)
                                        {
                                                sh.InCount = sh.Count;
                                                sh.OutCount = 0;
                                        }
                                        else
                                        {
                                                sh.InCount = 0;
                                                sh.OutCount = sh.Count;
                                        }
                                }
                        }
                        return list;
                }

                /// <summary>
                /// 获取审核状态列表
                /// </summary>
                /// <returns></returns>
                public List<CheckModel> GetCheckList()
                {
                       return  new List<CheckModel>()
                        {
                                new CheckModel()
                                {
                                        CheckId=0,
                                        CheckState="待审核"
                                },
                                 new CheckModel()
                                {
                                        CheckId=1,
                                        CheckState="已审核"
                                },
                                  new CheckModel()
                                {
                                        CheckId=2,
                                        CheckState="已作废"
                                },
                                   new CheckModel()
                                {
                                        CheckId=3,
                                        CheckState="已红冲"
                                }
                        };
                }

                /// <summary>
                /// 获取审核状态说明
                /// </summary>
                /// <param name="isChecked"></param>
                /// <returns></returns>
                private string GetCheckState(int isChecked)
                {
                        string cState = "";
                        switch (isChecked)
                        {
                                case 0:
                                        cState = "待审核";
                                        break;
                                case 1:
                                        cState = "已审核";
                                        break;
                                case 2:
                                        cState = "已作废";
                                        break;
                                case 3:
                                        cState = "已红冲";
                                        break;
                        }
                        return cState;
                }

                /// <summary>
                /// 获取单据类型说明
                /// </summary>
                /// <param name="shType"></param>
                /// <returns></returns>
                private string GetShTypeName(int shType)
                {
                        string shTypeName = "";
                        switch (shType)
                        {
                                case 1:
                                        shTypeName = "采购入库单";
                                        break;
                                case 2:
                                        shTypeName = "销售出库单";
                                        break;
                                case 3:
                                        shTypeName = "期初入库单";
                                        break;
                        }
                        return shTypeName;
                }
        }
}
