using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Interface
{
    public interface IQuickExcuteInterface
    {
        void QuickExcute(JobInfo jobInfo, string request);
    }
}
