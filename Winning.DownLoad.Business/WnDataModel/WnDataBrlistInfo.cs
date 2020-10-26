using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataBrlistInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataBrlistInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataBrlistInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string patid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string syxh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cwdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string blh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cardno { get; set; }
        /// <summary>
        /// 任桂珍
        /// </summary>
        public string hzxm { get; set; }
        /// <summary>
        /// 女
        /// </summary>
        public string sex { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string birth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sfzh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ksdm { get; set; }
        /// <summary>
        /// 耳鼻喉门诊
        /// </summary>
        public string ksmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bqdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bqmc { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string xtbz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zzysdm  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jzrq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ryrq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cyrq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string crbz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string brzt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yydm { get; set; }
    }
}
