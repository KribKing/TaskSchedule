using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class TargetDbJkInterface : JkInterface
    {
        public TargetDbJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = this.cur_JobInfo.TargetSql;
                string connstring = this.cur_JobInfo.IsTargetDbEncode ? EncodeAndDecode.Decode(this.cur_JobInfo.TargetDbString) : this.cur_JobInfo.TargetDbString;
                int renum= GlobalInstanceManager<GlobalSqlManager>.Intance.ExecuteNoneQuery(this.cur_JobInfo.TargetDbType, connstring, this.cur_JobInfo.TargetSql);
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
