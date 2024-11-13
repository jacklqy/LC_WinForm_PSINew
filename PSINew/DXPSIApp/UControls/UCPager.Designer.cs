namespace DXPSIApp.UControls
{
    partial class UCPager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPageInfo = new DevExpress.XtraEditors.LabelControl();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.txtPage = new DevExpress.XtraEditors.TextEdit();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPageInfo.Appearance.Options.UseFont = true;
            this.lblPageInfo.Appearance.Options.UseForeColor = true;
            this.lblPageInfo.Location = new System.Drawing.Point(31, 15);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(131, 19);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "共4页，当前第 1 页";
            // 
            // btnLast
            // 
            this.btnLast.ImageOptions.Image = global::DXPSIApp.Properties.Resources.last_16x16;
            this.btnLast.Location = new System.Drawing.Point(459, 9);
            this.btnLast.Name = "btnLast";
            this.btnLast.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLast.Size = new System.Drawing.Size(28, 29);
            this.btnLast.TabIndex = 4;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageOptions.Image = global::DXPSIApp.Properties.Resources.next_16x16;
            this.btnNext.Location = new System.Drawing.Point(411, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnNext.Size = new System.Drawing.Size(28, 29);
            this.btnNext.TabIndex = 3;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.ImageOptions.Image = global::DXPSIApp.Properties.Resources.prev_16x16;
            this.btnPrev.Location = new System.Drawing.Point(353, 9);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrev.Size = new System.Drawing.Size(28, 29);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageOptions.Image = global::DXPSIApp.Properties.Resources.first_16x16;
            this.btnFirst.Location = new System.Drawing.Point(303, 9);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnFirst.Size = new System.Drawing.Size(28, 29);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(557, 12);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(84, 24);
            this.txtPage.TabIndex = 5;
            // 
            // btnGo
            // 
            this.btnGo.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnGo.Appearance.Options.UseBackColor = true;
            this.btnGo.Location = new System.Drawing.Point(657, 9);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(53, 29);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "转到";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // UCPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblPageInfo);
            this.Name = "UCPager";
            this.Size = new System.Drawing.Size(762, 45);
            this.Load += new System.EventHandler(this.UCPager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblPageInfo;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.TextEdit txtPage;
        private DevExpress.XtraEditors.SimpleButton btnGo;
    }
}
