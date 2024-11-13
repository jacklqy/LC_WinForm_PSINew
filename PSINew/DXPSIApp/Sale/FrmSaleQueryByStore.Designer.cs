namespace DXPSIApp.Sale
{
    partial class FrmSaleQueryByStore
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.queryTool1 = new DXPSIApp.UControls.QueryTool();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlSTypes = new DevExpress.XtraTreeList.TreeList();
            this.colSTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ucPager1 = new DXPSIApp.UControls.UCPager();
            this.gcSaleData = new DevExpress.XtraGrid.GridControl();
            this.gvStoreList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGoodsName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDealPerson = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.pbSuppliers = new DevExpress.XtraEditors.PictureEdit();
            this.txtSupplier = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlSTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStoreList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuppliers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 66);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1434, 68);
            this.panelControl2.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("华文中宋", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(28, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(351, 44);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "销售查询（按仓库）";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Azure;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.AliceBlue;
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.queryTool1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1434, 66);
            this.panelControl1.TabIndex = 13;
            // 
            // queryTool1
            // 
            this.queryTool1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.queryTool1.Appearance.Options.UseBackColor = true;
            this.queryTool1.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryTool1.IsFindVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.queryTool1.IsStockDisVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.queryTool1.Location = new System.Drawing.Point(0, 0);
            this.queryTool1.Name = "queryTool1";
            this.queryTool1.Size = new System.Drawing.Size(1434, 66);
            this.queryTool1.TabIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.splitContainerControl1.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 218);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlSTypes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucPager1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSaleData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1429, 496);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 16;
            // 
            // tlSTypes
            // 
            this.tlSTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlSTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colSTypeName});
            this.tlSTypes.Location = new System.Drawing.Point(-2, 3);
            this.tlSTypes.Name = "tlSTypes";
            this.tlSTypes.Size = new System.Drawing.Size(287, 484);
            this.tlSTypes.TabIndex = 0;
            this.tlSTypes.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colSTypeName
            // 
            this.colSTypeName.Caption = "仓库类别";
            this.colSTypeName.FieldName = "STypeName";
            this.colSTypeName.Name = "colSTypeName";
            this.colSTypeName.Visible = true;
            this.colSTypeName.VisibleIndex = 0;
            // 
            // ucPager1
            // 
            this.ucPager1.CurrentPage = 1;
            this.ucPager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPager1.Location = new System.Drawing.Point(0, 451);
            this.ucPager1.Name = "ucPager1";
            this.ucPager1.PageSize = 20;
            this.ucPager1.Record = 0;
            this.ucPager1.Size = new System.Drawing.Size(1134, 45);
            this.ucPager1.StartRecord = 1;
            this.ucPager1.TabIndex = 4;
            // 
            // gcSaleData
            // 
            this.gcSaleData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSaleData.Location = new System.Drawing.Point(3, 3);
            this.gcSaleData.MainView = this.gvStoreList;
            this.gcSaleData.Name = "gcSaleData";
            this.gcSaleData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcSaleData.Size = new System.Drawing.Size(1130, 436);
            this.gcSaleData.TabIndex = 3;
            this.gcSaleData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStoreList});
            // 
            // gvStoreList
            // 
            this.gvStoreList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStoreId,
            this.colStoreName,
            this.colSaleCount,
            this.colSaleAmount,
            this.colStAmount});
            this.gvStoreList.GridControl = this.gcSaleData;
            this.gvStoreList.Name = "gvStoreList";
            this.gvStoreList.OptionsBehavior.Editable = false;
            this.gvStoreList.OptionsSelection.MultiSelect = true;
            this.gvStoreList.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colId.Caption = "编号";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 123;
            // 
            // colStoreId
            // 
            this.colStoreId.AppearanceCell.Options.UseTextOptions = true;
            this.colStoreId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStoreId.Caption = "仓库编号";
            this.colStoreId.FieldName = "StoreId";
            this.colStoreId.MinWidth = 25;
            this.colStoreId.Name = "colStoreId";
            this.colStoreId.Visible = true;
            this.colStoreId.VisibleIndex = 1;
            this.colStoreId.Width = 119;
            // 
            // colStoreName
            // 
            this.colStoreName.Caption = "仓库名称";
            this.colStoreName.FieldName = "StoreName";
            this.colStoreName.MinWidth = 25;
            this.colStoreName.Name = "colStoreName";
            this.colStoreName.OptionsColumn.AllowEdit = false;
            this.colStoreName.Visible = true;
            this.colStoreName.VisibleIndex = 2;
            this.colStoreName.Width = 372;
            // 
            // colSaleCount
            // 
            this.colSaleCount.AppearanceCell.Options.UseTextOptions = true;
            this.colSaleCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSaleCount.Caption = "销售数量";
            this.colSaleCount.FieldName = "TotalCount";
            this.colSaleCount.MinWidth = 25;
            this.colSaleCount.Name = "colSaleCount";
            this.colSaleCount.Visible = true;
            this.colSaleCount.VisibleIndex = 3;
            this.colSaleCount.Width = 174;
            // 
            // colSaleAmount
            // 
            this.colSaleAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colSaleAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSaleAmount.Caption = "销售金额";
            this.colSaleAmount.FieldName = "TotalAmount";
            this.colSaleAmount.MinWidth = 25;
            this.colSaleAmount.Name = "colSaleAmount";
            this.colSaleAmount.Visible = true;
            this.colSaleAmount.VisibleIndex = 4;
            this.colSaleAmount.Width = 167;
            // 
            // colStAmount
            // 
            this.colStAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colStAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStAmount.Caption = "成本金额";
            this.colStAmount.FieldName = "TotalStAmount";
            this.colStAmount.MinWidth = 25;
            this.colStAmount.Name = "colStAmount";
            this.colStAmount.Visible = true;
            this.colStAmount.VisibleIndex = 5;
            this.colStAmount.Width = 150;
            // 
            // itemPerCount
            // 
            this.itemPerCount.AutoHeight = false;
            this.itemPerCount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemPerCount.IsFloatValue = false;
            this.itemPerCount.Mask.EditMask = "N00";
            this.itemPerCount.Name = "itemPerCount";
            // 
            // itemRemark
            // 
            this.itemRemark.AutoHeight = false;
            this.itemRemark.Name = "itemRemark";
            // 
            // itemPerPrice
            // 
            this.itemPerPrice.AutoHeight = false;
            this.itemPerPrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemPerPrice.Name = "itemPerPrice";
            // 
            // itemGoodsName
            // 
            this.itemGoodsName.AutoHeight = false;
            this.itemGoodsName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.itemGoodsName.Name = "itemGoodsName";
            this.itemGoodsName.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtStoreName);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtGoodsName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtDealPerson);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.pbSuppliers);
            this.groupControl1.Controls.Add(this.txtSupplier);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 134);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1434, 81);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "查询条件";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(430, 44);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(206, 24);
            this.txtStoreName.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(349, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "仓库名称：";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(748, 44);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(206, 24);
            this.txtGoodsName.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(678, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "商品名称：";
            // 
            // txtDealPerson
            // 
            this.txtDealPerson.Location = new System.Drawing.Point(1059, 44);
            this.txtDealPerson.Name = "txtDealPerson";
            this.txtDealPerson.Size = new System.Drawing.Size(206, 24);
            this.txtDealPerson.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(989, 47);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 18);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "经手人：";
            // 
            // pbSuppliers
            // 
            this.pbSuppliers.EditValue = global::DXPSIApp.Properties.Resources.kh;
            this.pbSuppliers.Location = new System.Drawing.Point(309, 47);
            this.pbSuppliers.Name = "pbSuppliers";
            this.pbSuppliers.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbSuppliers.Properties.Appearance.Options.UseBackColor = true;
            this.pbSuppliers.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbSuppliers.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbSuppliers.Size = new System.Drawing.Size(18, 21);
            this.pbSuppliers.TabIndex = 5;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(97, 44);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(206, 24);
            this.txtSupplier.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "供应商：";
            // 
            // FrmSaleQueryByStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 715);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmSaleQueryByStore";
            this.Text = "销售查询页面--按仓库";
            this.Load += new System.EventHandler(this.FrmSaleQueryByStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlSTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStoreList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuppliers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlSTypes;
        private UControls.UCPager ucPager1;
        private DevExpress.XtraGrid.GridControl gcSaleData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStoreList;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colStAmount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSTypeName;
        private UControls.QueryTool queryTool1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDealPerson;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.PictureEdit pbSuppliers;
        private DevExpress.XtraEditors.TextEdit txtSupplier;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}