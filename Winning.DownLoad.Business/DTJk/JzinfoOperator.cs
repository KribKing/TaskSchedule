using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class JzinfoOperator:JkInterface
    {
        public JzinfoOperator(string jkcode, string url)
            : base(jkcode,url,"", "")
        {

        }
        public JzinfoOperator(string jkcode, string url, string cur_method, string cur_body)
             : base(jkcode,url, cur_method, cur_body)
         {

         }
        public override ResultInfo Run(string jkcode, JObject jobj)
        {
            ResultInfo info = new ResultInfo();
            try
            {
                string dbeginDate = (jobj["dbeginDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string dendDate = (jobj["dendDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string body = string.Format("?dbeginDate={0}&dendDate={1}", dbeginDate, dendDate);
                JkInterface jk = new JzmzinfoOperator(base.jkcode,base.url,"getMZJZXX", body);
                info = jk.Run(jkcode, jobj);
                //if (!info.ackflg)
                //{
                //    return info;
                //}
                string strmzmsg = "门诊:" + info.ackmsg;
                jk = new JzzyinfoOperator(base.jkcode, base.url, "getZYJZXX", body);
                info = jk.Run(jkcode, jobj);
                info.ackmsg = strmzmsg + "   住院:" + info.ackmsg;
            }
            catch (Exception ex)
            {
                info.ackcode = "300.1";
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
                retInfo = base.GetResponse();
                if (retInfo.ackflg)
                {
                    JzpatinfoList info = JsonConvert.DeserializeObject<JzpatinfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {

                            DataTable dt = Tools.ToDataTable<Jzpatinfo>(info.datas);
                            if (dt != null)
                            {
                                //string strsql = "INSERT INTO RIMS_ZLBRLIST(patid,syxh,cwdm,blh,kh,hzxm,xb,nl,csrq,sfzh,ksdm,ksmc,bqdm,bqmc,pdlsh,xtbz,memo,ybsm,jzrq,zsnr,bszy,tz)"
                                //                +"SELECT distinct CASE WHEN t.xtbz=0 THEN 'MZ' ELSE 'ZY' END+patid,syxh,cwdm,blh,kh,hzxm,xb,nl,csrq,sfzh,ksdm,ksmc,bqdm,bqmc,0 pdlsh,xtbz,memo,ybsm,jzrq,zsnr,bszy,tz "
                                //                +" FROM tmp_RIMS_ZLBRLIST t(nolock)"
                                //                +"WHERE not EXISTS(SELECT 1 FROM dbo.RIMS_ZLBRLIST br(nolock) WHERE br.patid=(CASE WHEN t.xtbz=0 THEN 'MZ' ELSE 'ZY' END +t.patid) AND br.syxh=t.syxh AND br.xtbz=t.xtbz)";

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
                retInfo.ackflg = false;
                retInfo.ackmsg = ex.Message;

            }
            return retInfo;
        }
    }
}