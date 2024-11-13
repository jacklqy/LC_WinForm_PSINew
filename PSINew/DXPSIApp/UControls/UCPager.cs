using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace DXPSIApp.UControls
{
    public partial class UCPager : DevExpress.XtraEditors.XtraUserControl
    {
        public UCPager()
        {
            InitializeComponent();
        }

        private int record = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Record
        {
            get { return record; }
            set
            {
                record = value;
                InitPageInfo();
            }
        }

        private int startRecord = 1;
        public int StartRecord
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
            set { startRecord = value; }
        }

        private int pageSize = 20;

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int currentPage = 1;

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        public int pageNum = 0;

        /// <summary>
        /// 总页码
        /// </summary>
        public int PageNum
        {
            get
            {
                if (Record == 0)
                {
                    pageNum = 0;
                }
                else
                {
                    if (Record % PageSize > 0)
                    {
                        pageNum = Record / PageSize + 1;
                    }
                    else
                    {
                        pageNum = Record / PageSize;
                    }
                }
                return pageNum;
            }

        }

        public void InitPageInfo()
        {
            if (Record == 0 || (Record > 0 && CurrentPage > pageNum))
            {
                CurrentPage = 1;
            }
            lblPageInfo.Text = string.Format("共 {0} 条记录  共 {1} 页  当前第 {2} 页", Record, PageNum, CurrentPage);
            txtPage.Text = CurrentPage.ToString();

        }

        //定义委托
        public delegate void BindHandle(object sender, EventArgs e);

        /// <summary>
        /// 绑定数据源事件
        /// </summary>
        public event BindHandle BindSource;

        private void UCPager_Load(object sender, EventArgs e)
        {
            if (BindSource != null)
            {
                BindSource(sender, e);
                InitPageInfo();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Record > 0)
            {
                if (!string.IsNullOrEmpty(txtPage.Text) && !Regex.IsMatch(txtPage.Text, @"^[\d]*$"))
                {
                    MessageBox.Show("请正确填写页码！");
                    return;
                }
                int page = Convert.ToInt32(txtPage.Text);
                if (page == 0)
                {
                    page = 1;
                }
                if (page > PageNum)
                {
                    page = PageNum;
                }

                CurrentPage = page;
                if (BindSource != null)
                {
                    BindSource(sender, e);
                    InitPageInfo();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (Record > 0)
            {
                if (CurrentPage == PageNum)
                {
                    //MessageBox.Show("当前已经是末页");
                    return;
                }
                else
                {
                    CurrentPage = PageNum;
                    if (BindSource != null)
                    {
                        BindSource(sender, e);
                        InitPageInfo();
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Record > 0)
            {
                if (CurrentPage == PageNum)
                {
                    //MessageBox.Show("当前已经是末页");
                    return;
                }
                else
                {
                    CurrentPage = CurrentPage + 1;
                    if (BindSource != null)
                    {
                        BindSource(sender, e);
                        InitPageInfo();
                    }
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (Record > 0)
            {
                if (CurrentPage == 1)
                {
                   // MessageBox.Show("当前已经是首页");
                    return;
                }
                else
                {
                    CurrentPage = CurrentPage - 1;
                    if (BindSource != null)
                    {
                        BindSource(sender, e);
                        InitPageInfo();
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (Record > 0)
            {
                if (CurrentPage == 1)
                {
                    //MessageBox.Show("当前已经是首页");
                    return;
                }
                else
                {
                    CurrentPage = 1;
                    if (BindSource != null)
                    {
                        BindSource(sender, e);
                        InitPageInfo();
                    }
                }
            }
        }
    }
}
