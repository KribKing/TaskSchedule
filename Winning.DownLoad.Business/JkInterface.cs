using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;
using System.Configuration;
using System.Data;
using Quartz;
using System.Diagnostics;

namespace Winning.DownLoad.Business
{
    public abstract class JkInterface
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
        public virtual ResultInfo GetResponse()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.HttpGetRequest(cur_JobInfo.weburl + method, body, token: TokenInfo.access_token);
                info.ackflg = true;
            }
            catch (Exception ex)
            {
                info.ackmsg = ex.Message;
                info.ackflg = false;
            }
            return info;
        }
        public virtual ResultInfo PostResponse()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.HttpPostRequest(cur_JobInfo.weburl + method, body, token: TokenInfo.access_token);
                info.body = info.ackmsg;
                info.ackflg = true;
            }
            catch (Exception ex)
            {
                info.ackcode = "300.0";
                info.ackmsg = ex.Message;
                info.ackflg = false;
            }
            return info;
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
                JkInterface.TokenInfo = new DTToken() { success = false };
            }
        }
        public virtual ResultInfo Run(JObject jobj)
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
                int dbtype = this.cur_JobInfo.TargetDbType;
                string connstring = this.cur_JobInfo.IsTargetDbEncode ? EncodeAndDecode.Decode(this.cur_JobInfo.TargetDbString) : this.cur_JobInfo.TargetDbString;
                string createtmp = this.cur_JobInfo.createtmp;
                string tmpname = this.cur_JobInfo.tmpname;
                string strsql = this.cur_JobInfo.TargetSql;
                GlobalInstanceManager<GlobalSqlManager>.Intance.BulkDb(dbtype, connstring, createtmp, tmpname, strsql, dt, ref retInfo);
            }
            else
            {
                retInfo.ackmsg = "接口无返回数据";
                retInfo.ackflg = true;
            }
        }
    }
   
    
    
}
