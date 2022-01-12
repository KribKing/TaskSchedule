using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Interface
{
    public interface IConfigUIInterface
    {
        object UIIndex { get; }
        void LoadChildInfo();
        bool CollectChildJobInfo();
        void ShowConfig();
        void SetJobInfo(JobInfo info);
    }
}
