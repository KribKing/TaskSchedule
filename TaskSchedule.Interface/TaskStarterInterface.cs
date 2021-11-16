using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Interface
{
    public interface ITaskStarterInterface
    {
        IRunInterface CreateInstance(JobInfo info);
    }
}
