using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwitchConfig
{
    [Serializable]
    public class JobNewInfo
    {

        private Guid _guid=Guid.NewGuid();

        public Guid GuId
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// 作业ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 作业名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 作业大类
        /// </summary>
        public string system { get; set; }
        /// <summary>
        /// 作业大类名称
        /// </summary>
        public string sysname { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string oper_date { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string expression { get; set; }

        /// <summary>
        /// 创建临时表脚本
        /// </summary>
        public string createtmp { get; set; }
        /// <summary>
        /// 临时表名
        /// </summary>
        public string tmpname { get; set; }
        /// <summary>
        /// 解析数据类型 0：json 1：xml
        /// </summary>
        public int nodelx { get; set; }
        /// <summary>
        /// 解析节点
        /// </summary>
        public string node { get; set; }
        /// <summary>
        /// xml解析配置
        /// </summary>
        public string xmlconfig { get; set; }
        /// <summary>
        /// 数据源类型 0:服务 1:数据库
        /// </summary>
        public int sourcetype { get; set; }
        /// <summary>
        /// 源数据库类型
        /// </summary>
        public int sourcedbtype { get; set; }
        /// <summary>
        /// 源数据库地址
        /// </summary>
        public string sourcedbstring { get; set; }
        /// <summary>
        /// 数据源脚本
        /// </summary>
        public string sourcesql { get; set; }
        /// <summary>
        /// 目标数据库类型
        /// </summary>
        public int targetdbtype { get; set; }
        /// <summary>
        /// 目标数据库地址
        /// </summary>
        public string targetdbstring { get; set; }
        /// <summary>
        /// 目标库脚本
        /// </summary>
        public string targetsql { get; set; }
        /// <summary>
        /// 是否批量操作
        /// </summary>
        public bool isbulkop { get; set; }
        /// <summary>
        /// 服务类型 0:http 1:ws 2:rest
        /// </summary>
        public int servertype { get; set; }
        /// <summary>
        /// 服务方法
        /// </summary>
        public string servermethod { get; set; }
        /// <summary>
        /// web地址
        /// </summary>
        public string weburl { get; set; }
        /// <summary>
        /// 条件数据库类型
        /// </summary>
        public int tjdbtype { get; set; }
        /// <summary>
        /// 条件数据库地址
        /// </summary>
        public string tjdbconnect { get; set; }
    }
}
