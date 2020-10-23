using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataLcxmInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataLcxmInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataLcxmInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 胸椎右侧屈位
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string py { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmdj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmdw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmgg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jlzt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmlb { get; set; }
       
    }
}
