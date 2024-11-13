namespace DXPSIApp.Stock
{
    partial class FrmSetMore
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
            this.lblStoreName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkUp = new DevExpress.XtraEditors.CheckEdit();
            this.chkDown = new DevExpress.XtraEditors.CheckEdit();
            this.spinUp = new DevExpress.XtraEditors.SpinEdit();
            this.spinDown = new DevExpress.XtraEditors.SpinEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDown.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStoreName
            // 
            this.lblStoreName.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStoreName.Appearance.ForeColor = System.Drawing.Color.Brown;
            this.lblStoreName.Appearance.Options.UseFont = true;
            this.lblStoreName.Appearance.Options.UseForeColor = true;
            this.lblStoreName.Location = new System.Drawing.Point(141, 43);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(30, 19);
            this.lblStoreName.TabIndex = 5;
            this.lblStoreName.Text = "全部";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(66, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "仓库：";
            // 
            // chkUp
            // 
            this.chkUp.Location = new System.Drawing.Point(66, 96);
            this.chkUp.Name = "chkUp";
            this.chkUp.Properties.Caption = "库存上限";
            this.chkUp.Size = new System.Drawing.Size(94, 22);
            this.chkUp.TabIndex = 7;
            // 
            // chkDown
            // 
            this.chkDown.Location = new System.Drawing.Point(66, 140);
            this.chkDown.Name = "chkDown";
            this.chkDown.Properties.Caption = "库存下限";
            this.chkDown.Size = new System.Drawing.Size(94, 22);
            this.chkDown.TabIndex = 7;
            // 
            // spinUp
            // 
            this.spinUp.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinUp.Location = new System.Drawing.Point(166, 95);
            this.spinUp.Name = "spinUp";
            this.spinUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinUp.Size = new System.Drawing.Size(125, 24);
            this.spinUp.TabIndex = 8;
            // 
            // spinDown
            // 
            this.spinDown.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDown.Location = new System.Drawing.Point(166, 138);
            this.spinDown.Name = "spinDown";
            this.spinDown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinDown.Size = new System.Drawing.Size(125, 24);
            this.spinDown.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.ImageOptions.Image = global::DXPSIApp.Properties.Resources.apply_16x16;
            this.btnSave.Location = new System.Drawing.Point(77, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.ImageOptions.Image = global::DXPSIApp.Properties.Resources.cancel_16x161;
            this.btnCancel.Location = new System.Drawing.Point(191, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            // 
            // FrmSetMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 291);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.spinDown);
            this.Controls.Add(this.spinUp);
            this.Controls.Add(this.chkDown);
            this.Controls.Add(this.chkUp);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.labelControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmSetMore";
            this.Text = "批量设置库存上下限";
            this.Load += new System.EventHandler(this.FrmSetMore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDown.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblStoreName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkUp;
        private DevExpress.XtraEditors.CheckEdit chkDown;
        private DevExpress.XtraEditors.SpinEdit spinUp;
        private DevExpress.XtraEditors.SpinEdit spinDown;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}