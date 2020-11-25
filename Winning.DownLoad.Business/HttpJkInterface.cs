﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    /// <summary>
    /// Web服务Json接口
    /// </summary>
    public class HttpJkInterface : JkInterface
    {
        public HttpJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj.ToString();
                retInfo = base.PostResponse();
                if (retInfo.ackflg)
                {
                    DataTable dt = Tools.JsonToDataTable(Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString());
                    base.ExcuteDataBaseBulk(dt, ref retInfo);
                }
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
