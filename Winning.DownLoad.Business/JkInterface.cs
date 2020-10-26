using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;
using System.Configuration;
using System.Data;

namespace Winning.DownLoad.Business
{
    public abstract class JkInterface
    {
        public static DTToken TokenInfo = new DTToken();
        protected string jkcode;
        protected string url;
        protected string method;
        protected string body;
        public JkInterface()
        {

        }
        public JkInterface(string cur_jkcode, string cur_url, string cur_method, string cur_body)
        {
            jkcode = cur_jkcode;
            url = cur_url;
            method = cur_method;
            body = cur_body;
        }
        public virtual ResultInfo GetResponse()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.HttpGetRequest(url + method, body, token: TokenInfo.access_token);
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
                info.ackmsg =  GlobalWebRequestHelper.HttpPostRequest(url + method, body, token: TokenInfo.access_token);
                info.ackflg = true;
            }
            catch (Exception ex)
            {
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
        public virtual ResultInfo Run(string jkcode, JObject jobj)
        {
            return new ResultInfo() { ackflg = false, ackcode = "100.3", ackmsg = "接口尚未实现" };
        }

        internal static void GetToken()
        {
            throw new NotImplementedException();
        }
        public virtual void ExcuteDataBase(DataTable dt,ref ResultInfo retInfo)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                string createtmp = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[jkcode.ToLower()].createtmp;
                string tmpname = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[jkcode.ToLower()].tmpname;
                string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[jkcode.ToLower()].sql;
                //dt = Tools.DeleteSameRow(dt, "ID");
                string body = retInfo.ackmsg;
                retInfo = TSqlHelper.SqlBulkCopyByRims(createtmp, tmpname, dt, strsql);
                retInfo.body = body;
            }
            else
            {
                retInfo.ackmsg = "接口无返回数据";
                retInfo.ackflg = true;
            }
        }
    }
}
