using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataPatInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataPatInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataPatInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string patid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string blh { get; set; }
        /// <summary>
        /// 张三
        /// </summary>
        public string hzxm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string py { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sfzh { get; set; }
        /// <summary>
        /// 女
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string birth { get; set; }
        /// <summary>
        /// 东四街道
        /// </summary>
        public string lxdz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lxdh { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string lxr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xtbz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yydm { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        public string lrczyh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sdate { get; set; }
       
    }
}
