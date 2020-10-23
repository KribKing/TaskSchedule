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
    public class BqOperator:JkInterface
    {
        public BqOperator(string jkcode, string url)
            : base(jkcode,url, "DictDept", "")
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
                    List<DeptInfo> list = JsonConvert.DeserializeObject<List<DeptInfo>>(retInfo.ackmsg);
                    if (list != null)
                    {
                        DataTable dt = Tools.ToDataTable<DeptInfo>(list);
                        if (dt != null)
                        {
                            //string createtmp = (jobj["createtmp"] ?? "").ToString();
                            //string tmpname = (jobj["tmpname"] ?? "").ToString();
                            //string strsql = (jobj["sql"] ?? "").ToString();
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
                        retInfo.ackflg = true;
                        retInfo.ackcode = "100.0";
                        retInfo.ackmsg = "成功无数据";
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
