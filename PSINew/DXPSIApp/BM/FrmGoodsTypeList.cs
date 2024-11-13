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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using Common;
using PSINew.Models.DModels;
using DXPSIApp.FModels;
using DevExpress.XtraGrid.Columns;

namespace DXPSIApp.BM
{
    public partial class FrmGoodsTypeList : DevExpress.XtraEditors.XtraForm
    {
        public FrmGoodsTypeList()
        {
            InitializeComponent();
        }
        string uName = "";
        GoodsTypeBLL gtBLL = new GoodsTypeBLL();
        string oldName = "";//修改前的类别名称
        public event Action ReloadTVGoodsTypes;//刷新商品类别TreeList
        private GTypeListViewModel fVModel = null;
        private GTypeModel curType = null;
        int isLoad = 0;
        private string msgTitle = "商品类别管理";


        private void FrmGoodsTypeList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                gbInfo.Visible = false;
                fVModel = new GTypeListViewModel();
                fVModel.IsShowDel = false;
                LoadGTypeList();
                SetDgvCols();
                InitCboParents();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "商品类别列表加载异常！");
        }

        private void InitCboParents()
        {
            List<GoodsTypeInfoModel> types = gtBLL.LoadAllGoodsTypes();
            foreach (GoodsTypeInfoModel type in types)
            {
                ComboBoxItem item = new ComboBoxItem(type.GTypeName, type.GTypeId);
                cboParents.Properties.Items.Add(item);
            }
            cboParents.Properties.Items.Insert(0, new ComboBoxItem("请选择", 0));
            cboParents.SelectedIndex = 0;
        }

        private void LoadGTypeList()
        {
            chkShowDel.DataBind(fVModel,"Checked",  "IsShowDel",true);
            txtKeywords.DataBind(fVModel, "KeyWords",true);
            gvGoodsTypeList.OptionsBehavior.AutoPopulateColumns = false;
            gcGoodsTypeList.DataBind(fVModel, "DataSource", "GTypeList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvGoodsTypeList.ShowOrHideNormalCols(fVModel.IsShowDel);
            gvGoodsTypeList.ShowOrHideCol("colAddChild", !fVModel.IsShowDel);
        }

        private void RegisterEvents()
        {
            listTool1.AddClick += ListTool1_AddClick;
            listTool1.EditClick += ListTool1_EditClick;
            listTool1.DeleteClick += ListTool1_DeleteClick;
            listTool1.RefreshClick += ListTool1_RefreshClick;
            listTool1.CloseClick += ListTool1_CloseClick;
            btnAdd.Click += BtnAdd_Click;
            chkShowDel.CheckedChanged += ChkShowDel_CheckedChanged;
            gvGoodsTypeList.RowCellClick += GvGoodsTypeList_RowCellClick;
            txtTypeName.TextChanged += TxtTypeName_TextChanged;
            btnFind.Click += BtnFind_Click;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindGTypeList();
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            curType = new GTypeModel();
            gbInfo.Visible = true;
            InitGTypeInfo(1);
        }

        private void InitGTypeInfo(int isAdd)
        {
            txtTypeName.DataBind(curType, "GTypeName", true);
            txtTypeNo.DataBind(curType, "GTypeNo", true);
            txtPYNo.DataBind(curType, "GTPYNo",true);
            spinOrder.DataBind(curType,"Value",  "GTOrder",true);
            cboParents.SetCboValue(curType.ParentId==null?0:curType.ParentId.Value);
            string btnText = isAdd == 1 ? "添加" : "修改";
            btnAdd.Text = btnText;
            if (curType.GTypeId > 0)
                oldName = curType.GTypeName;
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            if (gvGoodsTypeList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvGoodsTypeList.GetFocusedDataSourceRowIndex();
                GTypeModel type = fVModel.GTypeList[index] as GTypeModel;
                curType = type;
                InitGTypeInfo(2);
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要修改的类别信息！");
                return;
            }
        }

        /// <summary>
        /// 多个删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string errTitle = "删除商品类别";
            if (gvGoodsTypeList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(errTitle, "请选择要删除的商品类别！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(errTitle, "您确定要删除选择的商品类别信息吗？") == DialogResult.Yes)
            {
                List<int> gIds = new List<int>();
                string hasChildsNames = "";
                string hasAddGoodsNames = "";
                foreach (int index in gvGoodsTypeList.GetSelectedRows())
                {
                    GTypeModel type = fVModel.GTypeList[index];
                    //如果该类别添加了商品，不允许删除
                    bool hasAddGoods = gtBLL.CheckIsAddGoods(type.GTypeId);
                    //如果该类别添加了子类别，不允许删除
                    bool hasChilds = gtBLL.HasChildTypes(type.GTypeId);
                    if (!hasAddGoods && !hasChilds)
                    {
                        gIds.Add(type.GTypeId);
                    }
                    else if (hasAddGoods)
                    {
                        if (hasAddGoodsNames.Length > 0) hasAddGoodsNames += ",";
                        hasAddGoodsNames += type.GTypeName;
                    }
                    else if (hasChilds)
                    {
                        if (hasChildsNames.Length > 0) hasChildsNames += ",";
                        hasChildsNames += type.GTypeName;
                    }
                }
                if (gIds.Count > 0)
                {
                    bool bl = gtBLL.LogicDeleteList(gIds);//执行批量删除
                    string sucMsg = bl ? "成功" : "失败";
                    string msg = $"选择的类别信息中符合删除要求的信息 删除 {sucMsg}!";
                    if (bl)
                    {
                        if (!string.IsNullOrEmpty(hasChildsNames))
                            msg += $" {hasChildsNames} 已经添加了子类别，不能删除！";
                        if (!string.IsNullOrEmpty(hasAddGoodsNames))
                            msg += $" {hasAddGoodsNames} 已经添加商品，不能删除！";
                        MsgBoxHelper.MsgBoxShow(errTitle, msg);
                        FindGTypeList();
                        ReloadCboParents(gIds);
                    }
                    else
                        MsgBoxHelper.MsgErrorShow(errTitle,msg);
                }
                else
                    MsgBoxHelper.MsgErrorShow(errTitle,"没有符合删除要求的商品类别信息！");
            }
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.KeyWords = "";
            fVModel.IsShowDel = false;
            FindGTypeList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.ReloadTVGoodsTypes?.Invoke();
            this.Close();
        }

        /// <summary>
        /// 新增、修改、添加子类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //信息获取
                int parentId = cboParents.GetCboValue();
                string parentName = parentId == 0 ? null : cboParents.EditValue.ToString();
                curType.ParentId = parentId;
                curType.ParentName = parentName;
                //判空处理
                if (string.IsNullOrEmpty(curType.GTypeName))
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,"请输入商品类别名称！");
                    txtTypeName.Focus();
                    return;
                }
                //判断已存在
                if (curType.GTypeId  == 0 || (!string.IsNullOrEmpty(oldName) && oldName != curType.GTypeName))
                {
                    if (gtBLL.ExistName(curType.GTypeName))
                    {
                        MsgBoxHelper.MsgErrorShow(msgTitle,"该类别名称已存在！");
                        txtTypeName.Focus();
                        return;
                    }
                }

                //信息封装
                GoodsTypeInfoModel gtInfo = new GoodsTypeInfoModel()
                {
                    GTypeId = curType.GTypeId,
                    GTypeName = curType.GTypeName,
                    GTypeNo = curType.GTypeNo,
                    GTPYNo = curType.GTPYNo,
                    GTOrder = curType.GTOrder,
                    ParentId = parentId,
                    ParentName = parentName,
                    Creator = uName
                };

                //方法执行
                bool bl = false;
                int gTypeIdNew = 0;
                if (curType.GTypeId == 0)
                {
                    gTypeIdNew = gtBLL.AddGoodsType(gtInfo);
                    if (gTypeIdNew > 0)
                    {
                        bl = true;
                        gtInfo.GTypeId = gTypeIdNew;
                    }
                }
                else
                {
                    bl = gtBLL.UpdateGoodsType(gtInfo, oldName);
                }
                string actType = curType.GTypeId == 0 ? "添加" : "修改";
                string sucType = bl ? "成功" : "失败";
                string actMsg = $"商品类别信息:{curType.GTypeName} {actType} {sucType}";
              
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(msgTitle, actMsg);
                    FindGTypeList();
                    ReloadCboParents(curType, false, 0);//刷新下拉框
                    oldName = curType.GTypeName;
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(msgTitle,actMsg);
                    return;
                }
            };
            act.TryCatch(msgTitle,"保存类别信息异常！");
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindGTypeList ();
        }

        private void GvGoodsTypeList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            GTypeModel type = fVModel.GTypeList[index];
            switch (col.Name)
            {
                case "colAddChild":
                    gbInfo.Visible = true;
                    curType = new GTypeModel();
                    curType.ParentId = type.GTypeId;
                    cboParents.Enabled = false;
                    InitGTypeInfo(1);
                    break;
                case "colEdit":
                    gbInfo.Visible = true;
                    curType  = type;
                    InitGTypeInfo(2);
                    oldName = curType.GTypeName;
                    cboParents.Enabled = true;
                    break;
                case "colDelete":
                    DeleteGType(type, 1);
                    break;
                case "colRecover":
                    DeleteGType(type, 0);
                    break;
                case "colRemove":
                    DeleteGType(type, 2);
                    break;
                default: break;
            }
        }

        private void TxtTypeName_TextChanged(object sender, EventArgs e)
        {
            curType.GTPYNo = PingYinHelper.GetFirstSpell(curType.GTypeName);
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void FindGTypeList()
        {
            fVModel.GetGTypeList();
            SetDgvCols();
            if (isLoad == 1)
                gcGoodsTypeList.ReLoadData();
        }

        /// <summary>
        /// 移除下拉框中已删除的项
        /// </summary>
        /// <param name="typeIds"></param>
        private void ReloadCboParents(List<int> typeIds)
        {
            List<ComboBoxItem> delList = new List<ComboBoxItem>();
            foreach (ComboBoxItem item in cboParents.Properties.Items)
            {
                if (typeIds.Contains(item.Value))
                    delList.Add(item);
            }
            delList.ForEach(i => cboParents.Properties.Items.Remove(i));
        }

        private void DeleteGType(GTypeModel gt,int isDeleted)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(isDeleted);
            string errTitle = $"商品类别{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(msgTitle, $"您确定要{delTypeName}该商品类别？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (isDeleted)
                {
                    case 1://删除
                           //如果该类别添加了商品，不允许删除
                        bool hasAddGoods = gtBLL.CheckIsAddGoods(gt.GTypeId);
                        //如果该类别添加了子类别，不允许删除
                        bool hasChilds = gtBLL.HasChildTypes(gt.GTypeId);
                        if (!hasAddGoods && !hasChilds)
                        {
                            bl = gtBLL.LogicDelete(gt.GTypeId);
                        }
                        else if (hasAddGoods)
                        {
                            MsgBoxHelper.MsgErrorShow(errTitle, $"该类别:{gt.GTypeName} 已经添加商品，不能删除！");
                            return;
                        }
                        else if (hasChilds)
                        {
                            MsgBoxHelper.MsgErrorShow(errTitle, $"该类别:{gt.GTypeName} 已经添加了子类别，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = gtBLL.Recover(gt.GTypeId);
                        break;
                    case 2://移除
                        bl = gtBLL.Delete(gt.GTypeId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"商品类别:{gt.GTypeName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(errTitle, delMsg);
                    FindGTypeList();
                    if (isDeleted != 2)
                    {
                        ReloadCboParents(gt, true, isDeleted);
                    }
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(errTitle, delMsg);
                    return;
                }
            }
        }
        /// <summary>
        /// 刷新下拉框
        /// </summary>
        /// <param name="gt"></param>
        private void ReloadCboParents(GTypeModel gt, bool isDel, int isDeleted)
        {
            
            if (!isDel)
            {
                if (curType.GTypeId > 0 && oldName != gt.GTypeName)//修改提交时，类别名称信息发生改变
                {
                    foreach(ComboBoxItem item in cboParents.Properties.Items)
                    {
                        if(item.Value ==gt.GTypeId)
                        {
                            item.Text = gt.GTypeName;
                            break;
                        }
                    }
                }
                else if (curType.GTypeId == 0) //新增或添加子类别
                {
                    cboParents.Properties.Items.Add(new ComboBoxItem(gt.GTypeName,gt.GTypeId));
                }
            }
            else
            {
                if (isDeleted == 1)
                    cboParents.Properties.Items.Remove(new ComboBoxItem(gt.GTypeName, gt.GTypeId));
                else
                    cboParents.Properties.Items.Add(new ComboBoxItem(gt.GTypeName, gt.GTypeId));
            }
            cboParents.SetCboValue(gt.ParentId==null?0:gt.ParentId.Value);
        }
    }
}