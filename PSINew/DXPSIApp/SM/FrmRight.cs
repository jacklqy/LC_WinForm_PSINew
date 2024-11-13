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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace DXPSIApp.SM
{
    public partial class FrmRight : DevExpress.XtraEditors.XtraForm
    {
        public FrmRight()
        {
            InitializeComponent();
        }
        private string uName = "";
        int roleId = 0;
        bool blFlag = false;
        private RoleBLL roleBLL = new RoleBLL();
        private MenuBLL menuBLL = new MenuBLL();
        private ToolMenuBLL tmBLL = new ToolMenuBLL();
        private bool isAdmin = false;
        private string msgTitle = "权限分配";
        private void FrmRight_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                LoadCboRoles();//加载角色下拉框
                //tag  菜单项----loginUserName  
                //角色管理页面  权限分配按钮 roleId=0
                //分配权限操作列  ---RoleId>0 
                if (this.Tag != null)
                {
                    Type tagType = this.Tag.GetType();
                    if (tagType == typeof(string))
                        uName = this.Tag.ToString();
                    else if (tagType == typeof(FRightData))
                    {
                        FRightData fModel = this.Tag as FRightData;
                        uName = fModel.UName;
                        roleId = fModel.RoleId;
                    }
                }
                blFlag = true;
                xtraTabRight.SelectedTabPageIndex = 0;//设置默认选择菜单选项卡
                LoadTvMenus();//加载菜单TvMenus
                LoadTvToolMenus();//加载工具菜单TvTMenus
                RegisterEvents();
                if (roleId > 0)
                {
                    cboRoleList.SetCboValue(roleId);
                    cboRoleList.Enabled = false;
                }
                else
                    cboRoleList.SelectedIndex = 0;
            };
            act.TryCatch("权限分配", "加载权限页面信息异常！");
        }

        private void RegisterEvents()
        {
            cboRoleList.SelectedIndexChanged += CboRoleList_SelectedIndexChanged;
            btnCommit.Click += BtnCommit_Click;
        }

        private void BtnCommit_Click(object sender, EventArgs e)
        {
            int rId = cboRoleList.GetCboValue();
            CheckIsAdmin(rId);
            if (rId == 0)
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,"请选择要设置权限的角色！");
                return;
            }
            else
            {
                //1.获取菜单编号，工具栏菜单编号
                List<int> tMenuIds = GetToolMenuIds(rId);
                List<int> menuIds = new List<int>();
                menuIds = GetMenuIds(rId, menuIds, tlMenuList.Nodes);
                bool bl = false;//执行结果
                if (menuIds.Count == 0 && tMenuIds.Count == 0)
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"请设置该角色的菜单和工具栏权限！");
                    return;
                }
                else if (menuIds.Count == 0 && tMenuIds.Count > 0)
                {
                    if (MsgBoxHelper.MsgBoxConfirm("权限设置", "您没有设置系统菜单权限，将会无法使用系统菜单功能！是否继续？") == DialogResult.Yes)
                    {
                        //设置工具栏权限
                        bl = roleBLL.SetRoleRight(rId, null, tMenuIds, uName);
                    }
                }
                else if (menuIds.Count > 0 && tMenuIds.Count == 0)
                {
                    if (MsgBoxHelper.MsgBoxConfirm("权限设置", "您没有设置工具菜单权限，将会无法使用工具栏菜单功能！是否继续？") == DialogResult.Yes)
                    {
                        //设置菜单权限
                        bl = roleBLL.SetRoleRight(rId, menuIds, null, uName);
                    }
                }
                else
                {
                    //设置菜单和工具栏权限
                    bl = roleBLL.SetRoleRight(rId, menuIds, tMenuIds, uName);
                }
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, "权限设置保存成功！");
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"权限设置保存失败！");
                    return;
                }
            }
        }

        private List<int> GetMenuIds(int rId, List<int> menuIds, TreeListNodes nodes)
        {
            foreach (TreeListNode tn in nodes)
            {
                var data = tlMenuList.GetDataRecordByNode(tn) as MenuInfoModel;
                //string name= tn.GetDisplayText("MName");
               if(tn.Checked||(tn.Nodes.Count >0 &&tn.CheckState==CheckState.Indeterminate))
                {
                    menuIds.Add(data.MId);
                }
                GetMenuIds(rId, menuIds, tn.Nodes);
            }
            return menuIds;
        }

        private List<int> GetToolMenuIds(int rId)
        {
            List<int> tMenuIds = new List<int>();
            foreach (TreeListNode tn in tlTools.Nodes)
            {
                if (tn.Checked)
                {
                    ToolMenuInfoModel tmenu = tlTools.GetDataRecordByNode(tn) as ToolMenuInfoModel;
                    tMenuIds.Add(tmenu.TMenuId);
                }
            }
            return tMenuIds;
        }

        private void CboRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blFlag)
            {
                int rId = cboRoleList.GetCboValue();
                CheckIsAdmin(rId);
                if (isAdmin)
                {
                    //把所有节点选中，不能进行权限提交设置
                    tlMenuList.CheckAll();
                    tlTools.CheckAll();
                    btnCommit.Enabled = false;
                }
                else
                {
                    btnCommit.Enabled = true;
                    tlMenuList.UncheckAll();
                    tlTools.UncheckAll();
                    if (rId > 0)
                    {
                        //加载权限数据
                        //获取数据   角色菜单    角色工具栏
                        List<int> menuIds = menuBLL.GetRoleMenuIds(rId);
                        List<int> tMenuIds = tmBLL.GetRoleTMenuIds(rId);
                        //加载 处理节点勾选
                        if (menuIds.Count > 0)
                            LoadTLChekcedNode(menuIds, tlMenuList.Nodes,1);
                        if (tMenuIds.Count > 0)
                            LoadTLChekcedNode(tMenuIds, tlTools.Nodes,2);
                    }
                }
            }
        }
        private void LoadTvToolMenus()
        {
            List<ToolMenuInfoModel> list = tmBLL.GetToolMenuList();
            tlTools.Nodes.Clear();
            tlTools.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check; ;

            tlTools.DataSource = list;
            tlTools.KeyFieldName = "TMenuId";
            tlTools.ExpandAll();
        }

        private void LoadTvMenus()
        {
            List<MenuInfoModel> list = menuBLL.GetTvMenus();
            tlMenuList.Nodes.Clear();
            tlMenuList.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            tlMenuList.DataSource = list;
            tlMenuList.KeyFieldName = "MId";
            tlMenuList.ParentFieldName = "ParentId";
            tlMenuList.OptionsBehavior.AllowRecursiveNodeChecking = true;
        }



        private void LoadCboRoles()
        {
            List<RoleInfoModel> roles = roleBLL.GetAllRoles();
            foreach (RoleInfoModel role in roles)
            {
                ComboBoxItem item = new ComboBoxItem(role.RoleName, role.RoleId);
                cboRoleList.Properties.Items.Add(item);
            }
            cboRoleList.Properties.Items.Insert(0, new ComboBoxItem("请选择", 0));
            cboRoleList.SelectedIndex = 0;
        }

        /// <summary>
        /// 判断选择的角色是否是管理员
        /// </summary>
        /// <param name="rId"></param>
        private void CheckIsAdmin(int rId)
        {
            isAdmin = false;
            RoleInfoModel roleInfo = roleBLL.GetRole(rId);
            if (roleInfo != null)
            {
                if (roleInfo.IsAdmin == 1)
                    isAdmin = true;
            }
        }

        /// <summary>
        /// 加载已设置权限数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="pNode"></param>

        private void LoadTLChekcedNode(List<int> Ids, TreeListNodes nodes, int typeCode)
        {
            foreach (TreeListNode tn in nodes)
            {
                if (typeCode == 1)
                {
                    var data = tlMenuList.GetDataRecordByNode(tn) as MenuInfoModel;
                    //string name= tn.GetDisplayText("MName");
                    if (Ids.Contains(data.MId))
                        tn.Checked = true;
                    LoadTLChekcedNode(Ids, tn.Nodes, typeCode);
                }
                else
                {
                    var data = tlTools.GetDataRecordByNode(tn) as ToolMenuInfoModel;
                    //string name= tn.GetDisplayText("MName");
                    if (Ids.Contains(data.TMenuId))
                        tn.Checked = true;
                }
              
            }
        }
    }
}