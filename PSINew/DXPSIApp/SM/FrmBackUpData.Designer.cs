namespace DXPSIApp.SM
{
    partial class FrmBackUpData
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBackPath = new DevExpress.XtraEditors.TextEdit();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(75, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 18);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "备份位置：";
            // 
            // txtBackPath
            // 
            this.txtBackPath.Location = new System.Drawing.Point(156, 61);
            this.txtBackPath.Name = "txtBackPath";
            this.txtBackPath.Size = new System.Drawing.Size(301, 24);
            this.txtBackPath.TabIndex = 31;
            // 
            // btnChoose
            // 
            this.btnChoose.Appearance.BackColor = System.Drawing.Color.PowderBlue;
            this.btnChoose.Appearance.Options.UseBackColor = true;
            this.btnChoose.ImageOptions.Image = global::DXPSIApp.Properties.Resources.loadfrom_16x16;
            this.btnChoose.Location = new System.Drawing.Point(476, 52);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(72, 29);
            this.btnChoose.TabIndex = 32;
            this.btnChoose.Text = "选择...";
            // 
            // btnBackUp
            // 
            this.btnBackUp.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btnBackUp.Appearance.Options.UseBackColor = true;
            this.btnBackUp.Location = new System.Drawing.Point(273, 132);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(59, 29);
            this.btnBackUp.TabIndex = 33;
            this.btnBackUp.Text = "备份";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Location = new System.Drawing.Point(369, 132);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 29);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "关闭";
            // 
            // FrmBackUpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 208);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtBackPath);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmBackUpData";
            this.Text = "备份数据";
            this.Load += new System.EventHandler(this.FrmBackUpData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBackPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBackPath;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private DevExpress.XtraEditors.SimpleButton btnBackUp;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}