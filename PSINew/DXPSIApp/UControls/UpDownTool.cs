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
    public partial class UpDownTool : DevExpress.XtraEditors.XtraUserControl
    {
        public UpDownTool()
        {
            InitializeComponent();
        }
        public event ItemClickEventHandler SaveClick;
        public event ItemClickEventHandler SetMoreClick;
        public event ItemClickEventHandler CloseClick;
        public event ItemClickEventHandler RefreshClick;
        public bool IsSetMoreEnabled
        {
            get
            {
                return tibtnSetMore.Enabled;
            }
            set
            {
                tibtnSetMore.Enabled = value;
            }
        }
        private void tibtnSetMore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetMoreClick?.Invoke(sender, e);
        }

        private void tibtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveClick?.Invoke(sender, e);
        }

        private void tibtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshClick?.Invoke(sender, e);
        }

        private void tibtnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }
    }
}
