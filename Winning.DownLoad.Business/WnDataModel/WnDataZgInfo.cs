using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    [Serializable]
    public class WnDataZgInfoList
    {
        public WnDataHeader head { get; set; }
        public List<WnDataZgInfo> body { get; set; }
    }
    [Serializable]
    public class WnDataZgInfo
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string py { get; set; }
        /// <summary>
        /// 五笔
        /// </summary>
        public string wb { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string birth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hyzk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sfzh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ks_id { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string ks_mc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bq_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bq_mc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zglb { get; set; }    
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
