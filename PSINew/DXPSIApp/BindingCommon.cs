using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXPSIApp
{
    public static class BindingCommon
    {
        public static void DataBind(this Control c, object datasource, string proName, string dataMember)
        {
            if (c.DataBindings[proName] != null)
                RemoveBind(c, proName);
             c.DataBindings.Add(proName, datasource, dataMember);
        }
        public static void DataBind(this Control c, object datasource, string proName, string dataMember, bool IsUpdate)
        {
            if (c.DataBindings[proName] != null)
            {
                RemoveBind(c, proName);
            }
            if (!IsUpdate)
                c.DataBindings.Add(proName, datasource, dataMember);
            else
                c.DataBindings.Add(proName, datasource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void DataBind(this Control c, object datasource, string dataMember)
        {
            if (c.DataBindings["Text"] != null)
            {
                RemoveBind(c, "Text");
            }
             c.DataBindings.Add("Text", datasource, dataMember);
            //c.DataBindings.Add(new Binding("Text", datasource, dataMember));
        }

        public static void DataBind(this Control c, object datasource, string dataMember, bool IsUpdate)
        {
            if (c.DataBindings["Text"] != null)
            {
                RemoveBind(c, "Text");
            }
            if (!IsUpdate)
                c.DataBindings.Add("Text", datasource, dataMember);
            else
                c.DataBindings.Add("Text", datasource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public static void DataBind(this Control c, object datasource, string dataMember, bool IsUpdate,string formatStr)
        {
            if (c.DataBindings["Text"] != null)
            {
                RemoveBind(c, "Text");
            }
            if (!IsUpdate)
                c.DataBindings.Add("Text", datasource, dataMember);
            else
            {
                if (string.IsNullOrEmpty(formatStr))
                    c.DataBindings.Add("Text", datasource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
                else
                    c.DataBindings.Add("Text", datasource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged, null, formatStr);
            }
        }

        private static void RemoveBind(Control c, string proName)
        {
            Binding bind = c.DataBindings[proName];
            c.DataBindings.Remove(bind);
        }
    }
}
