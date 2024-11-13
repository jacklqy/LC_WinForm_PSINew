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
using DXPSIApp.FModels;
using PSINew.BLL;
using PSINew.UModels;

namespace DXPSIApp.QM
{
    public partial class FrmSheetInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmSheetInfo()
        {
            InitializeComponent();
        }
        SheetInfoData sModel = null;
        SheetQueryBLL sheetBLL = new SheetQueryBLL();
        SheetInfoViewModel fVModel = null;
        private void FrmSheetInfo_Load(object sender, EventArgs e)
        {
         
            Action act = () =>
            {
                if (this.Tag != null)
                    sModel = this.Tag as SheetInfoData;
                InitInfo();
                LoadSheetList();
                LoadSheetInfo();
                RegisterEvents();
            };
            act.TryCatch("明细列表","单据明细列表页面初始化异常！");
        }

        private void RegisterEvents()
        {
            queryTool1.CloseClick += QueryTool1_CloseClick;
            queryTool1.ExportClick += QueryTool1_ExportClick;
        }

        private void QueryTool1_ExportClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = fVModel.InfoText + "的相关" + fVModel.ShTypeName + "明细数据";
            FormUtility.DataToExcel(fVModel.SheetList, gridView1.Columns, fileName + ".xls", fileName, fileName, "导出明细数据");
        }

        private void QueryTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void LoadSheetList()
        {
            if (fVModel != null)
                fVModel.GetSheetList();
        }

        private void LoadSheetInfo()
        {
            if(fVModel!=null)
            {
                lblShTypeName.DataBind(fVModel, "ShTypeName");
                lblUnitDesp.DataBind(fVModel, "InfoDesp");
                lblInfoName.DataBind(fVModel, "InfoText");
                gcSheetGoodsList.DataBind(fVModel, "DataSource", "SheetList");
            }
        }

        private void InitInfo()
        {
            if (sModel != null)
            {
                fVModel = new SheetInfoViewModel();
                fVModel.SheetId = sModel.Id;
                fVModel.ShType = sModel.ShType;
                fVModel.TypeId = sModel.TypeId;
                fVModel.InfoText = sModel.InfoName;
            }
        }
    }
}