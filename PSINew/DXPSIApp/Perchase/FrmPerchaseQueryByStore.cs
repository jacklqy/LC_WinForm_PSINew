using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSINew.Models.DModels;
using PSINew.UModels;
using PSINew.BLL;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DXPSIApp.BM;
using DXPSIApp.FModels;
using DXPSIApp.QM;
using DevExpress.XtraTab;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;

namespace DXPSIApp.Perchase
{
    public partial class FrmPerchaseQueryByStore : DevExpress.XtraEditors.XtraForm
    {
        public FrmPerchaseQueryByStore()
        {
            InitializeComponent();
        }
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        public UnitModel unit = null;
        private PerQueryStoreViewModel fVModel = null;
        int isLoad = 0;

        private void FrmPerchaseQueryByStore_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new PerQueryStoreViewModel();
                RegisterEvents();
                InitStoreypes();
                LoadPerDataList();
            };
            act.TryCatch("采购统计","按仓库统计采购数据页面初始化异常！");
        }

      

        private void InitStoreypes()
        {
            tlSTypes.LoadTLStoreTypes(fVModel.STypeList);
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbSuppliers.Click += PbSuppliers_Click;
            tlSTypes.FocusedNodeChanged += TlSTypes_FocusedNodeChanged;
            gvStoreList.RowClick += GvStoreList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
        }

        private void LoadPerDataList()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName", true);
                txtSupplier.DataBind(fVModel, "UnitName", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                ucPager1.DataBind(fVModel, "StartRecord", "StartIndex", true);
                ucPager1.DataBind(fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcPerData.DataBind(fVModel, "DataSource", "PerList", true);
                isLoad = 1;
            }
        }

      

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindPerDataList();
        }

        private void GvStoreList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    PerQStoreModel perInfo = fVModel.PerList[rowIndex];
                    if (perInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType = 1,
                            TypeId = 2,
                            Id = perInfo.StoreId,
                            InfoName = perInfo.StoreName
                        };
                        XtraTabControl tab = this.Parent.Parent as XtraTabControl;
                        int index = -1;
                        if (FormUtility.CheckOpenForm(fSheetInfo.Name))
                        {
                            XtraTabPage page = tab.TabPages.Where(p => p.Name == fSheetInfo.Name).FirstOrDefault();
                            index = tab.TabPages.IndexOf(page);
                            tab.TabPages.Remove(page);
                        }
                        tab.AddTabFormPage(fSheetInfo, index);
                    }
                }
            }
        }

        private void TlSTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindPerDataList();
        }

        private void PbSuppliers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Supplier-PerQueryByStore"
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void QueryTool1_ExportClick(object sender, ItemClickEventArgs e)
        {
            //获取查询条件并封装
            QueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<PerQueryStoreModel> perData = perBLL.GetPerDataByStore(paraModel, 1, 100000000).ReList;
            string fileName = "采购统计——按仓库";
            FormUtility.DataToExcel<PerQueryStoreModel>(perData, gvStoreList.Columns, fileName + ".xls", fileName, fileName, "导出按仓库采购统计数据");
        }

        private void QueryTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindPerDataList();
        }

        private void FindPerDataList()
        {
            StoreTypeInfoModel selType = tlSTypes.GetDataRecordByNode(tlSTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            fVModel.GetPerQueryList();
            if (isLoad == 1)
            {
                gcPerData.ReLoadData();
            }
        }

        private QueryParaModel GetParaModel()
        {
            //条件获取与封装
            StoreTypeInfoModel selType = tlSTypes.GetDataRecordByNode(tlSTypes.FocusedNode) as StoreTypeInfoModel;
            if (selType != null)
            {
                fVModel.STypeId = selType.STypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }
    }
}