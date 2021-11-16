using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Business.ShortMessageNotify.Model
{
    [Serializable]
    public class Message
    {
        public List<SendPara> SendPara { get; set; }
    }

}
