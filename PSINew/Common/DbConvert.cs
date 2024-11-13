
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections;

namespace Common
{
    public class DbConvert
    {
        /// <summary>
        /// 将DataRow转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static T DataRowToModel<T>(DataRow dr, string cols)
        {
            T model = Activator.CreateInstance<T>();

            Type type = typeof(T);
            if (dr != null)
            {
                var properties = PropertyHelper.GetTypeProperties<T>(cols);
                foreach (var p in properties)
                {
                    string colName = p.GetColName();
                    if (dr[colName] is DBNull)
                        p.SetValue(model, null);
                    else
                    {
                        SetPropertyValue<T>(model, dr[colName], p);
                    }
                }
                return model;
            }
            else
                return default(T);

        }

        /// <summary>
        /// 将DataTable转换成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt, string cols)
        {
            List<T> list = new List<T>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    T model = DataRowToModel<T>(dr, cols);
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 将SqlDataReader对象转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T SqlDataReaderToModel<T>(SqlDataReader reader, string cols)
        {
            T model = Activator.CreateInstance<T>();
            Type type = typeof(T);
            var properties = PropertyHelper.GetTypeProperties<T>(cols);
            if (reader.Read())
            {
                foreach (var p in properties)
                {
                    string colName = p.GetColName();
                    if (reader[colName] is DBNull)
                    {
                        p.SetValue(model, null);
                    }
                    else
                    {
                        SetPropertyValue<T>(model, reader[colName], p);
                    }
                }
                return model;
            }
            else return default(T);
        }

        /// <summary>
        /// 将SqlDataReader转换成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> SqlDataReaderToList<T>(SqlDataReader reader, string cols)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            var properties = PropertyHelper.GetTypeProperties<T>(cols);
            while (reader.Read())
            {
                T model = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    string colName = p.GetColName();
                    if (reader[colName] is DBNull)
                    {
                        p.SetValue(model, null);
                    }
                    else
                    {
                        SetPropertyValue<T>(model, reader[colName], p);
                    }
                }
                list.Add(model);
            }
            return list;
        }
        //设置属性值
        private static void SetPropertyValue<T>(T model, object obj, PropertyInfo property)
        {
            if (property.PropertyType.IsGenericType &&
           property.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                property.SetValue(model, Convert.ChangeType(obj, Nullable.GetUnderlyingType(property.PropertyType)));
            }
            else
            {
                property.SetValue(model, Convert.ChangeType(obj, property.PropertyType));
            }



        }


    }
}
