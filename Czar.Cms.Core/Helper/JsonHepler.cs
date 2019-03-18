using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Czar.Cms.Core.Helper
{
    public class JsonHepler
    {
        public static string ObjectToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public static string ObjectToJSONByConverter(object obj,params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        public static T JSONToObject<T>(string jsonObj)
        {
            return JsonConvert.DeserializeObject<T>(jsonObj);
        }

        public static T JSONToObjectByConverter<T>(string input, params JsonConverter[] converter)
        {
            return JsonConvert.DeserializeObject<T>(input, converter);
        }

        public static T JSONToObjectBySetting<T>(string input, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(input, settings);
        }

        private static object NullToEmpty(object obj)
        {
            return null;
        }

        /// <summary>
        /// 数据库表转键值队集合
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns>hash表数组</returns>
        public static List<Dictionary<string,object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach(DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach(DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                list.Add(dic);
            }
            return list;
        }

        /// <summary>
        /// 数据集转键值对数据字典
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Dictionary<string,List<Dictionary<string,object>>> DataSetToDic(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> result =new  Dictionary<string, List<Dictionary<string, object>>>();
            foreach (DataTable dt in ds.Tables)
                DataTableToList(dt);
            return result;

        }

        /// <summary>
        /// 数据表转JSON
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJSON(DataTable dt) => ObjectToJSON(DataTableToList(dt));

        /// <summary>
        /// json转数据表
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static Dictionary<string,List<Dictionary<string,object>>> TableDataFromJSON(string jsonStr)
        {
            return JSONToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonStr);
        }

        /// <summary>
        /// json转数据行
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static Dictionary<string, object> DataRowFromJSON(string jsonStr) => JSONToObject<Dictionary<string, object>>(jsonStr);
       
    }
}
