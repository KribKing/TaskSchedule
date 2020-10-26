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
        public Dictionary<string, JobInfo> JobInfoDic = new Dictionary<string, JobInfo>();
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
                if (!string.IsNullOrEmpty(item.id))
                {
                    if (!JobInfoDic.Keys.Contains(item.id.ToLower()))
                    {
                        item.createtmp = EncodeHelper.DecodeBase64(item.createtmp);
                        item.sql = EncodeHelper.DecodeBase64(item.sql);
                        item.CreatJob();
                        JobInfoDic.Add(item.id.ToLower(), item);
                    }
                }
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
    }
    [Serializable]
    public class JobInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string system { get; set; }
        public string sysname { get; set; }
        public string memo { get; set; }
        public string oper_date { get; set; }
        public string weburl { get; set; }
        private string _expression;
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
        public string createtmp { get; set; }
        public string tmpname { get; set; }
        public string sql { get; set; }

        private string _jlzt = "0";
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
