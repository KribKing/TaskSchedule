using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataZgksbqInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataZgksbqInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataZgksbqInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string zgdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ksdm { get; set; }
        /// <summary>
        /// 妇科
        /// </summary>
        public string ksmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bqdm { get; set; }
        /// <summary>
        /// 妇科
        /// </summary>
        public string bqmc { get; set; }
    }
}
