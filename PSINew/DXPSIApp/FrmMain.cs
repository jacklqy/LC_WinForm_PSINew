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
using PSINew.Models.VModels;
using WinPSI.FModels;
using PSINew.Models.DModels;
using DevExpress.XtraBars;
using DevExpress.Utils;
using System.Reflection;
using DXPSIApp.FModels;
using DevExpress.XtraTab;

namespace DXPSIApp
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private MenuBLL menuBLL = new MenuBLL();
        private ToolMenuBLL tmBLL = new ToolMenuBLL();
        private SysBLL sysBLL = new SysBLL();
        List<ViewUserRoleModel> urList = null;
        string uName = "";
        bool isAdmin = false;
        FrmLogin fLogin = null;
        int IsFirst = 0;//是否是第一次加载页面
        bool hasOpened = false;//开账状态
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                IsFirst = 1;
                //获取开账状态(暂不处理) 默认账套，编号为1

                if (this.Tag != null)
                {
                    InitMainInfo();//初始化
                }
            };
            act.TryCatch("主页加载","主页面初始化出现异常");
        }
        /// <summary>
        /// 主页面初始化操作
        /// </summary>
        private void InitMainInfo()
        {
            LoginData loginModel = this.Tag as LoginData;
            if (loginModel != null)
            {
                urList = loginModel.URList;
                uName = urList[0].UserName;
                fLogin = loginModel.LoginForm;
                CheckIsAdmin();
                //创建菜单项和工具菜单项，并添加到菜单控件和工具栏里?
                AddMenusAndToolMenus();
                //初始化状态栏信息
                InitStatusBarInfo();
            }
        }

        //加载菜单栏与工具栏
        private void AddMenusAndToolMenus()
        {
            List<MenuInfoModel> menuList = new List<MenuInfoModel>();
            List<ToolMenuInfoModel> toolMenuList = new List<ToolMenuInfoModel>();
            hasOpened = sysBLL.GetOpenState(1);//开账状态获取
            if (isAdmin)//超级管理员
            {
                //获取所有的菜单和工具栏菜单
                //1.获取菜单数据
                menuList = menuBLL.GetMenuList(new List<int>());
                //2.获取工具菜单项数据
                toolMenuList = tmBLL.GetToolMenuList(new List<int>());
            }
            else
            {
                //加载登录者拥有的菜单和工具栏菜单?
                List<int> roleIds = urList.Select(ur => ur.RoleId).ToList();
                //1.获取菜单数据
                menuList = menuBLL.GetMenuList(roleIds);
                //2.获取工具菜单项数据
                toolMenuList = tmBLL.GetToolMenuList(roleIds);
            }
            psiMainMenus.ItemLinks.Clear();
            psiTools.ItemLinks.Clear();
            //添加菜单项
            barManager1.BeginUpdate();
            AddMenuItem(menuList, null, 0);//递归
            //添加工具菜单项
            AddToolMenuItem(toolMenuList);
            barManager1.EndUpdate();
        }

        //检查是否是管理员
        private void CheckIsAdmin()
        {
            isAdmin = false;
            foreach (var ur in urList)
            {
                if (ur.IsAdmin == 1)
                {
                    isAdmin = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 初始化状态栏信息
        /// </summary>
        private void InitStatusBarInfo()
        {
            lblLoginName.Caption = uName;
            if (isAdmin)
                lblRoleName.Caption = "管理员";
            else
            {
                string roleName = string.Join(",", urList.Select(ur => ur.RoleName).Distinct());
                lblRoleName.Caption = roleName;
            }
            lblCurTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lblRights.Caption = "朝夕教育所有";
        }

        /// <summary>
        ///递归添加菜单项
        /// </summary>
        /// <param name="mList"></param>
        /// <param name="pMenu"></param>
        /// <param name="pId"></param>
        private void AddMenuItem(List<MenuInfoModel> mList, BarSubItem pMenu, int pId)
        {
            //获取所有子菜单列表
            var childList = mList.Where(m => m.ParentId == pId);
            foreach (var child in childList)
            {
                //期初开账或反开账 是否加载？？
                if (child.MDesp == MenuDesp.OpenSys.ToString() && hasOpened)
                {
                    continue;
                }
                if (child.MDesp == MenuDesp.UnOpenSys.ToString() && !hasOpened)
                {
                    continue;
                }
                var childCount = mList.Where(m => m.ParentId == child.MId).ToList().Count;
                if (childCount > 0)
                {
                    BarSubItem mi = new BarSubItem();
                    mi.Name = child.MId.ToString();
                    mi.Caption = child.MName;
                    mi.Id = child.MId;
                    mi.AllowDrawArrow = DefaultBoolean.True;
                    mi.Manager = barManager1;
                    if (!string.IsNullOrEmpty(child.MKey))
                    {
                        //alt+K
                        string sKey = child.MKey.ToString().Trim();
                        //设置Alt快捷键  Ctrl+P   Shift+C
                        if (sKey.Length > 1 && sKey.Split('+')[0].ToLower() == "alt" && child.ParentId == 0)
                        {
                            mi.Caption += $"(&{sKey.Split('+')[1]})";
                        }
                        mi.ItemShortcut = FormUtility.SetShortKeys(sKey);
                    }
                    if (pMenu != null)
                        pMenu.ItemLinks.Add(mi);
                    else
                        psiMainMenus.ItemLinks.Add(mi);
                    AddMenuItem(mList, mi, child.MId);
                }
                else
                {
                    BarButtonItem mi = new BarButtonItem();
                    mi.Name = child.MId.ToString();
                    mi.Caption = child.MName;
                    mi.Id = child.MId;
                    mi.AllowDrawArrow = false;
                    barManager1.Items.Add(mi);
                    mi.Tag = child;
                    if (!string.IsNullOrEmpty(child.MKey))
                    {
                        //alt+K
                        string sKey = child.MKey.ToString().Trim();
                        //设置Alt快捷键  Ctrl+P   Shift+C
                        if (sKey.Length > 1 && sKey.Split('+')[0].ToLower() == "alt" && child.ParentId == 0)
                        {
                            mi.Caption += $"(&{sKey.Split('+')[1]})";
                        }
                        mi.ItemShortcut = FormUtility.SetShortKeys(sKey);
                    }
                    mi.ItemClick += Mi_ItemClick;
                    if (pMenu != null)
                        pMenu.ItemLinks.Add(mi);
                  
                }
            }
        }

        /// <summary>
        /// 菜单项响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mi_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 获取单击的菜单项
            BarButtonItem mi = e.Item as BarButtonItem;
            if (mi.Tag != null)
            {
                MenuInfoModel mInfo = mi.Tag as MenuInfoModel;
                if (!string.IsNullOrEmpty(mInfo.MUrl))
                    CreateForm(mInfo.MUrl, mInfo.IsTop);
                else if (mInfo.MDesp == MenuDesp.ExitSystem.ToString())
                {
                    Application.Exit();
                }
                //开账
                else if (mInfo.MDesp == MenuDesp.OpenSys.ToString())
                {
                    OpenSysStart();
                }
                //反开账
                else if (mInfo.MDesp == MenuDesp.UnOpenSys.ToString())
                {
                    UnOpenSys();
                }
            }
        }

        /// <summary>
        /// 添加工具菜单项
        /// </summary>
        /// <param name="toolList"></param>
        private void AddToolMenuItem(List<ToolMenuInfoModel> toolList)
        {
            //1.统计分组
            List<int> groupIds = new List<int>();
            groupIds = toolList.Select(tm => tm.TGroupId).Distinct().ToList();
            //2.工具菜单项的添加
            foreach (var groupId in groupIds)
            {
                var gTools = toolList.Where(t => t.TGroupId == groupId);
                if (gTools.ToList().Count > 0)
                {
                    int i = 0;
                    foreach (var tmi in gTools)
                    {
                        BarButtonItem tsbtn = new BarButtonItem();
                        barManager1.Items.Add(tsbtn);
                        
                        tsbtn.Caption = tmi.TMenuName;
                        tsbtn.Name = tmi.TMenuId.ToString();
                        //图片
                        if (!string.IsNullOrEmpty(tmi.TMPic))
                            tsbtn.ImageOptions.Image = Image.FromFile(Application.StartupPath + "/" + tmi.TMPic);
                        //图片与文本显示方式
                        tsbtn.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                        //文本与图片的显示位置
                        tsbtn.ImageToTextAlignment = BarItemImageToTextAlignment.BeforeText;
                        tsbtn.Tag = tmi;
                        tsbtn.ItemClick += Tsbtn_ItemClick; ;//单击事件注册                   
                        if (i == 0)
                        {
                            BarItemLink tsbtnLink = psiTools.AddItem(tsbtn);
                            tsbtnLink.BeginGroup = true;
                        }
                        else
                        {
                            psiTools.AddItem(tsbtn);
                        }
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// 工具项响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tsbtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem tsbtn = e.Item as BarButtonItem;
            if (tsbtn.Tag != null)
            {
                ToolMenuInfoModel tmInfo = tsbtn.Tag as ToolMenuInfoModel;
                string mUrl = tmInfo.TMUrl;
                if (!string.IsNullOrEmpty(mUrl))
                    CreateForm(mUrl, tmInfo.IsTop);
                else
                {
                    //特殊响应处理
                    //退出系统操作
                    if (tmInfo.TMDesp == ToolMenuDesp.ExitSystem.ToString())
                    {
                        Application.Exit();
                    }
                    else if (tmInfo.TMDesp == ToolMenuDesp.ChangeActor.ToString())
                    {
                        //更换操作员
                        this.Hide();
                        fLogin.Show();//不能showDialog()
                        IsFirst = 2;
                    }
                    else if (tmInfo.TMDesp == ToolMenuDesp.RefreshMenu.ToString())
                    {
                        //刷新菜单(菜单栏和工具栏)
                        AddMenusAndToolMenus();
                    }
                }
            }
        }
        /// <summary>
        /// 实例化窗体页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isTop"></param>
        private void CreateForm(string url, int isTop)
        {
            //程序集的名称
            string assName = this.GetType().Assembly.GetName().Name;
            Assembly ass = Assembly.Load(assName);
            if (ass != null)
            {
                var types = ass.GetTypes().Where(tt => tt.BaseType.Name == "XtraForm"|| tt.BaseType.Name == "SheetFormParent");
                Type fType = types.Where(tt => tt.FullName == assName + "." + url).FirstOrDefault();
                if (fType != null)
                {
                    //创建窗体或打开？？  是否已经打开？？  没--创建，打开---激活
                    //打开方式   模式窗体或内嵌到选项卡中？？

                    string frmName = url.Substring(url.LastIndexOf('.') + 1);

                    if (!FormUtility.CheckOpenForm(frmName))
                    {
                        object t = Activator.CreateInstance(fType);
                        XtraForm f = (XtraForm)t;
                        if (f.Name.Contains(MenuDesp.ModifyPwd.ToString()))//修改密码页面传值
                        {
                            f.Tag = new PwdData()
                            {
                                UName = uName,
                                FLogin = this.fLogin,
                                FMain = this
                            };
                        }
                        else
                            f.Tag = uName;
                        if (isTop == 0)
                        {
                            //内嵌到选项卡里
                            xtabPages.AddTabFormPage(f,-1);
                        }
                        else
                        {
                            //顶级显示
                            f.StartPosition = FormStartPosition.CenterScreen;
                            f.WindowState = FormWindowState.Normal;
                            f.ShowDialog();
                        }
                    }
                    else//如果已打开，则激活
                    {
                        foreach (XtraTabPage page in xtabPages.TabPages)
                        { 
                             if(page.Name ==frmName)
                            {
                                xtabPages.SelectedTabPage = page;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 反开账
        /// </summary>
        private void UnOpenSys()
        {
            if (sysBLL.GetAllCheckedCount() > 0)
            {
                MsgBoxHelper.MsgErrorShow("反开账提示","存在已审核的单据，不能反开账！");
                return;
            }
            else
            {
                bool blUnOpened = sysBLL.UnOpenedSys(1);
                if (blUnOpened)
                {
                    MsgBoxHelper.MsgBoxShow("反开账", "已成功反开账，可以进行期初数据录入工作了！");

                    hasOpened = false;
                    AddMenusAndToolMenus();
                }

            }
        }

        /// <summary>
        /// 开账
        /// </summary>
        private void OpenSysStart()
        {
            //检查是否存在未审核的期初录入单据
            StockBLL stockBLL = new StockBLL();
            if (stockBLL.HasUnCheckedStartStock())
            {
                MsgBoxHelper.MsgErrorShow("开账错误","存在未审核的期初入库单据，不能开账！");
                return;
            }
            else
            {
                if (sysBLL.OpenSys(1))
                {
                    MsgBoxHelper.MsgBoxShow("期初开账", "已成功开账，可以进行业务录入工作了！");
                    hasOpened = true;
                    AddMenusAndToolMenus();
                }
            }
        }

        /// <summary>
        /// 特殊工具菜单项说明
        /// </summary>
        private enum ToolMenuDesp
        {
            ExitSystem = 1,
            ChangeActor = 2,
            RefreshMenu = 3
        }

        /// <summary>
        /// 特殊菜单项说明
        /// </summary>
        private enum MenuDesp
        {
            ExitSystem = 1,
            ModifyPwd = 2,
            OpenSys = 3,
            UnOpenSys = 4
        }

        /// <summary>
        /// 关闭页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtabPages_CloseButtonClick(object sender, EventArgs e)
        {
            //获取选择的选项卡
            XtraTabPage selPage = xtabPages.SelectedTabPage;
            if (selPage != null)
            {
                xtabPages.TabPages.Remove(selPage);//移除
                FormUtility.CloseOpenForm(selPage.Name);//关闭窗体
            }
        }

        private void xtabPages_SizeChanged(object sender, EventArgs e)
        {
            if (xtabPages.TabPages.Count > 0)
            {
                Size size = xtabPages.SelectedTabPage.Size;
                foreach (XtraTabPage page in xtabPages.TabPages)
                {
                    Control c = page.Controls[0];
                    if (c is XtraForm)
                    {
                        XtraForm frm = c as XtraForm;
                        frm.WindowState = FormWindowState.Normal;
                        frm.SuspendLayout();
                        frm.Size = size;
                        frm.ResumeLayout(true);
                        frm.WindowState = FormWindowState.Maximized;
                    }
                }
            }
        }

        private void FrmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (IsFirst == 2)
            {
                InitMainInfo();
                IsFirst = 1;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MsgBoxHelper.MsgBoxConfirm("关闭系统", "您确定要退出系统？") == DialogResult.Yes)
            {
                Application.ExitThread();//退出消息循环
            }
            else
                e.Cancel = true;
        }
    }
}