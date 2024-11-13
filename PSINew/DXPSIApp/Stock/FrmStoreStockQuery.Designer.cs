namespace DXPSIApp.Stock
{
    partial class FrmStoreStockQuery
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.queryTool1 = new DXPSIApp.UControls.QueryTool();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGoodsName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pbStores = new DevExpress.XtraEditors.PictureEdit();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlGTypes = new DevExpress.XtraTreeList.TreeList();
            this.colGType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gcStockData = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.queryTool1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1442, 70);
            this.panelControl1.TabIndex = 14;
            // 
            // queryTool1
            // 
            this.queryTool1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTool1.IsFindVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.queryTool1.IsStockDisVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.queryTool1.Location = new System.Drawing.Point(3, 3);
            this.queryTool1.Name = "queryTool1";
            this.queryTool1.Size = new System.Drawing.Size(1436, 64);
            this.queryTool1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtGoodsName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.pbStores);
            this.groupControl1.Controls.Add(this.txtStoreName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Location = new System.Drawing.Point(1, 73);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1438, 83);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "查询条件";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(64, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 18);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "商品类别：";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(809, 44);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(229, 24);
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
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(464, 44);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(206, 24);
            this.txtStoreName.TabIndex = 17;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(393, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 18);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "仓    库：";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.splitContainerControl1.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 162);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlGTypes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcStockData);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1438, 533);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 17;
            // 
            // tlGTypes
            // 
            this.tlGTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlGTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGType});
            this.tlGTypes.Location = new System.Drawing.Point(-2, 3);
            this.tlGTypes.Name = "tlGTypes";
            this.tlGTypes.Size = new System.Drawing.Size(287, 521);
            this.tlGTypes.TabIndex = 0;
            this.tlGTypes.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colGType
            // 
            this.colGType.Caption = "treeListColumn1";
            this.colGType.FieldName = "GTypeName";
            this.colGType.Name = "colGType";
            this.colGType.Visible = true;
            this.colGType.VisibleIndex = 0;
            // 
            // gcStockData
            // 
            this.gcStockData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcStockData.Location = new System.Drawing.Point(1, 11);
            this.gcStockData.MainView = this.gvList;
            this.gcStockData.Name = "gcStockData";
            this.gcStockData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcStockData.Size = new System.Drawing.Size(1135, 513);
            this.gcStockData.TabIndex = 5;
            this.gcStockData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colGoodsName,
            this.colGoodsNo,
            this.colGUnit,
            this.colStCount,
            this.colCurCount,
            this.colStAmount,
            this.colGTypeName,
            this.colStPrice,
            this.colStockAmount});
            this.gvList.GridControl = this.gcStockData;
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.Editable = false;
            this.gvList.OptionsBehavior.ReadOnly = true;
            this.gvList.OptionsSelection.MultiSelect = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "编号";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 82;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "商品名称";
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.MinWidth = 25;
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 1;
            this.colGoodsName.Width = 188;
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
            this.colGoodsNo.Width = 83;
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
            this.colGUnit.Width = 62;
            // 
            // colStCount
            // 
            this.colStCount.Caption = "期初数量";
            this.colStCount.FieldName = "StCount";
            this.colStCount.MinWidth = 25;
            this.colStCount.Name = "colStCount";
            this.colStCount.Visible = true;
            this.colStCount.VisibleIndex = 5;
            this.colStCount.Width = 94;
            // 
            // colCurCount
            // 
            this.colCurCount.Caption = "当前库存";
            this.colCurCount.FieldName = "CurCount";
            this.colCurCount.MinWidth = 25;
            this.colCurCount.Name = "colCurCount";
            this.colCurCount.Visible = true;
            this.colCurCount.VisibleIndex = 7;
            this.colCurCount.Width = 92;
            // 
            // colStAmount
            // 
            this.colStAmount.Caption = "期初金额";
            this.colStAmount.FieldName = "StAmount";
            this.colStAmount.MinWidth = 25;
            this.colStAmount.Name = "colStAmount";
            this.colStAmount.Visible = true;
            this.colStAmount.VisibleIndex = 6;
            this.colStAmount.Width = 116;
            // 
            // colGTypeName
            // 
            this.colGTypeName.Caption = "商品类别";
            this.colGTypeName.FieldName = "GTypeName";
            this.colGTypeName.MinWidth = 25;
            this.colGTypeName.Name = "colGTypeName";
            this.colGTypeName.Visible = true;
            this.colGTypeName.VisibleIndex = 4;
            this.colGTypeName.Width = 163;
            // 
            // colStPrice
            // 
            this.colStPrice.Caption = "成本单价";
            this.colStPrice.FieldName = "StPrice";
            this.colStPrice.MinWidth = 25;
            this.colStPrice.Name = "colStPrice";
            this.colStPrice.Visible = true;
            this.colStPrice.VisibleIndex = 8;
            this.colStPrice.Width = 116;
            // 
            // colStockAmount
            // 
            this.colStockAmount.Caption = "库存金额";
            this.colStockAmount.FieldName = "StockAmount";
            this.colStockAmount.MinWidth = 25;
            this.colStockAmount.Name = "colStockAmount";
            this.colStockAmount.Visible = true;
            this.colStockAmount.VisibleIndex = 9;
            this.colStockAmount.Width = 118;
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
            // FrmStoreStockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 699);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmStoreStockQuery";
            this.Text = "仓库库存查询";
            this.Load += new System.EventHandler(this.FrmStoreStockQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pbStores;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlGTypes;
        private DevExpress.XtraGrid.GridControl gcStockData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colStCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colGTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colStPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStockAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private UControls.QueryTool queryTool1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGType;
    }
}