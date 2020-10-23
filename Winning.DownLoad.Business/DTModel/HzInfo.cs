using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class HzInfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<HzInfo> datas { get; set; }
    }
    [Serializable]
    public class HzInfo
    {
        public string cPatientCode { get; set; }
        public string sqksCode { get; set; }
        public string sqks { get; set; }
        public string hzksCode { get; set; }
        public string hzks { get; set; }
        public string perpose { get; set; }
        public string result { get; set; }
        public string sqysCode { get; set; }
        public string sqys { get; set; }
        public string hzlx { get; set; }
        public string hzsj { get; set; }
        public string hzysCode { get; set; }
        public string hzys { get; set; }
        public string flag { get; set; }
        public string patid { get; set; }
        public string bedNo { get; set; }
        public string sqdh { get; set; }
        public string Sqsj { get; set; }
        public string zd { get; set; }

    }
}
