using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataLcxmdyInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataLcxmdyInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataLcxmdyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string lcxmdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmsl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memo { get; set; }
    }
}
