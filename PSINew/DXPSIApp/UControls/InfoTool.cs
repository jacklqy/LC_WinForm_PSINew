using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DXPSIApp.UControls
{
    public partial class InfoTool : DevExpress.XtraEditors.XtraUserControl
    {
        public InfoTool()
        {
            InitializeComponent();
        }
        public bool IsSaveEnable
        {
            get { return tibtnSave.Enabled; }
            set { tibtnSave.Enabled = value; }
        }
        public bool IsClearEnable
        {
            get { return tibtnClear.Enabled; }
            set { tibtnClear.Enabled = value; }
        }
        public event ItemClickEventHandler SaveClick;
        public event ItemClickEventHandler ClearClick;
        public event ItemClickEventHandler CloseClick;
        private void tibtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveClick?.Invoke(sender, e);
        }

        private void tibtnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearClick?.Invoke(sender, e);
        }

        private void tibtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }
    }
}
