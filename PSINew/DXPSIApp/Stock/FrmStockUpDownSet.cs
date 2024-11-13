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
using PSINew.UModels;
using DXPSIApp.BM;
using DXPSIApp.FModels;
using PSINew.Models.DModels;
using PSINew.Models.VModels;

namespace DXPSIApp.Stock
{
    public partial class FrmStockUpDownSet : DevExpress.XtraEditors.XtraForm
    {
        public FrmStockUpDownSet()
        {
            InitializeComponent();
        }
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        StoreBLL storeBLL = new StoreBLL();
        StockBLL stockBLL = new StockBLL();
        public StoreModel store = null;
        private StockUpDownSetViewModel fVModel = null;
        int isLoad = 0;
        private void FrmStockUpDownSet_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                fVModel = new StockUpDownSetViewModel();
                RegisterEvents();
                LoadTVGTypes();//加载商品类别节点树
                LoadGoodsStockUpDownList();//加载商品上下限列表
            };
            act.TryCatch("库存上下限设置","加载商品库存查询异常！");
        }

        private void RegisterEvents()
        {
            upDownTool1.SetMoreClick += UpDownTool1_SetMoreClick;
            upDownTool1.SaveClick += UpDownTool1_SaveClick;
            upDownTool1.RefreshClick += UpDownTool1_RefreshClick;
            upDownTool1.CloseClick += UpDownTool1_CloseClick;
            tlGTypes.FocusedNodeChanged += TlGTypes_FocusedNodeChanged;
            pbStores.Click += PbStores_Click;
            txtStoreName.EditValueChanged += TxtStoreName_EditValueChanged;
        }

        private void TxtStoreName_EditValueChanged(object sender, EventArgs e)
        {
            fVModel.StoreName = txtStoreName.Text;
            if(string.IsNullOrEmpty(fVModel.StoreName))
            {
                fVModel.StoreId = 0;

                FindGoodsUpDownList();
            }
        }

        private void PbStores_Click(object sender, EventArgs e)
        {
            FrmChooseStores fChooseStore = new FrmChooseStores();
            fChooseStore.Tag = new ChooseTypeData()
            {
                FGet = this,
                TypeCode = "Store-StockUpDownSet"
            };
            fChooseStore.SetStore += () =>
            {
                fVModel.StoreName = store.StoreName;
                fVModel.StoreId = store.StoreId;
                FindGoodsUpDownList();
            };
            fChooseStore.ShowDialog();
        }

        private void LoadGoodsStockUpDownList()
        {
            if (tlGTypes.FocusedNode != null)
            {
                fVModel.GTypeId = (int) tlGTypes.FocusedNode.GetValue("GTypeId");
            }
            fVModel.GetGoodsUpDownList();
           
            if(fVModel!=null)
            {
                txtStoreName.DataBind(fVModel, "StoreName",true);
                gcGoodsStockList.DataBind(fVModel, "DataSource", "GoodsUpDownList",true);
                upDownTool1.DataBind(fVModel, "IsSetMoreEnabled", "IsSetMore", true);
                isLoad = 1;
            }
        }



        private void LoadTVGTypes()
        {
            tlGTypes.LoadTVGoodsTypes(fVModel.GTypeList);
        }

        private void FindGoodsUpDownList()
        {
            GoodsTypeInfoModel selType = tlGTypes.GetDataRecordByNode(tlGTypes.FocusedNode) as GoodsTypeInfoModel;
            if (selType != null)
            {
                fVModel.GTypeId = selType.GTypeId;
            }
            fVModel.GetGoodsUpDownList();
            if (isLoad == 1)
            {
                gcGoodsStockList.ReLoadData();
            }
        }

        private void TlGTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            FindGoodsUpDownList();
        }

        private void UpDownTool1_CloseClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CloseForm();
        }

        private void UpDownTool1_RefreshClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fVModel.StoreId = 0;
            fVModel.StoreName = "";
            tlGTypes.SelectNode(tlGTypes.Nodes[0]);
            FindGoodsUpDownList();
        }

        private void UpDownTool1_SaveClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                //获取列表数据，判断是否有修改的数据，移除未修改的数据，保存提交
                List<GoodsStockUpDownModel> list2 = new List<GoodsStockUpDownModel>();
                foreach (var gupdown in fVModel.GoodsUpDownList)
                {
                    foreach (var vsud in fVModel.ListStart)
                    {
                        if (vsud.StoreGoodsId == gupdown.StoreGoodsId && (vsud.StockUp != gupdown.StockUp || vsud.StockDown != gupdown.StockDown))
                        {
                            list2.Add(gupdown);
                            break;
                        }
                    }
                }
                if (list2.Count == 0)
                {
                    MsgBoxHelper.MsgErrorShow("保存设置","没有需要保存的信息！");
                    return;
                }
                List<ViewStoreStockUpDownModel> list = new List<ViewStoreStockUpDownModel>();
                list2.ForEach(g => list.Add(g.StoreUpDown));
                bool blSave = stockBLL.SetGoodsStockUpDown(list);
                if (blSave)
                {
                    MsgBoxHelper.MsgBoxShow("保存库存上下限", "库存上下限设置保存成功！");
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("保存库存上下限","库存上下限设置保存失败！");
                    return;
                }
            };
            act.TryCatch("保存库存上下限","保存库存上下限设置出现异常！");
        }

        private void UpDownTool1_SetMoreClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Action act = () =>
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    MsgBoxHelper.MsgErrorShow("批量设置","请选择要设置库存上下限的商品！");
                    return;
                }
                else
                {
                    if (MsgBoxHelper.MsgBoxConfirm("设置上下限", $"您确定设置这{gridView1.SelectedRowsCount}个商品的库存上下限吗？") == DialogResult.Yes)
                    {
                        //要进行统一设置的商品列表
                        List<GoodsStockUpDownModel> list = new List<GoodsStockUpDownModel>();
                        foreach (int index in gridView1.GetSelectedRows())
                        {
                            var info = fVModel.GoodsUpDownList[index];
                            list.Add(info);
                        }
                        //打开批量设置页面      list   storeName  刷新列表  订阅事件
                        FrmSetMore fSetMore = new FrmSetMore();
                        fSetMore.Tag = new StockSetMoreData()
                        {
                            StoreUpDownList = list,
                            StoreName = fVModel.StoreName
                        };
                        fSetMore.ReloadList += LoadGoodsStockUpDownList;
                        fSetMore.ShowDialog();
                    }
                }

            };
            act.TryCatch("批量设置","批量设置库存上下限出现异常！");
        }

     
    }
}