using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.WnDataModel
{
    
    [Serializable]
    public class WnDataHospitalInfoList
    {
        /// <summary>
        /// 
        /// </summary>
        public WnDataHeader head { get; set; }
        public List<WnDataHospitalInfo> body { get; set; }
    }
    /// <summary>
    /// 医院信息
    /// </summary>
    [Serializable]
    public class WnDataHospitalInfo
    {
        /// <summary>
        /// 医院编码
        /// </summary>
        public string yydm { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 医疗机构代码
        /// </summary>
        public string yljgdm { get; set; }
    }
}
