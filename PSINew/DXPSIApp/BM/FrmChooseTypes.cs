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
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DXPSIApp.Perchase;
using DXPSIApp.Sale;

namespace DXPSIApp.BM
{
    public partial class FrmChooseTypes : DevExpress.XtraEditors.XtraForm
    {
        public FrmChooseTypes()
        {
            InitializeComponent();
        }
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        UnitTypeBLL utBLL = new UnitTypeBLL();
        public event Action SetType;//赋值类别名称
        private ChooseTypeData cModel = null;
        private void FrmChooseTypes_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    cModel = this.Tag as ChooseTypeData;
                    if (cModel == null)
                    {
                        MsgBoxHelper.MsgErrorShow("选择类别","类别信息初始化失败！");
                        return;
                    }
                }
                LoadTypeInfos();
            };
            act.TryCatch("类别选择","类别信息初始化加载异常！");
        }

        private void LoadTypeInfos()
        {
            tlTypes.Nodes.Clear();
            tlTypes.OptionsBehavior.AutoPopulateColumns = false;
            
            string rootName = "";
            if (cModel.TypeCode.Contains("Goods"))//加载商品类别信息
            {
                this.Text = "请选择商品类别";
                rootName = "商品类别";
                colName.FieldName = "GTypeName";
            }
            else if (cModel.TypeCode == "Units")
            {
                this.Text = "请选择单位类别";
                rootName = "单位类别";
                colName.FieldName = "UTypeName";
            }
            if (cModel.TypeCode.Contains("Goods"))//加载商品类别信息
            {
                List<GoodsTypeInfoModel> gtList = gtBLL.LoadAllGoodsTypes();
                if (gtList.Count > 0)
                {
                    gtList.Insert(0, new GoodsTypeInfoModel()
                    {
                        GTypeId = 0,
                        GTypeName = rootName
                    });
                    tlTypes.DataSource = gtList;
                    tlTypes.KeyFieldName = "GTypeId";
                    tlTypes.ParentFieldName = "ParentId";
                }
            }
            else if (cModel.TypeCode == "Units")
            {
                List<UnitTypeInfoModel> utList = utBLL.LoadAllTVUnitTypes();
                if (utList.Count > 0)
                {
                    utList.Insert(0, new UnitTypeInfoModel()
                    {
                        UTypeId = 0,
                        UTypeName = rootName
                    });
                    tlTypes.DataSource = utList;
                    tlTypes.KeyFieldName = "UTypeId";
                    tlTypes.ParentFieldName = "ParentId";
                }
            }
            tlTypes.SelectNode(tlTypes.Nodes[0]);
            tlTypes.ExpandAll();
        }

        /// <summary>
        /// 选择类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoose_Click(object sender, EventArgs e)
        {
            TreeListNode selNode = tlTypes.FocusedNode;
            if (selNode != null)
            {
                var type =  tlTypes.GetDataRecordByNode(selNode);
                if (cModel.TypeCode == "Units")
                {
                    UnitTypeInfoModel selType = type as UnitTypeInfoModel;
                    if (selType.UTypeId == 0)
                        selType.UTypeName = null;
                    FrmUnitInfo fUnitInfo = cModel.FGet as FrmUnitInfo;
                    fUnitInfo.uType = selType;
                }
                else if (cModel.TypeCode.Contains("Goods"))
                {
                    GoodsTypeInfoModel selType = type as GoodsTypeInfoModel;
                    if (selType.GTypeId == 0)
                        selType.GTypeName = null;

                    switch (cModel.TypeCode)
                    {
                        case "Goods":
                            FrmGoodsInfo fGoodsInfo = cModel.FGet as FrmGoodsInfo;
                            fGoodsInfo.gTypeInfo = selType;
                            break;
                        case "Goods-PerQueryBySupplier":
                            FrmPerchaseQueryBySupplier fPerQueryBySupplier = cModel.FGet as FrmPerchaseQueryBySupplier;
                            fPerQueryBySupplier.gtInfo = selType;
                            break;
                        case "Goods-SaleQueryByCustomer":
                            FrmSaleQueryByCustomer fSaleQueryByCustomer = cModel.FGet as FrmSaleQueryByCustomer;
                            fSaleQueryByCustomer.gtInfo = selType;
                            break;
                    }
                }
                this.SetType?.Invoke();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}