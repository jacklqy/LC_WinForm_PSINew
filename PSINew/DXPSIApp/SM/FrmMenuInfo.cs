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
using DXPSIApp.FModels;
using PSINew.Models.DModels;
using PSINew.UModels;

namespace DXPSIApp.SM
{
    public partial class FrmMenuInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmMenuInfo()
        {
            InitializeComponent();
        }
        public event Action ReLoad;
        private MenuBLL menuBLL = new MenuBLL();
        FInfoData fModel = null;
        int menuId = 0;//修改的菜单编号
        string uName = "";
        string oldName = "";//修改前的菜单名称
        private MenuInfoModel fVModel = null;
        private void FrmMenuInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                    if (fModel != null)
                    {
                        uName = fModel.UName;
                        menuId = fModel.FId;
                        LoadCboParents();//加载父菜单下拉框
                        //LoadCboForms();//加载关联页面下拉框
                        FormUtility.LoadCboForms(lueMurls, this);
                        InitPageInfo();//初始化页面信息
                        RegisterEvents();
                    }
                }
            };
            act.TryCatch("加载菜单信息", "菜单信息页面加载异常!");
        }

        private void RegisterEvents()
        {
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
        }

        private void InfoTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void InfoTool1_ClearClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel = new MenuInfoModel();
            if (fModel.ActType == 3)
                fVModel.ParentId = menuId;
            BindInfo();
        }

        private void InfoTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string msgTitle = "保存菜单";
            if (string.IsNullOrEmpty(fVModel.MName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,"菜单名称不能为空！");
                txtMName.Focus();
                return;
            }
            //3.判断菜单名称是否已存在 （oldName=""||(oldName!="" && oleName!=mName)） 
            if (string.IsNullOrEmpty(oldName) || (!string.IsNullOrEmpty(oldName) && oldName != fVModel.MName))
            {
                //判断名称是否已存在
                if (menuBLL.ExistMenu(fVModel.MName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"菜单名称已存在！");
                    txtMName.Focus();
                    return;
                }
            }
            //4.信息的封装
            MenuInfoModel menuInfo = fVModel;
            menuInfo.Creator = uName;
            menuInfo.IsTop = menuInfo.IsTopLevel ? 1 : 0;
            //5.执行方法（添加、修改）
            bool bl = false;
            string actMsg = fModel.ActType == 2 ? "修改" : "新增";
            if (fModel.ActType == 1 || fModel.ActType == 3)
            {
                //新增操作
                bl = menuBLL.AddMenuInfo(menuInfo);
            }
            else if (fModel.ActType == 2)
            {
                //修改操作
                menuInfo.MId = menuId;
                bl = menuBLL.UpdateMenuInfo(menuInfo);
            }
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow($"{actMsg}菜单", $"菜单：{fVModel.MName} 信息 {actMsg}成功！");
                this.ReLoad?.Invoke();//刷新列表数据
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,$"菜单：{fVModel.MName} 信息 {actMsg}失败！");
                return;
            }
        }

        private void InitPageInfo()
        {
            string title = "";
            switch (fModel.ActType)
            {
                case 1://新增
                    fVModel = new MenuInfoModel();
                    title = "新增";
                    break;
                case 2://修改
                    title = "修改";
                    InitMenuInfo(menuId);//加载菜单信息
                    infoTool1.IsClearEnable = false;
                    break;
                case 3://添加子菜单
                    title = "添加子菜单";
                    fVModel = new MenuInfoModel();
                    fVModel.ParentId = menuId;
                    luePMenus.Enabled = false;
                    break;
                case 4://详情页面
                    title = "详情";
                    InitMenuInfo(menuId);//加载菜单信息
                    infoTool1.IsClearEnable = false;
                    infoTool1.IsSaveEnable = false;
                    break;
            }
            BindInfo();
            this.Text += "----" + title;
        }

        private void InitMenuInfo(int menuId)
        {
            fVModel = menuBLL.GetMenuInfo(menuId);
            if (fVModel != null)
            {
                fVModel.IsTopLevel = fVModel.IsTop == 1 ? true : false;
                oldName = fVModel.MName;
            }
        }

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        private void BindInfo()
        {
            if (fVModel != null)
            {
                txtMName.DataBind(fVModel, "MName", true);
                txtMKey.DataBind(fVModel,"ParentId", true);
                luePMenus.DataBind(fVModel, "EditValue", "ParentId", true);
                spinOrder.DataBind(fVModel, "Value", "MOrder", true);
                lueMurls.DataBind(fVModel, "EditValue", "MUrl", true);
                chkTopLevel.DataBind(fVModel,"Checked", "IsTopLevel",true);
                cboMDesps.DataBind(fVModel,"EditValue", "MDesp", true);
            }
        }

        /// <summary>
        /// 加载窗体列表
        /// </summary>
        private void LoadCboForms()
        {
            //程序集名称
            string assName = this.GetType().Assembly.GetName().Name;
            Type[] types = this.GetType().Assembly.GetTypes();
            //筛选出所有窗体类
            var frmTypes = types.Where(t => t.BaseType.Name == "XtraForm");
            Dictionary<string, string> listForms = new Dictionary<string, string>();
            listForms.Add("0", "请选择页面");
            foreach (Type type in frmTypes)
            {
                Form f = (Form)Activator.CreateInstance(type);
                listForms.Add(type.FullName.Remove(0, assName.Length + 1), f.Text);
                f.Dispose();
            }
            //绑定
            BindingSource bs = new BindingSource();
            bs.DataSource = listForms;
            lueMurls.Properties.DataSource = bs;
            lueMurls.Properties.DisplayMember = "Value";
            lueMurls.Properties.ValueMember = "Key";
            lueMurls.EditValue = "0";
        }

        /// <summary>
        /// 加载父菜单列表
        /// </summary>
        private void LoadCboParents()
        {
            List<MenuInfoModel> menuList = menuBLL.GetAllMenus();
            List<CboMenuItem> mList = menuList.Select(m => new CboMenuItem()
            {
                Id = m.MId,
                Name = m.MName
            }).ToList();
            luePMenus.Properties.DataSource = mList;
            luePMenus.Properties.DisplayMember = "Name";
            luePMenus.Properties.ValueMember = "Id";
        }
    }
}