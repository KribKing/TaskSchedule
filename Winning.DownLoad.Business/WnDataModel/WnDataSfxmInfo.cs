using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataSfxmInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataSfxmInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataSfxmInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 活动钢托义齿
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
        public string xmdw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xmgg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double xmdj { get; set; }       
       
        /// <summary>
        /// 
        /// </summary>
        public string xmlb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jlzt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memo { get; set; }
    }
}
