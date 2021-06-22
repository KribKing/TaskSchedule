using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DownLoad.Core.Schema
{
    [Serializable]
    public class SchemaInfo
    {
        /// <summary>
        /// 执行节点
        /// </summary>
        public string ExecuteNode { get; set; }
        /// <summary>
        /// xml命名空间
        /// </summary>
        public string RemoveNs { get; set; }
        private string _CData;
        /// <summary>
        /// 元数据文本
        /// </summary>
        public string CData
        {
            get { return _CData; }
            set { _CData = value; }
        }

        /// <summary>
        /// 表定义结构
        /// </summary>
        public List<TableSchema> TableSchema { get; set; }
        public override string ToString()
        {
            return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(this)).ToString();
        }
        public DataTable ToDt()
        {
            DataTable dt = new DataTable();
            if (TableSchema == null)
                return dt;

            foreach (TableSchema item in TableSchema)
            {
                DataColumn dc = new DataColumn(item.column);
                dt.Columns.Add(dc);
            }
            return dt;
        }
    }
}
