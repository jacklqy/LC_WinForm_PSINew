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
using PSINew.UModels;
using PSINew.Models.DModels;
using PSINew.BLL;
using DXPSIApp.FModels;
using DXPSIApp.BM;
using DevExpress.XtraGrid.Columns;
using Common;
using DXPSIApp.UControls;

namespace DXPSIApp.Perchase
{
    public partial class FrmPerchaseInStore : SheetFormParent
    {
        public FrmPerchaseInStore()
        {
            InitializeComponent();
        }
        public List<GoodsModel> chooseGoods =null;
        public StoreModel store = null;
        public UnitModel unit = null;
        public List<PayVModel> payList = null;
        public string totalThis = "";
        PerchaseInStoreBLL perBLL = new PerchaseInStoreBLL();
        UnitBLL unitBLL = new UnitBLL();
        SysBLL sysBLL = new SysBLL();
        StoreBLL storeBLL = new StoreBLL();
        private FInfoData fModel = null;
        private string uName = "";
        private int actType = 1;//页面状态
        private int perId = 0;//当前编辑状态下采购单编号
        private bool isOpened = false;//开账状态
        private int addGoods = 0;//添加商品明细状态值
        private PerchaseInStoreViewModel fVModel = null;


        private void FrmPerchaseInStore_Load(object sender, EventArgs e)
        {
            
            Action act = () =>
            {
            
                fVModel = new PerchaseInStoreViewModel();
           
                if (this.Tag != null)
                {
                    Type tagType = this.Tag.GetType();
                    if (tagType == typeof(string))
                    {
                        uName = this.Tag.ToString();
                    }
                    else if (tagType == typeof(FInfoData))//列表页进来的
                    {
                        fModel = this.Tag as FInfoData;
                        if (fModel != null)
                        {
                            uName = fModel.UName;
                            actType = fModel.ActType;
                            fVModel.PerId = fModel.FId;
                            fVModel.Creator = uName;
                        }
                    }
                }
                perId = fVModel.PerId;
                InitInfo();//初始化加载 
                RegisterEvents();
            };
            act.TryCatch("采购单","销售单页面初始化异常！");
        }

        private void RegisterEvents()
        {
            sheetTool1.SaveClick += SheetTool1_SaveClick;
            sheetTool1.AddClick += SheetTool1_AddClick;
            sheetTool1.CheckClick += SheetTool1_CheckClick;
            sheetTool1.NoUseClick += SheetTool1_NoUseClick;
            sheetTool1.RedCheckClick += SheetTool1_RedCheckClick;
            sheetTool1.CloseClick += SheetTool1_CloseClick;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            pbSupplier.Click += PbSupplier_Click;
            pbStore.Click += PbStore_Click;
            pbPay.Click += PbPay_Click;
            txtThisAmount.KeyPress += TxtThisAmount_KeyPress ;
        }

        private void InitInfo()
        {
            fVModel.IsOpened = sysBLL.GetOpenState(1);
            if (perId == 0)
            {
                //清空处理
                ClearInfo();
            }
            else  //修改状态
            {
                //加载指定的采购单信息
                fVModel.GetPerchaseInfo();
                fVModel.GetPerGoodsList();
                if (fVModel.PerchaseInfo != null)
                {
                    if (fVModel.UnitId > 0)
                        unit = new UnitModel()
                        {
                            UnitId = fVModel.UnitId,
                            UnitName = fVModel.UnitName
                        };
                    if (fVModel.StoreId > 0)
                        store = new StoreModel()
                        {
                            StoreId = fVModel.StoreId,
                            StoreName = fVModel.StoreName
                        };
                    BindInfo();
                }
            }
          
            SetBtnsEnablebByOpenState();
        }
        /// <summary>
        /// 根据开账状态设置页面按钮可用
        /// </summary>
        private void SetBtnsEnablebByOpenState()
        {
            isOpened = fVModel.IsOpened;
            sheetTool1.IsAddEnabled = isOpened;
            sheetTool1.IsSaveEnabled = isOpened;
            sheetTool1.IsCheckEnabled = isOpened;
            sheetTool1.IsActsEnabled = isOpened;
            btnAdd.Enabled = isOpened;
            btnDelete.Enabled = isOpened;
            pbStore.Visible = isOpened;
            pbSupplier.Visible = isOpened;
            pbPay.Visible = isOpened;
            if (isOpened)
                SetBtnsEnabled(fVModel.IsChecked);
        }
        /// <summary>
        /// 根据审核状态设置页面按钮可用
        /// </summary>
        /// <param name="isChecked"></param>
        private void SetBtnsEnabled(int isChecked)
        {
            if (isChecked == 0)
            {
                if (perId == 0)
                {
                    sheetTool1.IsCheckEnabled = false;
                    sheetTool1.IsActsEnabled = false;
                }
                else
                {
                    sheetTool1.IsCheckEnabled = true;
                    sheetTool1.IsActsEnabled = true;
                    sheetTool1.IsNoUseEnabled = true;
                }
                sheetTool1.IsRedCheckedEnabled = false;
                sheetTool1.IsSaveEnabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (isChecked == 1)
            {
                sheetTool1.IsActsEnabled = true;
                sheetTool1.IsCheckEnabled = false;
                sheetTool1.IsNoUseEnabled = false;
                sheetTool1.IsRedCheckedEnabled = true;
                sheetTool1.IsSaveEnabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else  //作废 红冲
            {
                sheetTool1.IsCheckEnabled = false;
                sheetTool1.IsActsEnabled = false;
                sheetTool1.IsSaveEnabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void ClearInfo()
        {
            fVModel = new PerchaseInStoreViewModel();
            fVModel.IsOpened = sysBLL.GetOpenState(1);
            BindInfo();
        }

        /// <summary>
        /// 绑定页面信息
        /// </summary>
        private void BindInfo()
        {
            lblUnopenedInfo.DataBind(fVModel, "Visible", "IsShowUnOpenInfo", true);
            lblCheckState.DataBind(fVModel, "CheckState", true);
            lblPerchaseNo.DataBind(fVModel, "PerchaseNo", true);
            txtSupplier.DataBind(fVModel, "UnitName", true);
            txtStoreName.DataBind(fVModel, "StoreName", true);
            txtDealPerson.DataBind(fVModel, "DealPerson", true);
            txtPayInfo.DataBind(fVModel, "PayDesp", true);
            txtThisAmount.DataBind(fVModel, "ThisAmount", true, "0.00");
            txtRemark.DataBind(fVModel, "Remark", true);
            txtTotalAmount.DataBind(fVModel, "TotalAmount", true, "0.00");
            txtYFAmount.DataBind(fVModel, "YHAmount", true, "0.00");
            txtCreator.DataBind(fVModel, "Creator", true);
            txtCreateTime.DataBind(fVModel, "CreateTime", true, "yyyy-MM-dd");
            lblTotalCount.DataBind(fVModel, "TotalCount", true);
            lblTotalAmount.DataBind(fVModel, "TotalAmount", true, "0.00");
            lblTotalInfo.DataBind(fVModel, "TotalPageInfo");
            gcPerGoods.DataBind(fVModel, "DataSource", "PerGoodsList", true);
        }


        private void TxtThisAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //当输入非数字键 不让输入  0-9   . enter 
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 13)//enter  
            {
                fVModel.PayDesp= "现金 " + fVModel.ThisAmount;
            }
        }

        private void PbPay_Click(object sender, EventArgs e)
        {
            FrmPayFor fPayFor = new FrmPayFor();
            fPayFor.Tag = new PayModel()
            {
                PayType = "pay",
                FGet = this,
                StrPayFor =fVModel.PayDesp
            };
            fPayFor.SetPayInfo += SetPayTypeInfo;
            fPayFor.ShowDialog();
        }

        private void SetPayTypeInfo()
        {
            string strPay = "";
            if (payList != null && payList.Count > 0)
            {
                foreach (var pi in payList)
                {
                    if (pi.PayMoney > 0)
                    {
                        if (strPay != "")
                            strPay += ";";
                        strPay += pi.PayName + " " + pi.PayMoney.ToString();
                    }
                }
            }
            fVModel.PayDesp = strPay;
            fVModel.ThisAmount = totalThis.GetDecimal();
        }

        private void PbStore_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                UName = uName,
                TypeCode = "Store-PerchaseInStore"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbSupplier_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Supplier-PerInStore",
                UName = uName
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void SheetTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (actType == 1)
            {
                if (MsgBoxHelper.MsgBoxConfirm("采购单", "该单据并未保存，你确定要关闭采购单页面吗？") == DialogResult.Yes)
                {
                    this.CloseForm();
                }
            }
            else
                this.CloseForm();
        }

        private void SheetTool1_RedCheckClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("采购单红冲", "你确定要红冲该采购单吗？") == DialogResult.Yes)
                {
                    bool bl = perBLL.RedCheckPerchaseInfo(perId, store.StoreId);
                    if (bl)
                    {
                        fVModel.IsChecked =3;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Green;
                        SetBtnsEnabled(3);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("采购单红冲", "红冲采购单出现异常！");
        }

        private void SheetTool1_NoUseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("采购单作废", "你确定要作废该采购单吗？") == DialogResult.Yes)
                {
                    bool bl = perBLL.NoUsePerchaseInfo(perId);
                    if (bl)
                    {
                        fVModel.IsChecked = 2;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Gray;
                        SetBtnsEnabled(2);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("采购单作废","作废采购单出现异常！");
        }

        private void SheetTool1_CheckClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (actType == 1)
                {
                    MsgBoxHelper.MsgErrorShow("采购单审核","采购单还未保存，不能审核！");
                    return;
                }
                if (MsgBoxHelper.MsgBoxConfirm("采购单审核", "你确定要审核该采购单吗？") == DialogResult.Yes)
                {
                    bool bl = perBLL.CheckPerchaseInfo(perId, uName, store.StoreId);
                    if (bl)
                    {
                        fVModel.IsChecked = 1;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Red;
                        SetBtnsEnabled(1);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("采购单审核","审核采购单出现异常！");
        }

        private void SheetTool1_AddClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            actType = 1;
            perId = 0;
            SetBtnsEnabled(0);
            ClearInfo();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SheetTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string msgTitle = "保存采购单";
            Action act = () =>
            {
                //信息接收
                if (!CheckPerInfo(msgTitle)) return;
                DateTime? payTime = null;
                 if (fVModel.ThisAmount > 0 && fVModel.ThisAmount <= fVModel.TotalAmount)
                {
                    fVModel.IsPayed = 1;//已付款
                    if (fVModel.ThisAmount == fVModel.TotalAmount)
                        fVModel.IsPayFull = 1;//已付完
                    payTime = DateTime.Now;
                }
                //信息封装：单据信息   明细信息
                PerchaseInStoreInfoModel perInfo = fVModel.PerchaseInfo;
                if (fVModel.IsPayed == 1)
                    perInfo.PayTime = payTime;
                List<PerchaseGoodsInfoModel> perList = fVModel.PerGoodsList.Select(g => new PerchaseGoodsInfoModel()
                {
                    PerId = g.PerId,
                    GoodsId = g.GoodsId,
                    Count = g.PerCount,
                    GUnit = g.GUnit,
                    PerPrice = g.PerPrice,
                    Amount = g.PerAmount,
                    Remark = g.PerRemark
                }).ToList();
                //提交
                if (perId == 0)//新单保存
                {
                    //reStr  perId,PerNo
                    string reStr = perBLL.AddPerchaseInfo(perInfo, perList);
                    if (!string.IsNullOrEmpty(reStr))
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "采购单新增保存成功！");
                        string[] reStrs = reStr.Split(',');
                        perId = reStrs[0].GetInt();//生成的采购单编号
                        fVModel.PerchaseNo = reStrs[1];//生成的采购单号
                        actType = 2;
                        sheetTool1.IsActsEnabled = true;
                        SetBtnsEnabled(0);//更新页面按钮的可用状态
                        this.ReloadListHandler();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle,"采购单保存失败！");
                        return;
                    }
                }
                else//修改保存   新增后修改     单据列表页进来 
                {
                    fVModel.PerId= perId;
                    bool bl = perBLL.UpdatePerchaseInfo(perInfo, perList);
                    if (bl)
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "采购单修改保存成功！");
                        this.ReloadListHandler();
                    }
                }
            };
            act.TryCatch(msgTitle,"采购单提交出现异常！");
        }

        private bool CheckPerInfo(string title)
        {
            if (fVModel.StoreId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择入货仓库！");
                txtStoreName.Focus();
                return false;
            }
            if (fVModel.UnitId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择供应商！");
                txtSupplier.Focus();
                return false;
            }
            if(string.IsNullOrEmpty(fVModel.DealPerson))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入经手人！");
                txtDealPerson.Focus();
                return false;
            }
            if (fVModel.ThisAmount > fVModel.ThisAmount)
            {
                MsgBoxHelper.MsgErrorShow(title, "付款金额不能大于应付金额！");
                txtThisAmount.Focus();
                return false;
            }
           
            if (fVModel.PerGoodsList == null || fVModel.PerGoodsList.Count == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择采购商品！");
                return false;
            }
            else
            {
                List<PerGoodsModel> list2 = fVModel.PerGoodsList.ToList();
                foreach (var vpi in list2)
                {
                    if (string.IsNullOrEmpty(vpi.GoodsName))
                    {
                        DialogResult dr = MsgBoxHelper.MsgBoxConfirm("采购商品", $"商品不能为空，是否删除这行？");
                        if (dr == DialogResult.Yes)
                        {
                            fVModel.PerGoodsList.Remove(vpi);
                            gcPerGoods.ReLoadData();
                        }
                        return false;
                    }
                    else if (vpi.PerPrice == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的采购单价不能为0！");
                        return false;
                    }
                    else if (vpi.PerCount == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的采购数量不能为0！");
                        return false;
                    }

                }
            }
            return true;
        }


        private void SetDgvGoods()
        {
            var list = fVModel.PerGoodsList;
            int id = 0;
            if (list.Count == 1)
            {
                list.RemoveAt(0);
                id = 0;
            }
            else
            {
                list.RemoveAt(list.Count - 1);
                id = list[list.Count - 1].Id;
            }
            foreach (GoodsModel g in chooseGoods)
            {
                id += 1;
                list.Add(new PerGoodsModel()
                {
                    Id = id,
                    GoodsId = g.GoodsId,
                    GoodsNo = g.GoodsNo,
                    GoodsName = g.GoodsName,
                    GoodsTXNo = g.GoodsTXNo,
                    GUnit = g.GUnit,
                    PerCount = 1,
                    PerPrice = 0,
                    PerAmount = 0,
                    PerRemark=""
                });
            }
            fVModel.PerGoodsList = list;
            fVModel.SumTotalInfo();
            addGoods = 0;//不能添加商品
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //将dgv 数据源中选中的数据行的数据移除
            if (gvGoodsList.SelectedRowsCount > 0)
            {
                foreach (int index in gvGoodsList.GetSelectedRows())
                {
                    fVModel.PerGoodsList.RemoveAt(index);
                }
                fVModel.SumTotalInfo();//总计
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var list = fVModel.PerGoodsList;
            int id = 0;
            if (list != null)
            {
                var list2 = list.Where(g => string.IsNullOrEmpty(g.GoodsName) == true);
                foreach (var g in list2)
                {
                    fVModel.PerGoodsList.Remove(g);
                }
                id = list.Count + 1;//已添加了明细后空记录的Id
            }
            else
                id += 1; //未添加明细的空记录Id

            fVModel.PerGoodsList.Add(new PerGoodsModel()
            {
                Id = id,
                GoodsNo = "",
                GoodsTXNo = "",
                GoodsName = "",
                GUnit = "",
                PerCount = 0,
                PerPrice = 0,
                PerAmount = 0,
                PerRemark = ""
            });
            fVModel.SumTotalInfo();
            addGoods = 1;//添加商品
        }

        private void itemGoodsName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (addGoods==1 && e.Button.Tag.ToString()=="addgoods")
            {
                if (fVModel.StoreId > 0 && fVModel.UnitId > 0)
                {
                    //显示商品选择页面
                    FrmChooseGoods fGoods = new FrmChooseGoods();
                    fGoods.Tag = new ChooseTypeData()
                    {
                        FGet = this,
                        UName = uName,
                        TypeCode = "DgvGoods-PerchaseInStore"
                    };
                    fGoods.SetChooseGoods += SetDgvGoods;
                    fGoods.ShowDialog();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("商品选择", "请先选择入货仓库和供应商！");
                    return;
                }
            }
        }

        private void gvGoodsList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index = e.RowHandle;
            GridColumn col = e.Column;
            int perCount = 0;
            decimal perPrice = 0;
            decimal perAmount = 0;
           if(col.Name =="colPerCount"||col.Name=="colPerPrice")
            {
                perCount = fVModel.PerGoodsList[index].PerCount;
                perPrice = fVModel.PerGoodsList[index].PerPrice;
                perAmount = perCount * perPrice;
                fVModel.PerGoodsList[index].PerAmount = perAmount;
                fVModel.SumTotalInfo();
            }
        }
    }
}