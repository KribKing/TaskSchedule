using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.PushMessage
{
    [Serializable]
    public class JobInfoPushMessage : JobInfo
    {
        public string weburl { get; set; }
        public int dbtype { get; set; }
        public string dbstring { get; set; }

        public string tokenweburl { get; set; }
        public override string ToString()
        {
            return "消息推送作业";
        }
    }
}
