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
                retInfo = base.WebInvoke();
                if (retInfo.ackflg)
                {
                    string jarray = Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString();
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
