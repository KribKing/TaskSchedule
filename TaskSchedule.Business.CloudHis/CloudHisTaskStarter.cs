using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.CloudHis
{
    public class CloudHisTaskStarter : ITaskStarterInterface
    {
        public IRunInterface CreateInstance(JobInfo info)
        {
            IRunInterface iface = new RunInterface(info);
            return iface;
        }
    }
}
