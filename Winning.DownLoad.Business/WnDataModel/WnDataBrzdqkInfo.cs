using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataBrzdqkInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataBrzdqkInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataBrzdqkInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string patid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xtbz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string syxh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zdlx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zdlb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ysdm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ysmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zddm { get; set; }
        /// <summary>
        /// 待定
        /// </summary>
        public string zdmc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lrrq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string yydm { get; set; }
    }
}
