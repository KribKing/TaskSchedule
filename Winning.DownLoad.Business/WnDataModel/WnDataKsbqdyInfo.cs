using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataKsbqdyInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataKsbqdyInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataKsbqdyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ksdm { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string ksmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bqdm { get; set; }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string bqmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memo { get; set; }
    }
}
