using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.Model;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class ZgOperator : JkInterface
    {
        public ZgOperator(string jkcode, string url)
            : base(jkcode,url, "", "")
        {

        }
        public ZgOperator(string jkcode, string url, string cur_method, string cur_body)
            : base(jkcode,url, cur_method, cur_body)
        {

        }
        public override ResultInfo Run(string jkcode, JObject jobj)
        {
            ResultInfo info = new ResultInfo();
            try
            {
                JkInterface jk = new ZgmzOperator(base.jkcode,base.url, "getMZRYXX", "?cName=all");
                info = jk.Run(jkcode, jobj);
                string strmzmsg="门诊:"+info.ackmsg;
                //if (!info.ackflg)
                //{
                //    strmzmsg=
                //}
                jk = new ZgzyOperator(base.jkcode,base.url, "getZYRYXX", "?cName=all");
                info = jk.Run(jkcode, jobj);
                info.ackmsg = strmzmsg + "   住院:" + info.ackmsg;
            }
            catch (Exception ex)
            {
                info.ackmsg = ex.Message;
                info.ackflg = false;
            }
            return info;
        }

        public virtual ResultInfo GetResult(string jkcode, JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                ResultInfo retinfo = base.GetResponse();
                if (retinfo.ackflg)
                {
                    ZginfoList info = JsonConvert.DeserializeObject<ZginfoList>(retinfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {
                            DataTable dt = Tools.ToDataTable<Zginfo>(info.datas);
                            if (dt != null)
                            {
                                string createtmp = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].createtmp;
                                string tmpname = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].tmpname;
                                string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].sql;                 
                                dt = Tools.DeleteSameRow(dt, "id");
                                retInfo = TSqlHelper.SqlBulkCopyByRims(createtmp,tmpname, dt, strsql);
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
                            retInfo.ackmsg = info.msg;
                            retInfo.ackflg = false;
                        }
                    }
                }
                else
                {
                    retInfo = retinfo;
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
