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
using DevExpress.XtraGrid.Columns;
using PSINew.Models.DModels;

namespace DXPSIApp.BM
{
    public partial class FrmStoreTypeList : DevExpress.XtraEditors.XtraForm
    {
        public FrmStoreTypeList()
        {
            InitializeComponent();
        }
        string uName = "";
        StoreTypeBLL stBLL = new StoreTypeBLL();
        string oldName = "";//修改前的类别名称
        public event Action TVStoreTypeReload;//刷新列表页的类别节点树
        private STypeListViewModel fVModel = null;
        private STypeModel curType = null;
        int isLoad = 0;
        private string msgTitle = "仓库类别管理";
        private void FrmStoreTypeList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                gbInfo.Visible = false;
                fVModel = new STypeListViewModel();
                fVModel.IsShowDel = false;
                LoadSTypeList();
                SetDgvCols();
                RegisterEvents();
            };
            act.TryCatch(msgTitle, "计量单位列表加载异常！");
        }

        private void LoadSTypeList()
        {
            chkShowDel.DataBind(fVModel,"Checked",  "IsShowDel",true);
            gvStoreTypeList.OptionsBehavior.AutoPopulateColumns = false;
            gcStoreTypeList.DataBind(fVModel,"DataSource",  "STypeList");
            isLoad = 1;
        }

        private void SetDgvCols()
        {
            gvStoreTypeList.ShowOrHideNormalCols(fVModel.IsShowDel);
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
            gvStoreTypeList.RowCellClick += GvStoreTypeList_RowCellClick;
            txtTypeName.TextChanged += TxtTypeNamee_TextChanged;
        }

        private void ListTool1_AddClick(object sender, ItemClickEventArgs e)
        {
            curType = new STypeModel();
            gbInfo.Visible = true;
            InitSTypeInfo(1);
        }
        private void InitSTypeInfo(int isAdd)
        {
            txtTypeName.DataBind(curType, "STypeName",true);
            txtPYNo.DataBind (curType, "STPYNo", true);
            spinOrder.DataBind(curType, "Value", "STypeOrder", true);
            string btnText = isAdd == 1 ? "添加" : "修改";
            btnAdd.Text = btnText;
            if (curType.STypeId > 0)
                oldName = curType.STypeName;
        }

        private void ListTool1_EditClick(object sender, ItemClickEventArgs e)
        {
            if (gvStoreTypeList.GetFocusedDataSourceRowIndex() > -1)
            {
                int index = gvStoreTypeList.GetFocusedDataSourceRowIndex();
                STypeModel type = fVModel.STypeList[index] as STypeModel;
                curType = type;
                InitSTypeInfo(2);
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(msgTitle, "请选择要修改的类别信息！");
                return;
            }
        }

        private void ListTool1_DeleteClick(object sender, ItemClickEventArgs e)
        {
            string errTitle = "删除仓库类别";
            if (gvStoreTypeList.SelectedRowsCount == 0)
            {
                MsgBoxHelper.MsgErrorShow(errTitle, "请选择要删除的仓库类别！");
                return;
            }
            if (MsgBoxHelper.MsgBoxConfirm(errTitle, "您确定要删除选择的仓库类别信息吗？") == DialogResult.Yes)
            {
                List<int> typeIds = new List<int>();
                string hasAddStoresNames = "";
                foreach (int index in gvStoreTypeList.GetSelectedRows())
                {
                    STypeModel type = fVModel.STypeList[index];
                    //如果该类别添加了仓库，不允许删除
                    bool hasAddStores = stBLL.IsAddStores(type.STypeId);
                    if (!hasAddStores)
                    {
                        typeIds.Add(type.STypeId);
                    }
                    else
                    {
                        if (hasAddStoresNames.Length > 0) hasAddStoresNames += ",";
                        hasAddStoresNames += type.STypeName;
                    }
                }
                if (typeIds.Count > 0)
                {
                    bool bl = stBLL.LogicDeleteList(typeIds);//执行批量删除
                    string sucMsg = bl ? "成功" : "失败";
                    string msg = $"选择的类别信息中符合删除要求的信息 删除 {sucMsg}!";
                    if (bl)
                    {
                        if (!string.IsNullOrEmpty(hasAddStoresNames))
                            msg += $" {hasAddStoresNames} 已经添加了仓库，不能删除！";
                        MsgBoxHelper.MsgBoxShow(errTitle, msg);
                        FindSTypeList();
                    }
                    else
                        MsgBoxHelper.MsgErrorShow(errTitle,msg);
                }
                else
                    MsgBoxHelper.MsgErrorShow(errTitle,"没有符合删除要求的类别信息!");
            }
        }

        private void ListTool1_RefreshClick(object sender, ItemClickEventArgs e)
        {
            fVModel.IsShowDel = false;
            FindSTypeList();
        }

        private void ListTool1_CloseClick(object sender, ItemClickEventArgs e)
        {
            this.TVStoreTypeReload?.Invoke();
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string title = "保存仓库类别";
            //判空处理
            if (string.IsNullOrEmpty(curType.STypeName))
            {
                MsgBoxHelper.MsgErrorShow(title,"请输入仓库类别名称！");
                txtTypeName.Focus();
                return;
            }
            //判断已存在
            if (curType.STypeId == 0 || (!string.IsNullOrEmpty(oldName) && oldName != curType.STypeName))
            {
                if (stBLL.ExistsStoreType(curType.STypeName))
                {
                    MsgBoxHelper.MsgErrorShow(title,"该仓库类别已存在！");
                    txtTypeName.Focus();
                    return;
                }
            }

            //信息封装
            StoreTypeInfoModel stInfo = new StoreTypeInfoModel()
            {
                STypeId = curType.STypeId,
                STypeName = curType.STypeName,
                STPYNo = curType.STPYNo,
                STypeOrder = curType.STypeOrder,
                Creator = uName
            };

            //方法执行
            bool bl = false;
            if (curType.STypeId == 0)
            {
                int stTypeId = stBLL.AddStoreType(stInfo);
                if(stTypeId>0)
                {
                    bl = true;
                    curType.STypeId = stTypeId;
                    oldName = curType.STypeName;
                }
            }
            else
            {
                bl = stBLL.UpdateStoreType(stInfo);
            }
            string actType = curType.STypeId == 0 ? "添加" : "修改";
            string sucType = bl ? "成功" : "失败";
            string actMsg = $"仓库类别信息:{curType.STypeName} {actType} {sucType}";
            string msgTitle = $"{actType}仓库类别";
            if (bl)
            {
                MsgBoxHelper.MsgBoxShow(msgTitle, actMsg);
                FindSTypeList();

            }
            else
            {
                MsgBoxHelper.MsgErrorShow(title,actMsg);
                return;
            }
        }

        private void ChkShowDel_CheckedChanged(object sender, EventArgs e)
        {
            fVModel.IsShowDel = chkShowDel.Checked;
            FindSTypeList();
        }

        private void GvStoreTypeList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int index = e.RowHandle;//行索引
            GridColumn col = e.Column;//当前点击单元格所在的列
            STypeModel type = fVModel.STypeList[index];
            switch (col.Name)
            {
                case "colEdit":
                    gbInfo.Visible = true;
                    curType = type;
                    InitSTypeInfo(2);
                    oldName = curType.STypeName;
                    break;
                case "colDelete":
                    DeleteSType(type, 1);
                    break;
                case "colRecover":
                    DeleteSType(type, 0);
                    break;
                case "colRemove":
                    DeleteSType(type, 2);
                    break;
                default: break;
            }
        }

        private void DeleteSType(STypeModel type, int delType)
        {
            string delTypeName = FormUtility.GetDeleteTypeName(delType);
            string title = $"仓库类别{delTypeName}";
            if (MsgBoxHelper.MsgBoxConfirm(title, $"您确定要{delTypeName}该仓库类别？") == DialogResult.Yes)
            {
                bool bl = false;
                switch (delType)
                {
                    case 1://删除
                           //如果该类别添加了仓库，不允许删除
                        bool hasAddStores = stBLL.IsAddStores(type.STypeId);
                        if (!hasAddStores)
                        {
                            bl = stBLL.LogicDelete(type.STypeId);
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow(title,$"该类别:{type.STypeName} 已经添加了仓库，不能删除！");
                            return;
                        }
                        break;
                    case 0://恢复
                        bl = stBLL.Recover(type.STypeId);
                        break;
                    case 2://移除
                        bl = stBLL.Delete(type.STypeId);
                        break;
                }
                string sucType = bl ? "成功" : "失败";
                string delMsg = $"仓库类别:{type.STypeName} {delTypeName} {sucType}";
                if (bl)
                {
                    MsgBoxHelper.MsgBoxShow(title, delMsg);
                    FindSTypeList();
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow(title,delMsg);
                    return;
                }
            }
        }

        private void TxtTypeNamee_TextChanged(object sender, EventArgs e)
        {
            curType.STPYNo = PingYinHelper.GetFirstSpell(curType.STypeName);
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void FindSTypeList()
        {
            fVModel.GetSTypeList();
            SetDgvCols();
            if (isLoad == 1)
                gcStoreTypeList.ReLoadData();
        }
    }
}