using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class JobInfoManager
    {
        public Dictionary<JobKey, JobInfo> JobInfoDic = new Dictionary<JobKey, JobInfo>();
        public JobInfoManager()
        {
            this.ReInit();
        }
        public void ReInit()
        {
            JobInfoDic.Clear();
            string strsql = "select * from CronJob ";
            DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
            List<JobInfo> JobInfoList = Tools.ToDataList<JobInfo>(dt);

            foreach (JobInfo item in JobInfoList)
            {
                if (!string.IsNullOrEmpty(item.id) && !string.IsNullOrEmpty(item.system))
                {

                    if (!IsExists(item.id, item.system))
                    {
                        JobKey key = new JobKey(item.id, item.system);
                        item.createtmp = EncodeHelper.DecodeBase64(item.createtmp);
                        item.sql = EncodeHelper.DecodeBase64(item.sql);
                        item.xmlschema = EncodeHelper.DecodeBase64(item.xmlschema);
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
            List<JobInfo> list = Tools.Clone<JobInfo>(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.ToList());
            foreach (JobInfo item in list)
            {
                item.createtmp = EncodeHelper.EncodeBase64(item.createtmp);
                item.sql = EncodeHelper.EncodeBase64(item.sql);
                item.xmlschema = EncodeHelper.EncodeBase64(item.xmlschema);
            }
            DataTable dt = Tools.ToDataTable<JobInfo>(list);         
            ResultInfo retInfo = new ResultInfo();
            JobInfo adminjob=GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo("Admin00","Admin");
            TSqlHelper.SqlBulkCopyByRims(adminjob.createtmp, adminjob.tmpname, dt, adminjob.sql, ref retInfo);
            if (!retInfo.ackcode.Contains("100"))
            {
                //MessageBox.Show(retInfo.ackmsg);
                GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(string.Format("作业保存发生异常，原因：" + retInfo.ackmsg));
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
            string strsql = "exec usp_jk_getjobzxtj @id='" + id + "',@system='" + system + "'";
            DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
            if (dt == null || dt.Rows.Count <= 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();
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
        public string sql { get; set; }
        /// <summary>
        /// 解析数据类型 0：json 1：xml
        /// </summary>
        public int nodelx { get; set; }
        /// <summary>
        /// 解析节点
        /// </summary>
        public string node { get; set; }
        /// <summary>
        /// 作业类型 0：远程服务批量插入数据 1：数据库作业
        /// </summary>
        public int zylx { get; set; }

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
    }
}
