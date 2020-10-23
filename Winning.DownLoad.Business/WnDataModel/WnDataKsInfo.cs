using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataKsInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataKsInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataKsInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 肺功能室
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
        public string yydm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yjks_id { get; set; }
        /// <summary>
        /// 医技科室
        /// </summary>
        public string yjks_mc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ybks_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ybks_mc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ejks_id { get; set; }
        /// <summary>
        /// 肺功能室
        /// </summary>
        public string ejks_mc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kslb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ksbz { get; set; }
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
