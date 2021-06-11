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
                    DataTable dt = base.RunWithBody(retInfo.body, ref retInfo);
                    this.ExcuteDataBaseBulk(dt, ref retInfo);
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
                Log4netUtil.Error("【" + cur_JobInfo.name + "】JkInterfaceByWs执行异常:" + ex.Message,ex);
            }
            return retInfo;
        }
    }
}
