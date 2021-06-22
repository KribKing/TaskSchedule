using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DownLoad.Core;

namespace DownLoad.Business
{
    /// <summary>
    /// Web服务Json接口
    /// </summary>
    public class JkInterfaceByHttp : JkInterface
    {
        public JkInterfaceByHttp(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj;

                retInfo = this.cur_JobInfo.servermethod.ToLower() == "get" ? this.GetRequest() : this.PostRequest();

                if (retInfo.ackflg)
                {
                    DataTable dt = base.RunWithBody(retInfo.body, ref retInfo);
                    this.ExcuteDataBaseBulk(dt, ref retInfo);
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
                Log4netUtil.Error("【" + cur_JobInfo.name + "】JkInterfaceByHttp执行异常:" + ex.Message, ex);
            }
            return retInfo;
        }
        public ResultInfo GetRequest()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.HttpGetRequest(cur_JobInfo.weburl + method, body, token: TokenInfo.access_token);
                info.body = info.ackmsg;
                info.ackflg = true;
            }
            catch (Exception ex)
            {
                info.ackcode = "300.0";
                info.ackmsg = ex.Message;
                info.ackflg = false;
                Log4netUtil.Error("【" + cur_JobInfo.name + "】执行异常:" + ex.Message, ex);
            }
            return info;
        }
        public ResultInfo PostRequest()
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
                Log4netUtil.Error("【" + cur_JobInfo.name + "】执行异常:" + ex.Message, ex);
            }
            return info;
        }
    }
}
