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

namespace DXPSIApp.UControls
{
    public partial class SheetFormParent : DevExpress.XtraEditors.XtraForm
    {
        public SheetFormParent()
        {
            InitializeComponent();
        }
        public event Action ReloadList;//刷新单据列表页的事件
                                       //调用事件方法
        public void ReloadListHandler()
        {
            this.ReloadList?.Invoke();
        }
    }
}