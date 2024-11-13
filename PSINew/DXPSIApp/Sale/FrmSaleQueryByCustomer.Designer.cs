namespace DXPSIApp.Sale
{
    partial class FrmSaleQueryByCustomer
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlUTypes = new DevExpress.XtraTreeList.TreeList();
            this.colUTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ucPager1 = new DXPSIApp.UControls.UCPager();
            this.gcSaleData = new DevExpress.XtraGrid.GridControl();
            this.gvUnitList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnItName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYHAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.queryTool1 = new DXPSIApp.UControls.QueryTool();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pbGTypes = new DevExpress.XtraEditors.PictureEdit();
            this.txtGoodsType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGoodsName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pbStores = new DevExpress.XtraEditors.PictureEdit();
            this.txtDealPerson = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.pbSuppliers = new DevExpress.XtraEditors.PictureEdit();
            this.txtCustomer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlUTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnitList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuppliers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.splitContainerControl1.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 277);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlUTypes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucPager1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSaleData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1241, 451);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 16;
            // 
            // tlUTypes
            // 
            this.tlUTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlUTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colUTypeName});
            this.tlUTypes.Location = new System.Drawing.Point(1, -5);
            this.tlUTypes.Name = "tlUTypes";
            this.tlUTypes.Size = new System.Drawing.Size(282, 453);
            this.tlUTypes.TabIndex = 0;
            this.tlUTypes.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colUTypeName
            // 
            this.colUTypeName.Caption = "客户类别";
            this.colUTypeName.FieldName = "UTypeName";
            this.colUTypeName.Name = "colUTypeName";
            this.colUTypeName.Visible = true;
            this.colUTypeName.VisibleIndex = 0;
            // 
            // ucPager1
            // 
            this.ucPager1.CurrentPage = 1;
            this.ucPager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPager1.Location = new System.Drawing.Point(0, 406);
            this.ucPager1.Name = "ucPager1";
            this.ucPager1.PageSize = 20;
            this.ucPager1.Record = 0;
            this.ucPager1.Size = new System.Drawing.Size(946, 45);
            this.ucPager1.StartRecord = 1;
            this.ucPager1.TabIndex = 4;
            // 
            // gcSaleData
            // 
            this.gcSaleData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSaleData.Location = new System.Drawing.Point(8, 3);
            this.gcSaleData.MainView = this.gvUnitList;
            this.gcSaleData.Name = "gcSaleData";
            this.gcSaleData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcSaleData.Size = new System.Drawing.Size(938, 397);
            this.gcSaleData.TabIndex = 3;
            this.gcSaleData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUnitList});
            // 
            // gvUnitList
            // 
            this.gvUnitList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUnItName,
            this.colUnitId,
            this.colSaleCount,
            this.colStAmount,
            this.colAmount,
            this.colYHAmount});
            this.gvUnitList.GridControl = this.gcSaleData;
            this.gvUnitList.Name = "gvUnitList";
            this.gvUnitList.OptionsBehavior.Editable = false;
            this.gvUnitList.OptionsSelection.MultiSelect = true;
            this.gvUnitList.OptionsView.ShowGroupPanel = false;
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
            this.colId.Width = 110;
            // 
            // colUnItName
            // 
            this.colUnItName.Caption = "单位名称";
            this.colUnItName.FieldName = "UnitName";
            this.colUnItName.MinWidth = 25;
            this.colUnItName.Name = "colUnItName";
            this.colUnItName.Visible = true;
            this.colUnItName.VisibleIndex = 2;
            this.colUnItName.Width = 320;
            // 
            // colUnitId
            // 
            this.colUnitId.Caption = "单位编号";
            this.colUnitId.FieldName = "UnitId";
            this.colUnitId.MinWidth = 25;
            this.colUnitId.Name = "colUnitId";
            this.colUnitId.OptionsColumn.AllowEdit = false;
            this.colUnitId.Visible = true;
            this.colUnitId.VisibleIndex = 1;
            this.colUnitId.Width = 181;
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
            this.colSaleCount.Width = 120;
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
            this.colStAmount.VisibleIndex = 6;
            this.colStAmount.Width = 119;
            // 
            // colAmount
            // 
            this.colAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAmount.Caption = "销售金额";
            this.colAmount.FieldName = "TotalAmount";
            this.colAmount.MinWidth = 25;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 4;
            this.colAmount.Width = 144;
            // 
            // colYHAmount
            // 
            this.colYHAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colYHAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colYHAmount.Caption = "应收金额";
            this.colYHAmount.FieldName = "TotalYHAmount";
            this.colYHAmount.MinWidth = 25;
            this.colYHAmount.Name = "colYHAmount";
            this.colYHAmount.Visible = true;
            this.colYHAmount.VisibleIndex = 5;
            this.colYHAmount.Width = 120;
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
            // queryTool1
            // 
            this.queryTool1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.queryTool1.Appearance.Options.UseBackColor = true;
            this.queryTool1.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryTool1.IsFindVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.queryTool1.IsStockDisVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.queryTool1.Location = new System.Drawing.Point(0, 0);
            this.queryTool1.Name = "queryTool1";
            this.queryTool1.Size = new System.Drawing.Size(1246, 62);
            this.queryTool1.TabIndex = 17;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 62);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1246, 82);
            this.panelControl2.TabIndex = 18;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("华文中宋", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(25, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(351, 44);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "销售查询（按客户）";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.pbGTypes);
            this.groupControl1.Controls.Add(this.txtGoodsType);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtGoodsName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.pbStores);
            this.groupControl1.Controls.Add(this.txtDealPerson);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.txtStoreName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.pbSuppliers);
            this.groupControl1.Controls.Add(this.txtCustomer);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 144);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1246, 127);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "查询条件";
            // 
            // pbGTypes
            // 
            this.pbGTypes.EditValue = global::DXPSIApp.Properties.Resources.zh;
            this.pbGTypes.Location = new System.Drawing.Point(309, 90);
            this.pbGTypes.Name = "pbGTypes";
            this.pbGTypes.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbGTypes.Properties.Appearance.Options.UseBackColor = true;
            this.pbGTypes.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbGTypes.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbGTypes.Size = new System.Drawing.Size(20, 19);
            this.pbGTypes.TabIndex = 23;
            // 
            // txtGoodsType
            // 
            this.txtGoodsType.Location = new System.Drawing.Point(97, 87);
            this.txtGoodsType.Name = "txtGoodsType";
            this.txtGoodsType.Size = new System.Drawing.Size(206, 24);
            this.txtGoodsType.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "商品类别：";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(809, 44);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(206, 24);
            this.txtGoodsName.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(739, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "商品名称：";
            // 
            // pbStores
            // 
            this.pbStores.EditValue = global::DXPSIApp.Properties.Resources.book;
            this.pbStores.Location = new System.Drawing.Point(676, 47);
            this.pbStores.Name = "pbStores";
            this.pbStores.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbStores.Properties.Appearance.Options.UseBackColor = true;
            this.pbStores.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbStores.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbStores.Size = new System.Drawing.Size(18, 21);
            this.pbStores.TabIndex = 18;
            // 
            // txtDealPerson
            // 
            this.txtDealPerson.Location = new System.Drawing.Point(464, 87);
            this.txtDealPerson.Name = "txtDealPerson";
            this.txtDealPerson.Size = new System.Drawing.Size(206, 24);
            this.txtDealPerson.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(401, 90);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 18);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "经手人：";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(464, 44);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(206, 24);
            this.txtStoreName.TabIndex = 17;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(379, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(83, 18);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "*出货仓库：";
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
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(97, 44);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(206, 24);
            this.txtCustomer.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "客  户：";
            // 
            // FrmSaleQueryByCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 730);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.queryTool1);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmSaleQueryByCustomer";
            this.Text = "销售查询页面--按客户";
            this.Load += new System.EventHandler(this.FrmSaleQueryByCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlUTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnitList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSuppliers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlUTypes;
        private UControls.UCPager ucPager1;
        private DevExpress.XtraGrid.GridControl gcSaleData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUnitList;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUnItName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitId;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colYHAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private UControls.QueryTool queryTool1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PictureEdit pbGTypes;
        private DevExpress.XtraEditors.TextEdit txtGoodsType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pbStores;
        private DevExpress.XtraEditors.TextEdit txtDealPerson;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PictureEdit pbSuppliers;
        private DevExpress.XtraEditors.TextEdit txtCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUTypeName;
    }
}