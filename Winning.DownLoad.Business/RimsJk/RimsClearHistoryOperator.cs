using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.RimsJk
{
    public class RimsClearHistoryOperator : JkInterface
    {
        public RimsClearHistoryOperator(string jkcode, string url)
            : base(jkcode, url, "", "")
        {

        }
        public override ResultInfo Run(string jkcode, JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[jkcode.ToLower()].sql;
                DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    retInfo.ackmsg = "无返回数据";
                    retInfo.ackflg = false;
                }
                else
                {
                    retInfo.ackmsg = dt.Rows[0][1].ToString();
                    retInfo.ackflg = dt.Rows[0][0].ToString()=="T";
                }
            }
            catch (Exception ex)
            {
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
}
