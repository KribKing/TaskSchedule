using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Interface
{
    public interface IJobSettingInterface
    {
        List<JobInfo> Default{get;}
        void Save();
        void Init();
        void Add(JobInfo info);
        void Delete(JobInfo info);
    }
}
