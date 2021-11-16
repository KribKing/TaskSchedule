using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData.Impl
{
    public class RunInterfaceByWebService : RunInterface
    {
        public RunInterfaceByWebService(JobInfo info)
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
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】RunInterfaceByWebService执行异常:" + ex.Message, ex);
            }
        }
        public override string WebRequest()
        {
            string result = "";
            try
            {
                WebServiceArgs list = JsonConvert.DeserializeObject<WebServiceArgs>(this.Cur_Job.GetExcuteCondition());
                object[] args = null;
                if (list != null && list.ArgsList != null && list.ArgsList.Count > 0)
                {
                    args = new object[list.ArgsList.Count];
                    foreach (WebServiceArgsInfo item in list.ArgsList)
                    {
                        args.SetValue(item.Value, item.KeyIndex);
                    }
                }
                result = GlobalWebRequestHelper.SoapRequest(this.Cur_Job.weburl, this.Cur_Job.servermethod, args);

            }
            catch (Exception ex)
            {

                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】RunInterfaceByWebService执行异常:" + ex.Message, ex);
            }
            return result;
        }
    }
    public class WebServiceArgs
    {
        public List<WebServiceArgsInfo> ArgsList { get; set; }
    }
    public class WebServiceArgsInfo
    {
        public int KeyIndex { get; set; }
        public string Value { get; set; }

    }
}
