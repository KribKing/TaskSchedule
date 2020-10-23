using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataBqInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataBqInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataBqInfo
    {
        public string ward_code { get; set; }
        public string dept_name { get; set; }
        public string py { get; set; }
        public string wb { get; set; }
        public string yydm { get; set; }
        public string lb { get; set; }
        public string jlzt { get; set; }
        public string memo { get; set; }
    }
}
