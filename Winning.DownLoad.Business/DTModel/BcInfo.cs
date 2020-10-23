using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class BcInfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<BcInfo> datas { get; set; }
    }
    [Serializable]
    public class BcInfo
    {
        public string patid { get; set; }
        public string cPatientCode { get; set; }
        public string iBookID { get; set; }
        public string cBookName { get; set; }
        public string text { get; set; }
        public string datatime { get; set; }
        public string cPatientType { get; set; }
   
    }
}
