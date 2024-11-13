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
    public partial class QueryTool : DevExpress.XtraEditors.XtraUserControl
    {
        public QueryTool()
        {
            InitializeComponent();
        }
        public event ItemClickEventHandler FindClick;//查询单击
        public event ItemClickEventHandler StockDistClick;//库存分布单击
        public event ItemClickEventHandler CloseClick;//关闭单击
        public event ItemClickEventHandler ExportClick;//导出单击

        /// <summary>
        /// 库存分布是否显示
        /// </summary>
        public BarItemVisibility IsStockDisVisible
        {
            get { return this.tibtnStockDist.Visibility; }
            set { this.tibtnStockDist.Visibility = value; }
        }

        /// <summary>
        /// 查询是否显示
        /// </summary>
        public BarItemVisibility IsFindVisible
        {
            get { return this.tibtnFind.Visibility; }
            set { this.tibtnFind.Visibility = value; }
        }

        public bool IsDistriEnabled
        {
            get { return this.tibtnFind.Enabled; }
            set { this.tibtnFind.Enabled = value; }
        }

        private void tibtnFind_ItemClick(object sender, ItemClickEventArgs e)
        {
            FindClick?.Invoke(sender, e);
        }

        private void tibtnStockDist_ItemClick(object sender, ItemClickEventArgs e)
        {
            StockDistClick?.Invoke(sender, e);
        }

        private void tibtnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }

        private void tibtnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportClick?.Invoke(sender, e);
        }
    }
}
