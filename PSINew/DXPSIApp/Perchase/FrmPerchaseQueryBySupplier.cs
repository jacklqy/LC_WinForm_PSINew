﻿using System;
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
using DXPSIApp.BM;
using DXPSIApp.FModels;
using DXPSIApp.QM;
using DevExpress.XtraTab;
using PSINew.Models.UIModels;
using PSINew.Models.VModels;

namespace DXPSIApp.Perchase
{
    public partial class FrmPerchaseQueryBySupplier : DevExpress.XtraEditors.XtraForm
    {
        public FrmPerchaseQueryBySupplier()
        {
            InitializeComponent();
        }
        UnitTypeBLL utBLL = new UnitTypeBLL();
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        public StoreModel store = null;
        public UnitModel unit = null;
        public GoodsTypeInfoModel gtInfo = null;//选择的商品类别
        private PerQuerySupplierViewModel fVModel = null;
        int isLoad = 0;
        private void FrmPerchaseQueryBySupplier_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new PerQuerySupplierViewModel();
                RegisterEvents();
                InitUnitTypes();
                LoadPerDataList();
            };
            act.TryCatch("采购统计","按供应商统计采购数据页面初始化异常！");
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbGTypes.Click += PbGTypes_Click;
            pbStores.Click += PbStores_Click;
            pbSuppliers.Click += PbSuppliers_Click;
            tlUTypes.FocusedNodeChanged += TlUTypes_FocusedNodeChanged;
            gvPerList.RowClick += GvPerList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
            txtGoodsType.KeyPress += TxtGoodsType_KeyPress;
        }

        private void QueryTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void QueryTool1_FindClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindPerData();
        }

        private void QueryTool1_ExportClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //获取查询条件并封装
            QueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<PerQuerySupplierModel> perData = perBLL.GetPerDataBySupplier(paraModel, 1, 100000000).ReList;
            string fileName = "采购统计——按供应商";
            FormUtility.DataToExcel<PerQuerySupplierModel>(perData, gvPerList.Columns, fileName + ".xls", fileName, fileName, "导出按供应商采购统计数据");
        }

        private QueryParaModel GetParaModel()
        {
            //条件获取与封装
            UnitTypeInfoModel selType = tlUTypes.GetDataRecordByNode(tlUTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }

       

       

        private void TxtGoodsType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindPerData();
        }

        private void GvPerList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.Clicks==2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    PerQSupplierModel perInfo = fVModel.PerList[rowIndex];
                    if (perInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType = 1,
                            TypeId = 1,
                            Id = perInfo.UnitId,
                            InfoName = perInfo.UnitName
                        };
                        XtraTabControl tab = this.Parent.Parent as XtraTabControl;
                        int index = -1;
                        if (FormUtility.CheckOpenForm(fSheetInfo.Name))
                        {
                            XtraTabPage page= tab.TabPages.Where(p => p.Name == fSheetInfo.Name).FirstOrDefault();
                             index  = tab.TabPages.IndexOf(page);
                            tab.TabPages.Remove(page);
                        }
                        tab.AddTabFormPage(fSheetInfo,index);
                    }
                }
            }
           
        }

        private void TlUTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            FindPerData();
        }

        private void PbSuppliers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Supplier-PerQueryBySupplier"
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void PbStores_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Store-PerQueryBySupplier"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbGTypes_Click(object sender, EventArgs e)
        {
            FrmChooseTypes fCTypes = new FrmChooseTypes();
            fCTypes.Tag = new ChooseTypeData()
            {
                TypeCode = "Goods-PerQueryBySupplier",
                FGet = this
            };
            fCTypes.SetType += () => {
                fVModel.GTypeName = gtInfo.GTypeName;
                fVModel.GTypeId = gtInfo.GTypeId;
            };
            fCTypes.ShowDialog();
        }

        private void LoadPerDataList()
        {
             if(fVModel!=null)
            {
                txtGoodsName.DataBind(fVModel, "GoodsName", true);
                txtStoreName.DataBind(fVModel, "StoreName",true);
                txtGoodsType.DataBind(fVModel, "GTypeName", true);
                txtSupplier.DataBind(fVModel, "UnitName", true);
                txtDealPerson.DataBind(fVModel, "DealPerson", true);
                ucPager1.DataBind(fVModel, "StartRecord","StartIndex",true);
                ucPager1.DataBind( fVModel, "PageSize", "PageSize", true);
                ucPager1.DataBind(fVModel, "Record", "TotalCount", true);
                gcPerData.DataBind(fVModel, "DataSource", "PerList", true);
                isLoad = 1;
            }
        }

        private void InitUnitTypes()
        {
            tlUTypes.LoadTVUnitTypes(fVModel.UTypeList);
        }

        private void FindPerData()
        {
            UnitTypeInfoModel selType = tlUTypes.GetDataRecordByNode(tlUTypes.FocusedNode) as UnitTypeInfoModel;
            if (selType != null)
            {
                fVModel.UTypeId = selType.UTypeId;
            }
            fVModel.GetPerQueryList();
            if (isLoad == 1)
            {
                gcPerData.ReLoadData();
            }
        }
    }
}