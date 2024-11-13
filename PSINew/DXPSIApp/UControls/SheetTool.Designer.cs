namespace DXPSIApp.UControls
{
    partial class SheetTool
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
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.biNoUse = new DevExpress.XtraBars.BarButtonItem();
            this.biRedChecked = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.tibtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.tibtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.tibtnCheck = new DevExpress.XtraBars.BarButtonItem();
            this.tibtnActs = new DevExpress.XtraBars.BarButtonItem();
            this.tibtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.BarAppearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarItemHorzIndent = 5;
            this.bar2.BarName = "工具";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "工具";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biNoUse),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRedChecked)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // biNoUse
            // 
            this.biNoUse.Caption = "作废";
            this.biNoUse.Id = 18;
            this.biNoUse.Name = "biNoUse";
            this.biNoUse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNoUse_ItemClick);
            // 
            // biRedChecked
            // 
            this.biRedChecked.Caption = "红冲";
            this.biRedChecked.Id = 19;
            this.biRedChecked.Name = "biRedChecked";
            this.biRedChecked.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biRedChecked_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.tibtnActs,
            this.biNoUse,
            this.biRedChecked,
            this.tibtnAdd,
            this.tibtnSave,
            this.tibtnCheck,
            this.tibtnClose});
            this.barManager1.MaxItemId = 25;
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.BarAppearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarAppearance.Normal.Options.UseImage = true;
            this.bar1.BarItemHorzIndent = 8;
            this.bar1.BarItemVertIndent = 3;
            this.bar1.BarName = "工具";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnCheck),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnActs),
            new DevExpress.XtraBars.LinkPersistInfo(this.tibtnClose)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "工具";
            // 
            // tibtnAdd
            // 
            this.tibtnAdd.Caption = "新单";
            this.tibtnAdd.Id = 21;
            this.tibtnAdd.ImageOptions.Image = global::DXPSIApp.Properties.Resources.add;
            this.tibtnAdd.Name = "tibtnAdd";
            this.tibtnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnAdd_ItemClick);
            // 
            // tibtnSave
            // 
            this.tibtnSave.Caption = "保存";
            this.tibtnSave.Id = 22;
            this.tibtnSave.ImageOptions.Image = global::DXPSIApp.Properties.Resources.save;
            this.tibtnSave.Name = "tibtnSave";
            this.tibtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnSave_ItemClick);
            // 
            // tibtnCheck
            // 
            this.tibtnCheck.Caption = "审核";
            this.tibtnCheck.Id = 23;
            this.tibtnCheck.ImageOptions.Image = global::DXPSIApp.Properties.Resources.check;
            this.tibtnCheck.Name = "tibtnCheck";
            this.tibtnCheck.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.tibtnCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.tibtnCheck_ItemClick);
            // 
            // tibtnActs
            // 
            this.tibtnActs.ActAsDropDown = true;
            this.tibtnActs.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.tibtnActs.Caption = "操作";
            this.tibtnActs.DropDownControl = this.popupMenu1;
            this.tibtnActs.Id = 17;
            this.tibtnActs.ImageOptions.Image = global::DXPSIApp.Properties.Resources.action;
            this.tibtnActs.Name = "tibtnActs";
            this.tibtnActs.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tibtnClose
            // 
            this.tibtnClose.Caption = "关闭";
            this.tibtnClose.Id = 24;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1054, 46);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 46);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1054, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 46);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1054, 46);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // SheetTool
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::DXPSIApp.Properties.Resources.tlbg;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SheetTool";
            this.Size = new System.Drawing.Size(1054, 46);
            this.Load += new System.EventHandler(this.SheetTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem tibtnActs;
        private DevExpress.XtraBars.BarButtonItem biNoUse;
        private DevExpress.XtraBars.BarButtonItem biRedChecked;
        private DevExpress.XtraBars.BarButtonItem tibtnAdd;
        private DevExpress.XtraBars.BarButtonItem tibtnSave;
        private DevExpress.XtraBars.BarButtonItem tibtnCheck;
        private DevExpress.XtraBars.BarButtonItem tibtnClose;
    }
}
