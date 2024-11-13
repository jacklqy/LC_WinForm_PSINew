namespace DXPSIApp.SM
{
    partial class FrmUserInfo
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
            this.txtUName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.infoTool1 = new DXPSIApp.UControls.InfoTool();
            this.txtUPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkNormal = new DevExpress.XtraEditors.CheckEdit();
            this.chkFrozen = new DevExpress.XtraEditors.CheckEdit();
            this.lbRoleList = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNormal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrozen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRoleList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(115, 114);
            this.txtUName.Name = "txtUName";
            this.txtUName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUName.Properties.Appearance.Options.UseFont = true;
            this.txtUName.Size = new System.Drawing.Size(219, 26);
            this.txtUName.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(64, 117);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 20);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "账号：";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.infoTool1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(638, 67);
            this.panelControl1.TabIndex = 5;
            // 
            // infoTool1
            // 
            this.infoTool1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.infoTool1.Appearance.Options.UseBackColor = true;
            this.infoTool1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoTool1.IsClearEnable = true;
            this.infoTool1.IsSaveEnable = true;
            this.infoTool1.Location = new System.Drawing.Point(3, 3);
            this.infoTool1.Name = "infoTool1";
            this.infoTool1.Size = new System.Drawing.Size(632, 61);
            this.infoTool1.TabIndex = 0;
            // 
            // txtUPwd
            // 
            this.txtUPwd.Location = new System.Drawing.Point(115, 164);
            this.txtUPwd.Name = "txtUPwd";
            this.txtUPwd.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUPwd.Properties.Appearance.Options.UseFont = true;
            this.txtUPwd.Properties.PasswordChar = '*';
            this.txtUPwd.Size = new System.Drawing.Size(219, 26);
            this.txtUPwd.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(64, 167);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 20);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "密码：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(64, 213);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 20);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "状态：";
            // 
            // chkNormal
            // 
            this.chkNormal.EditValue = true;
            this.chkNormal.Location = new System.Drawing.Point(115, 213);
            this.chkNormal.Name = "chkNormal";
            this.chkNormal.Properties.Caption = "正常";
            this.chkNormal.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.chkNormal.Properties.RadioGroupIndex = 1;
            this.chkNormal.Size = new System.Drawing.Size(58, 22);
            this.chkNormal.TabIndex = 9;
            // 
            // chkFrozen
            // 
            this.chkFrozen.Location = new System.Drawing.Point(209, 213);
            this.chkFrozen.Name = "chkFrozen";
            this.chkFrozen.Properties.Caption = "冻结";
            this.chkFrozen.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.chkFrozen.Properties.RadioGroupIndex = 1;
            this.chkFrozen.Size = new System.Drawing.Size(58, 22);
            this.chkFrozen.TabIndex = 10;
            this.chkFrozen.TabStop = false;
            // 
            // lbRoleList
            // 
            this.lbRoleList.CheckOnClick = true;
            this.lbRoleList.Location = new System.Drawing.Point(115, 256);
            this.lbRoleList.MultiColumn = true;
            this.lbRoleList.Name = "lbRoleList";
            this.lbRoleList.Size = new System.Drawing.Size(431, 97);
            this.lbRoleList.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(64, 257);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 20);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "状态：";
            // 
            // FrmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 404);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbRoleList);
            this.Controls.Add(this.chkFrozen);
            this.Controls.Add(this.chkNormal);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtUPwd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtUName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmUserInfo";
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.FrmUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNormal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFrozen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRoleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private UControls.InfoTool infoTool1;
        private DevExpress.XtraEditors.TextEdit txtUPwd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkNormal;
        private DevExpress.XtraEditors.CheckEdit chkFrozen;
        private DevExpress.XtraEditors.CheckedListBoxControl lbRoleList;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}