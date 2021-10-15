using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Business
{
    public class JkInterfaceByTargetDb : JkInterface
    {
        public JkInterfaceByTargetDb(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = this.cur_JobInfo.targetsql;
                string connstring = this.cur_JobInfo.targetdbstring;
                int renum = GlobalInstanceManager<GlobalSqlManager>.Intance.ExecuteNoneQuery(this.cur_JobInfo.targetdbtype, connstring, this.cur_JobInfo.targetsql);
                retInfo.ackcode = renum < 0 ? "100.1" : "100.0";
                retInfo.ackmsg = renum < 0 ? "无执行记录" : "执行成功";
                retInfo.ackflg = renum < 0 ? false : true;
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
                Log4netUtil.Error("【" + cur_JobInfo.name + "】JkInterfaceByTargetDb执行异常:" + ex.Message,ex);
            }
            return retInfo;
        }
    }
}
