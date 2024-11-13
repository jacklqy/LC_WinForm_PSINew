namespace DXPSIApp.BM
{
    partial class FrmChooseTypes
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.tlTypes = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnCancel);
            this.groupControl2.Controls.Add(this.btnChoose);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl2.Location = new System.Drawing.Point(2, 3);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(488, 62);
            this.groupControl2.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.ImageOptions.Image = global::DXPSIApp.Properties.Resources.cancel_16x161;
            this.btnCancel.Location = new System.Drawing.Point(412, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnChoose.Appearance.Options.UseBackColor = true;
            this.btnChoose.ImageOptions.Image = global::DXPSIApp.Properties.Resources.apply_16x16;
            this.btnChoose.Location = new System.Drawing.Point(320, 20);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(58, 29);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "选择";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // tlTypes
            // 
            this.tlTypes.Caption = "类别列表：";
            this.tlTypes.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.tlTypes.Location = new System.Drawing.Point(2, 71);
            this.tlTypes.Name = "tlTypes";
            this.tlTypes.OptionsView.ShowCaption = true;
            this.tlTypes.ParentFieldName = "ParentId";
            this.tlTypes.Size = new System.Drawing.Size(487, 515);
            this.tlTypes.TabIndex = 12;
            this.tlTypes.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            // 
            // colName
            // 
            this.colName.Caption = "类型名称";
            this.colName.FieldName = "GTypeName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // FrmChooseTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 588);
            this.Controls.Add(this.tlTypes);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmChooseTypes";
            this.Text = "选择商品/单位类别";
            this.Load += new System.EventHandler(this.FrmChooseTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private DevExpress.XtraTreeList.TreeList tlTypes;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
    }
}