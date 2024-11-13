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
using PSINew.UModels;
using PSINew.Models.DModels;
using DevExpress.XtraBars;
using Common;

namespace DXPSIApp.BM
{
    public partial class FrmStoreInfo : DevExpress.XtraEditors.XtraForm
    {
        StoreBLL storeBLL = new StoreBLL();
        StoreTypeBLL stBLL = new StoreTypeBLL();
        public event Action ReLoadHandler;//刷新列表页
        private FInfoData fModel = null;//页面传值的信息实体
        string oldName = "";//当前编辑前的仓库名称
        private StoreModel fVModel = null;
        int oldTypeId = 0;
        public FrmStoreInfo()
        {
            InitializeComponent();
        }

        private void FrmStoreInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                }
                if (fModel == null)
                {
                    MsgBoxHelper.MsgErrorShow("仓库信息","仓库信息初始化失败！");
                    return;
                }
                InitCboStoreTypes();//加载仓库类别下拉框
                InitPageInfo();
                RegisterEvents();
            };
            act.TryCatch("仓库信息","仓库信息页面初始化异常！");
        }

        private void RegisterEvents()
        {
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
            pbSTypes.Click += PbSTypes_Click;
            txtStoreName.TextChanged += TxtStoreName_TextChanged;
        }

        private void TxtStoreName_TextChanged(object sender, EventArgs e)
        {
            fVModel.StorePYNo= PingYinHelper.GetFirstSpell(txtStoreName.Text.Trim());
        }

        private void PbSTypes_Click(object sender, EventArgs e)
        {
            FrmStoreTypeList fStoreTypeList = new FrmStoreTypeList();
            fStoreTypeList.Tag = fModel.UName;
            fStoreTypeList.TVStoreTypeReload += InitCboStoreTypes;//刷新类别下拉框
            fStoreTypeList.ShowDialogNew();
        }

        private void InfoTool1_SaveClick(object sender, ItemClickEventArgs e)
        {
            string actMsg = fModel.ActType == 1 ? "添加" : "修改";
            string titleMsg = $"{actMsg}仓库信息";
            Action act = () =>
            {
                //信息获取

                int sTypeId = cboStoreTypes.GetCboValue();
                string storeName = fVModel.StoreName;
                //判断
                if (CheckStoreInfo(storeName, sTypeId, titleMsg) == false) return;
                //信息的封装
                StoreInfoModel storeInfo = fVModel.StoreInfo;
                storeInfo.STypeId = sTypeId;
                if (fModel.ActType == 1) storeInfo.Creator = fModel.UName;
                //调用方法
                bool bl = false;
                bl = fModel.ActType == 1 ? storeBLL.AddStoreInfo(storeInfo) : storeBLL.UpdateStoreInfo(storeInfo);
             
                string sucType = bl ? "成功" : "失败";
                string msg = $"仓库信息{actMsg} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(titleMsg, msg);
                    this.ReLoadHandler?.Invoke();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(titleMsg,msg);
                    return;
                }
            };
            act.TryCatch(titleMsg,"仓库信息提交出现异常");
        }

        private bool CheckStoreInfo(string storeName,int sTypeId,string title)
        {
            if (string.IsNullOrEmpty(fVModel.StoreName))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入仓库名称");
                txtStoreName.Focus();
                return false;
            }
            //判断是否已存在
            if (fModel.ActType == 1 || (!string.IsNullOrEmpty(oldName) && oldName != storeName) || (!string.IsNullOrEmpty(oldName) && (oldName == storeName) && (oldTypeId != sTypeId)))
            {
                if (storeBLL.ExistsStore(storeName, sTypeId))
                {
                    MsgBoxHelper.MsgErrorShow(title, "该仓库已存在！");
                    txtStoreName.Focus();
                    return false;
                }
            }
            if (sTypeId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择仓库类别！");
                cboStoreTypes.Focus();
                return false;
            }
            return true;
        }

        private void InfoTool1_ClearClick(object sender, ItemClickEventArgs e)
        {
            fVModel = new StoreModel();
            foreach (Control c in panelInfo.Controls)
            {
                c.DataBindings.Clear();
            }
            BindInfo();
        }

        private void InfoTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void InitPageInfo()
        {
            string lblTitleType = "";
            switch (fModel.ActType)
            {
                case 1:
                    fVModel = new StoreModel();
                    lblTitleType = "新增";
                    break;
                case 2:
                    InitStoreInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    lblTitleType = "修改";
                    break;
                case 4:
                    InitStoreInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    infoTool1.IsSaveEnable = false;
                    lblTitleType = "详情";
                    break;
                default: break;
            }
            this.Text += "----" + lblTitleType;
            BindInfo();//绑定信息
        }

        private void BindInfo()
        {
            foreach (Control c in panelInfo.Controls)
            {
                c.DataBindings.Clear();
            }
            if (fVModel != null)
            {
                txtStoreName.DataBind(fVModel, "StoreName", true);
                txtStoreNo.DataBind(fVModel, "StoreNo");
                txtStorePYNo.DataBind( fVModel, "StorePYNo");
                spinStoreOrder.DataBind(fVModel,"Value",  "StoreOrder");
                txtStoreRemark.DataBind(fVModel,"EditValue",  "StoreRemark" ,true);
                cboStoreTypes.SetCboValue(fVModel.STypeId);
            }
           
        }

        private void InitStoreInfo(int storeId)
        {
            if (fVModel == null) fVModel = new StoreModel();
            fVModel.StoreId = storeId;
            fVModel.GetStoreInfo();
            oldName = fVModel.StoreName;
            oldTypeId = fVModel.STypeId;
        }

        private void InitCboStoreTypes()
        {
            List<StoreTypeInfoModel> types = stBLL.LoadAllDrpStoreTypes();
            foreach (StoreTypeInfoModel type in types)
            {
                ComboBoxItem item = new ComboBoxItem(type.STypeName, type.STypeId);
                cboStoreTypes.Properties.Items.Add(item);
            }
            cboStoreTypes.Properties.Items.Insert(0, new ComboBoxItem("请选择", 0));
            cboStoreTypes.SelectedIndex = 0;
        }
    }
}