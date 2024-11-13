using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PropertyHelper
    {
        public static PropertyInfo[] GetTypeProperties<T>(string cols)
        {
            Type type = typeof(T);
            List<string> listCols = cols.GetStrList(',', true);
            //获取所有属性
            PropertyInfo[] properties = type.GetProperties();
            if (listCols != null && listCols.Count > 0)
            {
                properties = properties.Where(p => listCols.Contains(p.GetColName().ToLower())).ToArray();
            }
            return properties;

        }
    }
}
