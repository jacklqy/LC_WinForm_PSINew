using Common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DXPSIApp.FModels;
using PSINew.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXPSIApp
{
    public static class FormUtility
    {


        /// <summary>
        /// try  catch 异常处理
        /// </summary>
        /// <param name="act"></param>
        /// <param name="message"></param>
        public static void TryCatch(this Action act, string errTItle,string message)
        {
            try
            {
                act.Invoke();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgErrorShow(errTItle, ex.Message);
            }
        }

        /// <summary>
        /// 判断Form是否已打开
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static bool CheckOpenForm(string formName)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }

        /// <summary>
        /// 关闭指定的窗体
        /// </summary>
        /// <param name="formName"></param>
        public static void CloseOpenForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    frm.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// 返回指定的Form
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static Form GetOpenForm(string formName)
        {
            Form f = null;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == formName)
                {
                    f = frm;
                    break;
                }
            }
            return f;
        }

        /// <summary>
        /// 添加窗体页面到选项卡中
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="form"></param>
        public static void AddTabFormPage(this XtraTabControl tab, XtraForm form,int index)
        {
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.TopLevel = false;
            form.WindowState = FormWindowState.Maximized;
            XtraTabPage page = new XtraTabPage();
            form.Parent = page;
            form.Dock = DockStyle.Fill;
            form.AutoSize = false;
            page.Name = form.Name;
            page.Text = form.Text;
            page.AutoScroll = true;
            if (index != -1)
                tab.TabPages.Insert(index, page);
            else 
                 tab.TabPages.Add(page);
            tab.SelectedTabPage = page;
            form.Show();
        }

        /// <summary>
        /// 加载应用程序中所有的窗体选择列表
        /// </summary>
        /// <param name="cboForms"></param>
        /// <param name="frm"></param>
        public static void LoadCboForms(LookUpEdit lueForms, XtraForm frm)
        {
            //程序集名称
            string assName = frm.GetType().Assembly.GetName().Name;
            Type[] types = frm.GetType().Assembly.GetTypes();
            //筛选出所有窗体类
            var frmTypes = types.Where(t => t.BaseType.Name == "XtraForm");
            Dictionary<string, string> listForms = new Dictionary<string, string>();
            foreach (Type type in frmTypes)
            {
                XtraForm f = (XtraForm)Activator.CreateInstance(type);
                listForms.Add(type.FullName.Remove(0, assName.Length + 1), f.Text);
                f.Dispose();
            }
            //绑定
            BindingSource bs = new BindingSource();
            bs.DataSource = listForms;
            lueForms.Properties.DataSource = bs;
            lueForms.Properties.DisplayMember = "Value";
            lueForms.Properties.ValueMember = "Key";
        }

        /// <summary>
        /// 关闭显示在选择卡中的窗体
        /// </summary>
        /// <param name="form"></param>
        public static void CloseForm(this XtraForm form)
        {
            if (!form.TopLevel)
            {
                XtraTabPage tp = form.Parent as XtraTabPage;
                XtraTabControl tc = tp.Parent as XtraTabControl;
                tc.TabPages.Remove(tp);
            }
            form.Close();

        }

        /// <summary>
        /// 获取Ip
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            string ip = "";
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry myEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < myEntry.AddressList.Length; i++)
            {
                //从IP地址列表中筛选出IPv4类型的IP地址
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                if (myEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = myEntry.AddressList[i].ToString();
                    break;
                }
            }
            return ip;
        }

        /// <summary>
        /// 获取快捷键
        /// </summary>
        /// <param name="mkey"></param>
        /// <returns></returns>
        public static BarShortcut SetShortKeys(string mkey)
        {
            Keys reKey = default(Keys);
            string[] arrKeys = mkey.Split('+');
            if (arrKeys.Length == 2)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[1], out k);
                if (arrKeys[0].ToLower() == "ctrl")
                {
                    reKey = Keys.Control | k;
                }
                else if (arrKeys[0].ToLower() == "alt")
                {
                    reKey = Keys.Alt | k;
                }
                else if (arrKeys[0].ToLower() == "shift")
                {
                    reKey = Keys.Shift | k;
                }
            }
            else if (arrKeys.Length == 3)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[2], out k);
                string start = arrKeys[0].ToLower() + "+" + arrKeys[1].ToLower();
                switch (start)
                {
                    case "shift+alt":
                        reKey = Keys.Shift | Keys.Alt | k;
                        break;
                    case "ctrl+alt":
                        reKey = Keys.Control | Keys.Alt | k;
                        break;
                    case "ctrl+shift":
                        reKey = Keys.Control | Keys.Shift | k;
                        break;
                }
            }
            else if (arrKeys.Length == 4)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[3], out k);
                reKey = Keys.Control | Keys.Shift | Keys.Alt | k;
            }
            return new BarShortcut(reKey);

        }

        /// <summary>
        /// 刷新控件数据
        /// </summary>
        /// <param name="gc"></param>
        public static void ReLoadData(this Control c)
        {
            c.DataBindings[0].ReadValue();
        }

        public static void ShowDialogNew(this XtraForm frm)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        /// <summary>
        /// 设置ComboBox的值
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="val"></param>
        public static void SetCboValue(this ComboBoxEdit cbo,int val)
        {
            foreach (var item in cbo.Properties.Items)
            {
                 if(item is ComboBoxItem)
                {
                    ComboBoxItem cboItem = item as ComboBoxItem;
                    if(cboItem.Value ==val)
                    {
                        cbo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取ComboBoxEdit的值
        /// </summary>
        /// <param name="cbo"></param>
        /// <returns></returns>
        public static int GetCboValue(this ComboBoxEdit cbo)
        {
            foreach (var item in cbo.Properties.Items)
            {
                if (item is ComboBoxItem)
                {
                    ComboBoxItem cboItem = item as ComboBoxItem;
                    if (cboItem.Text ==cbo.EditValue.ToString())
                    {
                        return cboItem.Value;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 设置指定名称的列是否显示
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="colName"></param>
        /// <param name="isShow"></param>
        public static void ShowOrHideCol(this GridView gv,string colName,bool isShow)
        {
            gv.Columns.ColumnByName(colName).Visible =isShow;
        }

        /// <summary>
        /// 基本的修改、删除、恢复、移除列的显示
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="isShow"></param>
        public static void ShowOrHideNormalCols(this GridView gv,  bool isShow)
        {
            gv.Columns.ColumnByName("colEdit").Visible = !isShow;
            gv.Columns.ColumnByName("colDelete").Visible = !isShow;
            gv.Columns.ColumnByName("colRemove").Visible = isShow;
            gv.Columns.ColumnByName("colRecover").Visible = isShow;
        }

     

        /// <summary>
        /// 获取删除操作的名称
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public static string GetDeleteTypeName(int isDeleted)
        {
            string typeName = "";
            switch (isDeleted)
            {
                case 1: typeName = "删除"; break;
                case 0: typeName = "恢复"; break;
                case 2: typeName = "移除"; break;
                default: break;
            }
            return typeName;
        }


        public static void LoadTLStoreTypes(this TreeList tlStoreTypes,List<StoreTypeInfoModel> typeList)
        {
            tlStoreTypes.Nodes.Clear();
            tlStoreTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlStoreTypes.DataSource = typeList;
            tlStoreTypes.KeyFieldName = "STypeId";
            tlStoreTypes.ParentFieldName = "ParentId";
            tlStoreTypes.SelectNode(tlStoreTypes.Nodes[0]);
            tlStoreTypes.ExpandAll();
        }

        public static void LoadTVGoodsTypes(this TreeList tlGoodsTypes,List<GoodsTypeInfoModel> gTypeList)
        {
            tlGoodsTypes.Nodes.Clear();
            tlGoodsTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlGoodsTypes.DataSource =gTypeList;
            tlGoodsTypes.KeyFieldName = "GTypeId";
            tlGoodsTypes.ParentFieldName = "ParentId";
            tlGoodsTypes.SelectNode(tlGoodsTypes.Nodes[0]);
            tlGoodsTypes.ExpandAll();
        }

        public static void LoadTVUnitTypes(this TreeList tlUnitTypes, List<UnitTypeInfoModel> uTypeList)
        {
            tlUnitTypes.Nodes.Clear();
            tlUnitTypes.OptionsBehavior.AutoPopulateColumns = false;
            tlUnitTypes.DataSource = uTypeList;
            tlUnitTypes.KeyFieldName = "UTypeId";
            tlUnitTypes.ParentFieldName = "ParentId";
            tlUnitTypes.SelectNode(tlUnitTypes.Nodes[0]);
            tlUnitTypes.ExpandAll();
        }

        public static void DataToExcel<T>(List<T> list, GridColumnCollection cols, string fileName, string sheetName, string msg, string title)
        {
            if (list != null && list.Count > 0)
            {
                string filePath = "";
                FolderBrowserDialog fbdChoose = new FolderBrowserDialog();
                if (fbdChoose.ShowDialog() == DialogResult.OK)
                {
                    filePath = fbdChoose.SelectedPath;
                }
                if (string.IsNullOrEmpty(filePath))
                {
                    MsgBoxHelper.MsgErrorShow(title, "请选择导出的位置！");
                    return;
                }
                if (filePath.LastIndexOf('/') != filePath.Length - 1)
                    filePath += "/";
                Dictionary<string, string> colsName = new Dictionary<string, string>();
                foreach (GridColumn dc in cols)
                {
                    colsName.Add(dc.FieldName, dc.Caption);
                }
                int count = ExcelHelper.ListToExcel<T>(list, filePath + fileName, sheetName, colsName);
                if (count > 0)
                    MsgBoxHelper.MsgBoxShow(title, msg + "数据导出成功！");
                else
                {
                    MsgBoxHelper.MsgErrorShow(title, msg + "数据导出失败！");
                }
            }
            else
            {
                MsgBoxHelper.MsgErrorShow(title,"没有数据可导出！");
                return;
            }
        }
    }
}
