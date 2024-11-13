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
using PSINew.BLL;
using DXPSIApp.FModels;
using PSINew.UModels;
using DXPSIApp.Perchase;
using DXPSIApp.Sale;
using Common;

namespace DXPSIApp.BM
{
    public partial class FrmPayFor : DevExpress.XtraEditors.XtraForm
    {
        public FrmPayFor()
        {
            InitializeComponent();
        }
        //设置付款
        public event Action SetPayInfo;//设置付款信息
        private PayBLL payBLL = new PayBLL();
        //private string paytype = "";
        private Form fInfo = null;
        // private string strPayFor = "";
        private PayListViewModel fVModel = null;
        private void FrmPayFor_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                fVModel = new PayListViewModel();
                PayModel pModel = this.Tag as PayModel;
                if (pModel != null)
                {
                    fVModel.PayType = pModel.PayType;
                    fInfo = pModel.FGet;
                    fVModel.StrPayFor = pModel.StrPayFor;
                    fVModel.GetPayList();
                }

                LoadPayList();
              
            }
        }

        private void LoadPayList()
        {
            gcPayList.DataBind(fVModel, "DataSource", "PayList", true);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (fVModel.PayType == "pay")
            {
                FrmPerchaseInStore frm = fInfo as FrmPerchaseInStore;
                frm.payList = fVModel.PayList.ToList();
                frm.totalThis = fVModel.PayList.Sum(p => p.PayMoney).ToString();
            }
            else if (fVModel.PayType == "get")
            {
                FrmSaleOutStore frm = fInfo as FrmSaleOutStore;
                frm.payList = fVModel.PayList.ToList();
                frm.totalThis = fVModel.PayList.Sum(p => p.PayMoney).ToString();

            }
            this.SetPayInfo?.Invoke();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }
    }
}