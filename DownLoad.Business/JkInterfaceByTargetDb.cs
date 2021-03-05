using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DownLoad.Core;

namespace DownLoad.Business
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
                string connstring =this.cur_JobInfo.targetdbstring;
                int renum= GlobalInstanceManager<GlobalSqlManager>.Intance.ExecuteNoneQuery(this.cur_JobInfo.targetdbtype, connstring, this.cur_JobInfo.targetsql);
                if (renum<0)
                {
                    retInfo.ackcode = "100.1";
                    retInfo.ackmsg = "无执行记录";
                    retInfo.ackflg = false;
                }
                else
                {
                    retInfo.ackcode = "100.0";
                    retInfo.ackmsg = "执行成功";
                    retInfo.ackflg = true;
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
