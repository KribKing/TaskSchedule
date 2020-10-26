using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class HzinfoOperator:JkInterface
    {
        public HzinfoOperator(string jkcode, string url)
            : base(jkcode, url, "getHZSQXX", "")
        {

        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string dbeginDate = (jobj["dbeginDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string dendDate = (jobj["dendDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                base.body = string.Format("?dbeginDate={0}&dendDate={1}", dbeginDate, dendDate);

                retInfo = base.GetResponse();
                if (retInfo.ackflg)
                {
                    HzInfoList info = JsonConvert.DeserializeObject<HzInfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {

                            DataTable dt = Tools.ToDataTable<HzInfo>(info.datas);
                            if (dt != null)
                            {
                                string createtmp = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].createtmp;
                                string tmpname = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].tmpname;
                                string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].sql;
                                retInfo = TSqlHelper.SqlBulkCopyByRims(createtmp, tmpname, dt, strsql);
                            }
                            else
                            {
                                retInfo.ackcode = "100.0";
                                retInfo.ackflg = true;
                                retInfo.ackmsg = "成功无数据";

                            }
                        }
                        else
                        {
                            retInfo.ackcode = "200.1";
                            retInfo.ackflg = false;
                            retInfo.ackmsg = info.msg;
                        }
                    }
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
