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
    public partial class ListTool : DevExpress.XtraEditors.XtraUserControl
    {
        public ListTool()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 类别项是否显示
        /// </summary>
       
        public BarItemVisibility IsTypeVisible
        {
            get { return this.tibtnType.Visibility; }
            set { this.tibtnType.Visibility = value; }
        }
        /// <summary>
        /// 类别项的文本
        /// </summary>
        public string TypeItemText
        {
            get { return tibtnType.Caption; }
            set { tibtnType.Caption = value; }
        }
        /// <summary>
        /// 是否显示详情项
        /// </summary>
        public BarItemVisibility IsInfoVisible
        {
            get { return this.tibtnInfo.Visibility; }
            set { this.tibtnInfo.Visibility = value; }
        }
        /// <summary>
        /// 类别项点击事件
        /// </summary>
        public event ItemClickEventHandler  TypeClick;
        /// <summary>
        /// 添加项点击事件
        /// </summary>
        public event ItemClickEventHandler AddClick;
        /// <summary>
        /// 修改项点击事件
        /// </summary>
        public event ItemClickEventHandler EditClick;
        /// <summary>
        /// 删除项点击事件
        /// </summary>
        public event ItemClickEventHandler DeleteClick;
        /// <summary>
        /// 详情项点击事件
        /// </summary>
        public event ItemClickEventHandler InfoClick;
        /// <summary>
        /// 刷新项点击事件
        /// </summary>
        public event ItemClickEventHandler RefreshClick;
        /// <summary>
        /// 关闭项点击事件
        /// </summary>
        public event ItemClickEventHandler CloseClick;
        private void ListTool_Load(object sender, EventArgs e)
        {
           
        }

        private void tibtnType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TypeClick != null)
                TypeClick(sender, e);
        }

        private void tibtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (AddClick != null)
                AddClick(sender, e);
        }

        private void tibtnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (EditClick != null)
                EditClick(sender, e);
        }

        private void tibtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DeleteClick != null)
                DeleteClick(sender, e);
        }

        private void tibtnInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (InfoClick != null)
                InfoClick(sender, e);
        }

        private void tibtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (RefreshClick != null)
                RefreshClick(sender, e);
        }

        private void tibtnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CloseClick != null)
                CloseClick(sender, e);
        }
    }
}
