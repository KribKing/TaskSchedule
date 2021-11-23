using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Interface
{
    public delegate void ScheduleLog(string msg);
    public delegate void ScheduleLogWithJob(JobInfo info, string msg);
    public class SchedulerManager
    {
        private IScheduler scheduler;
        public SchedulerManager()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
        }
        public void InitTask()
        {
            GlobalInstanceManager<JobInfoManager>.Intance.Init();
        }
        public JobInfoManager JobInfoManager
        {
            get
            {
                return GlobalInstanceManager<JobInfoManager>.Intance;
            }
        }
        public void CreatJob(JobInfo info)
        {
            try
            {
                if (info.jlzt == "1" || string.IsNullOrEmpty(info.expression)) return;
                IJobDetail job = JobBuilder.Create<ParamJob>()
                                          .WithIdentity(info.GuId.ToString(), info.system)
                                          .Build();              
                ITrigger trigger = TriggerBuilder.Create()
                       .WithIdentity(info.GuId.ToString(), info.system)
                       .StartNow()
                       .WithCronSchedule(info.expression)
                       .Build();
                if (job != null && trigger != null)
                {
                    TriggerKey tri = new TriggerKey(info.GuId.ToString(), info.system);
                    if (!this.scheduler.CheckExists(tri))
                    {
                        this.scheduler.ScheduleJob(job, trigger);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("【" + info.name + "】创建发生异常:" + ex.Message, ex);
            }
        }
        public IJobDetail GetJob(JobInfo info)
        {
            return this.scheduler.GetJobDetail(new JobKey(info.GuId.ToString(),info.system));
        }
        public void DeleteJob(JobInfo info)
        {
            try
            {
                this.scheduler.DeleteJob(new JobKey(info.GuId.ToString(), info.system));
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("【" + info.name + "】删除发生异常:" + ex.Message, ex);
            }
        }

        public void RefreshTrigger(JobInfo jobInfo)
        {
            if (jobInfo == null) return;
            TriggerKey tri = new TriggerKey(jobInfo.GuId.ToString(), jobInfo.system);
            IJobDetail job = this.scheduler.GetJobDetail(new JobKey(jobInfo.GuId.ToString(), jobInfo.system));
            if (job == null)
            {
                this.CreatJob(jobInfo);
            }
            else
            {
                if (jobInfo.jlzt == "0" && !string.IsNullOrEmpty(jobInfo.expression))
                {
                    ITrigger trigger = TriggerBuilder.Create()
                           .WithIdentity(jobInfo.GuId.ToString(), jobInfo.system)
                           .StartNow()
                           .WithCronSchedule(jobInfo.expression)
                           .Build();
                    this.scheduler.ScheduleJob(job, new Quartz.Collection.HashSet<ITrigger> { trigger }, true);
                }
            }
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
            if (jobInfo == null) return;
            TriggerKey tri = new TriggerKey(jobInfo.GuId.ToString(), jobInfo.system);
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
    [DisallowConcurrentExecution]
    public class ParamJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;
            JobInfo jobinfo = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(key);
            if (jobinfo == null) return;
            try
            {
                jobinfo.Run();            
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("【" + jobinfo.name + "】定时执行异常:" + ex.Message, ex);
            }
        }
    }
}
