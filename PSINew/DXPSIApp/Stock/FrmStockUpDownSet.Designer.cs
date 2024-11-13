namespace DXPSIApp.Stock
{
    partial class FrmStockUpDownSet
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
            this.upDownTool1 = new DXPSIApp.UControls.UpDownTool();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pbStores = new DevExpress.XtraEditors.PictureEdit();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlGTypes = new DevExpress.XtraTreeList.TreeList();
            this.colGType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gcGoodsStockList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockDown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockUp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemStockUp = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.itemStockDown = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodsStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.AutoSize = true;
            this.panelControl1.Controls.Add(this.upDownTool1);
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1188, 67);
            this.panelControl1.TabIndex = 0;
            // 
            // upDownTool1
            // 
            this.upDownTool1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDownTool1.IsSetMoreEnabled = true;
            this.upDownTool1.Location = new System.Drawing.Point(3, 3);
            this.upDownTool1.Name = "upDownTool1";
            this.upDownTool1.Size = new System.Drawing.Size(1182, 61);
            this.upDownTool1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.pbStores);
            this.groupControl1.Controls.Add(this.txtStoreName);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Location = new System.Drawing.Point(1, 71);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1188, 83);
            this.groupControl1.TabIndex = 17;
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
            this.splitContainerControl1.Location = new System.Drawing.Point(1, 157);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tlGTypes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcGoodsStockList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1188, 525);
            this.splitContainerControl1.SplitterPosition = 288;
            this.splitContainerControl1.TabIndex = 18;
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
            this.tlGTypes.Size = new System.Drawing.Size(287, 515);
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
            // gcGoodsStockList
            // 
            this.gcGoodsStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcGoodsStockList.Location = new System.Drawing.Point(1, 4);
            this.gcGoodsStockList.MainView = this.gridView1;
            this.gcGoodsStockList.Name = "gcGoodsStockList";
            this.gcGoodsStockList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.itemStockUp,
            this.itemStockDown,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gcGoodsStockList.Size = new System.Drawing.Size(886, 514);
            this.gcGoodsStockList.TabIndex = 5;
            this.gcGoodsStockList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colGoodsName,
            this.colGoodsNo,
            this.colGUnit,
            this.colStockDown,
            this.colStockUp});
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
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 120;
            // 
            // colGoodsName
            // 
            this.colGoodsName.Caption = "商品名称";
            this.colGoodsName.FieldName = "GoodsName";
            this.colGoodsName.MinWidth = 25;
            this.colGoodsName.Name = "colGoodsName";
            this.colGoodsName.OptionsColumn.AllowEdit = false;
            this.colGoodsName.Visible = true;
            this.colGoodsName.VisibleIndex = 1;
            this.colGoodsName.Width = 275;
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
            this.colGoodsNo.Width = 121;
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
            this.colGUnit.Width = 90;
            // 
            // colStockDown
            // 
            this.colStockDown.Caption = "库存下限";
            this.colStockDown.ColumnEdit = this.repositoryItemTextEdit1;
            this.colStockDown.FieldName = "StockDown";
            this.colStockDown.MinWidth = 25;
            this.colStockDown.Name = "colStockDown";
            this.colStockDown.OptionsColumn.ImmediateUpdateRowPosition = DevExpress.Utils.DefaultBoolean.True;
            this.colStockDown.Visible = true;
            this.colStockDown.VisibleIndex = 5;
            this.colStockDown.Width = 189;
            // 
            // colStockUp
            // 
            this.colStockUp.Caption = "库存上限";
            this.colStockUp.ColumnEdit = this.repositoryItemTextEdit2;
            this.colStockUp.FieldName = "StockUp";
            this.colStockUp.MinWidth = 25;
            this.colStockUp.Name = "colStockUp";
            this.colStockUp.Visible = true;
            this.colStockUp.VisibleIndex = 4;
            this.colStockUp.Width = 190;
            // 
            // itemStockUp
            // 
            this.itemStockUp.AutoHeight = false;
            this.itemStockUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemStockUp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.itemStockUp.IsFloatValue = false;
            this.itemStockUp.Mask.EditMask = "N00";
            this.itemStockUp.Name = "itemStockUp";
            // 
            // itemStockDown
            // 
            this.itemStockDown.AutoHeight = false;
            this.itemStockDown.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.itemStockDown.Name = "itemStockDown";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // FrmStockUpDownSet
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 685);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmStockUpDownSet";
            this.Text = "库存上下限设置";
            this.Load += new System.EventHandler(this.FrmStockUpDownSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlGTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGoodsStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStockDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UControls.UpDownTool upDownTool1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PictureEdit pbStores;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlGTypes;
        private DevExpress.XtraGrid.GridControl gcGoodsStockList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colStockDown;
        private DevExpress.XtraGrid.Columns.GridColumn colStockUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemStockUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit itemStockDown;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGType;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
    }
}