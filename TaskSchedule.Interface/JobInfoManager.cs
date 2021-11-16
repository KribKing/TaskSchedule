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

        public JobInfoManager()
        {

        }
        public void Init()
        {
            if (AddinsSetting.Default == null || AddinsSetting.Default.Count <= 0) return;
            foreach (AddinsInfo ai in AddinsSetting.Default)
            {
                ITaskStarterInterface task = GlobalInstanceManager<ITaskStarterInterface>.ReflectInstance(ai.AssemblyName, ai.TaskStarter);
                IJobSettingInterface setting = GlobalInstanceManager<IJobSettingInterface>.ReflectInstance(ai.AssemblyName, ai.SettingInterface);
                setting.Init();
                List<JobInfo> list = setting.Default;
                if (list == null) continue;
                foreach (var item in list)
                {
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
