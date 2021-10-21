using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using System.Configuration;
using System.Data;
using Quartz;
using System.Diagnostics;
using System.Xml;
using TaskSchedule.Core.Schema;

namespace TaskSchedule.Business
{
    public class JkInterface
    {
        public static DTToken TokenInfo = new DTToken();
        protected JobInfo cur_JobInfo;
        protected string method;
        protected string body;
        public JkInterface()
        {

        }
        public JkInterface(JobInfo cur_jkkey, string cur_method, string cur_body)
        {
            cur_JobInfo = cur_jkkey;
            method = cur_method;
            body = cur_body;
        }       
        public static void GetToken(string weburl)
        {
            try
            {
                string url = weburl + "getAccessToken";
                string body = string.Format("?uid={0}&appSecret={1}", ConfigurationManager.AppSettings["userid"].ToString(), ConfigurationManager.AppSettings["appsecret"].ToString());
                string strresult = GlobalWebRequestHelper.HttpGetRequest(url, body);
                DTToken jobj = JsonConvert.DeserializeObject<DTToken>(strresult);
                JkInterface.TokenInfo = jobj;
            }
            catch (Exception ex)
            {
                //Log4netUtil.Error("【" + cur_JobInfo.name + "】执行异常:" + ex.Message, ex);
                JkInterface.TokenInfo = new DTToken() { success = false };
            }
        }
        public virtual ResultInfo Run(string jobj)
        {
            return new ResultInfo() { ackflg = false, ackcode = "100.3", ackmsg = "接口尚未实现" };
        }

        internal static void GetToken()
        {
            throw new NotImplementedException();
        }
        public virtual void ExcuteDataBaseBulk(DataTable dt, ref ResultInfo retInfo)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                int dbtype = this.cur_JobInfo.targetdbtype;
                string connstring = this.cur_JobInfo.targetdbstring;
                string createtmp = this.cur_JobInfo.createtmp;
                string tmpname = this.cur_JobInfo.tmpname;
                string strsql = this.cur_JobInfo.targetsql;
                GlobalInstanceManager<GlobalSqlManager>.Intance.BulkDb(dbtype, connstring, createtmp, tmpname, strsql, dt, ref retInfo);
            }
            else
            {
                retInfo.ackmsg = "接口无返回数据";
                retInfo.ackflg = true;
            }
        }

        public virtual DataTable RunWithBody(string strresult, ref ResultInfo retInfo)
        {
            try
            {
                DataTable dt = null;
                if (this.cur_JobInfo.nodelx == 0)
                {
                    string jarray = Tools.GetJsonNodeValue(strresult, this.cur_JobInfo.node, "[]").ToString();
                    dt = Tools.JsonToDataTable(jarray);
                }
                else if (this.cur_JobInfo.nodelx == 1)
                {
                    SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(this.cur_JobInfo.xmlconfig);
                    XmlDocument xml = XmlHelper.RemoveNameSpace(strresult, info.RemoveNs);
                    if (string.IsNullOrEmpty(this.cur_JobInfo.node))
                    {
                        Log4netUtil.Error("RunWithBody发生异常：解析节点设置为空，无法继续");
                        return null;
                    }
                    dt = XmlHelper.XmlToDataTable(info.ExecuteNode, info, xml);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message,ex);
                return null;
            }
        }
    }


    public class WebServiceArgs
    {
        public List<WebServiceArgsInfo> ArgsList { get; set; }
    }
    public class WebServiceArgsInfo
    {
        public int KeyIndex { get; set; }
        public string Value { get; set; }

    }
}
