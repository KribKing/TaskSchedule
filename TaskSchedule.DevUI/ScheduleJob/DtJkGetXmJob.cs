using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.UI.ScheduleJob
{
    public class DtJkGetXmJob : IJob
    {
        private string JobHead = "获取项目作业-DT02";
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                LogHelper.Log(JobHead + ":开始执行");
                string strrequest = "{}";
                string requeststr = GetStrJsonHelper.GetReqJson("DT02", "", strrequest);
                LogHelper.Log(JobHead + requeststr);
                //string strret = GlobalWebRequestHelper.HttpPostRequest(Settings.Default.weburl, requeststr);
                string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(requeststr);
                LogHelper.Log(JobHead + strret);
                LogHelper.Log(JobHead + ":结束执行");
            }
            catch (Exception ex)
            {
                LogHelper.Log(JobHead + ex.Message);
                LogHelper.Log(JobHead + ":结束工作");
            }
        }
    }
}
