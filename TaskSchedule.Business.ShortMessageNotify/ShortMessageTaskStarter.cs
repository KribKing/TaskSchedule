using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Business.ShortMessageNotify.Impl;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.ShortMessageNotify
{
    [Serializable]
    public class ShortMessageTaskStarter : ITaskStarterInterface
    {
        public IRunInterface CreateInstance(JobInfo info)
        {
            IRunInterface iface = null;

            if (info.id == "SMS_Pat")//患者短信推送
            {
                iface = new RunInterfaceForNotifyPat(info);
            }

            return iface;
        }
    }
}
