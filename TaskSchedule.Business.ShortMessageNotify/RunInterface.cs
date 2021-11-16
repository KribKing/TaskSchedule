using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;
using TaskSchedule.Business.ShortMessageNotify.Impl;

namespace TaskSchedule.Business.ShortMessageNotify
{
    public class RunInterface : IRunInterface
    {
        public JobInfoShortMessage Cur_Job { get; set; }
        public RunInterface(JobInfo info)
        {
            this.Cur_Job = info as JobInfoShortMessage;
        }
        public virtual void Run()
        {
            throw new NotImplementedException();
        }
        public void PostRequest(string body)
        {
            try
            {
                GlobalWebRequestHelper.HttpPostRequest(this.Cur_Job.weburl, body);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】PostRequest推送异常:" + ex.Message + "|参数：" + body, ex);
            }
        }
    }
}
