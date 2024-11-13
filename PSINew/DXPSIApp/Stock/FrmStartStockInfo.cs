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
using DXPSIApp.UControls;
using PSINew.BLL;
using DXPSIApp.FModels;
using DevExpress.XtraBars;
using DXPSIApp.BM;
using Common;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.Stock
{
    public partial class FrmStartStockInfo : SheetFormParent
    {
        public FrmStartStockInfo()
        {
            InitializeComponent();
        }
        public List<GoodsModel> chooseGoods = null;
        public StoreModel store = null;

        SysBLL sysBLL = new SysBLL();
        StoreBLL storeBLL = new StoreBLL();
        StockBLL stockBLL = new StockBLL();
        private FInfoData fModel = null;
        string uName = "";
        int stockId = 0;//当前编辑的入库单编号
        int actType = 1;//当前单据页面的类别
        bool isOpened = false;//开账状态
        int addGoods = 0;//添加商品标识
        StockStoreViewModel fVModel = null;
        private void FrmStartStockInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new StockStoreViewModel();
                if (this.Tag != null)
                {
                    Type tagType = this.Tag.GetType();
                    if (tagType == typeof(string))
                        uName = this.Tag.ToString();
                    else if (tagType == typeof(FInfoData))
                    {
                        fModel = this.Tag as FInfoData;
                        uName = fModel.UName;
                        stockId = fModel.FId;
                        actType = fModel.ActType;
                    }
                }
                fVModel.StockId = stockId;
                InitInfo();//初始化
                RegisterEvents();
            };
            act.TryCatch("期初入库单","商品信息页面初始化异常！");
        }

        private void InitInfo()
        {
            fVModel.IsOpened = sysBLL.GetOpenState(1);
            if (stockId == 0)
            {
                //清空处理
                ClearInfo();
            }
            else  //修改状态
            {
                //加载指定的入库单信息
                fVModel.GetStockInfo();
                fVModel.GetStockGoodsList();
                if (fVModel.StockInfo != null)
                {
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
            sheetTool1.IsAddEnabled = !isOpened;
            sheetTool1.IsSaveEnabled = !isOpened;
            sheetTool1.IsCheckEnabled = !isOpened;
            sheetTool1.IsActsEnabled = !isOpened;
            btnAdd.Enabled = !isOpened;
            btnDelete.Enabled = !isOpened;
            pbStores.Visible = !isOpened;
            if (!isOpened)
                SetBtnsEnabled(fVModel.IsChecked);
        }

        private void SetBtnsEnabled(int isChecked)
        {
            if (isChecked == 0)
            {
                if (stockId == 0)
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
            fVModel = new StockStoreViewModel();
            fVModel.IsOpened = sysBLL.GetOpenState(1);
            BindInfo();
        }

        private void BindInfo()
        {
            lblOpenedInfo.DataBind(fVModel, "Visible", "IsShowOpenInfo", true);
            lblCheckState.DataBind(fVModel, "CheckState", true);
            lblStockNo.DataBind(fVModel, "StockNo", true);
            txtStoreName.DataBind(fVModel, "StoreName", true);
            txtDealPerson.DataBind(fVModel, "DealPerson", true);
            txtRemark.DataBind(fVModel, "Remark", true);
            txtCreator.DataBind(fVModel, "Creator", true);
            txtCreateTime.DataBind(fVModel, "CreateTime", true, "yyyy-MM-dd");
            lblTotalCount.DataBind(fVModel, "TotalCount", true);
            lblTotalAmount.DataBind(fVModel, "TotalStAmount", true, "0.00");
            lblTotalInfo.DataBind(fVModel, "TotalPageInfo");
            gcStGoods.DataBind(fVModel, "DataSource", "StockGoodsList", true);
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
            pbStores.Click += PbStores_Click;
            itemGoodsName.ButtonClick += ItemGoodsName_ButtonClick;
        }

        private void ItemGoodsName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (addGoods == 1 && e.Button.Tag.ToString() == "addgoods")
            {
                if (fVModel.StoreId > 0 )
                {
                    //显示商品选择页面
                    FrmChooseGoods fGoods = new FrmChooseGoods();
                    fGoods.Tag = new ChooseTypeData()
                    {
                        FGet = this,
                        UName = uName,
                        TypeCode = "DgvGoods-StartStock"
                    };
                    fGoods.SetChooseGoods += SetDgvGoods;
                    fGoods.ShowDialog();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("商品选择", "请先选择入货仓库！");
                    return;
                }
            }
        }

        private void SetDgvGoods()
        {
            var list = fVModel.StockGoodsList;
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
                list.Add(new StockGoodsModel()
                {
                    Id = id,
                    GoodsId = g.GoodsId,
                    GoodsNo = g.GoodsNo,
                    GoodsName = g.GoodsName,
                    GoodsTXNo = g.GoodsTXNo,
                    GUnit = g.GUnit,
                    StCount = 1,
                    StPrice = 0,
                    StAmount = 0,
                    Remark = ""
                });
            }
            fVModel.StockGoodsList = list;
            fVModel.SumTotalInfo();
            addGoods = 0;//不能添加商品
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var list = fVModel.StockGoodsList;
            int id = 0;
            if (list != null)
            {
                var list2 = list.Where(g => string.IsNullOrEmpty(g.GoodsName) == true);
                foreach (var g in list2)
                {
                    fVModel.StockGoodsList.Remove(g);
                }
                id = list.Count + 1;//已添加了明细后空记录的Id
            }
            else
                id += 1; //未添加明细的空记录Id

            fVModel.StockGoodsList.Add(new StockGoodsModel()
            {
                Id = id,
                GoodsNo = "",
                GoodsTXNo = "",
                GoodsName = "",
                GUnit = "",
                StCount = 0,
                StPrice = 0,
                StAmount = 0,
                Remark = ""
            });
            fVModel.SumTotalInfo();
            addGoods = 1;//添加商品
        }

        private void SheetTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            actType = 1;
            stockId = 0;
            SetBtnsEnabled(0);
            ClearInfo();
        }

        private void SheetTool1_CheckClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (actType == 1)
                {
                    MsgBoxHelper.MsgErrorShow("入库单审核", "入库单还未保存，不能审核！");
                    return;
                }
                if (MsgBoxHelper.MsgBoxConfirm("入库单审核", "你确定要审核该入库单吗？") == DialogResult.Yes)
                {
                    bool bl = stockBLL.CheckStartStock(stockId, uName, store.StoreId);
                    if (bl)
                    {
                        fVModel.IsChecked = 1;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Red;
                        SetBtnsEnabled(1);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("入库单审核", "审核入库单出现异常！");
        }

        private void SheetTool1_NoUseClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("入库单作废", "你确定要作废该入库单吗？") == DialogResult.Yes)
                {
                    bool bl = stockBLL.NoUseStartStock(stockId);
                    if (bl)
                    {
                        fVModel.IsChecked = 2;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Gray;
                        SetBtnsEnabled(2);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("入库单作废", "作废入库单出现异常！");
        }

        private void SheetTool1_RedCheckClick(object sender, ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (MsgBoxHelper.MsgBoxConfirm("入库单红冲", "你确定要红冲该入库单吗？") == DialogResult.Yes)
                {
                    bool bl = stockBLL.RedCheckedStartStock(stockId, store.StoreId);
                    if (bl)
                    {
                        fVModel.IsChecked = 3;
                        lblCheckState.ReLoadData();
                        lblCheckState.ForeColor = Color.Green;
                        SetBtnsEnabled(3);//更新页面按钮的可用
                    }
                }
            };
            act.TryCatch("入库单红冲", "红冲入库单出现异常！");
        }

        private void SheetTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            if (actType == 1)
            {
                if (MsgBoxHelper.MsgBoxConfirm("期初入库单", "该单据并未保存，你确定要关闭期初入库单页面吗？") == DialogResult.Yes)
                {
                    this.CloseForm();
                }
            }
            else
                this.CloseForm();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (gvGoodsList.SelectedRowsCount > 0)
            {
                foreach (int index in gvGoodsList.GetSelectedRows())
                {
                    fVModel.StockGoodsList.RemoveAt(index);
                }
                fVModel.SumTotalInfo();//总计
            }
        }

        private void PbStores_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                UName = uName,
                TypeCode = "Store-StartStock"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
            };
            fChooseStore.ShowDialog();
        }

        private void SheetTool1_SaveClick(object sender, ItemClickEventArgs e)
        {
            string msgTitle = "保存期初入库单";
            Action act = () =>
            {
                //信息接收
                if (!CheckStockInfo(msgTitle)) return;
                //信息封装：单据信息   明细信息
                StockStoreInfoModel stockInfo = fVModel.StockInfo;
                List<StStockGoodsInfoModel> stockList = fVModel.StockGoodsList.Select(g => new StStockGoodsInfoModel()
                {
                    StockId = g.StockId,
                    GoodsId = g.GoodsId,
                    StCount = g.StCount,
                    StPrice = g.StPrice,
                    StAmount = g.StAmount,
                    Remark = g.Remark
                }).ToList();
                //提交
                if (stockId == 0)//新单保存
                {
                    string reStr = stockBLL.AddStartStockInfo(stockInfo, stockList);
                    if (!string.IsNullOrEmpty(reStr))
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "期初入库单新增保存成功！");
                        string[] reStrs = reStr.Split(',');
                        stockId = reStrs[0].GetInt();//生成的期初入库单编号
                        fVModel.StockNo = reStrs[1];//生成的期初入库单号
                        actType = 2;
                        sheetTool1.IsActsEnabled = true;
                        SetBtnsEnabled(0);//更新页面按钮的可用状态
                        this.ReloadListHandler();
                    }
                    else
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle, "期初入库单保存失败！");
                        return;
                    }
                }
                else//修改保存   新增后修改     单据列表页进来 
                {
                    fVModel.StockId = stockId;
                    bool bl = stockBLL.UpdateStartStockInfo(stockInfo, stockList);
                    if (bl)
                    {
                        MsgBoxHelper.MsgBoxShow(msgTitle, "期初入库单修改保存成功！");
                        this.ReloadListHandler();
                    }
                }
            };
            act.TryCatch(msgTitle, "期初入库单提交出现异常！");
        }

        private bool CheckStockInfo(string title)
        {
            if (fVModel.StoreId == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择入货仓库！");
                txtStoreName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(fVModel.DealPerson))
            {
                MsgBoxHelper.MsgErrorShow(title, "请输入经手人！");
                txtDealPerson.Focus();
                return false;
            }

            if (fVModel.StockGoodsList == null || fVModel.StockGoodsList.Count == 0)
            {
                MsgBoxHelper.MsgErrorShow(title, "请选择入库商品！");
                return false;
            }
            else
            {
                List<StockGoodsModel> list2 = fVModel.StockGoodsList.ToList();
                foreach (var vpi in list2)
                {
                    if (string.IsNullOrEmpty(vpi.GoodsName))
                    {
                        DialogResult dr = MsgBoxHelper.MsgBoxConfirm("入库商品", $"商品不能为空，是否删除这行？");
                        if (dr == DialogResult.Yes)
                        {
                            fVModel.StockGoodsList.Remove(vpi);
                            gcStGoods.ReLoadData();
                        }
                        return false;
                    }
                    else if (vpi.StPrice == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的期初入库成本价不能为0！");
                        return false;
                    }
                    else if (vpi.StCount == 0)
                    {
                        MsgBoxHelper.MsgErrorShow(title, $"商品：{vpi.GoodsName}的入库数量不能为0！");
                        return false;
                    }

                }
            }
            return true;
        }

        private void gvGoodsList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index = e.RowHandle;
            GridColumn col = e.Column;
            int stCount = 0;
            decimal stPrice = 0;
            decimal stAmount = 0;
            if (col.Name == "colStCount" || col.Name == "colStPrice")
            {
                stCount = fVModel.StockGoodsList[index].StCount;
                stPrice = fVModel.StockGoodsList[index].StPrice;
                stAmount = stCount * stPrice;
                fVModel.StockGoodsList[index].StAmount = stAmount;
                fVModel.SumTotalInfo();
            }
        }
    }
}