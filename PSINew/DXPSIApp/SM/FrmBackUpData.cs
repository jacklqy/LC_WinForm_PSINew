using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSINew.BLL;

namespace DXPSIApp.SM
{
    public partial class FrmBackUpData : DevExpress.XtraEditors.XtraForm
    {
        public FrmBackUpData()
        {
            InitializeComponent();
        }

        private void FrmBackUpData_Load(object sender, EventArgs e)
        {
            txtBackPath.EditValue = "";
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnChoose.Click += BtnChoose_Click;
            btnClose.Click += BtnClose_Click;
            btnBackUp.Click += BtnBackUp_Click;
        }

        private void BtnBackUp_Click(object sender, EventArgs e)
        {
            string path = txtBackPath.Text.Trim();
           string msgTitle= "备份数据";
            if (string.IsNullOrEmpty(path))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,"请选择备份文件存放的位置!");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, "您确定要备份数据库吗?") == DialogResult.Yes)
            {
                SysBLL sysBLL = new SysBLL();
                bool bl = sysBLL.BackupData(path);
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, "系统数据备份完毕!");
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"数据备份失败!");
                    return;
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBackPath.Text = ofd.SelectedPath;
            }
            
        }
    }
}