using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Interface
{
    public class JobInfoManager
    {
        public Dictionary<Guid, JobInfo> JobInfoDic = new Dictionary<Guid, JobInfo>();
        public List<JobInfo> BaseJob = new List<JobInfo>();
        public void Init()
        {

            if (GlobalInstanceManager<AddinsSetting>.Intance.Default == null || GlobalInstanceManager<AddinsSetting>.Intance.Default.Count <= 0) return;
            foreach (AddinsInfo ai in GlobalInstanceManager<AddinsSetting>.Intance.Default)
            {
                if (!ai.IsUse) continue;
                ITaskStarterInterface task = GlobalInstanceManager<ITaskStarterInterface>.ReflectInstance(ai.AssemblyName, ai.TaskStarter);
                IJobSettingInterface<JobInfo> setting = GlobalInstanceManager<IJobSettingInterface<JobInfo>>.ReflectInstance(ai.AssemblyName, ai.SettingInterface);
                setting.Init();
                JobInfo baseJob = GlobalInstanceManager<JobInfo>.ReflectInstance(ai.AssemblyName, ai.JobInfo);
                baseJob.TaskStarter = task;
                baseJob.SettingInterface = setting;
                baseJob.AddinsInfo = ai;
                this.BaseJob.Add(baseJob);
                List<JobInfo> list = setting.Default;
                if (list == null) continue;
                foreach (var item in list)
                {
                    item.AddinsInfo = ai;
                    item.TaskStarter = task;
                    this.JobInfoDic.Add(item.GuId, item);
                }
            }
        }

        public JobInfo GetJobInfo(JobKey key)
        {
            return JobInfoDic.FirstOrDefault(a => a.Key.ToString() == key.Name).Value;
        }
    }
}
