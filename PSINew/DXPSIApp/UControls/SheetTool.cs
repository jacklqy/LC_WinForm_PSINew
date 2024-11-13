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
    public partial class SheetTool : DevExpress.XtraEditors.XtraUserControl
    {
        public SheetTool()
        {
            InitializeComponent();
        }
        public event ItemClickEventHandler SaveClick;
        public event ItemClickEventHandler AddClick;
        public event ItemClickEventHandler CloseClick;
        public event ItemClickEventHandler CheckClick;
        public event ItemClickEventHandler NoUseClick;
        public event ItemClickEventHandler RedCheckClick;
        /// <summary>
        /// 作废是否可用
        /// </summary>
        public bool IsNoUseEnabled
        {
            get { return this.biNoUse.Enabled; }
            set { this.biNoUse.Enabled = value; }
        }
        /// <summary>
        /// 红冲是否可用
        /// </summary>
        public bool IsRedCheckedEnabled
        {
            get { return this.biRedChecked.Enabled; }
            set { this.biRedChecked.Enabled = value; }
        }
        /// <summary>
        /// 新增按钮是否可用
        /// </summary>
        public bool IsAddEnabled
        {
            get { return this.tibtnAdd.Enabled; }
            set { this.tibtnAdd.Enabled = value; }
        }
        /// <summary>
        /// 保存按钮是否可用
        /// </summary>
        public bool IsSaveEnabled
        {
            get { return this.tibtnSave.Enabled; }
            set { this.tibtnSave.Enabled = value; }
        }
        /// <summary>
        /// 审核按钮是否可用
        /// </summary>
        public bool IsCheckEnabled
        {
            get { return this.tibtnCheck.Enabled; }
            set { this.tibtnCheck.Enabled = value; }
        }

        /// <summary>
        /// 操作按钮是否可用
        /// </summary>
        public bool IsActsEnabled
        {
            get { return this.tibtnActs.Enabled; }
            set { this.tibtnActs.Enabled = value; }
        }

        private void SheetTool_Load(object sender, EventArgs e)
        {

        }

        private void tibtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddClick?.Invoke(sender, e);
        }

        private void tibtnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveClick?.Invoke(sender, e);
        }

        private void tibtnCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            CheckClick?.Invoke(sender, e);
        }

        private void tibtnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }

        private void biNoUse_ItemClick(object sender, ItemClickEventArgs e)
        {
            NoUseClick?.Invoke(sender, e);
        }

        private void biRedChecked_ItemClick(object sender, ItemClickEventArgs e)
        {
            RedCheckClick?.Invoke(sender, e);
        }
    }
}
