using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Core
{
    [Serializable]
    public class DTToken
    {
        public string access_token { get; set; }
        public string  refresh_token { get; set; }
        public bool success { get; set; }
        public string msg { get; set; }

        
    }
}
