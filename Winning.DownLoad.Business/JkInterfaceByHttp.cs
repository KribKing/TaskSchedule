using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
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
                if (this.cur_JobInfo.servermethod.ToLower()=="get")
                {
                    retInfo = base.GetResponse();
                }
                else
                {
                    retInfo = base.PostResponse();
                }            
                if (retInfo.ackflg)
                {
                    Tools.log("原始json串："+retInfo.body);
                    string jarray = Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString();
                    Tools.log("返回json串：" + jarray);
                    DataTable dt = Tools.JsonToDataTable(jarray);
                    base.ExcuteDataBaseBulk(dt, ref retInfo);
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
