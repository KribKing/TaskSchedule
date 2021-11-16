using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using TaskSchedule.Business.SyncData.Impl;
using TaskSchedule.Core;
using TaskSchedule.Core.Schema;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData
{
    public class RunInterface : IRunInterface
    {
        public JobInfoSyncData Cur_Job { get; set; }
        public RunInterface(JobInfo info)
        {
            this.Cur_Job = info as JobInfoSyncData;
        }
        public virtual void Run()
        {
            Log4netUtil.Warn("无任务信息执行");
            return;
        }
        public virtual void ExcuteDataBaseBulk(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                int dbtype = this.Cur_Job.targetdbtype;
                string connstring = this.Cur_Job.targetdbstring;
                string createtmp = this.Cur_Job.createtmp;
                string tmpname = this.Cur_Job.tmpname;
                string strsql = this.Cur_Job.targetsql;
                GlobalInstanceManager<GlobalSqlManager>.Intance.BulkDb(dbtype, connstring, createtmp, tmpname, strsql, dt);
            }
            else
            {
                Log4netUtil.Info("作业【" + this.Cur_Job.name + "】接口无返回数据");
            }
        }
        public virtual DataTable RunWithBody(string strresult)
        {
            try
            {
                DataTable dt = null;
                if (this.Cur_Job.nodelx == 0)
                {
                    string jarray = Tools.GetJsonNodeValue(strresult, this.Cur_Job.node, "[]").ToString();
                    dt = Tools.JsonToDataTable(jarray);
                }
                else if (this.Cur_Job.nodelx == 1)
                {
                    SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(this.Cur_Job.xmlconfig);
                    XmlDocument xml = XmlHelper.RemoveNameSpace(strresult, info.RemoveNs);
                    if (string.IsNullOrEmpty(this.Cur_Job.node))
                    {
                        Log4netUtil.Error("作业【" + this.Cur_Job.name + "】RunWithBody发生异常：解析节点设置为空，无法继续");
                        return null;
                    }
                    dt = XmlHelper.XmlToDataTable(info.ExecuteNode, info, xml);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message, ex);
                return null;
            }
        }
        public virtual string WebRequest()
        {
            return "";
        }

    }
}
