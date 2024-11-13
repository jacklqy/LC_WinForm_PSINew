using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINew.DAL
{
        public class StoreTypeDAL : BaseDAL<StoreTypeInfoModel>
        {
                /// <summary>
                /// 加载所有的仓库类别信息
                /// </summary>
                /// <param name="isDeleted"></param>
                /// <returns></returns>
                public List<StoreTypeInfoModel> LoadAllStoreTypes(int isDeleted)
                {
                        string cols = "STypeId,STypeName,STPYNo,STypeOrder";
                        return GetModelList($"IsDeleted={isDeleted} order by STypeOrder", cols);
                }

                /// <summary>
                /// 获取所有有效的类别（编号、名称）---用于绑定下拉框或TreeView
                /// </summary>
                /// <returns></returns>
                public List<StoreTypeInfoModel> LoadAllDrpStoreTypes()
                {
                        string cols = "STypeId,STypeName";
                        return GetModelList($"IsDeleted=0 ", cols);
                }

                /// <summary>
                /// 获取指定类别信息
                /// </summary>
                /// <param name="typeId"></param>
                /// <returns></returns>
                public StoreTypeInfoModel  GetStoreType(int typeId)
                {
                        string cols = "STypeId,STypeName,STPYNo,STypeOrder";
                        // return GetModel($"STypeId={typeId} ", cols);
                        return GetById(typeId, cols);
                }

                /// <summary>
                /// 判断类别名称是否已存在
                /// </summary>
                /// <param name="storeName"></param>
                /// <returns></returns>
               public bool   ExistsStoreType(string storeName)
                {
                        return ExistsByName("STypeName", storeName);
                }

                /// <summary>
                /// 新增仓库类别信息
                /// </summary>
                /// <param name="storeTypeInfo"></param>
                /// <returns></returns>
               public int  AddStoreType(StoreTypeInfoModel storeTypeInfo)
                {
                        return Add(storeTypeInfo, "STypeName,STPYNo,STypeOrder,Creator",1);
                }

                /// <summary>
                /// 修改仓库类别信息
                /// </summary>
                /// <param name="storeTypeInfo"></param>
                /// <returns></returns>
                public bool UpdateStoreType(StoreTypeInfoModel storeTypeInfo)
                {
                        return Update(storeTypeInfo, "STypeId,STypeName,STPYNo,STypeOrder");
                }
        }
}
