using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;
using TaskSchedule.Business.PushMessage.Impl;
using TaskSchedule.Business.PushMessage.Model;
using Newtonsoft.Json;

namespace TaskSchedule.Business.PushMessage
{

    public class RunInterface : IRunInterface
    {
        public JobInfoPushMessage Cur_Job { get; set; }
        public RunInterface(JobInfo info)
        {
            this.Cur_Job = info as JobInfoPushMessage;
        }
        public virtual void Run()
        {
            throw new NotImplementedException();
        }
        public virtual string PostRequest(string body)
        {
            string result = "";
            try
            {
                result = GlobalWebRequestHelper.HttpPostRequest(this.Cur_Job.weburl, body);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】PostRequest推送异常:" + ex.Message + "|参数：" + body, ex);
            }
            return result;
        }
    }
}
