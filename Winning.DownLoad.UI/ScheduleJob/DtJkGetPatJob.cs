using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;
using Winning.DownLoad.UI.Properties;

namespace Winning.DownLoad.UI.ScheduleJob
{
    public class DtJkGetPatJob : IJob
    {
        private string JobHead = "患者基础信息作业-DT06";
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                LogHelper.Log(JobHead+":开始执行");
                string strrequest = "{\"dbeginDate\":\"" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "\",\"dendDate\":\"" + DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd") + "\"}";
                string requeststr = GetStrJsonHelper.GetReqJson("DT06", "", strrequest);
                LogHelper.Log(JobHead + requeststr);
                //string strret = GlobalWebRequestHelper.HttpPostRequest(Settings.Default.weburl, requeststr);
                string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(requeststr);
                LogHelper.Log(JobHead + strret);
                LogHelper.Log(JobHead + ":结束执行");
            }
            catch (Exception ex)
            {
                LogHelper.Log(JobHead+ex.Message);
                LogHelper.Log(JobHead + ":结束工作");
            }
        }  
    }
}
