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
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using Common;

namespace DXPSIApp.BM
{
    public partial class FrmUnitInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmUnitInfo()
        {
            InitializeComponent();
        }
        private UnitBLL unitBLL = new UnitBLL();
        private RegionBLL regionBLL = new RegionBLL();
        private UnitTypeBLL utBLL = new UnitTypeBLL();
        public event Action ReLoadHandler;
        private FInfoData fModel = null;
        private string oldName = "";//修改前的单位名称
        public UnitTypeInfoModel uType = null;//单位类别实体
        private int oldTypeId = 0;//修改前的类别编号
        private UnitModel fVModel = null;
        
        private void FrmUnitInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                }
                if (fModel == null)
                {
                    MsgBoxHelper.MsgErrorShow("单位信息","单位信息初始化失败！");
                    return;
                }
                RegisterEvents();
                fVModel = new UnitModel();
                InitUnitProperties();//加载单位性质列表
                txtNation.Text = fVModel.NationName;
                InitProvinces();//加载所有的省区域列表
                InitPageInfo();
               
            };
            act.TryCatch("单位信息","单位信息页面初始化异常！");
        }

        private void RegisterEvents()
        {
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
            pbUTypes.Click += PbUTypes_Click;
            txtUnitName.TextChanged += TxtUnitName_TextChanged;
            cboProvinces.SelectedIndexChanged += CboProvinces_SelectedIndexChanged;
            cboCitys.SelectedIndexChanged += CboCitys_SelectedIndexChanged;
        }

        private void CboCitys_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCountries();
        }

        private void CboProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCities();
        }

        private void TxtUnitName_TextChanged(object sender, EventArgs e)
        {
            fVModel.UnitPYNo = PingYinHelper.GetFirstSpell(txtUnitName.Text.Trim());
        }

        private void PbUTypes_Click(object sender, EventArgs e)
        {
            FrmChooseTypes fChooseTypes = new FrmChooseTypes();
            fChooseTypes.Tag = new ChooseTypeData()
            {
                TypeCode = "Units",
                FGet = this
            };
            fChooseTypes.SetType += () =>
            {
                fVModel.UTypeId = uType.UTypeId;
                fVModel.UTypeName = uType.UTypeName;
            };
            fChooseTypes.ShowDialog();
        }

        private void InfoTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void InfoTool1_ClearClick(object sender, ItemClickEventArgs e)
        {
            fVModel = new UnitModel();
            BindInfo();
        }

        private void InitPageInfo()
        {
            string lblTitleType = "";
            switch (fModel.ActType)
            {
                case 1:
                    lblTitleType = "新增";
                    break;
                case 2:
                    InitUnitInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    lblTitleType = "修改";
                    break;
                case 4:
                    InitUnitInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    infoTool1.IsSaveEnable = false;
                    lblTitleType = "详情";
                    break;
                default: break;
            }
            this.Text += "----" + lblTitleType;
            BindInfo();
        }

        private void BindInfo()
        {
          
            if (fVModel != null)
            {
                txtUnitName.DataBind(fVModel,  "UnitName",true);
                txtUnitNo.DataBind(fVModel,  "UnitNo", true);
                cboUProperties.DataBind(fVModel, "EditValue", "UnitProperties", true);
                cboProvinces.SetCboValue(fVModel.ProvinceId);
                cboCitys.SetCboValue(fVModel.CityId);
                cboCountries.SetCboValue(fVModel.CountryId);
                txtUnitPYNo.DataBind(fVModel,  "UnitPYNo", true);
                txtAddress.DataBind(fVModel,  "Address", true);
                txtUnitTypes.DataBind(fVModel, "UTypeName", true);
                txtUnitRemark.DataBind(fVModel, "Remark", true);
                txtContactPerson.DataBind(fVModel,  "ContactPerson", true);
                txtPhoneNumber.DataBind(fVModel, "PhoneNumber", true);
                txtTelephone.DataBind(fVModel, "Telephone", true);
                txtFax.DataBind(fVModel, "Fax", true);
                txtEmail.DataBind(fVModel, "Email", true);
                txtPostalCode.DataBind(fVModel, "PostalCode", true);
               
            }
           
        }

        private void InitUnitInfo(int unitId)
        {
            if (fVModel == null) fVModel = new UnitModel();
            fVModel.UnitId = unitId;
            fVModel.GetUnitInfo();
            oldName = fVModel.UnitName;
            uType = new UnitTypeInfoModel()
            {
                UTypeId = fVModel.UTypeId,
                UTypeName = fVModel.UTypeName
            };
            oldTypeId = fVModel.UTypeId;
        }

        private void InitProvinces()
        {
            List<RegionInfoModel> provinces = regionBLL.GetProvinces();
            provinces.Insert(0, new RegionInfoModel()
            {
                RegionId = 0,
                RegionName = ""
            });
            provinces.ForEach(p => cboProvinces.Properties.Items.Add(new ComboBoxItem(p.RegionName,p.RegionId) ));
            cboProvinces.SelectedIndex = 0;
        }

        private void InitUnitProperties()
        {
            List<string> list = new List<string>() { "供应商", "客户", "供应商既客户" };
            list.ForEach(s => cboUProperties.Properties.Items.Add(s));
            cboUProperties.SelectedIndex = 0;
        }

        private void InitCountries()
        {
            List<RegionInfoModel> countries = regionBLL.GetCountries(cboCitys.GetCboValue());
            //countries.Insert(0, new RegionInfoModel()
            //{
            //    RegionId = 0,
            //    RegionName = ""
            //});
            cboCountries.Properties.Items.Clear();
            countries.ForEach(c => cboCountries.Properties.Items.Add(new ComboBoxItem(c.RegionName, c.RegionId)));
        }

        private void InitCities()
        {
            List<RegionInfoModel> cities = regionBLL.GetCities(cboProvinces.GetCboValue());
            //cities.Insert(0, new RegionInfoModel()
            //{
            //    RegionId = 0,
            //    RegionName = ""
            //});
            cboCitys.Properties.Items.Clear();
            cities.ForEach(c => cboCitys.Properties.Items.Add(new ComboBoxItem(c.RegionName, c.RegionId)));
        }

        private void InfoTool1_SaveClick(object sender, ItemClickEventArgs e)
        {
            string actMsg = fModel.ActType == 1 ? "添加" : "修改";
            string titleMsg = $"{actMsg}单位信息";
            Action act = () =>
            {
                //信息获取
                fVModel.RegionId = GetRegionId();
                fVModel.GetRegionAddress();
                if (CheckUnitInfo(titleMsg) == false) return;

                //信息的封装
                UnitInfoModel unitInfo = fVModel.UnitInfo;
                if (fModel.ActType == 1)
                {
                    fVModel.Creator = fModel.UName;
                }
                //调用方法
                bool bl = false;
                bl = fModel.ActType == 1 ? unitBLL.AddUnitInfo(unitInfo) : unitBLL.UpdateUnitInfo(unitInfo);
                string sucType = bl ? "成功" : "失败";
                string msg = $"单位信息{actMsg} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(titleMsg, msg);
                    this.ReLoadHandler?.Invoke();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(titleMsg, msg);
                    return;
                }
            };
            act.TryCatch(titleMsg, "单位信息提交出现异常");
        }

        private int GetRegionId()
        {
            int regionId = 0;
            int provinceId = cboCountries.GetCboValue();
            int cityId = cboCitys.GetCboValue();
            int countryId = cboCountries.GetCboValue();
            if (countryId > 0)
                regionId = countryId;
            else if (cityId > 0)
                regionId = cityId;
            else if (provinceId > 0)
                regionId = provinceId;
            return regionId;
        }

        private bool CheckUnitInfo(string title)
        {
            string unitName = fVModel.UnitName;
            int uTypeId = fVModel.UTypeId;
            //判断
            if (string.IsNullOrEmpty(unitName))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入单位名称");
                txtUnitName.Focus();
                return false;
            }
            //判断是否已存在
            if (fModel.ActType == 1 || (!string.IsNullOrEmpty(oldName) && oldName != unitName) || (!string.IsNullOrEmpty(oldName) && oldName == unitName && (uTypeId != oldTypeId)))
            {
                if (unitBLL.ExistUnit(unitName, uTypeId))
                {
                    MsgBoxHelper.MsgErrorShow(title, "该单位已存在！");
                    txtUnitName.Focus();
                    return false;
                }
            }
            if (uTypeId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择单位类别！");
                txtUnitTypes.Focus();
                return false;
            }
            return true;
        }
    }
}