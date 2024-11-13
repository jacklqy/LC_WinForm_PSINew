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
using PSINew.UModels;
using PSINew.Models.DModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.BM
{
    public partial class FrmGoodsList : DevExpress.XtraEditors.XtraForm
    {
        public FrmGoodsList()
        {
            InitializeComponent();
        }
        private string uName = "";//账号
        GoodsBLL goodsBLL = new GoodsBLL();
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        private GoodsListViewModel fVModel = null;
        int isLoad = 0;//是否已初始化Dgv
        private void FrmGoodsList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    uName = this.Tag.ToString();
                }
                fVModel = new GoodsListViewModel();
                RegisterEvents();
                LoadTVGoodsTypes();
                fVModel.GTypeId = 0;
                fVModel.GTypeName = "商品类别";
                LoadGoodsList();//加载所有商品信息
                SetDgvCols();
            };
            act.TryCatch("商品管理","商品信息加载异常！");
        }

     

        private void RegisterEvents()
        {
            listTool1.CloseClick += ListTool1_CloseClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.InfoClick += ListTool1_InfoClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.TypeClick += ListTool1_TypeClick;
            chkIsStopped.CheckedChanged += ChkIsStopped_CheckedChanged;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            tlGoodsTypes.FocusedNodeChanged += TlGoodsTypes_FocusedNodeChanged;
            ucPager1.BindSource += UcPager1_BindSource;
            gvGoodsList.RowCellClick += GvGoodsList_RowCellClick;
            btnFind.Click += BtnFind_Click;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindGoodsList();
        }

        private void ListTool1_TypeClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmGoodsTypeList fGoodsType = new FrmGoodsTypeList();
            fGoodsType.Tag = uName;
            fGoodsType.ReloadTVGoodsTypes += LoadTVGoodsTypes;
            fGoodsType.ShowDialog();
        }

        private void ListTool1_AddClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowGoodsInfoPage(1, 0);
        }

        private void ListTool1_EditClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowInfoOrEdit(2);
        }

        private void ListTool1_DeleteClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvGoodsList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow("删除商品", "请选择要删除的商品信息！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm("删除商品", "您确定要删除选择的商品信息吗？") == DialogResult.Yes)
            {
                List<int> goodsIds = new List<int>();
                string IsUseGoodsNames = "";
                foreach (int index in gvGoodsList.GetSelectedRows())
                {
                    GoodsModel gInfo = fVModel.GoodsList[index];
                    //如果该类别添加了商品，不允许删除
                    bool isGoodsUse = goodsBLL.CheckIsGoodsUse(gInfo.GoodsId);
                    if (!isGoodsUse)
                    {
                        goodsIds.Add(gInfo.GoodsId);
                    }
                    else
                    {
                        if (IsUseGoodsNames.Length > 0) IsUseGoodsNames += ",";
                        IsUseGoodsNames += gInfo.GoodsName;
                    }
                }
                if (goodsIds.Count > 0)
                {
                    bool bl = goodsBLL.DeleteGoodsInfos(goodsIds);//执行批量删除
                    string sucMsg = bl ? "成功" : "失败";
                    string msg = $"选择的商品信息中符合删除要求的信息 删除 {sucMsg}!";

                    if (bl)
                    {
                        if (!string.IsNullOrEmpty(IsUseGoodsNames))
                            msg += $" {IsUseGoodsNames} 已经使用，不能删除！";
                        MsgBoxHelper.MsgBoxShow("删除商品", msg);
                        FindGoodsList();
                    }
                    else
                        MsgBoxHelper.MsgErrorShow("删除商品",msg);
                }
                else
                    MsgBoxHelper.MsgErrorShow("删除商品","没有符合删除要求的商品信息！");
            }
        }

        private void ListTool1_InfoClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowInfoOrEdit(4);
        }

        private void ListTool1_RefreshClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            fVModel.IsStopped = false;
            fVModel.GTypeId = 0;
            fVModel.GTypeName = "商品类别";
            FindGoodsList();
        }

        private void ListTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void LoadGoodsList()
        {
            ClearDataBindings();
            if(fVModel!=null)
            {
                txtKeywords.DataBindings.Add("Text", fVModel, "KeyWords", false, DataSourceUpdateMode.OnPropertyChanged);
                chkIsStopped.DataBindings.Add("Checked", fVModel, "IsStopped", false, DataSourceUpdateMode.OnPropertyChanged);
                chkShowDel.DataBindings.Add("Checked", fVModel, "IsShowDel", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("StartRecord", fVModel, "StartIndex", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("PageSize", fVModel, "PageSize", false, DataSourceUpdateMode.OnPropertyChanged);
                ucPager1.DataBindings.Add("Record", fVModel, "TotalCount", false, DataSourceUpdateMode.OnPropertyChanged);
                tlGoodsTypes.SetFocusedValue(fVModel.GTypeName);
                gcGoodsList.DataBindings.Add("DataSource", fVModel, "GoodsList");
                isLoad = 1;
            }
        }

        private void ClearDataBindings()
        {
            txtKeywords.DataBindings.Clear();
            chkIsStopped.DataBindings.Clear();
            chkShowDel.DataBindings.Clear();
            tlGoodsTypes.DataBindings.Clear();
            gcGoodsList.DataBindings.Clear();
            ucPager1.DataBindings.Clear();
        }

        private void LoadTVGoodsTypes()
        {
            tlGoodsTypes.Nodes.Clear();
            tlGoodsTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlGoodsTypes.DataSource = fVModel.GTypeList;
            tlGoodsTypes.KeyFieldName = "GTypeId";
            tlGoodsTypes.ParentFieldName = "ParentId";
            tlGoodsTypes.SelectNode(tlGoodsTypes.Nodes[0]);
            tlGoodsTypes.ExpandAll();
        }
    

        private void SetDgvCols()
        {
            gvGoodsList.ShowOrHideNormalCols(fVModel.IsShowDel);
        }

        private void UcPager1_BindSource(object sender, EventArgs e)
        {
            fVModel.StartIndex = ucPager1.StartRecord;
            fVModel.PageSize = ucPager1.PageSize;
            FindGoodsList();
        }

        private void TlGoodsTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            FindGoodsList();
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindGoodsList();
        }

        private void ChkIsStopped_CheckedChanged(object sender, EventArgs e)
        {
            FindGoodsList();
        }

        private void GvGoodsList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            GoodsModel gInfo = fVModel.GoodsList[index];
            switch (col.Name)
            {
                case "colEdit":
                    ShowGoodsInfoPage(2, gInfo.GoodsId);
                    break;
                case "colDelete":
                    DeleteGoods(gInfo, 1);
                    break;
                case "colRecover":
                    DeleteGoods(gInfo, 0);
                    break;
                case "colRemove":
                    DeleteGoods(gInfo, 2);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        private void FindGoodsList()
        {
            GoodsTypeInfoModel selType = tlGoodsTypes.GetDataRecordByNode(tlGoodsTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
                //fVModel.GTypeName = selType.GTypeName;
            }
            fVModel.GetGoodsList();
            SetDgvCols();
            if (isLoad == 1)
            {
                gcGoodsList.ReLoadData();
                
            }
               
        }

        /// <summary>
        /// 显示商品信息页面（新增、修改、详情）
        /// </summary>
        /// <param name="actType">1  add  2 edit  4 info</param>
        /// <param name="goodsId"></param>
        private void ShowGoodsInfoPage(int actType, int goodsId)
        {
            //另一种刷新：利用事件   为信息页面定义一个事件
            FrmGoodsInfo fGoodsInfo = new FrmGoodsInfo();
            fGoodsInfo.Tag = new FInfoData()
            {
                ActType = actType,
                FId = goodsId,
                UName = uName
            };
            if (actType <4)
                fGoodsInfo.ReLoad += FindGoodsList;//订阅  
            fGoodsInfo.ShowDialogNew();
        }

        /// <summary>
        /// 打开详情或修改页
        /// </summary>
        /// <param name="actType"></param>
        private void ShowInfoOrEdit(int actType)
        {
            if (gvGoodsList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvGoodsList.GetFocusedDataSourceRowIndex();
                GoodsModel goods = fVModel.GoodsList[index] as GoodsModel;
                ShowGoodsInfoPage(actType, goods.GoodsId);
            }
            else
            {
                string title = "查看商品", errMsg = "请选择你要查看的商品信息";
                if (actType == 2)
                {
                    title = "修改商品";
                    errMsg = "请选择你要修改的商品信息";
                }
                MsgBoxHelper.MsgErrorShow(title, errMsg);
                return;
            }
        }

        private void DeleteGoods(GoodsModel goods,int delType)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(delType);
            string msgTitle = $"商品信息{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该商品信息？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (delType)
                {
                    case 1://删除
                           //如果商品在使用中，不允许删除
                        bool IsGoodsUse = goodsBLL.CheckIsGoodsUse(goods.GoodsId);
                        if (!IsGoodsUse)
                        {
                            bl = goodsBLL.DeleteGoodsInfo(goods.GoodsId);
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(msgTitle,$"该商品:{goods.GoodsName}在使用中，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = goodsBLL.RecoverGoodsInfo(goods.GoodsId, uName);
                        break;
                    case 2://移除
                        bl = goodsBLL.RemoveGoodsInfo(goods.GoodsId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"商品信息:{goods.GoodsName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, delMsg);
                    LoadGoodsList();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,delMsg);
                    return;
                }
            }
        }
    }
}