using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData.Impl
{
    public class RunInterfaceByRest : RunInterface
    {
        public RunInterfaceByRest(JobInfo info)
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
                Log4netUtil.Error("【" + this.Cur_Job.name + "】RunInterfaceByRest执行异常:" + ex.Message, ex);
            }
        }
        public override string WebRequest()
        {
            string result = "";
            try
            {
                result = GlobalWebRequestHelper.RestRequest(this.Cur_Job.weburl, this.Cur_Job.servermethod, this.Cur_Job.GetExcuteCondition(), this.Cur_Job.node);

            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】RunInterfaceByRest执行异常:" + ex.Message, ex);
                result = "";
            }
            return result;
        }
    }
}
