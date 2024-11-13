namespace DXPSIApp
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.psiTools = new DevExpress.XtraBars.Bar();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.psiMainMenus = new DevExpress.XtraBars.Bar();
            this.miSystem = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.miBasic = new DevExpress.XtraBars.BarSubItem();
            this.statusBar = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblLoginName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.lblRoleName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.lblCurTime = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.lblRights = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.biUsers = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.xtabPages = new DevExpress.XtraTab.XtraTabControl();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.bar6 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabPages)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(0, 67);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 10);
            this.groupControl1.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.psiTools,
            this.psiMainMenus,
            this.statusBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.miSystem,
            this.miBasic,
            this.biUsers,
            this.barSubItem2,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.lblLoginName,
            this.lblRoleName,
            this.lblCurTime,
            this.barStaticItem4,
            this.lblRights});
            this.barManager1.MainMenu = this.psiMainMenus;
            this.barManager1.MaxItemId = 27;
            this.barManager1.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Never;
            this.barManager1.PopupShowMode = DevExpress.XtraBars.PopupShowMode.Classic;
            this.barManager1.StatusBar = this.statusBar;
            // 
            // psiTools
            // 
            this.psiTools.BarItemVertIndent = 2;
            this.psiTools.BarName = "工具";
            this.psiTools.DockCol = 0;
            this.psiTools.DockRow = 1;
            this.psiTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.psiTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.psiTools.OptionsBar.AllowQuickCustomization = false;
            this.psiTools.OptionsBar.MultiLine = true;
            this.psiTools.OptionsBar.UseWholeRow = true;
            this.psiTools.Text = "工具";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "采购入库";
            this.barButtonItem4.Id = 16;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "商品信息";
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.ImageOptions.Image = global::DXPSIApp.Properties.Resources.goods;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "销售出库";
            this.barButtonItem5.Id = 17;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // psiMainMenus
            // 
            this.psiMainMenus.BarItemVertIndent = 5;
            this.psiMainMenus.BarName = "主菜单";
            this.psiMainMenus.DockCol = 0;
            this.psiMainMenus.DockRow = 0;
            this.psiMainMenus.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.psiMainMenus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.miSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.miBasic)});
            this.psiMainMenus.OptionsBar.AllowCollapse = true;
            this.psiMainMenus.OptionsBar.AllowQuickCustomization = false;
            this.psiMainMenus.OptionsBar.MultiLine = true;
            this.psiMainMenus.OptionsBar.UseWholeRow = true;
            this.psiMainMenus.Text = "主菜单";
            // 
            // miSystem
            // 
            this.miSystem.Caption = "系统管理(&S)";
            this.miSystem.Id = 9;
            this.miSystem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S));
            this.miSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.miSystem.Name = "miSystem";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "用户管理";
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "角色管理";
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // miBasic
            // 
            this.miBasic.Caption = "基础资料";
            this.miBasic.Id = 10;
            this.miBasic.Name = "miBasic";
            // 
            // statusBar
            // 
            this.statusBar.BarName = "状态栏";
            this.statusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.statusBar.DockCol = 0;
            this.statusBar.DockRow = 0;
            this.statusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.statusBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblLoginName),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblRoleName),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCurTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblRights)});
            this.statusBar.OptionsBar.AllowQuickCustomization = false;
            this.statusBar.OptionsBar.DrawDragBorder = false;
            this.statusBar.OptionsBar.UseWholeRow = true;
            this.statusBar.Text = "状态栏";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "操作员：";
            this.barStaticItem1.Id = 18;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // lblLoginName
            // 
            this.lblLoginName.Caption = "admin";
            this.lblLoginName.Id = 22;
            this.lblLoginName.Name = "lblLoginName";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "角色：";
            this.barStaticItem2.Id = 19;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Caption = "管理员";
            this.lblRoleName.Id = 23;
            this.lblRoleName.Name = "lblRoleName";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "时间：";
            this.barStaticItem3.Id = 20;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // lblCurTime
            // 
            this.lblCurTime.Caption = "2021-01-18 10:21:23";
            this.lblCurTime.Id = 24;
            this.lblCurTime.Name = "lblCurTime";
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem4.Caption = "版权：";
            this.barStaticItem4.Id = 25;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // lblRights
            // 
            this.lblRights.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblRights.Caption = "朝夕教育";
            this.lblRights.Id = 26;
            this.lblRights.Name = "lblRights";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1246, 67);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 715);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1246, 35);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 67);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 648);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1246, 67);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 648);
            // 
            // biUsers
            // 
            this.biUsers.Caption = "用户管理";
            this.biUsers.Id = 11;
            this.biUsers.Name = "biUsers";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "角色管理";
            this.barSubItem2.Id = 12;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "系统管理";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bar4
            // 
            this.bar4.BarName = "自定义5";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 2;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.Text = "自定义5";
            // 
            // xtabPages
            // 
            this.xtabPages.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtabPages.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.xtabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabPages.Location = new System.Drawing.Point(0, 77);
            this.xtabPages.Name = "xtabPages";
            this.xtabPages.Size = new System.Drawing.Size(1246, 638);
            this.xtabPages.TabIndex = 5;
            this.xtabPages.CloseButtonClick += new System.EventHandler(this.xtabPages_CloseButtonClick);
            this.xtabPages.SizeChanged += new System.EventHandler(this.xtabPages_SizeChanged);
            // 
            // bar5
            // 
            this.bar5.BarName = "自定义5";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 2;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.Text = "自定义5";
            // 
            // bar6
            // 
            this.bar6.BarName = "自定义5";
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 2;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar6.Text = "自定义5";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 750);
            this.Controls.Add(this.xtabPages);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmMain.IconOptions.Icon")));
            this.MinimumSize = new System.Drawing.Size(1256, 785);
            this.Name = "FrmMain";
            this.Text = "朝夕进销存管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmMain_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtabPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar psiTools;
        private DevExpress.XtraBars.Bar psiMainMenus;
        private DevExpress.XtraBars.Bar statusBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem miSystem;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem miBasic;
        private DevExpress.XtraBars.BarButtonItem biUsers;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraTab.XtraTabControl xtabPages;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarStaticItem lblLoginName;
        private DevExpress.XtraBars.BarStaticItem lblRoleName;
        private DevExpress.XtraBars.BarStaticItem lblCurTime;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem lblRights;
        private DevExpress.XtraBars.Bar bar6;
    }
}