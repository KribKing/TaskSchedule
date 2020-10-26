using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;
using Winning.DownLoad.UI.Properties;

namespace Winning.DownLoad.UI.ScheduleJob
{
    public delegate void OnJobFinished(string ackmsg);
    public class DTScheduler
    {
        private IScheduler scheduler;
        public void Start()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            //string expression = "0 */1 * * * ?";//每5秒执行一次
            //string expression = "0 57 23 L * ?";//每月最后一天的23点57分执行。  
            #region 基础数据接口
            IJobDetail getbqjob = JobBuilder.Create<DtJkGetTokenJob>()
                                          .WithIdentity("DtJkGetBqJob", "DtJk")
                                          .Build();
            ITrigger getbqtrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetBqTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT01"].expression)
              .Build();
            IJobDetail getxmjob = JobBuilder.Create<DtJkGetXmJob>()
                                      .WithIdentity("DtJkGetXmJob", "DtJk")
                                      .Build();
            ITrigger getxmtrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetXmTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT02"].expression)
              .Build();
            IJobDetail getryjob = JobBuilder.Create<DtJkGetRyJob>()
                                     .WithIdentity("DtJkGetRyJob", "DtJk")
                                     .Build();
            ITrigger getrytrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetRyTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT03"].expression)
              .Build();
            IJobDetail getksjob = JobBuilder.Create<DtJkGetKsJob>()
                                    .WithIdentity("DtJkGetKsJob", "DtJk")
                                    .Build();
            ITrigger getkstrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetKsTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT04"].expression)
              .Build();
            IJobDetail getzdjob = JobBuilder.Create<DtJkGetZdJob>()
                                 .WithIdentity("DtJkGetZdJob", "DtJk")
                                 .Build();
            ITrigger getzdtrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetZdTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT05"].expression)
              .Build();
            scheduler.ScheduleJob(getbqjob, getbqtrigger);
            scheduler.ScheduleJob(getxmjob, getxmtrigger);
            scheduler.ScheduleJob(getryjob, getrytrigger);
            scheduler.ScheduleJob(getksjob, getkstrigger);
            scheduler.ScheduleJob(getzdjob, getzdtrigger);
            #endregion 
            #region 业务数据接口
            IJobDetail getpatjob = JobBuilder.Create<DtJkGetPatJob>()
                                          .WithIdentity("DtJkGetPatJob", "DtJk")
                                          .Build();
            ITrigger getpattrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetPatTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT06"].expression)
              .Build();
            IJobDetail getjzpatjob = JobBuilder.Create<DtJkGetJzPatJob>()
                                      .WithIdentity("DtJkGetJzPatJob", "DtJk")
                                      .Build();
            ITrigger getjzpattrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetJzPatTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT07"].expression)
              .Build();
            IJobDetail getjzxmjob = JobBuilder.Create<DtJkGetJzXmJob>()
                                     .WithIdentity("DtJkGetJzXmJob", "DtJk")
                                     .Build();
            ITrigger getjzxmtrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetJzXmTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT08"].expression)
              .Build();
            IJobDetail getjzzdjob = JobBuilder.Create<DtJkGetJzZdJob>()
                                    .WithIdentity("DtJkGetJzZdJob", "DtJk")
                                    .Build();
            ITrigger getjzzdtrigger = TriggerBuilder.Create()
              .WithIdentity("DtJkGetJzZdTrigger", "DtJk")
              .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT09"].expression)
              .Build();
            //IJobDetail getjyjob = JobBuilder.Create<DtJkGetJyJob>()
            //                        .WithIdentity("DtJkGetJyJob", "DtJk")
            //                        .Build();
            //ITrigger getjytrigger = TriggerBuilder.Create()
            //  .WithIdentity("DtJkGetJyTrigger", "DtJk")
            //  .WithCronSchedule(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic["DT10"].expression)
            //  .Build();
            scheduler.ScheduleJob(getpatjob, getpattrigger);
            scheduler.ScheduleJob(getjzpatjob, getjzpattrigger);
            scheduler.ScheduleJob(getjzxmjob, getjzxmtrigger);
            scheduler.ScheduleJob(getjzzdjob, getjzzdtrigger);
            //scheduler.ScheduleJob(getjyjob, getjytrigger);  
            #endregion 
        }
        public void ReStart()
        {
            scheduler.ResumeAll();
        }
        public void Pause()
        {       
            scheduler.PauseAll();               
        }
        public void Shutdown()
        {
            scheduler.Shutdown(true);
        }
    }
}
