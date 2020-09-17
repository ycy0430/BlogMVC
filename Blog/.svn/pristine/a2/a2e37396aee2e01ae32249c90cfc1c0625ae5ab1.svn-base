using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rui
{
    /// <summary>
    /// APP返回结果
    /// </summary>
    public class appReturnResult
    {
        //代表方法是否成功
        public bool result { get; set; }
        //返回的提示文本
        public string message { get; set; }

        //返回的附加数据(keyValue形式)
        public Dictionary<string,string> data { get; set; }

        public static appReturnResult getResult(bool result,string message)
        {
            appReturnResult obj = new appReturnResult();
            obj.result = result;
            obj.message = message;
            return obj;
        }

        /// <summary>
        /// 添加DataTable数据
        /// </summary>
        /// <param name="dtName"></param>
        /// <param name="dtData"></param>
        public void addTable(string dtName,DataTable dtData)
        {
            if (this.data == null)
                this.data = new Dictionary<string, string>();
            if (this.data.ContainsKey(dtName) == false)
                this.data.Add(dtName, rui.appReturnResult.dataTableToJson(dtData));
            else
                this.data[dtName] = rui.appReturnResult.dataTableToJson(dtData);
        }

        /// <summary>
        /// 添加key/value数据
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        public void addValue(string keyName,string keyValue)
        {
            if (this.data == null)
                this.data = new Dictionary<string, string>();
            if (this.data.ContainsKey(keyName) == false)
                this.data.Add(keyName, keyValue);
            else
                this.data[keyName] = keyValue;
        }

        /// <summary>
        /// 批量添加键值对
        /// </summary>
        /// <param name="dic"></param>
        public void addDic(Dictionary<string,string> dic)
        {
            if (dic == null)
                return;

            foreach (string key in dic.Keys)
                addValue(key, dic[key]);
        }

        /// <summary>
        /// 通过反射将实体中包含的属性及其值加入到dic中
        /// </summary>
        /// <param name="entry"></param>
        public void addEntry(object entry)
        {
            foreach (System.Reflection.PropertyInfo p in entry.GetType().GetProperties())
            {
                if(this.data.ContainsKey(p.Name)==false)
                {
                    this.data.Add(p.Name, rui.typeHelper.toString(p.GetValue(entry)));
                }
            }
        }

        /// <summary>
        /// 把dataTable转为json
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string dataTableToJson(DataTable table)
        {
            if (table.Rows.Count == 0)
                return "";

            JsonData data = new JsonData();
            foreach (DataRow row in table.Rows)
            {
                JsonData item = new JsonData();
                foreach(DataColumn col in table.Columns)
                {
                    item[col.ColumnName] = rui.typeHelper.toString(row[col.ColumnName]);
                }
                data.Add(item);
            }
            return data.ToJson();
        }
    }

}
