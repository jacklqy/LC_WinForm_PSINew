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
using PSINew.Models.VModels;

namespace DXPSIApp.Stock
{
    public partial class FrmSetMore : DevExpress.XtraEditors.XtraForm
    {
        public FrmSetMore()
        {
            InitializeComponent();
        }
        public event Action ReloadList;//刷新上下限列表
        StockSetMoreData sModel = null;
        private StockBLL stockBLL = new StockBLL();
        private SetModelViewModel fVModel = null;

        private void FrmSetMore_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new SetModelViewModel();
                RegisterEvents();
                if (this.Tag != null)
                {
                    sModel = this.Tag as StockSetMoreData;
                    fVModel.StoreName = sModel.StoreName;
                    fVModel.StoreUpDownList = sModel.StoreUpDownList;
                    BindInfo();
                }
            };
            act.TryCatch("批量设置页面","批量设置上下限页面加载异常！");
        }

        private void RegisterEvents()
        {
            chkUp.CheckedChanged += ChkUp_CheckedChanged;
            chkDown.CheckedChanged += ChkDown_CheckedChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<ViewStoreStockUpDownModel> list = new List<ViewStoreStockUpDownModel>();
            fVModel.StoreUpDownList.ForEach(g => list.Add(g.StoreUpDown));
            bool blSave = stockBLL.SetMoreGoodsStockUpDown(list, fVModel.StockUp, fVModel.StockDown);
            if (blSave)
            {
                MsgBoxHelper.MsgBoxShow("批量设置库存上下限", "保存成功！");
                this.ReloadList?.Invoke();
                this.Close();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow("批量设置库存上下限", "保存失败！");
                return;
            }
        }

        private void ChkDown_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsDown = chkDown.Checked;
            fVModel.IsTxtDownEnabled = fVModel.IsDown;
        }

        private void ChkUp_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsUp = chkUp.Checked;
            fVModel.IsTxtUpEnabled = fVModel.IsUp;
        }

        private void BindInfo()
        {
             if(fVModel!=null)
            {
                lblStoreName.DataBind(fVModel, "StoreName");
                chkDown.DataBind(fVModel, "Checked", "IsDown", true);
                chkUp.DataBind(fVModel, "Checked", "IsUp", true);
                spinDown.DataBind(fVModel, "Enabled", "IsTxtDownEnabled", true);
                spinUp.DataBind(fVModel, "Enabled", "IsTxtUpEnabled", true);
                spinUp.DataBind(fVModel, "Value", "StockUp", true);
                spinDown.DataBind(fVModel, "Value", "StockDown", true);
            }
        }
    }
}