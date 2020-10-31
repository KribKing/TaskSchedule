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
        public virtual void ExcuteDataBase(DataTable dt, ref ResultInfo retInfo)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string createtmp = this.cur_JobInfo.createtmp;
                string tmpname = this.cur_JobInfo.tmpname;
                string strsql = this.cur_JobInfo.sql;
                TSqlHelper.SqlBulkCopyByRims(createtmp, tmpname, dt, strsql, ref retInfo);
            }
            else
            {
                retInfo.ackmsg = "接口无返回数据";
                retInfo.ackflg = true;
            }
        }
    }
    /// <summary>
    /// Web服务Json接口
    /// </summary>
    public class JsonWsJkInterface : JkInterface
    {
        public JsonWsJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj.ToString();
                retInfo = base.PostResponse();
                if (retInfo.ackflg)
                {
                    DataTable dt = Tools.JsonToDataTable(Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString());
                    base.ExcuteDataBase(dt, ref retInfo);
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
    /// <summary>
    /// Web服务Xml接口
    /// </summary>
    public class XmlWsJkInterface : JkInterface
    {
        public XmlWsJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj.ToString();
                retInfo = base.PostResponse();
                if (retInfo.ackflg)
                {
                    DataTable dt = Tools.JsonToDataTable(Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString());
                    base.ExcuteDataBase(dt, ref retInfo);
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public class DbJkInterface : JkInterface
    {
        public DbJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = this.cur_JobInfo.sql;
                DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    retInfo.ackmsg = "无返回数据";
                    retInfo.ackflg = false;
                }
                else
                {
                    retInfo.ackflg = dt.Rows[0][0].ToString() == "T";
                    retInfo.ackmsg = dt.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
}
