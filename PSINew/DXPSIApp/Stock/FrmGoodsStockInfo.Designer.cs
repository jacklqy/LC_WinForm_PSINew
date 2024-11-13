namespace DXPSIApp.Stock
{
    partial class FrmGoodsStockInfo
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblGoodsName = new DevExpress.XtraEditors.LabelControl();
            this.lblGUnit = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gcGoodsStockList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colCurCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPerCount = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPerPrice = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalStockAmount = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodsStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.lblGoodsName);
            this.panelControl1.Controls.Add(this.lblGUnit);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Location = new System.Drawing.Point(1, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(860, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseBorderColor = true;
            this.btnClose.ImageOptions.Image = global::DXPSIApp.Properties.Resources.close0;
            this.btnClose.Location = new System.Drawing.Point(741, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblGoodsName
            // 
            this.lblGoodsName.Location = new System.Drawing.Point(129, 23);
            this.lblGoodsName.Name = "lblGoodsName";
            this.lblGoodsName.Size = new System.Drawing.Size(45, 18);
            this.lblGoodsName.TabIndex = 4;
            this.lblGoodsName.Text = "调味品";
            // 
            // lblGUnit
            // 
            this.lblGUnit.Location = new System.Drawing.Point(320, 23);
            this.lblGUnit.Name = "lblGUnit";
            this.lblGUnit.Size = new System.Drawing.Size(15, 18);
            this.lblGUnit.TabIndex = 4;
            this.lblGUnit.Text = "件";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(269, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "单位：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(48, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 18);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "商品名称：";
            // 
            // gcGoodsStockList
            // 
            this.gcGoodsStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcGoodsStockList.Location = new System.Drawing.Point(1, 74);
            this.gcGoodsStockList.MainView = this.gridView1;
            this.gcGoodsStockList.Name = "gcGoodsStockList";
            this.gcGoodsStockList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemPerCount,
            this.itemRemark,
            this.itemPerPrice,
            this.itemGoodsName});
            this.gcGoodsStockList.Size = new System.Drawing.Size(860, 360);
            this.gcGoodsStockList.TabIndex = 4;
            this.gcGoodsStockList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStoreName,
            this.colCurCount,
            this.colStPrice,
            this.colStockAmount});
            this.gridView1.GridControl = this.gcGoodsStockList;
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
            this.colId.Width = 118;
            // 
            // colStoreName
            // 
            this.colStoreName.Caption = "仓库名称";
            this.colStoreName.ColumnEdit = this.itemGoodsName;
            this.colStoreName.FieldName = "StoreName";
            this.colStoreName.MinWidth = 25;
            this.colStoreName.Name = "colStoreName";
            this.colStoreName.Visible = true;
            this.colStoreName.VisibleIndex = 1;
            this.colStoreName.Width = 295;
            // 
            // itemGoodsName
            // 
            this.itemGoodsName.AutoHeight = false;
            this.itemGoodsName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.itemGoodsName.Name = "itemGoodsName";
            this.itemGoodsName.ReadOnly = true;
            // 
            // colCurCount
            // 
            this.colCurCount.Caption = "库存数量";
            this.colCurCount.FieldName = "CurCount";
            this.colCurCount.MinWidth = 25;
            this.colCurCount.Name = "colCurCount";
            this.colCurCount.Visible = true;
            this.colCurCount.VisibleIndex = 2;
            this.colCurCount.Width = 136;
            // 
            // colStPrice
            // 
            this.colStPrice.Caption = "成本单价";
            this.colStPrice.FieldName = "StPrice";
            this.colStPrice.MinWidth = 25;
            this.colStPrice.Name = "colStPrice";
            this.colStPrice.Visible = true;
            this.colStPrice.VisibleIndex = 3;
            this.colStPrice.Width = 179;
            // 
            // colStockAmount
            // 
            this.colStockAmount.Caption = "库存金额";
            this.colStockAmount.FieldName = "StockAmount";
            this.colStockAmount.MinWidth = 25;
            this.colStockAmount.Name = "colStockAmount";
            this.colStockAmount.Visible = true;
            this.colStockAmount.VisibleIndex = 4;
            this.colStockAmount.Width = 183;
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
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.lblTotalStockAmount);
            this.panelControl2.Controls.Add(this.lblTotalCount);
            this.panelControl2.Location = new System.Drawing.Point(1, 437);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(860, 37);
            this.panelControl2.TabIndex = 5;
            // 
            // lblTotalStockAmount
            // 
            this.lblTotalStockAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStockAmount.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotalStockAmount.Appearance.Options.UseBackColor = true;
            this.lblTotalStockAmount.Appearance.Options.UseTextOptions = true;
            this.lblTotalStockAmount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblTotalStockAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalStockAmount.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTotalStockAmount.Location = new System.Drawing.Point(714, 3);
            this.lblTotalStockAmount.Name = "lblTotalStockAmount";
            this.lblTotalStockAmount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTotalStockAmount.Size = new System.Drawing.Size(98, 27);
            this.lblTotalStockAmount.TabIndex = 5;
            this.lblTotalStockAmount.Text = "0.00";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCount.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTotalCount.Appearance.Options.UseBackColor = true;
            this.lblTotalCount.Appearance.Options.UseTextOptions = true;
            this.lblTotalCount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblTotalCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalCount.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTotalCount.Location = new System.Drawing.Point(388, 3);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTotalCount.Size = new System.Drawing.Size(82, 27);
            this.lblTotalCount.TabIndex = 5;
            this.lblTotalCount.Text = "0";
            // 
            // FrmGoodsStockInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 475);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.gcGoodsStockList);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmGoodsStockInfo";
            this.Text = "商品仓库分布";
            this.Load += new System.EventHandler(this.FrmGoodsStockInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodsStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPerPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblGUnit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gcGoodsStockList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStockAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itemRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemPerPrice;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblTotalCount;
        private DevExpress.XtraEditors.LabelControl lblTotalStockAmount;
    }
}