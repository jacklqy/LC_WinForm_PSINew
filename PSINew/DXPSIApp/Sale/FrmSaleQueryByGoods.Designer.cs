namespace DXPSIApp.Sale
{
    partial class FrmSaleQueryByGoods
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
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvGoodsList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSaleData = new DevExpress.XtraGrid.GridControl();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ucPager1 = new DXPSIApp.UControls.UCPager();
            this.tlGTypes = new DevExpress.XtraTreeList.TreeList();
            this.colGTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtGoodsName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pbStores = new DevExpress.XtraEditors.PictureEdit();
            this.txtDealPerson = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.pbCustomers = new DevExpress.XtraEditors.PictureEdit();
            this.txtCustomer = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.queryTool1 = new DXPSIApp.UControls.QueryTool();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoodsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemPerPrice
            // 
            this.itemPerPrice.AutoHeight = false;
            this.itemPerPrice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemPerPrice.Name = "itemPerPrice";
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
            // colAmount
            // 
            this.colAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAmount.Caption = "销售金额";
            this.colAmount.FieldName = "TotalAmount";
            this.colAmount.MinWidth = 25;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;
            this.colAmount.Width = 94;
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
            this.colSaleCount.VisibleIndex = 4;
            this.colSaleCount.Width = 71;
            // 
            // colGUnit
            // 
            this.colGUnit.Caption = "单位";
            this.colGUnit.FieldName = "GUnit";
            this.colGUnit.MinWidth = 25;
            this.colGUnit.Name = "colGUnit";
            this.colGUnit.OptionsColumn.AllowEdit = false;
            this.colGUnit.Visible = true;
            this.colGUnit.VisibleIndex = 3;
            this.colGUnit.Width = 63;
            // 
            // colGoodsNo
            // 
            this.colGoodsNo.Caption = "商品编码";
            this.colGoodsNo.FieldName = "GoodsNo";
            this.colGoodsNo.MinWidth = 25;
            this.colGoodsNo.Name = "colGoodsNo";
            this.colGoodsNo.OptionsColumn.AllowEdit = false;
            this.colGoodsNo.Visible = true;
            this.colGoodsNo.VisibleIndex = 2;
            this.colGoodsNo.Width = 132;
            // 
            // itemGoodsName
            // 
            this.itemGoodsName.AutoHeight = false;
            this.itemGoodsName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.itemGoodsName.Name = "itemGoodsName";
            this.itemGoodsName.ReadOnly = true;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "商品名称";
            this.colGoodsName.ColumnEdit = this.itemGoodsName;
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.MinWidth = 25;
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 1;
            this.colGoodsName.Width = 187;
            // 
            // colId
            // 
            this.colId.Caption = "编号";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 67;
            // 
            // gvGoodsList
            // 
            this.gvGoodsList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colGoodsName,
            this.colGoodsNo,
            this.colGUnit,
            this.colSaleCount,
            this.colAmount,
            this.colStAmount});
            this.gvGoodsList.GridControl = this.gcSaleData;
            this.gvGoodsList.Name = "gvGoodsList";
            this.gvGoodsList.OptionsBehavior.Editable = false;
            this.gvGoodsList.OptionsSelection.MultiSelect = true;
            this.gvGoodsList.OptionsView.ShowGroupPanel = false;
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
            this.colStAmount.Width = 94;
            // 
            // gcSaleData
            // 
            this.gcSaleData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSaleData.Location = new System.Drawing.Point(3, 3);
            this.gcSaleData.MainView = this.gvGoodsList;
            this.gcSaleData.Name = "gcSaleData";
            this.gcSaleData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcSaleData.Size = new System.Drawing.Size(1135, 422);
            this.gcSaleData.TabIndex = 3;
            this.gcSaleData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGoodsList});
            // 
            // itemRemark
            // 
            this.itemRemark.AutoHeight = false;
            this.itemRemark.Name = "itemRemark";
            // 
            // ucPager1
            // 
            this.ucPager1.CurrentPage = 1;
            this.ucPager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPager1.Location = new System.Drawing.Point(0, 431);
            this.ucPager1.Name = "ucPager1";
            this.ucPager1.PageSize = 20;
            this.ucPager1.Record = 0;
            this.ucPager1.Size = new System.Drawing.Size(1137, 45);
            this.ucPager1.StartRecord = 1;
            this.ucPager1.TabIndex = 4;
            // 
            // tlGTypes
            // 
            this.tlGTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlGTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGTypeName});
            this.tlGTypes.Location = new System.Drawing.Point(-2, 3);
            this.tlGTypes.Name = "tlGTypes";
            this.tlGTypes.OptionsSelection.InvertSelection = true;
            this.tlGTypes.Size = new System.Drawing.Size(287, 470);
            this.tlGTypes.TabIndex = 0;
            this.tlGTypes.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colGTypeName
            // 
            this.colGTypeName.Caption = "treeListColumn1";
            this.colGTypeName.FieldName = "GTypeName";
            this.colGTypeName.Name = "colGTypeName";
            this.colGTypeName.OptionsColumn.AllowEdit = false;
            this.colGTypeName.OptionsColumn.AllowMove = false;
            this.colGTypeName.Visible = true;
            this.colGTypeName.VisibleIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.splitContainerControl1.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 232);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlGTypes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucPager1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSaleData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1438, 482);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 12;
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
            this.labelControl2.Location = new System.Drawing.Point(732, 47);
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
            this.txtDealPerson.Location = new System.Drawing.Point(1156, 44);
            this.txtDealPerson.Name = "txtDealPerson";
            this.txtDealPerson.Size = new System.Drawing.Size(206, 24);
            this.txtDealPerson.TabIndex = 16;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(1086, 47);
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
            // pbCustomers
            // 
            this.pbCustomers.EditValue = global::DXPSIApp.Properties.Resources.kh;
            this.pbCustomers.Location = new System.Drawing.Point(309, 47);
            this.pbCustomers.Name = "pbCustomers";
            this.pbCustomers.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbCustomers.Properties.Appearance.Options.UseBackColor = true;
            this.pbCustomers.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbCustomers.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbCustomers.Size = new System.Drawing.Size(18, 21);
            this.pbCustomers.TabIndex = 5;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(97, 44);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(206, 24);
            this.txtCustomer.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.txtGoodsName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.pbStores);
            this.groupControl1.Controls.Add(this.txtDealPerson);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.txtStoreName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.pbCustomers);
            this.groupControl1.Controls.Add(this.txtCustomer);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Location = new System.Drawing.Point(2, 145);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1438, 81);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "查询条件";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "客  户：";
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
            this.labelControl1.Text = "销售查询（按商品）";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(2, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1438, 74);
            this.panelControl2.TabIndex = 10;
            // 
            // queryTool1
            // 
            this.queryTool1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.queryTool1.Appearance.Options.UseBackColor = true;
            this.queryTool1.Dock = System.Windows.Forms.DockStyle.Top;
            this.queryTool1.IsFindVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.queryTool1.IsStockDisVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.queryTool1.Location = new System.Drawing.Point(3, 3);
            this.queryTool1.Name = "queryTool1";
            this.queryTool1.Size = new System.Drawing.Size(1437, 64);
            this.queryTool1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Azure;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.AliceBlue;
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.queryTool1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1443, 70);
            this.panelControl1.TabIndex = 9;
            // 
            // FrmSaleQueryByGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 715);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmSaleQueryByGoods";
            this.Text = "销售查询页面--按商品";
            this.Load += new System.EventHandler(this.FrmSaleQueryByGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGoodsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaleData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDealPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGoodsList;
        private DevExpress.XtraGrid.GridControl gcSaleData;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private UControls.UCPager ucPager1;
        private DevExpress.XtraTreeList.TreeList tlGTypes;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.TextEdit txtGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pbStores;
        private DevExpress.XtraEditors.TextEdit txtDealPerson;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PictureEdit pbCustomers;
        private DevExpress.XtraEditors.TextEdit txtCustomer;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private UControls.QueryTool queryTool1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colStAmount;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGTypeName;
    }
}