using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class JyOperator : JkInterface
    {
        public JyOperator(string jkcode, string url)
            : base(jkcode, url, "lab/report", "")
        {

        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strtime = GetTimeStamp(false);
                string pas = "DFTYBN78GH3DU875FGY767JGD335680IHFW3";
                string strmd5 = EncodeHelper.MD5Encrypt(pas + strtime);
                string strhead = "{"
                            + "\"token\":\"" + strmd5 + "\","
                            + "\"time\":\"" + strtime + "\","
                            + "\"fromtype\":\"zongbuzhiliao\""
                                         + "}";

                string strbody = "{"
                                 + "\"cpatientcode\":\"3520283467\""
                                + "}";
                base.body = "jsonData={ "
                            + "\"head\":\"" + EncodeHelper.EncodeBase64(strhead) + "\","
                            + "\"body\":\"" + EncodeHelper.EncodeBase64(strbody) + "\""
                          + "}".Replace("+", "%2B");
                retInfo = GetResponse();
                //Result r = JsonConvert.DeserializeObject<Result>(retInfo.ackmsg);
                //string jsonhead = EncodeHelper.DecodeBase64(r.head.Replace("%2B", "+"));
                //string jsonbody = EncodeHelper.DecodeBase64(r.body.Replace("%2B", "+"));
                if (retInfo.ackflg)
                {
                    Result list = JsonConvert.DeserializeObject<Result>(retInfo.ackmsg);
                    if (list != null)
                    {
                        DataTable dt = null; //Tools.ToDataTable<DeptInfo>(list);
                        if (dt != null)
                        {
                            //string createtmp = (jobj["createtmp"] ?? "").ToString();
                            //string tmpname = (jobj["tmpname"] ?? "").ToString();
                            //string strsql = (jobj["sql"] ?? "").ToString();
                            string createtmp = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].createtmp;
                            string tmpname = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].tmpname;
                            string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].sql;
                            retInfo = TSqlHelper.SqlBulkCopyByRims(createtmp, tmpname, dt, strsql);
                        }
                        else
                        {
                            retInfo.ackcode = "100.0";
                            retInfo.ackflg = true;
                            retInfo.ackmsg = "成功无数据";
                        }
                    }
                    else
                    {
                        retInfo.ackflg = true;
                        retInfo.ackcode = "100.0";
                        retInfo.ackmsg = "成功无数据";
                    }
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

        public override ResultInfo GetResponse()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.HttpPostRequest(url + method, body, contentttype: "x-www-form-urlencoded");
                info.ackflg = true;
            }
            catch (Exception ex)
            {
                info.ackmsg = ex.Message;
                info.ackflg = false;
            }
            return info;
        }
        public string GetTimeStamp(bool bflag = true)
        {
            TimeSpan span = (TimeSpan)(DateTime.UtcNow - new DateTime(0x7b2, 1, 1, 0, 0, 0, 0));
            if (bflag)
            {
                return Convert.ToInt64(span.TotalSeconds).ToString();
            }
            return Convert.ToInt64(span.TotalMilliseconds).ToString();
        }
    }
    public class Result
    {
        public string head { get; set; }
        public string body { get; set; }
    }

}
