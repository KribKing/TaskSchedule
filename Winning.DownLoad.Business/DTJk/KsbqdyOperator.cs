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
    /// <summary>
    /// 获取住院科室病区对应字典
    /// </summary>
    public class KsbqdyOperator : JkInterface
    {
        public KsbqdyOperator(string jkcode,string url)
            : base(jkcode,url,"getStaffKSVsBQ", "")
        { }

        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                retInfo = base.GetResponse();
                if (retInfo.ackflg)
                {
                    KsbqinfoList info = JsonConvert.DeserializeObject<KsbqinfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {
                            DataTable dt = Tools.ToDataTable<Ksbqinfo>(info.datas);
                            if (dt!=null)
                            {
                                //string strsql = "INSERT INTO dbo.PUB_KSBQDYK( ID, KSDM, KSMC, BQDM, BQMC, MEMO )"
                                //                +"SELECT  distinct  ID, KSDM, KSMC, BQDM, BQMC, MEMO FROM tmp_PUB_KSBQDYK  t(NOLOCK)"
                                //                +"WHERE NOT EXISTS(SELECT 1 FROM PUB_KSBQDYK ks(nolock) WHERE ks.ID=t.ID)";
                                //string createtmp = (jobj["createtmp"] ?? "").ToString();
                                //string tmpname = (jobj["tmpname"] ?? "").ToString();
                                //string strsql = (jobj["sql"] ?? "").ToString();
                                string createtmp = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].createtmp;
                                string tmpname = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].tmpname;
                                string strsql = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[base.jkcode].sql;
                                retInfo = TSqlHelper.SqlBulkCopyByComm(createtmp,tmpname, dt, strsql);
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
