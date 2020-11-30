using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class JobInfoManager
    {
        public Dictionary<JobKey, JobInfo> JobInfoDic = new Dictionary<JobKey, JobInfo>();
        private readonly string configPath = Application.StartupPath + "//SetConfig.xml";
        private int cur_dbtype = 0;
        private string cur_dbconstring = "";
        public JobInfoManager()
        {
            this.ReInit();
        }
        public JobInfoManager(int dbtype,string connstring)
        {
            this.cur_dbtype = dbtype;
            this.cur_dbconstring = connstring;
            this.ReInit();
          
        }
        public void ReInit()
        {
            JobInfoDic.Clear();
            //string strsql = "select * from CronJob ";
            //DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
            if (!File.Exists(configPath))
                return;
            DataTable dt = new DataTable();
            dt.ReadXml(configPath);
            List<JobInfo> JobInfoList = Tools.ToDataList<JobInfo>(dt);

            foreach (JobInfo item in JobInfoList)
            {
                if (!string.IsNullOrEmpty(item.id) && !string.IsNullOrEmpty(item.system))
                {
                    if (!IsExists(item.id, item.system))
                    {
                        JobKey key = new JobKey(item.id, item.system);
                        item.createtmp = EncodeHelper.DecodeBase64(item.createtmp);
                        item.targetsql = EncodeHelper.DecodeBase64(item.targetsql);
                        item.sourcesql = EncodeHelper.DecodeBase64(item.sourcesql);
                        item.xmlschema = EncodeHelper.DecodeBase64(item.xmlschema);
                        item.sourcedbstring = EncodeAndDecode.Decode(item.sourcedbstring);
                        item.targetdbstring = EncodeAndDecode.Decode(item.targetdbstring);
                        item.CreatJob();
                        this.JobInfoDic.Add(key, item);
                    }
                }
            }
        }
        public bool IsExists(string id, string system)
        {
            var lkey = JobInfoDic.Keys.Where(a => { return a.Name == id && a.Group == system; });
            if (lkey.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddJobInfo(JobInfo jobInfo)
        {
            if (IsExists(jobInfo.id, jobInfo.system))
                return true;
            try
            {
                JobKey key = new JobKey(jobInfo.id, jobInfo.system);
                jobInfo.CreatJob();
                this.JobInfoDic.Add(key, jobInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public void SaveJobInfo()
        {
            try
            {
                List<JobInfo> list = Tools.Clone<JobInfo>(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.ToList());
                foreach (JobInfo item in list)
                {
                    item.createtmp = EncodeHelper.EncodeBase64(item.createtmp);
                    item.targetsql = EncodeHelper.EncodeBase64(item.targetsql);
                    item.sourcesql = EncodeHelper.EncodeBase64(item.sourcesql);
                    item.xmlschema = EncodeHelper.EncodeBase64(item.xmlschema);
                    item.sourcedbstring = EncodeAndDecode.Encode(item.sourcedbstring);
                    item.targetdbstring = EncodeAndDecode.Encode(item.targetdbstring);
                }
                DataTable dt = Tools.ToDataTable<JobInfo>(list);
                dt.TableName = "CronJob";
              
                dt.WriteXml(configPath,XmlWriteMode.WriteSchema, true);
                //JobInfo adminjob = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo("Admin00", "Admin");
            }
            catch (Exception ex)
            {
                GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(string.Format("作业保存发生异常，原因：" + ex.Message));
            }
        }
        public JobInfo GetJobInfo(string id, string system)
        {
            if (this.JobInfoDic == null)
                return new JobInfo();
            foreach (var item in this.JobInfoDic)
            {
                if (item.Key.Name == id && item.Key.Group == system)
                {
                    return this.JobInfoDic[item.Key];
                }
            }
            return new JobInfo();
        }
        public JobInfo GetJobInfo(JobKey key)
        {
            return this.GetJobInfo(key.Name, key.Group);
        }

        public string GetExcuteCondition(JobKey jobKey)
        {
            return this.GetExcuteCondition(jobKey.Name, jobKey.Group);
        }
        public string GetExcuteCondition(JobInfo jobInfo)
        {
            return this.GetExcuteCondition(jobInfo.id, jobInfo.system);
        }
        public string GetExcuteCondition(string id, string system)
        {
            try
            {
                string strsql = "exec usp_jk_getjobzxtj @id='" + id + "',@system='" + system + "'";
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.cur_dbtype, this.cur_dbconstring, strsql);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return "";
                }
                else
                {
                    return dt.Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
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
                        if (jlzt == "0")
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
                        this.RefreshJlzt();
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
        private string _serverMethod="POST";

        public string servermethod
        {
            get { return _serverMethod; }
            set { _serverMethod = value; }
        }
        
    }
    
}
