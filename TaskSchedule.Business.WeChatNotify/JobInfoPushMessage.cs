using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.PushMessage
{
    [Serializable]
    public class JobInfoPushMessage : JobInfo
    {
        public string weburl { get; set; }
        public int dbtype { get; set; }
        public string dbstring { get; set; }
        public override Form Config()
        {
            return new ConfigFrm(this);
        }

        public string tokenweburl { get; set; }
    }
}
