using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class GetBcjlOperator:JkInterface
    {
        public GetBcjlOperator(string jkcode, string url)
            : base(jkcode, url, "getBCJL", "")
        {

        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strpat = (jobj["patid"] ?? "").ToString();
                string strxtbz = (jobj["xtbz"] ?? "1").ToString();
                base.body = string.Format("patid={0}&cPatientType={1}", strpat, strxtbz);
                retInfo = base.GetResponse();             
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
}
