namespace DXPSIApp.SM
{
    partial class FrmRight
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
            this.btnCommit = new DevExpress.XtraEditors.SimpleButton();
            this.cboRoleList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabRight = new DevExpress.XtraTab.XtraTabControl();
            this.tpMenus = new DevExpress.XtraTab.XtraTabPage();
            this.tlMenuList = new DevExpress.XtraTreeList.TreeList();
            this.tlcolName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tpTools = new DevExpress.XtraTab.XtraTabPage();
            this.tlTools = new DevExpress.XtraTreeList.TreeList();
            this.tlcolTMName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabRight)).BeginInit();
            this.xtraTabRight.SuspendLayout();
            this.tpMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlMenuList)).BeginInit();
            this.tpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlTools)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCommit);
            this.panelControl1.Controls.Add(this.cboRoleList);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(600, 73);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnCommit.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Appearance.Options.UseBackColor = true;
            this.btnCommit.Appearance.Options.UseFont = true;
            this.btnCommit.Location = new System.Drawing.Point(498, 28);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(84, 32);
            this.btnCommit.TabIndex = 2;
            this.btnCommit.Text = "提交设置";
            // 
            // cboRoleList
            // 
            this.cboRoleList.Location = new System.Drawing.Point(242, 32);
            this.cboRoleList.Name = "cboRoleList";
            this.cboRoleList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoleList.Size = new System.Drawing.Size(202, 24);
            this.cboRoleList.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(184, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "角色：";
            // 
            // xtraTabRight
            // 
            this.xtraTabRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabRight.Location = new System.Drawing.Point(6, 79);
            this.xtraTabRight.Name = "xtraTabRight";
            this.xtraTabRight.SelectedTabPage = this.tpMenus;
            this.xtraTabRight.Size = new System.Drawing.Size(588, 607);
            this.xtraTabRight.TabIndex = 1;
            this.xtraTabRight.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMenus,
            this.tpTools});
            // 
            // tpMenus
            // 
            this.tpMenus.AutoScroll = true;
            this.tpMenus.Controls.Add(this.tlMenuList);
            this.tpMenus.ImageOptions.SvgImage = global::DXPSIApp.Properties.Resources.menu;
            this.tpMenus.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.tpMenus.Name = "tpMenus";
            this.tpMenus.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.tpMenus.Size = new System.Drawing.Size(586, 563);
            this.tpMenus.Text = "菜单";
            // 
            // tlMenuList
            // 
            this.tlMenuList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcolName});
            this.tlMenuList.KeyFieldName = "MId";
            this.tlMenuList.Location = new System.Drawing.Point(7, 10);
            this.tlMenuList.Name = "tlMenuList";
            this.tlMenuList.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlMenuList.OptionsView.ShowColumns = false;
            this.tlMenuList.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.tlMenuList.ParentFieldName = "ParentId";
            this.tlMenuList.Size = new System.Drawing.Size(570, 544);
            this.tlMenuList.TabIndex = 0;
            this.tlMenuList.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            // 
            // tlcolName
            // 
            this.tlcolName.Caption = "treeListColumn1";
            this.tlcolName.FieldName = "MName";
            this.tlcolName.Name = "tlcolName";
            this.tlcolName.Visible = true;
            this.tlcolName.VisibleIndex = 0;
            // 
            // tpTools
            // 
            this.tpTools.Controls.Add(this.tlTools);
            this.tpTools.ImageOptions.Image = global::DXPSIApp.Properties.Resources.ide_32x32;
            this.tpTools.Name = "tpTools";
            this.tpTools.Size = new System.Drawing.Size(586, 563);
            this.tpTools.Text = "工具栏";
            // 
            // tlTools
            // 
            this.tlTools.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcolTMName});
            this.tlTools.KeyFieldName = "TMenuId";
            this.tlTools.Location = new System.Drawing.Point(6, 9);
            this.tlTools.Name = "tlTools";
            this.tlTools.OptionsView.RootCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.Check;
            this.tlTools.OptionsView.ShowColumns = false;
            this.tlTools.ParentFieldName = "ParentId";
            this.tlTools.Size = new System.Drawing.Size(573, 548);
            this.tlTools.TabIndex = 0;
            // 
            // tlcolTMName
            // 
            this.tlcolTMName.Caption = "工具项名";
            this.tlcolTMName.FieldName = "TMenuName";
            this.tlcolTMName.Name = "tlcolTMName";
            this.tlcolTMName.Visible = true;
            this.tlcolTMName.VisibleIndex = 0;
            // 
            // FrmRight
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 691);
            this.Controls.Add(this.xtraTabRight);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmRight";
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.FrmRight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoleList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabRight)).EndInit();
            this.xtraTabRight.ResumeLayout(false);
            this.tpMenus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlMenuList)).EndInit();
            this.tpTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlTools)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoleList;
        private DevExpress.XtraEditors.SimpleButton btnCommit;
        private DevExpress.XtraTab.XtraTabControl xtraTabRight;
        private DevExpress.XtraTab.XtraTabPage tpMenus;
        private DevExpress.XtraTab.XtraTabPage tpTools;
        private DevExpress.XtraTreeList.TreeList tlMenuList;
        private DevExpress.XtraTreeList.TreeList tlTools;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcolName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcolTMName;
    }
}