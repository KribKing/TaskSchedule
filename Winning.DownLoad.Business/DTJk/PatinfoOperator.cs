using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    /// <summary>
    /// 获取病人基本信息
    /// </summary>
    public class PatinfoOperator : JkInterface
    {
        public PatinfoOperator(string jkcode, string url)
            : base(jkcode,url,"", "")
        {

        }
        public PatinfoOperator(string jkcode, string url, string cur_method, string cur_body)
            : base(jkcode,url, cur_method, cur_body)
        {

        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo info = new ResultInfo();
            try
            {
                string dbeginDate = (jobj["dbeginDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string dendDate = (jobj["dendDate"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string body = string.Format("?cPatientCode=all&BeginDate={0}&EndDate={1}", dbeginDate, dendDate);
                JkInterface jk = new PatinfomzOperator(base.jkcode,base.url, "getMZBRXX", body);
                info = jk.Run(jkcode, jobj);
                //if (!info.ackflg)
                //{
                //    return info;
                //}
                string strmzmsg = "门诊:" + info.ackmsg;
                jk = new PatinfozyOperator(base.jkcode, base.url, "getZYBRXX", body);
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
                    PatinfoList info = JsonConvert.DeserializeObject<PatinfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {

                            DataTable dt = Tools.ToDataTable<Patinfo>(info.datas);
                            if (dt != null)
                            {
                                //string strsql = "INSERT INTO dbo.RIMS_BRXXK(patid,blh,hzxm,wb,py,cardno,zypatid,sbh,qtkh,sfzh,sex,birth,lxdz,lxdh,yzbm,lxr,ybdm,pzh,dwbm,dwmc,qxdm,zhje,"
                                //          + "ljje,zhszrq,zjrq,czyh,lrrq,tybz,cardtype,xtbz)"
                                //          + "SELECT distinct case when t.xtbz=0 then 'MZ' else 'ZY' end+patid,blh,hzxm,wb,py,cardno,0 as zypatid,sbh,qtkh,sfzh,sex,'' as birth,lxdz,lxdh,yzbm,lxr,ybdm,pzh,dwbm,dwmc,qxdm,0 as zhje,"
                                //          + "0 as ljje,zhszrq,zjrq,czyh,lrrq,0 as tybz,cardtype,xtbz FROM tmp_RIMS_BRXXK t(nolock)"
                                //          + "WHERE NOT EXISTS(SELECT 1 FROM RIMS_BRXXK br(nolock)WHERE case when t.xtbz=0 then 'MZ' else 'ZY' end+t.patid=br.patid AND t.xtbz=br.xtbz)";

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
