using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class ZgksbqdyOperator:JkInterface
    {
        public ZgksbqdyOperator(string jkcode,string url)
            : base(jkcode,url, "getZGVsKS", "")
        {
         
        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                retInfo = base.GetResponse();
                if (retInfo.ackflg)
                {
                    ZgksinfoList info = JsonConvert.DeserializeObject<ZgksinfoList>(retInfo.ackmsg);                
                }
               
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackflg = false;
                retInfo.ackmsg = ex.Message;
            }
            return retInfo;
        }
    }
}
