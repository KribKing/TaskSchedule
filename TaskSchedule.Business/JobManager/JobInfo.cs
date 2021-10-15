using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Business
{
    [Serializable]
    public class JobInfo
    {
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
        /// web地址
        /// </summary>
        public string weburl { get; set; }
        private string _expression;
        /// <summary>
        /// 表达式
        /// </summary>
        public string expression
        {
            get
            {
                return _expression;
            }
            set
            {
                if (_expression == null)
                {
                    _expression = value;
                }
                else
                {
                    string oldexp = _expression;
                    if (oldexp != value && !string.IsNullOrWhiteSpace(value))
                    {
                        _expression = value;
                        if (jlzt == "0" && !string.IsNullOrWhiteSpace(this.id))
                        {
                            this.RefreshTrigger();
                        }
                    }
                }

            }
        }
        /// <summary>
        /// 创建临时表脚本
        /// </summary>
        public string createtmp { get; set; }
        /// <summary>
        /// 临时表名
        /// </summary>
        public string tmpname { get; set; }
        /// <summary>
        /// 同步脚本
        /// </summary>
        public string targetsql { get; set; }
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


        private string _jlzt = "0";
        /// <summary>
        /// 记录状态 0：执行 1：停止
        /// </summary>
        public string jlzt
        {
            get
            {
                return _jlzt;
            }
            set
            {
                if (_jlzt == null)
                {
                    _jlzt = value;
                }
                else
                {
                    string old = _jlzt;
                    if (old != value && !string.IsNullOrWhiteSpace(value))
                    {
                        _jlzt = value;
                        if (!string.IsNullOrWhiteSpace(this.id))
                        {
                            this.RefreshJlzt();
                        }
                    }
                }

            }
        }

        public void CreatJob()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.CreatJob(this);
        }
        private void RefreshTrigger()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.RefreshTrigger(this);
        }

        private void RefreshJlzt()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.RefreshJlzt(this);
        }

        public string xmlschema { get; set; }
        /// <summary>
        /// 数据源类型 0:服务 1:数据库
        /// </summary>
        public int sourcetype { get; set; }
        /// <summary>
        /// 源数据库类型
        /// </summary>
        public int sourcedbtype { get; set; }
        /// <summary>
        /// 源数据库是否加密
        /// </summary>
        public bool issourcedbencode { get; set; }
        public string sourcedbstring { get; set; }
        public string sourcesql { get; set; }
        public int targetdbtype { get; set; }
        public bool istargetdbencode { get; set; }
        public string targetdbstring { get; set; }
        /// <summary>
        /// 是否批量操作
        /// </summary>
        public bool isbulkop { get; set; }
        /// <summary>
        /// 服务类型 0:http 1:ws
        /// </summary>
        public int servertype { get; set; }
        private string _serverMethod = "POST";

        public string servermethod
        {
            get { return _serverMethod; }
            set { _serverMethod = value; }
        }
        public JobInfo Copy()
        {
            JobInfo newinfo = Tools.CloneSingle<JobInfo>(this);
            newinfo.id = "";
            newinfo.jlzt = "1";
            return newinfo;
        }
    }
}
