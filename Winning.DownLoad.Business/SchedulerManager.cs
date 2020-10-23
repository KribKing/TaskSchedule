using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public delegate void ScheduleLog(string msg);
    public delegate void ScheduleLogWithJob(JobInfo info, string msg);
    public class SchedulerManager
    {
        private IScheduler scheduler;
        public event ScheduleLog OnScheduleLog;
        public event ScheduleLogWithJob OnScheduleLogWithJob;
        public SchedulerManager()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
        }
        public void CreatJob(JobInfo info)
        {
            if (info.jlzt == "1")
                return;       
            IJobDetail job = JobBuilder.Create<ParamJob>()
                                      .WithIdentity(info.id, info.system)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                   .WithIdentity(info.id, info.system)
                   .StartNow()
                   .WithCronSchedule(info.expression)
                   .Build();
            if (job != null && trigger != null)
            {
                TriggerKey tri = new TriggerKey(info.id, info.system);
                ITrigger tr = this.scheduler.GetTrigger(tri);
                if (tr == null)
                {
                    this.scheduler.ScheduleJob(job, trigger);
                }

            }
        }

        public void cur_job_OnScheduleLog(string msg)
        {
            if (OnScheduleLog != null)
            {
                OnScheduleLog(msg);
            }
        }
        public void cur_job_OnScheduleLog(JobInfo info, string msg)
        {
            if (OnScheduleLogWithJob != null)
            {
                OnScheduleLogWithJob(info, msg);
            }
        }
        public void RefreshTrigger(JobInfo jobInfo)
        {
            if (jobInfo == null)
                return;
            TriggerKey tri = new TriggerKey(jobInfo.id, jobInfo.system);
            ITrigger tr = this.scheduler.GetTrigger(tri);
            if (tr == null)
            {
                this.CreatJob(jobInfo);
                tr = this.scheduler.GetTrigger(tri);
            }
            tr.GetTriggerBuilder().WithCronSchedule(jobInfo.expression);
            this.scheduler.ResumeTrigger(tri);
        }

        public void ShutDown()
        {
            this.scheduler.Shutdown(false);
        }
        public void PauseAll()
        {
            this.scheduler.PauseAll();
        }
        public void ResumeAll()
        {
            this.scheduler.ResumeAll();
        }
        public void RefreshJlzt(JobInfo jobInfo)
        {
            if (jobInfo == null)
                return;
            TriggerKey tri = new TriggerKey(jobInfo.id, jobInfo.system);
            if (jobInfo.jlzt == "1")
            {
                this.scheduler.PauseTrigger(tri);
            }
            else
            {
                this.RefreshTrigger(jobInfo);
            }
        }
    }
    /// <summary>
    /// 带参作业
    /// </summary>
    public class ParamJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            try
            {
                string strrequest = "{\"dbeginDate\":\"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"dendDate\":\"" + DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd") + "\"}";
                string requeststr = GetStrJsonHelper.GetReqJson(key.Name, "", strrequest);
                GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[key.Name.ToLower()], requeststr);
                string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(requeststr);
                GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[key.Name.ToLower()], strret);
            }
            catch (Exception ex)
            {
                string strret = GetStrJsonHelper.GetRetJson(key.Name, "300.1", ex.Message);
                GlobalInstanceManager<SchedulerManager>.Intance.cur_job_OnScheduleLog(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[key.Name.ToLower()], strret);
            }
        }
    }
}
