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
    public class DtJkGetTokenJob:IJob
    {
        private string JobHead = "获取Token作业-DT00";
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                LogHelper.Log(JobHead + ":开始执行");
                string strrequest = "{\"uid\":\"" + Settings.Default.uid + "\",\"appSecret\":\"" + Settings.Default.appSecret + "\"}";
                string requeststr = GetStrJsonHelper.GetReqJson("DT00", GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT00"].weburl, strrequest);
                LogHelper.Log(JobHead + requeststr);
                //string strret = GlobalWebRequestHelper.HttpPostRequest(JobInfoManager.JobInfoDic["DT00"].weburl, requeststr);
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
