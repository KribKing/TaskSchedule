using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DownLoad.Core;
using Newtonsoft.Json;

namespace DownLoad.Business
{
    /// <summary>
    /// Web服务Xml接口
    /// </summary>
    public class JkInterfaceByWs : JkInterface
    {
        public JkInterfaceByWs(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj;
                retInfo = this.WebInvoke();
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
                Log4netUtil.Error("【" + cur_JobInfo.name + "】JkInterfaceByWs执行异常:" + ex.Message, ex);
            }
            return retInfo;
        }
        public  ResultInfo WebInvoke()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                WebServiceArgs list = JsonConvert.DeserializeObject<WebServiceArgs>(body);
                object[] args = null;
                if (list != null && list.ArgsList != null && list.ArgsList.Count > 0)
                {
                    args = new object[list.ArgsList.Count];
                    foreach (WebServiceArgsInfo item in list.ArgsList)
                    {
                        args.SetValue(item.Value, item.KeyIndex);
                    }
                }
                info.ackmsg = GlobalWebRequestHelper.SoapRequest(cur_JobInfo.weburl, cur_JobInfo.servermethod, args);
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
