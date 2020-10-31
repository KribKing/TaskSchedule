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
            string strsql = "select * from RIMS_COM_SQL ";
            DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
            List<JobInfo> JobInfoList = Tools.ToDataList<JobInfo>(dt);

            foreach (JobInfo item in JobInfoList)
            {
                if (!string.IsNullOrEmpty(item.id) && !string.IsNullOrEmpty(item.system))
                {

                  if(!IsExists(item.id,item.system)){
                        JobKey key = new JobKey(item.id, item.system);
                        item.createtmp = EncodeHelper.DecodeBase64(item.createtmp);
                        item.sql = EncodeHelper.DecodeBase64(item.sql);
                        item.CreatJob();
                        this.JobInfoDic.Add(key, item);
                }
                }
            }
        }
        public bool IsExists(string id,string system)
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
            }
            DataTable dt = Tools.ToDataTable<JobInfo>(list);
            string strsql = "update a set a.expression=b.expression,a.tmpname=b.tmpname,a.createtmp=b.createtmp,a.sql=b.sql,a.weburl=b.weburl,a.jlzt=b.jlzt "
                         + " from RIMS_COM_SQL a(nolock) "
                         + " inner join RIMS_COM_SQLCOPY b(nolock) on a.id=b.id and a.system=b.system  drop table RIMS_COM_SQLCOPY";

            ResultInfo retInfo = new ResultInfo();
            TSqlHelper.SqlBulkCopyByRims(@"IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name='RIMS_COM_SQLCOPY')
                                                                BEGIN
	                                                                CREATE TABLE RIMS_COM_SQLCOPY
	                                                                (
	                                                                    id VARCHAR(32) PRIMARY KEY NOT NULL ,
	                                                                    name VARCHAR(1024), 
	                                                                    system VARCHAR(32), 
	                                                                    sysname VARCHAR(1024),
	                                                                    memo VARCHAR(1024), 
	                                                                    oper_date DATETIME,
	                                                                    sql VARCHAR(max),
	                                                                    weburl VARCHAR(1024),
	                                                                    createtmp VARCHAR(max),
	                                                                    tmpname VARCHAR(256),
	                                                                    expression VARCHAR(max),
	                                                                    jlzt SMALLINT 
	                                                                )
                                                                END 
                                                                ELSE 
                                                                BEGIN 
                                                                    TRUNCATE TABLE RIMS_COM_SQLCOPY
                                                                END ", "RIMS_COM_SQLCOPY", dt, strsql, ref retInfo);
            if (!retInfo.ackcode.Contains("100"))
            {
                //MessageBox.Show(retInfo.ackmsg);
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
            string strsql = "exec usp_rims_jk_getjobzxtj @id='" + jobKey.Name + "',@system='"+jobKey.Group+"'";
            DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
            if (dt==null||dt.Rows.Count<=0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
            
        }
        public string GetExcuteCondition(JobInfo jobInfo)
        {
            string strsql = "exec usp_rims_jk_getjobzxtj @id='" + jobInfo.id + "',@system='" + jobInfo.system + "'";
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
        public string GetExcuteCondition(string id,string system)
        {
            string strsql = "exec usp_rims_jk_getjobzxtj @id='" + id + "',@system='" + system + "'";
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
    }
}
