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
using System.IO;

namespace DXPSIApp.SM
{
    public partial class FrmTMenuInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmTMenuInfo()
        {
            InitializeComponent();
        }
        public event Action ReLoad;
        private ToolMenuBLL tmenuBLL = new ToolMenuBLL();
        private ToolGroupBLL tgroupBLL = new ToolGroupBLL();
        FInfoData fModel = null;
        int tmenuId = 0;//修改的工具菜单编号
        string uName = "";
        string oldName = "";//修改前的工具菜单名称
        private ToolMenuModel fVModel = null;
        string msgTitle = "工具组信息";
        private void FrmTMenuInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fVModel = new ToolMenuModel();
                    fModel = this.Tag as FInfoData;
                    InitPageInfo();
                    BindInfo();//绑定页面信息
                    RegisterEvents();
                }
            };
            act.TryCatch(msgTitle, "工具菜单信息页面加载异常!");
        }
        private void InitPageInfo()
        {
            if (fModel != null)
            {
                uName = fModel.UName;
                tmenuId = fModel.FId;
                LoadCboGroups();//加载工具组下拉框
                FormUtility.LoadCboForms(lueMurls, this);//加载关联页面下拉框
                string title = "";
                switch (fModel.ActType)
                {
                    case 1://新增
                        title = "新增";
                        break;
                    case 2://修改
                        title = "修改";
                        InitTMenuInfo(tmenuId);//加载工具菜单信息
                        infoTool1.IsClearEnable = false;
                        break;
                    case 4://详情页面
                        title = "详情";
                        InitTMenuInfo(tmenuId);//加载工具菜单信息
                        infoTool1.IsSaveEnable = false;
                        infoTool1.IsClearEnable = false;
                        break;
                }
                this.Text += "----" + title;
            }
        }

        private void BindInfo()
        {
            txtMName.DataBind(fVModel, "TMName", true);
            if (!string.IsNullOrEmpty(fVModel.TMPic))
            {
                fVModel.TMImg = Image.FromFile(Application.StartupPath + "/" + fVModel.TMPic);
                // pbImg.DataBindings.Add("Image", fVModel, "TMImg");
                pbImg.DataBind(fVModel, "Image", "TMImg", true);
            }
            lueGroups.DataBind(fVModel, "EditValue", "TGroupId", true);
            spinOrder.DataBind(fVModel, "Value", "TMOrder", true);
            lueMurls.DataBind(fVModel, "EditValue", "TMUrl", true);
            chkTopLevel.DataBind(fVModel, "Checked", "IsTop", true);
            cboMDesps.DataBind(fVModel, "EditValue", "TMDesp", true);
        }

        private void RegisterEvents()
        {
            btnChoose.Click += BtnChoose_Click;
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
        }


        #region 工具栏响应
        private void InfoTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool blCheck = CheckToolMenuInfo();
            if (!blCheck) return;
            //4.信息的封装
            ToolMenuInfoModel menuInfo = new ToolMenuInfoModel()
            {
                TMenuId = tmenuId,
                TMenuName = fVModel.TMName,
                TGroupId = fVModel.TGroupId,
                TMUrl = fVModel.TMUrl,
                TMOrder = fVModel.TMOrder,
                IsTop = fVModel.IsTop?1:0,
                TMDesp = fVModel.TMDesp,
                TMPic = fVModel.TMPic,
                Creator = fModel.UName
            };
            //5.执行方法（添加、修改）
            bool bl = false;
            string actMsg = fModel.ActType == 2 ? "修改" : "新增";
            if (fModel.ActType == 1)
            {
                //新增操作
                bl = tmenuBLL.AddToolMenuInfo(menuInfo);
            }
            else if (fModel.ActType == 2)
            {
                //修改操作
                bl = tmenuBLL.UpdateToolMenuInfo(menuInfo);
            }
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow($"{actMsg}工具菜单", $"工具菜单：{fVModel.TMName} 信息 {actMsg}成功！");
                this.ReLoad?.Invoke();//跨页面刷新列表数据
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle,$"工具菜单：{fVModel.TMName} 信息 {actMsg}失败！");
                return;
            }
        }

        private bool CheckToolMenuInfo()
        {
            //2.判断菜单名称不能为空
            if (string.IsNullOrEmpty(fVModel.TMName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "工具菜单名称不能为空！");
                txtMName.Focus();
                return false;
            }
            //3.判断菜单名称是否已存在 （oldName=""||(oldName!="" && oleName!=mName)） 
            if (tmenuId == 0 || (!string.IsNullOrEmpty(oldName) && oldName != fVModel.TMName))
            {
                //判断名称是否已存在
                if (tmenuBLL.ExistToolMenu(fVModel.TMName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle, "工具菜单名称已存在！");
                    txtMName.Focus();
                    return false;
                }
            }
            return true;
        }

        private void InfoTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void InfoTool1_ClearClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel = new ToolMenuModel();
            foreach(Control c in this.Controls)
            {
                c.DataBindings.Clear();
            }
            BindInfo();
        }
        #endregion
        /// <summary>
        /// 选择图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(ofdPic.FileName);
                fVModel.TMImg = Image.FromFile(ofdPic.FileName);
                if(pbImg.DataBindings.Count ==0)
                {
                    pbImg.DataBind(fVModel,"Image",  "TMImg",true);
                }
                string newPath = Application.StartupPath + "imgs/";
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);
                if (!File.Exists(newPath + ofdPic.SafeFileName))
                    File.Copy(path, newPath + ofdPic.SafeFileName);//保存到指定位置
                fVModel.TMPic = "/imgs/" + ofdPic.SafeFileName;
            }
        }


        private void InitTMenuInfo(int tmenuId)
        {
            fVModel.TMenuId = tmenuId;
            fVModel.GetToolMenuInfo();
            oldName = fVModel.TMName;
        }

        private void LoadCboGroups()
        {
            List<ToolGroupInfoModel> tgroups = tgroupBLL.GetToolGroups();
            List<CboMenuItem> mList = tgroups.Select(g => new CboMenuItem()
            {
                Id = g.TGroupId,
                Name = g.TGroupName
            }).ToList();
            lueGroups.Properties.DataSource = mList;
            lueGroups.Properties.DisplayMember = "Name";
            lueGroups.Properties.ValueMember = "Id";
        }
    }
}