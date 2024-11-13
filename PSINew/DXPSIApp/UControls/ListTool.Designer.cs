namespace DXPSIApp.UControls
{
    partial class ListTool
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListTool));
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.tibtnType = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnAdd = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnEdit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnInfo = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.tibtnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar1.BarName = "工具";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "工具";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.tibtnType,
            this.barLargeButtonItem2,
            this.tibtnAdd,
            this.tibtnEdit,
            this.tibtnDelete,
            this.tibtnInfo,
            this.tibtnRefresh,
            this.tibtnClose});
            this.barManager1.MaxItemId = 14;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarItemHorzIndent = 5;
            this.bar2.BarName = "工具";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnType),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnClose)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "工具";
            // 
            // tibtnType
            // 
            this.tibtnType.Caption = "工具栏组";
            this.tibtnType.Id = 6;
            this.tibtnType.ImageOptions.Image = global::DXPSIApp.Properties.Resources.type;
            this.tibtnType.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tibtnType.ItemAppearance.Normal.Options.UseFont = true;
            this.tibtnType.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.tibtnType.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tibtnType.Name = "tibtnType";
            this.tibtnType.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnType.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.tibtnType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnType_ItemClick);
            // 
            // tibtnAdd
            // 
            this.tibtnAdd.Caption = "新增";
            this.tibtnAdd.Id = 8;
            this.tibtnAdd.ImageOptions.Image = global::DXPSIApp.Properties.Resources.add;
            this.tibtnAdd.Name = "tibtnAdd";
            this.tibtnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnAdd_ItemClick);
            // 
            // tibtnEdit
            // 
            this.tibtnEdit.Caption = "修改";
            this.tibtnEdit.Id = 9;
            this.tibtnEdit.ImageOptions.Image = global::DXPSIApp.Properties.Resources.edit;
            this.tibtnEdit.Name = "tibtnEdit";
            this.tibtnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnEdit_ItemClick);
            // 
            // tibtnDelete
            // 
            this.tibtnDelete.Caption = "删除";
            this.tibtnDelete.Id = 10;
            this.tibtnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tibtnDelete.ImageOptions.Image")));
            this.tibtnDelete.Name = "tibtnDelete";
            this.tibtnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnDelete_ItemClick);
            // 
            // tibtnInfo
            // 
            this.tibtnInfo.Caption = "详情";
            this.tibtnInfo.Id = 11;
            this.tibtnInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tibtnInfo.ImageOptions.Image")));
            this.tibtnInfo.Name = "tibtnInfo";
            this.tibtnInfo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnInfo_ItemClick);
            // 
            // tibtnRefresh
            // 
            this.tibtnRefresh.Caption = "刷新";
            this.tibtnRefresh.Id = 12;
            this.tibtnRefresh.ImageOptions.Image = global::DXPSIApp.Properties.Resources.refresh;
            this.tibtnRefresh.Name = "tibtnRefresh";
            this.tibtnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnRefresh_ItemClick);
            // 
            // tibtnClose
            // 
            this.tibtnClose.Caption = "关闭";
            this.tibtnClose.Id = 13;
            this.tibtnClose.ImageOptions.Image = global::DXPSIApp.Properties.Resources.close0;
            this.tibtnClose.Name = "tibtnClose";
            this.tibtnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(226)))), ((int)(((byte)(248)))));
            this.barDockControlTop.Appearance.BackColor2 = System.Drawing.Color.White;
            this.barDockControlTop.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(400, 64);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 66);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(400, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 64);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 2);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(400, 64);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 2);
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "商品类别";
            this.barLargeButtonItem2.Id = 7;
            this.barLargeButtonItem2.ImageOptions.Image = global::DXPSIApp.Properties.Resources.type;
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // ListTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ListTool";
            this.Size = new System.Drawing.Size(400, 66);
            this.Load += new System.EventHandler(this.ListTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnType;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnAdd;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnEdit;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnDelete;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnInfo;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem tibtnClose;
    }
}
