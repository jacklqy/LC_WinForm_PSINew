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
using DXPSIApp.FModels;
using PSINew.BLL;
using PSINew.Models.DModels;
using PSINew.UModels;
using Common;
using System.IO;

namespace DXPSIApp.BM
{
    public partial class FrmGoodsInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmGoodsInfo()
        {
            InitializeComponent();
        }
        public event Action ReLoad;
        GoodsUnitBLL guBLL = new GoodsUnitBLL();
        GoodsBLL goodsBLL = new GoodsBLL();
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        private FInfoData fModel = null;
        private string oldName = "";//当前编辑前的商品名称
        public GoodsTypeInfoModel gTypeInfo = null;
        private string oldPic = "";//修改前的图片路径
        private GoodsModel fVModel = null;
        private string msgTitle = "商品信息";
        private void FrmGoodsInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoData;
                }
                if (fModel == null)
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"商品信息初始化失败！");
                    return;
                }
                InitCboGUnits();//加载单位下拉框（计量单位）
                InitCboGoodsProperties();//加载商品性质下拉框
                InitPageInfo();//初始化页面信息
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "商品信息页面加载失败！");
        }

        private void InitPageInfo()
        {
            string lblTitleType = "";
            switch (fModel.ActType)
            {
                case 1:
                    fVModel = new GoodsModel();
                    lblTitleType = "新增";
                    break;
                case 2:
                    InitGoodsInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    lblTitleType = "修改";
                    break;
                case 4:
                    InitGoodsInfo(fModel.FId);
                    infoTool1.IsClearEnable = false;
                    infoTool1.IsSaveEnable = false;
                    lblTitleType = "详情";
                    break;
                default: break;
            }
            this.Text += "----" + lblTitleType;
            BindInfo();//绑定页面信息
        }

       
        private void InitGoodsInfo(int goodsId)
        {
            if (fVModel == null) fVModel = new GoodsModel();
            fVModel.GoodsId = goodsId;
            fVModel.GetGoodsInfo();
            oldName = fVModel.GoodsName;
            if (!string.IsNullOrEmpty(fVModel.GoodsPic))
            {
                string picPath = Application.StartupPath + "/" + fVModel.GoodsPic;
                fVModel.GoodsPic = picPath;
                oldPic = picPath;
            }
        }

        private void InitCboGoodsProperties()
        {
            List<string> list = new List<string>() { "商品", "商品(服务)", "商品(无成本)" };
            list.ForEach(s => cboGProperties.Properties.Items.Add(s));
            cboGProperties.SelectedIndex = 0;
        }

        private void InitCboGUnits()
        {
            List<GoodsUnitInfoModel> list = guBLL.GetAllUnits(false);
            cboGUnits.Properties.Items.Clear();//清空
            list.ForEach(u => cboGUnits.Properties.Items.Add(u.GUnitName));
            cboGUnits.SelectedIndex = 0;
        }

        private void BindInfo()
        {
            if (fVModel != null)
            {
                txtGoodsName.DataBind(fVModel,  "GoodsName",true);
                txtGoodsNo.DataBind(fVModel, "GoodsNo", true);
                txtGoodsSName.DataBind(fVModel, "GoodsSName", true);
                txtGoodsTXNo.DataBind(fVModel, "GoodsTXNo", true);
                txtGoodsPYNo.DataBind(fVModel, "GoodsPYNo", true);
                cboGUnits.DataBind(fVModel, "EditValue", "GUnit", true);
                cboGProperties.DataBind(fVModel,"EditValue",  "GProperties", true);
                txtGoodsType.DataBind(fVModel, "GTypeName", true);
                gTypeInfo = new GoodsTypeInfoModel()
                {
                    GTypeId = fVModel.GTypeId,
                    GTypeName = fVModel.GTypeName
                };
                spinRetailPrice.DataBind (fVModel,"Value", "RetailPrice", true);
                spinLowPrice.DataBind(fVModel,"Value",  "LowPrice", true);
                spinPrePrice.DataBind(fVModel, "Value", "PrePrice", true);
                spinBidPrice.DataBind(fVModel,"Value",  "BidPrice", true);
                spinDiscount.DataBind(fVModel,"Value",  "Discount", true);
                if (!string.IsNullOrEmpty(fVModel.GoodsPic))
                {
                    fVModel.GoodsImg = Image.FromFile( fVModel.GoodsPic);
                    pbGoodsPic.DataBind(fVModel,"Image",  "GoodsImg", true);
                }
                chkIsStopped.DataBind(fVModel, "Checked", "IsStopped", true);
                txtGoodsRemark.DataBind( fVModel, "Remark", true);
            }
          
        }


        private void RegisterEvents()
        {
            infoTool1.SaveClick += InfoTool1_SaveClick;
            infoTool1.ClearClick += InfoTool1_ClearClick;
            infoTool1.CloseClick += InfoTool1_CloseClick;
            pbGTypes.Click += PbGTypes_Click;
            pbUnit.Click += PbUnit_Click;
            btnChoose.Click += BtnChoose_Click;
            txtGoodsName.TextChanged += TxtGoodsName_TextChanged;
        }

        private void TxtGoodsName_TextChanged(object sender, EventArgs e)
        {
            fVModel.GoodsPYNo = PingYinHelper.GetFirstSpell(txtGoodsName.Text.Trim());
        }

        private void InfoTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void InfoTool1_ClearClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel = new GoodsModel();
            BindInfo();
        }

        private void InfoTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string actMsg = fModel.ActType == 1 ? "添加" : "修改";
            string title = $"{actMsg}商品信息";
            Action act = () =>
            {
                string goodsPic = null;
                if (fVModel.GoodsImg!=null)
                {
                    goodsPic = GetImgPath();
                }
                fVModel.GoodsPic = goodsPic;
                string goodsName = fVModel.GoodsName;
                int gTypeId = gTypeInfo == null ? 0 : gTypeInfo.GTypeId;
                bool blCheck = CheckGoodsInfo(goodsName, title, gTypeId);
                if (!blCheck) return;
                //封装商品信息
                GoodsInfoModel goodsInfo = fVModel.GoodsInfo;
                goodsInfo.GoodsPic = goodsPic;
                if(fModel.ActType==1)
                    goodsInfo.Creator = fModel.UName;
                //执行
                bool bl = false;
                bl = fModel.ActType == 1 ? goodsBLL.AddGoodsInfo(goodsInfo) : goodsBLL.UpdateGoodsInfo(goodsInfo);
             
                string sucType = bl ? "成功" : "失败";
                string msg = $"商品信息{actMsg} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(title, msg);
                    this.ReLoad?.Invoke();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(title, msg);
                    return;
                }
            };
            act.TryCatch(title,"商品信息提交异常！");
        }

        private bool CheckGoodsInfo(string goodsName,string title,int gTypeId)
        {
            //判断
            if (string.IsNullOrEmpty(goodsName))
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请输入商品名称");
                txtGoodsName.Focus();
                return false;
            }
            else if (fModel.ActType == 1 || (!string.IsNullOrEmpty(oldName) && oldName != goodsName))
            {
                if (goodsBLL.ExistGoodsName(goodsName))
                {
                    MsgBoxHelper.MsgErrorShow(title, "商品名称已存在！");
                    txtGoodsName.Focus();
                    return false;
                }
            }
            if (gTypeId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择商品类别！");
                return false;
            }
            return true;
        }

        private string GetImgPath()
        {
            string dict = "imgs/products";
            if (fVModel.GoodsImg!=null)
            {
                if (string.IsNullOrEmpty(oldPic) || fModel.ActType == 1 || (!string.IsNullOrEmpty(oldPic) && oldPic != fVModel.GoodsPic))
                {
                    //将图片保存到项目文件夹：Imgs/products/
                    if (!Directory.Exists(dict))
                        Directory.CreateDirectory(dict);
                    //扩展名
                    string ext = Path.GetExtension(fVModel.GoodsPic);
                    //生成文件名
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                    string savePath = dict + "/" + fileName;
                    //保存到数据里的路径
                    if (!File.Exists(savePath))
                        File.Copy(fVModel.GoodsPic, Application.StartupPath + "/" + savePath);
                    if (!string.IsNullOrEmpty(oldPic) && oldPic != fVModel.GoodsPic)
                    {
                        File.Delete(Application.StartupPath + "/" + oldPic);
                    }
                    return dict + "/" + fileName;

                }
                else if (!string.IsNullOrEmpty(oldPic) && oldPic == fVModel.GoodsPic)
                {
                    return dict + "/" + Path.GetFileName(oldPic);
                }

            }
            return null;
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdialog = new OpenFileDialog();
            // ofdialog.Filter = "(*.jpg,*.png,*.bmp.*.jpeg)|*.jpg;*.png;*.bmp;*.jpeg";
            //可以选择的图片类型
            ofdialog.Filter = "jpg 图片(*.jpg)|*.jpg|png图片(*.png)|*.png|bmp图片(*.bmp)|*.bmp|jpeg图片(*.jpeg)|*.jpeg";
            if (ofdialog.ShowDialog() == DialogResult.OK)
            {
                string path = ofdialog.FileName;
                fVModel.GoodsPic = path;
                fVModel.GoodsImg = Image.FromFile(path);
                if (pbGoodsPic.DataBindings.Count ==0)
                {
                    pbGoodsPic.DataBindings.Add("Image", fVModel, "GoodsImg");
                }
               
            }
        }

        private void PbUnit_Click(object sender, EventArgs e)
        {
            //刷新下拉框
            FrmGUnitList fGUnitList = new FrmGUnitList();
            //uName  刷新的委托--old     不需要
            fGUnitList.Tag = fModel.UName;
            fGUnitList.GUnitsReLoad += InitCboGUnits;
            fGUnitList.ShowDialogNew();
        }

        private void PbGTypes_Click(object sender, EventArgs e)
        {
            FrmChooseTypes frmType = new FrmChooseTypes();
            frmType.Tag = new ChooseTypeData()
            {
                TypeCode = "Goods",
                FGet = this
            };
            frmType.SetType += () =>
            {
                fVModel.GTypeId = gTypeInfo.GTypeId;
                fVModel.GTypeName = gTypeInfo.GTypeName;
            };
            frmType.ShowDialogNew();
        }
    }
}