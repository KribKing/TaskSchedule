using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using TaskSchedule.Core;
using TaskSchedule.Core.Schema;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.CloudHis
{
    public class RunInterface : IRunInterface
    {
        public JobInfoCloudHis Cur_Job { get; set; }
        public RunInterface(JobInfo info)
        {
            this.Cur_Job = info as JobInfoCloudHis;
        }
        public void Run()
        {
            try
            {
                this.ExcuteDataBaseBulk(this.RunWithBody(this.WebRequest()));
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】Run发生异常：" + ex.Message, ex);
            }
        }
        public void ExcuteDataBaseBulk(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0) return;
            string connstring = this.Cur_Job.targetdbstring;
            string createtmp = this.Cur_Job.createtmp;
            string tmpname = this.Cur_Job.tmpname;
            string strsql = this.Cur_Job.targetsql;
            GlobalInstanceManager<GlobalSqlManager>.Intance.BulkDb(0, connstring, createtmp, tmpname, strsql, dt);
        }
        public DataTable RunWithBody(string retxml)
        {
            try
            {
                DataSet ds = Tools.CXmlToDataSet(retxml);
                DataTable resDt = ds.Tables["RESULT"] ?? null;

                if (resDt == null || resDt.Rows.Count <= 0)
                {
                    Log4netUtil.Warn("作业【" + this.Cur_Job.name + "】结果表未返回：" + retxml);
                    return null;
                }
                if (resDt.Rows[0]["RST"].ToString() != "T")
                {
                    Log4netUtil.Warn("作业【" + this.Cur_Job.name + "】结果表返回错误：" + retxml);
                    return null;
                }
                DataTable jgDt = ds.Tables[this.Cur_Job.businesstable] ?? null;
                return jgDt;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】RunWithBody发生异常：" + ex.Message, ex);
                return null;
            }
        }
        public virtual string WebRequest()
        {
            try
            {
                string requestxml = string.Format(this.Cur_Job.requestxml, DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                string userid = this.Cur_Job.isencode ? SecurityHelper.DESEnCode(this.Cur_Job.CloudUserId, this.Cur_Job.Key) : this.Cur_Job.CloudUserId;
                string password = this.Cur_Job.isencode ? SecurityHelper.DESEnCode(this.Cur_Job.CloudUserPassword, this.Cur_Job.Key) : this.Cur_Job.CloudUserPassword;
                string xml = this.Cur_Job.isencode ? SecurityHelper.DESEnCode(this.Cur_Job.requestxml, this.Cur_Job.Key) : this.Cur_Job.requestxml;
                string retxml = "";
                using (WebReference.NetHisWebService websrv = new WebReference.NetHisWebService())
                {
                    websrv.Url = this.Cur_Job.weburl;
                    retxml = websrv.nethis_common_business(userid, password, this.Cur_Job.businesscode, xml);
                }
                Log4netUtil.Info("作业【" + this.Cur_Job.name + "】Run出参：" + retxml);
                return retxml;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】WebRequest发生异常：" + ex.Message, ex);
                return "";
            }
        }

        public DataTable GetTmpTable()
        {
            return RunWithBody(WebRequest());
        }
    }
}
