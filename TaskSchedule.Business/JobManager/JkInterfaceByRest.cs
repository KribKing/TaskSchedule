using TaskSchedule.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TaskSchedule.Business
{
    public class JkInterfaceByRest:JkInterface
    {
        public JkInterfaceByRest(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj;

                retInfo = this.RestRequest();

                if (retInfo.ackflg)
                {
                    DataTable dt=base.RunWithBody(retInfo.body, ref retInfo);
                    this.ExcuteDataBaseBulk(dt, ref retInfo);
                }
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
                Log4netUtil.Error("【" + cur_JobInfo.name + "】JkInterfaceByRest执行异常:" + ex.Message, ex);
            }
            return retInfo;
        }

        public ResultInfo RestRequest()
        {
            ResultInfo info = new ResultInfo();
            try
            {
                info.ackmsg = GlobalWebRequestHelper.RestRequest(cur_JobInfo.weburl, cur_JobInfo.servermethod,body,cur_JobInfo.node);
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
