using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Core;
using Dos.ORM;
using TaskSchedule.Core.Schema;
using System.Data.Common;
using System.Text.RegularExpressions;
//using Oracle.DataAccess.Client;

namespace TaskSchedule.Business
{
    public class JobInfoManager
    {
        public Dictionary<JobKey, JobInfo> JobInfoDic = new Dictionary<JobKey, JobInfo>();
        private readonly string configPath = Application.StartupPath + "//SetConfig.xml";
        private int cur_dbtype = 0;
        public int Cur_dbtype
        {
            get { return cur_dbtype; }
            set { cur_dbtype = value; }
        }

        private string cur_dbconstring = "";

        public string Cur_dbconstring
        {
            get { return cur_dbconstring; }
            set { cur_dbconstring = value; }
        }

        public JobInfoManager()
        {
            this.ReInit();
        }
        public JobInfoManager(int dbtype, string connstring)
        {
            this.cur_dbtype = dbtype;
            this.cur_dbconstring = connstring;
            this.ReInit();

        }
        public void ReInit()
        {
            JobInfoDic.Clear();
            if (!File.Exists(configPath)) return;
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
                        item.xmlconfig = EncodeAndDecode.Decode(item.xmlconfig);
                        item.CreatJob();
                        this.JobInfoDic.Add(key, item);
                    }
                }
            }
            this.InitScript();
        }
        private void InitScript()
        {
            try
            {              
                string result = File.ReadAllText(Path.Combine(Application.StartupPath, "Script.sql"), System.Text.Encoding.Default);
                if (!string.IsNullOrEmpty(result))
                {
                    result = Regex.Replace(result,@"\bgo\b"," ",RegexOptions.IgnoreCase);
                    var db = new DbSession(GlobalInstanceManager<GlobalSqlManager>.Intance.GetDbTyle(this.cur_dbtype), this.cur_dbconstring);
                    db.FromSql(result).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("执行初始化脚本失败" + ex.Message, ex);
            }
        }
        public bool IsExists(string id, string system)
        {
            var lkey = JobInfoDic.Keys.Where(a => { return a.Name == id && a.Group == system; });
            return lkey.Count() > 0;
        }
        public bool AddJobInfo(JobInfo jobInfo)
        {
            try
            {
                if (!IsExists(jobInfo.id, jobInfo.system))
                {
                    JobKey key = new JobKey(jobInfo.id, jobInfo.system);
                    jobInfo.CreatJob();
                    this.JobInfoDic.Add(key, jobInfo);
                }

                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                return true;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("增加作业执行异常:" + ex.Message, ex);
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
                    item.xmlconfig = EncodeAndDecode.Encode(item.xmlconfig);
                }
                DataTable dt = Tools.ToDataTable<JobInfo>(list);
                dt.TableName = "CronJob";
                dt.WriteXml(configPath, XmlWriteMode.WriteSchema, true);
                //JobInfo adminjob = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo("Admin00", "Admin");
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("保存作业执行异常:" + ex.Message, ex);
                //GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(string.Format("作业保存发生异常，原因：" + ex.Message));
            }
        }
        public bool RemoveJobInfo(JobInfo jobInfo)
        {
            if (!IsExists(jobInfo.id, jobInfo.system)) return true;
            try
            {
                JobKey key = new JobKey(jobInfo.id, jobInfo.system);
                this.JobInfoDic.Remove(key);
                GlobalInstanceManager<SchedulerManager>.Intance.DeleteJob(jobInfo);
                this.SaveJobInfo();
                return true;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("移除作业执行异常:" + ex.Message, ex);
                return false;
            }
        }
        public JobInfo GetJobInfo(string id, string system)
        {
            return this.JobInfoDic == null ? new JobInfo() : this.JobInfoDic.Values.First(a => a.id == id && a.system == system) ?? new JobInfo();
        }
        public JobInfo GetJobInfo(JobKey key)
        {
            return this.GetJobInfo(key.Name, key.Group);
        }
        public List<JobInfo> GetJobInfoListBySystemName(string systemname)
        {
            return this.JobInfoDic == null ? null : this.JobInfoDic.Values.Where(a => a.sysname.Trim() == systemname.Trim()).ToList();
        }
        public JobInfo GetFirstJobBySystemName(string systemname)
        {
            return this.JobInfoDic == null ? null : this.JobInfoDic.Values.First(a => a.sysname == systemname);
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
            string strexcute = "";
            try
            {
                DatabaseType type = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDbTyle(this.cur_dbtype);
                string paraid = type == (DatabaseType.Oracle | DatabaseType.MySql) ? "id" : "@id";
                string parasystem = type == (DatabaseType.Oracle | DatabaseType.MySql) ? "system" : "@system";
                var db = new DbSession(GlobalInstanceManager<GlobalSqlManager>.Intance.GetDbTyle(this.cur_dbtype), this.cur_dbconstring);

                DataTable dt = db.FromProc("usp_jk_getjobzxtj").AddInParameter(paraid, DbType.String, id).AddInParameter(parasystem, DbType.String, id).ToDataTable();
                strexcute = dt == null || dt.Rows.Count <= 0 ? "" : dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("获取作业执行条件异常[" + id + "]:[" + system + "]" + ex.Message, ex);
                strexcute = "";
            }
            return strexcute;
        }
    }


}
