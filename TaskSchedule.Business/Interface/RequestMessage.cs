using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Business
{
    [Serializable]
    public class RequestMessage
    {
        public Request Request { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    [Serializable]
    public class Request
    {
        public Head Head { get; set; }
        public string Body { get; set; }
    }
}
