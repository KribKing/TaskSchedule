using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData.Impl
{
    public class RunInterfaceByHttp : RunInterface
    {
        public RunInterfaceByHttp(JobInfo info)
            : base(info)
        {

        }
        public override void Run()
        {
            try
            {              
                DataTable dt = base.RunWithBody(this.WebRequest());
                this.ExcuteDataBaseBulk(dt);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】JkInterfaceByHttp执行异常:" + ex.Message, ex);
            }
        }

        public override string WebRequest()
        {          
            string result = "";
            try
            {
                result = this.Cur_Job.servermethod.ToLower() == "get" ? GlobalWebRequestHelper.HttpGetRequest(this.Cur_Job.weburl, this.Cur_Job.GetExcuteCondition()) : GlobalWebRequestHelper.HttpPostRequest(this.Cur_Job.weburl, this.Cur_Job.GetExcuteCondition());
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】执行WebRequest异常:" + ex.Message, ex);
                result = "";
            }
            return result;
        }
    }
}
