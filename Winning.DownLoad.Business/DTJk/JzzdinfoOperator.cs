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
    public class JzzdinfoOperator:JkInterface
    {
        public JzzdinfoOperator(string jkcode, string url)
            : base(jkcode,url,"", "")
        {

        }
        public JzzdinfoOperator(string jkcode, string url, string cur_method, string cur_body)
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
                string body = string.Format("?BeginDate={0}&EndDate={1}", dbeginDate, dendDate);
                JkInterface jk = new JzzdmzinfoOperator(base.jkcode, base.url, "getMZZDXX", body);
                info = jk.Run(jkcode, jobj);
                //if (!info.ackflg)
                //{
                //    return info; 
                //}
                string strmzmsg = "门诊:" + info.ackmsg;
                jk = new JzzdzyinfoOperator(base.jkcode, base.url, "getZYZDXX", body);
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
                    JzzdinfoList info = JsonConvert.DeserializeObject<JzzdinfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {

                            DataTable dt = Tools.ToDataTable<Jzzdinfo>(info.datas);
                            if (dt != null)
                            {
                                //string strsql = "INSERT INTO dbo.RIMS_BRZDQK(patid,xtbz,ghxh,syxh,zdlx,zdlb,ysdm,ysmc,zddm,zdmc,lrrq,memo)"
                                //                +"SELECT distinct patid,xtbz,ISNULL(ghxh,0),ISNULL(syxh,0),zdlx,zdlb,ysdm ,ysmc,zddm,zdmc ,lrrq ,memo  FROM tmp_RIMS_BRZDQK t(nolock)"
                                //                +"WHERE NOT EXISTS(SELECT 1 FROM RIMS_BRZDQK zd(nolock) "
                                //                +"WHERE zd.patid=CASE WHEN t.xtbz=0 THEN 'MZ' ELSE 'ZY' END +t.patid "
                                //                +"AND t.xtbz=zd.xtbz "
                                //                +"AND ISNULL(zd.ghxh,0)=ISNULL(t.ghxh,0) "
                                //                +"AND ISNULL(zd.syxh,0)=ISNULL(t.syxh,0) "
                                //                +"AND zd.lrrq=t.lrrq)";

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
