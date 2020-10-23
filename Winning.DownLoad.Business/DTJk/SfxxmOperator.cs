using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Business.Model;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    /// <summary>
    /// 获取收费小项目信息
    /// </summary>
    public class SfxxmOperator : JkInterface
    {
        public SfxxmOperator(string jkcode, string url)
            :base(jkcode,url,"","")
        {

        }
        public SfxxmOperator(string jkcode, string url, string cur_method, string cur_body)
            : base(jkcode,url, cur_method, cur_body)
        {

        }  
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo info = new ResultInfo();
            try
            {
                JkInterface jk = new SfxxmmzOperator(base.jkcode,base.url,"getMZXXZD", "");
                info = jk.Run(jkcode, jobj);
                //if (!info.ackflg)
                //{
                //    return info;
                //}
                string strmzmsg = "门诊:" + info.ackmsg;
                jk = new SfxxmzyOperator(base.jkcode,base.url,"getZYXXZD", "");
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
                    XminfoList info = JsonConvert.DeserializeObject<XminfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {

                            DataTable dt = Tools.ToDataTable<Xminfo>(info.datas);
                            if (dt != null)
                            {
                                //string strsql = "INSERT INTO dbo.RIMS_SFXXMK(id,name,py,wb,dxmdm,xmdw,xmgg,xmdj,yhbl,txbl,mzzfbz,mzzfbl,zyzfbz,zyzfbl,xmlb,yjqrbz,sybz,yjbz,mzbz,zybz,yzxm,zxks_id,memo,dydm,ybkzbz,ekbz,yydm)"
                                //                +"SELECT distinct id,name,py,wb,dxmdm,xmdw,xmgg,xmdj,yhbl,txbl,mzzfbz,mzzfbl,zyzfbz,zyzfbl,xmlb,yjqrbz,sybz,yjbz,mzbz,zybz,yzxm,zxks_id,memo,dydm,ybkzbz,ekbz,yydm "
                                //                +"FROM tmp_RIMS_SFXXMK t(nolock) "
                                //                +"WHERE NOT EXISTS(SELECT 1 FROM dbo.RIMS_SFXXMK sf(nolock) WHERE t.id=sf.id)";

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
