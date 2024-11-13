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
using DevExpress.XtraBars;
using DXPSIApp.BM;
using Common;
using DXPSIApp.UControls;
using DevExpress.XtraGrid.Columns;
using PSINew.Models.VModels;

namespace DXPSIApp.Sale
{
    public partial class FrmSaleOutStore :SheetFormParent
    {
        public FrmSaleOutStore()
        {
            InitializeComponent();
        }
        public List<GoodsModel> chooseGoods = null;
        public StoreModel store = null;
        public UnitModel unit = null;
        public List<PayVModel> payList = null;
        public string totalThis = "";
        SaleOutStoreBLL saleBLL = new SaleOutStoreBLL();
        UnitBLL unitBLL = new UnitBLL();
        SysBLL sysBLL = new SysBLL();
        StoreBLL storeBLL = new StoreBLL();
        private FInfoData fModel = null;
        private string uName = "";
        private int actType = 1;//页面状态
        private int saleId = 0;//当前编辑状态下销售单编号
        private bool isOpened = false;//开账状态
        private int addGoods = 0;//添加商品明细状态值
        private SaleOutStoreViewModel fVModel = null;
        private void FrmSaleOutStore_Load(object sender, EventArgs e)
        {

            Action act = () =>
            {
                fVModel = new SaleOutStoreViewModel();
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
                            fVModel.SaleId = fModel.FId;
                            fVModel.Creator = uName;
                        }
                    }
                }
                saleId = fVModel.SaleId;
                InitInfo();//初始化加载 
                RegisterEvents();
            };
            act.TryCatch("采购单", "销售单页面初始化异常！");
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
            pbCustomers.Click += PbCustomers_Click;
            pbStore.Click += PbStore_Click;
            pbPay.Click += PbPay_Click;
            txtThisAmount.KeyPress += TxtThisAmount_KeyPress;
            itemGoodsName.ButtonClick += ItemGoodsName_ButtonClick;
            gvGoods.CellValueChanged += GvGoods_CellValueChanged;
        }

      

        private void InitInfo()
        {
            fVModel.IsOpened = sysBLL.GetOpenState(1);
            if (saleId == 0)
            {
                //清空处理
                ClearInfo();
            }
            else  //修改状态
            {
                //加载指定的采购单信息
                fVModel.GetsaleInfo();
                fVModel.GetSaleGoodsList();
                if (fVModel.SaleInfo != null)
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
            pbCustomers.Visible = isOpened;
            pbPay.Visible = isOpened;
            if (isOpened)
                SetBtnsEnabled(fVModel.IsChecked);
        }

        private void SetBtnsEnabled(int isChecked)
        {
            if (isChecked == 0)
            {
                if (saleId == 0)
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

        private void BindInfo()
        {
            lblUnopenedInfo.DataBind(fVModel, "Visible", "IsShowUnOpenInfo", true);
            lblCheckState.DataBind(fVModel, "CheckState", true);
            lblSaleNo.DataBind(fVModel, "SaleOutNo", true);
            txtCustomer.DataBind(fVModel, "UnitName", true);
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
            gcSaleGoods.DataBind(fVModel, "DataSource", "SaleGoodsList", true);
        }

        private void ClearInfo()
        {
            fVModel = new SaleOutStoreViewModel();
            fVModel.IsOpened= sysBLL.GetOpenState(1);
            BindInfo();
        }

        private void TxtThisAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //当输入非数字键 不让输入  0-9   . enter 
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 13)//enter  
            {
                fVModel.PayDesp = "现金 " + fVModel.ThisAmount;
            }
        }

        private void PbPay_Click(object sender, EventArgs e)
        {
            FrmPayFor fPayFor = new FrmPayFor();
            fPayFor.Tag = new PayModel()
            {
                PayType = "get",
                FGet = this,
                StrPayFor = fVModel.PayDesp
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
                TypeCode = "Store-SaleOutStore"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void PbCustomers_Click(object sender, EventArgs e)
        {
            FrmChooseUnits fChooseUnits = new FrmChooseUnits();
            fChooseUnits.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Customer-SaleOutStore",
                UName = uName
            };
            fChooseUnits.SetUnit += () =>
            {
                fVModel.UnitName = unit.UnitName;
                fVModel.UnitId = unit.UnitId;
            };
            fChooseUnits.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //将dgv 数据源中选中的数据行的数据移除
            if (gvGoods.SelectedRowsCount > 0)
            {
                foreach (int index in gvGoods.GetSelectedRows())
                {
                    fVModel.SaleGoodsList.RemoveAt(index);
                }
                fVModel.SumTotalInfo();//总计
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var list = fVModel.SaleGoodsList;
            int id = 0;
            if (list != null)
            {
                var list2 = list.Where(g => string.IsNullOrEmpty(g.GoodsName) == true);
                foreach (var g in list2)
                {
                    fVModel.SaleGoodsList.Remove(g);
                }
                id = list.Count + 1;//已添加了明细后空记录的Id
            }
            else
                id += 1; //未添加明细的空记录Id

            fVModel.SaleGoodsList.Add(new SaleGoodsModel()
            {
                Id = id,
                GoodsNo = "",
                GoodsTXNo = "",
                GoodsName = "",
                GUnit = "",
                SaleCount = 0,
                SalePrice = 0,
                SaleAmount = 0,
                SaleRemark = ""
            });
            fVModel.SumTotalInfo();
            addGoods = 1;//添加商品
        }

        private void SheetTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            if (actType == 1)
            {
                if (MsgBoxHelper.MsgBoxConfirm("销售单", "该单据并未保存，你确定要关闭销售单页面吗？") == DialogResult.Yes)
                {
                    this.CloseForm();
                }
            }
            else
                this.CloseForm();
        }

        private void SheetTool1_RedCheckClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("销售单红冲", "你确定要红冲该销售单吗？") == DialogResult.Yes)
                {
                    bool bl = saleBLL.RedCheckSaleInfo(saleId, store.StoreId);
                    if (bl)
                    {
                        fVModel.IsChecked = 3;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Green;
                        SetBtnsEnabled(3);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("销售单红冲", "红冲销售单出现异常！");
        }

        private void SheetTool1_NoUseClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("销售单作废", "你确定要作废该销售单吗？") == DialogResult.Yes)
                {
                    bool bl = saleBLL.NoUseSaleInfo(saleId);
                    if (bl)
                    {
                        fVModel.IsChecked = 2;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Gray;
                        SetBtnsEnabled(2);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("销售单作废", "作废销售单出现异常！");
        }

        private void SheetTool1_CheckClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("销售单审核", "你确定要审核该销售单吗？") == DialogResult.Yes)
                {
                    //检查库存
                    string reStockStr = CheckGoodsStock();
                    string[] arrStock = reStockStr.Split(';');
                    string[] noArrStock = arrStock.Where(str => str.Contains("2")).ToArray();
                    string[] notArrStock = arrStock.Where(str => str.Contains("3")).ToArray();
                    if (noArrStock.Length == 0 && notArrStock.Length == 0)//都有足够库存
                    {
                        bool bl = saleBLL.CheckSaleInfo(saleId, uName, store.StoreId);
                        if (bl)
                        {
                            fVModel.IsChecked = 1;
                            lblCheckState.ReLoadData();
                            lblCheckState.ForeColor = Color.Red;
                            SetBtnsEnabled(1);//更新页面按钮的可用
                        }
                    }
                    else if (noArrStock.Length > 0)
                    {
                        string msg = string.Join(",", noArrStock.Select(str => str.Split('-')[0]));
                        MsgBoxHelper.MsgErrorShow("销售单审核", $"当前销售单中商品{msg} 当前没有库存,不能进行审核操作!");
                        return;
                    }
                    else if (notArrStock.Length > 0)
                    {
                        string msg = string.Join(",", notArrStock.Select(str => str.Split('-')[0]));
                        MsgBoxHelper.MsgErrorShow("销售单审核",$"当前销售单中商品{msg} 当前库存不足,不能进行审核操作!");
                        return;
                    }

                   
                }
            };
            act.TryCatch("销售单审核", "审核销售单出现异常！");
        }

        private void SheetTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            actType = 1;
            saleId = 0;
            SetBtnsEnabled(0);
            ClearInfo();
        }

        private void SheetTool1_SaveClick(object sender, ItemClickEventArgs e)
        {
            string msgTitle = "保存销售单";
            Action act = () =>
            {
                //信息接收
                if (!CheckSaleInfo(msgTitle)) return;
                DateTime? payTime = null;
                if (fVModel.ThisAmount > 0 && fVModel.ThisAmount <= fVModel.TotalAmount)
                {
                    fVModel.IsPayed = 1;//已收款
                    if (fVModel.ThisAmount == fVModel.TotalAmount)
                        fVModel.IsPayFull = 1;//已收完
                    payTime = DateTime.Now;
                }
                //信息封装：单据信息   明细信息
                SaleOutStoreInfoModel saleInfo = fVModel.SaleInfo;
                if (fVModel.IsPayed == 1)
                    saleInfo.PayTime = payTime;
                List<SaleGoodsInfoModel> saleList = fVModel.SaleGoodsList.Select(g => new SaleGoodsInfoModel()
                {
                    SaleId = g.SaleId,
                    GoodsId = g.GoodsId,
                    Count = g.SaleCount,
                    GUnit = g.GUnit,
                    SalePrice = g.SalePrice,
                    Amount = g.SaleAmount,
                    Remark = g.SaleRemark
                }).ToList();
                //提交
                if (saleId == 0)//新单保存
                {
                    //reStr  saleId,SaleNo
                    string reStr = saleBLL.AddSaleInfo(saleInfo, saleList);
                    if (!string.IsNullOrEmpty(reStr))
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "销售单新增保存成功！");
                        string[] reStrs = reStr.Split(',');
                        saleId = reStrs[0].GetInt();//生成的销售单编号
                        fVModel.SaleOutNo = reStrs[1];//生成的销售单号
                        actType = 2;
                        sheetTool1.IsActsEnabled = true;
                        SetBtnsEnabled(0);//更新页面按钮的可用状态
                        this.ReloadListHandler();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle, "销售单保存失败！");
                        return;
                    }
                }
                else//修改保存   新增后修改     单据列表页进来 
                {
                    fVModel.SaleId = saleId;
                    bool bl = saleBLL.UpdateSaleInfo(saleInfo, saleList);
                    if (bl)
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "销售单修改保存成功！");
                        this.ReloadListHandler();
                    }
                }
            };
            act.TryCatch(msgTitle, "销售单提交出现异常！");
        }

        private bool CheckSaleInfo(string title)
        {
            if (fVModel.StoreId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择出货仓库！");
                txtStoreName.Focus();
                return false;
            }
            if (fVModel.UnitId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择客户！");
                txtCustomer.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(fVModel.DealPerson))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入经手人！");
                txtDealPerson.Focus();
                return false;
            }
            if (fVModel.ThisAmount > fVModel.ThisAmount)
            {
                MsgBoxHelper.MsgErrorShow(title, "收款金额不能大于应收金额！");
                txtThisAmount.Focus();
                return false;
            }

            if (fVModel.SaleGoodsList == null || fVModel.SaleGoodsList.Count == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择销售商品！");
                return false;
            }
            else
            {
                List<SaleGoodsModel> list2 = fVModel.SaleGoodsList.ToList();
                foreach (var vpi in list2)
                {
                    if (string.IsNullOrEmpty(vpi.GoodsName))
                    {
                        DialogResult dr = MsgBoxHelper.MsgBoxConfirm("销售商品", $"商品不能为空，是否删除这行？");
                        if (dr == DialogResult.Yes)
                        {
                            fVModel.SaleGoodsList.Remove(vpi);
                            gcSaleGoods.ReLoadData();
                        }
                        return false;
                    }
                    else if (vpi.SalePrice == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的销售单价不能为0！");
                        return false;
                    }
                    else if (vpi.SaleCount == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的销售数量不能为0！");
                        return false;
                    }

                }
            }
            return true;
        }

        private void ItemGoodsName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (addGoods == 1 && e.Button.Tag.ToString() == "addgoods")
            {
                if (fVModel.StoreId > 0 && fVModel.UnitId > 0)
                {
                    //显示商品选择页面
                    FrmChooseGoods fGoods = new FrmChooseGoods();
                    fGoods.Tag = new ChooseTypeData()
                    {
                        FGet = this,
                        UName = uName,
                        TypeCode = "DgvGoods-SaleOutStore"
                    };
                    fGoods.SetChooseGoods += SetDgvGoods;
                    fGoods.ShowDialog();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("商品选择", "请先选择出货仓库和客户！");
                    return;
                }
            }
        }

        private void SetDgvGoods()
        {
            var list = fVModel.SaleGoodsList ;
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
                list.Add(new SaleGoodsModel()
                {
                    Id = id,
                    GoodsId = g.GoodsId,
                    GoodsNo = g.GoodsNo,
                    GoodsName = g.GoodsName,
                    GoodsTXNo = g.GoodsTXNo,
                    GUnit = g.GUnit,
                    SaleCount = 1,
                    SalePrice = 0,
                    SaleAmount = 0,
                    SaleRemark = ""
                });
            }
            fVModel.SaleGoodsList = list;
            fVModel.SumTotalInfo();
            addGoods = 0;//不能添加商品
        }

        private void GvGoods_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index = e.RowHandle;
            GridColumn col = e.Column;
            int saleCount = 0;
            decimal salePrice = 0;
            decimal saleAmount = 0;
            if (col.Name == "colSaleCount" || col.Name == "colSalePrice")
            {
                saleCount = fVModel.SaleGoodsList[index].SaleCount;
                salePrice = fVModel.SaleGoodsList[index].SalePrice;
                saleAmount = saleCount * salePrice;
                fVModel.SaleGoodsList[index].SaleAmount = saleAmount;
                fVModel.SumTotalInfo();
            }
        }

        /// <summary>
        /// 检查销售商品的库存
        /// </summary>
        /// <returns></returns>
        private string CheckGoodsStock()
        {
            string re = "";
            StockBLL stockBLL = new StockBLL();
            List<int> goodsIds = fVModel.SaleGoodsList.Select(sg => sg.GoodsId).ToList();
            int storeId = 0;
            if (store != null)
                storeId = store.StoreId;
            List<GoodsStoreStockModel> listStock = stockBLL.GetGoodsStoreStockCount(goodsIds, storeId);
            if (listStock.Count > 0)
            {
                foreach (var gs in listStock)
                {
                    SaleGoodsModel saleGoods = fVModel.SaleGoodsList.Where(sg => sg.GoodsId == gs.GoodsId).First();
                    if (re != "")
                        re += ";";
                    if (gs.CurCount == 0)
                    {
                        re += saleGoods.GoodsName + "-2";//表示没有库存
                    }
                    else if (gs.CurCount < saleGoods.SaleCount)
                    {
                        re += saleGoods.GoodsName + "-3";//库存不足
                    }
                    else
                    {
                        re += saleGoods.GoodsName + "-1";//库存足够
                    }
                }
            }
            return re;
        }


    }
}