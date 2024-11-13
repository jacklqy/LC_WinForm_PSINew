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
using PSINew.Models.UIModels;
using PSINew.Models.VModels;
using DXPSIApp.QM;
using DevExpress.XtraTab;

namespace DXPSIApp.Perchase
{
    public partial class FrmPerchaseQueryByGoods : DevExpress.XtraEditors.XtraForm
    {
        public FrmPerchaseQueryByGoods()
        {
            InitializeComponent();
        }
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        public StoreModel store = null;
        public UnitModel unit = null;
        private PerQueryGoodsViewModel fVModel = null;
        int isLoad = 0;
        private void FrmPerchaseQueryByGoods_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new PerQueryGoodsViewModel();
                RegisterEvents();
                InitGoodsTypes();
                LoadPerDataList();
            };
            act.TryCatch("采购统计", "按商品统计采购数据页面初始化异常！");
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

        private void InitGoodsTypes()
        {
            tlGTypes.LoadTVGoodsTypes(fVModel.GTypeList);
        }

        private void RegisterEvents()
        {
            queryTool1.FindClick += QueryTool1_FindClick;
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
            pbStore.Click += PbStore_Click;
            pbSuppliers.Click += PbSuppliers_Click;
            tlGTypes.FocusedNodeChanged += TlGTypes_FocusedNodeChanged;
            gvGoodsList.RowClick += GvGoodsList_RowClick;
            ucPager1.BindSource += UcPager1_BindSource;
        }

     

        private void TlGTypes_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            FindPerData();
        }

        private void QueryTool1_ExportClick(object sender, ItemClickEventArgs e)
        {
            //获取查询条件并封装
            QueryParaModel paraModel = GetParaModel();
            //条件查询出来的所有数据
            List<PerQueryGoodsModel> perData = perBLL.GetPerDataByGoods(paraModel, 1, 100000000).ReList;
            string fileName = "采购统计——按商品";
            FormUtility.DataToExcel<PerQueryGoodsModel>(perData, gvGoodsList.Columns, fileName + ".xls", fileName, fileName, "导出按商品采购统计数据");
        }

        private QueryParaModel GetParaModel()
        {
            //条件获取与封装
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            //封装查询条件实体
            QueryParaModel pModel = fVModel.GetParaModel();
            return pModel;
        }

        private void QueryTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void QueryTool1_FindClick(object sender, ItemClickEventArgs e)
        {
            FindPerData();
        }

        private void PbStore_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Store-PerQueryByGoods"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbSuppliers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Supplier-PerQueryByGoods"
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }


        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindPerData();
        }

        private void GvGoodsList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                int rowIndex = e.RowHandle;
                if (rowIndex != -1)
                {
                    PerQGoodsModel perInfo = fVModel.PerList[rowIndex];
                    if (perInfo != null)
                    {
                        FrmSheetInfo fSheetInfo = new FrmSheetInfo();
                        //shType   typeId  id  infoName
                        fSheetInfo.Tag = new SheetInfoData()
                        {
                            ShType = 1,
                            TypeId = 3,
                            Id = perInfo.GoodsId,
                            InfoName = perInfo.GoodsName
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

        private void FindPerData()
        {
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            fVModel.GetPerQueryList();
            if (isLoad == 1)
            {
                gcPerData.ReLoadData();
            }
        }
    }
}