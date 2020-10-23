using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataZdInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataZdInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataZdInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
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
        public string jlzt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memo { get; set; }
    }
}
