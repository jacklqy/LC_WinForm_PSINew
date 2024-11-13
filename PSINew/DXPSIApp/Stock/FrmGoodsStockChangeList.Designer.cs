namespace DXPSIApp.Stock
{
    partial class FrmGoodsStockChangeList
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
            this.queryTool1 = new DXPSIApp.UControls.QueryTool();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblStoreName = new DevExpress.XtraEditors.LabelControl();
            this.lblGoodsName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblDesp = new DevExpress.XtraEditors.LabelControl();
            this.gcChangeList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChangeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            this.SuspendLayout();
            // 
            // queryTool1
            // 
            this.queryTool1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTool1.IsFindVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.queryTool1.IsStockDisVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.queryTool1.Location = new System.Drawing.Point(3, 3);
            this.queryTool1.Name = "queryTool1";
            this.queryTool1.Size = new System.Drawing.Size(1737, 65);
            this.queryTool1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.queryTool1);
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1743, 71);
            this.panelControl1.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblStoreName);
            this.groupControl1.Controls.Add(this.lblGoodsName);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.lblDesp);
            this.groupControl1.Location = new System.Drawing.Point(1, 75);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1743, 57);
            this.groupControl1.TabIndex = 18;
            // 
            // lblStoreName
            // 
            this.lblStoreName.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblStoreName.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStoreName.Appearance.Options.UseFont = true;
            this.lblStoreName.Appearance.Options.UseForeColor = true;
            this.lblStoreName.Location = new System.Drawing.Point(465, 23);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(60, 19);
            this.lblStoreName.TabIndex = 21;
            this.lblStoreName.Text = "第一仓库";
            // 
            // lblGoodsName
            // 
            this.lblGoodsName.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblGoodsName.Appearance.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblGoodsName.Appearance.Options.UseFont = true;
            this.lblGoodsName.Appearance.Options.UseForeColor = true;
            this.lblGoodsName.Location = new System.Drawing.Point(171, 23);
            this.lblGoodsName.Name = "lblGoodsName";
            this.lblGoodsName.Size = new System.Drawing.Size(30, 19);
            this.lblGoodsName.TabIndex = 21;
            this.lblGoodsName.Text = "上衣";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(120, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 18);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "商品：";
            // 
            // lblDesp
            // 
            this.lblDesp.Location = new System.Drawing.Point(394, 23);
            this.lblDesp.Name = "lblDesp";
            this.lblDesp.Size = new System.Drawing.Size(65, 18);
            this.lblDesp.TabIndex = 15;
            this.lblDesp.Text = "仓    库：";
            // 
            // gcChangeList
            // 
            this.gcChangeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcChangeList.Location = new System.Drawing.Point(1, 138);
            this.gcChangeList.MainView = this.gridView1;
            this.gcChangeList.Name = "gcChangeList";
            this.gcChangeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcChangeList.Size = new System.Drawing.Size(1743, 577);
            this.gcChangeList.TabIndex = 19;
            this.gcChangeList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colGoodsName,
            this.colGoodsId,
            this.colGUnit,
            this.colOutCount,
            this.colAmount,
            this.colPrice,
            this.colInCount,
            this.colCurCount,
            this.colCheckState,
            this.colSheetNo,
            this.colShTypeName,
            this.colCreateTime,
            this.colCheckTime,
            this.colStoreName,
            this.colStPrice,
            this.colStAmount,
            this.colDealPerson});
            this.gridView1.GridControl = this.gcChangeList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "编号";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 59;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "商品名称";
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.MinWidth = 25;
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 7;
            this.colGoodsName.Width = 113;
            // 
            // colGoodsId
            // 
            this.colGoodsId.Caption = "商品编号";
            this.colGoodsId.FieldName = "GoodsNo";
            this.colGoodsId.MinWidth = 25;
            this.colGoodsId.Name = "colGoodsId";
            this.colGoodsId.OptionsColumn.AllowEdit = false;
            this.colGoodsId.Visible = true;
            this.colGoodsId.VisibleIndex = 6;
            this.colGoodsId.Width = 105;
            // 
            // colGUnit
            // 
            this.colGUnit.Caption = "单位";
            this.colGUnit.FieldName = "GUnit";
            this.colGUnit.MinWidth = 25;
            this.colGUnit.Name = "colGUnit";
            this.colGUnit.OptionsColumn.AllowEdit = false;
            this.colGUnit.Visible = true;
            this.colGUnit.VisibleIndex = 8;
            this.colGUnit.Width = 70;
            // 
            // colOutCount
            // 
            this.colOutCount.Caption = "出库数量";
            this.colOutCount.FieldName = "OutCount";
            this.colOutCount.MinWidth = 25;
            this.colOutCount.Name = "colOutCount";
            this.colOutCount.Visible = true;
            this.colOutCount.VisibleIndex = 10;
            this.colOutCount.Width = 82;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "金额";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 25;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 12;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "单价";
            this.colPrice.FieldName = "Price";
            this.colPrice.MinWidth = 25;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 11;
            this.colPrice.Width = 94;
            // 
            // colInCount
            // 
            this.colInCount.Caption = "入库数量";
            this.colInCount.FieldName = "InCount";
            this.colInCount.MinWidth = 25;
            this.colInCount.Name = "colInCount";
            this.colInCount.Visible = true;
            this.colInCount.VisibleIndex = 9;
            this.colInCount.Width = 85;
            // 
            // colCurCount
            // 
            this.colCurCount.Caption = "库存余量";
            this.colCurCount.FieldName = "CurCount";
            this.colCurCount.MinWidth = 25;
            this.colCurCount.Name = "colCurCount";
            this.colCurCount.Visible = true;
            this.colCurCount.VisibleIndex = 13;
            this.colCurCount.Width = 79;
            // 
            // colCheckState
            // 
            this.colCheckState.Caption = "审核状态";
            this.colCheckState.FieldName = "CheckState";
            this.colCheckState.MinWidth = 25;
            this.colCheckState.Name = "colCheckState";
            this.colCheckState.Visible = true;
            this.colCheckState.VisibleIndex = 14;
            this.colCheckState.Width = 92;
            // 
            // colSheetNo
            // 
            this.colSheetNo.Caption = "单据编号";
            this.colSheetNo.FieldName = "SheetNo";
            this.colSheetNo.MinWidth = 25;
            this.colSheetNo.Name = "colSheetNo";
            this.colSheetNo.Visible = true;
            this.colSheetNo.VisibleIndex = 1;
            this.colSheetNo.Width = 123;
            // 
            // colShTypeName
            // 
            this.colShTypeName.Caption = "单据类型";
            this.colShTypeName.FieldName = "ShTypeName";
            this.colShTypeName.MinWidth = 25;
            this.colShTypeName.Name = "colShTypeName";
            this.colShTypeName.Visible = true;
            this.colShTypeName.VisibleIndex = 2;
            this.colShTypeName.Width = 108;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "单据日期";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.MinWidth = 25;
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 3;
            this.colCreateTime.Width = 118;
            // 
            // colCheckTime
            // 
            this.colCheckTime.Caption = "审核日期";
            this.colCheckTime.FieldName = "CheckTime";
            this.colCheckTime.MinWidth = 25;
            this.colCheckTime.Name = "colCheckTime";
            this.colCheckTime.Visible = true;
            this.colCheckTime.VisibleIndex = 4;
            this.colCheckTime.Width = 123;
            // 
            // colStoreName
            // 
            this.colStoreName.Caption = "仓库";
            this.colStoreName.FieldName = "StoreName";
            this.colStoreName.MinWidth = 25;
            this.colStoreName.Name = "colStoreName";
            this.colStoreName.Visible = true;
            this.colStoreName.VisibleIndex = 5;
            this.colStoreName.Width = 124;
            // 
            // colStPrice
            // 
            this.colStPrice.Caption = "成本价";
            this.colStPrice.FieldName = "StPrice";
            this.colStPrice.MinWidth = 25;
            this.colStPrice.Name = "colStPrice";
            this.colStPrice.Visible = true;
            this.colStPrice.VisibleIndex = 15;
            this.colStPrice.Width = 78;
            // 
            // colStAmount
            // 
            this.colStAmount.Caption = "成本金额";
            this.colStAmount.FieldName = "StAmount";
            this.colStAmount.MinWidth = 25;
            this.colStAmount.Name = "colStAmount";
            this.colStAmount.Visible = true;
            this.colStAmount.VisibleIndex = 16;
            this.colStAmount.Width = 79;
            // 
            // colDealPerson
            // 
            this.colDealPerson.Caption = "经手人";
            this.colDealPerson.FieldName = "DealPerson";
            this.colDealPerson.MinWidth = 25;
            this.colDealPerson.Name = "colDealPerson";
            this.colDealPerson.Visible = true;
            this.colDealPerson.VisibleIndex = 17;
            this.colDealPerson.Width = 115;
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
            // FrmGoodsStockChangeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 717);
            this.Controls.Add(this.gcChangeList);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmGoodsStockChangeList";
            this.Text = "查看商品库存变动明细";
            this.Load += new System.EventHandler(this.FrmGoodsStockChangeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChangeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UControls.QueryTool queryTool1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblDesp;
        private DevExpress.XtraEditors.LabelControl lblStoreName;
        private DevExpress.XtraGrid.GridControl gcChangeList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsId;
        private DevExpress.XtraGrid.Columns.GridColumn colGUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colOutCount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colInCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckState;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colStPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDealPerson;
    }
}