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
    public class SqxminfoOperator : JkInterface
    {
        public SqxminfoOperator(string jkcode, string url)
            : base(jkcode,url,"", "")
        {

        }
        public SqxminfoOperator(string jkcode, string url, string cur_method, string cur_body)
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
                string body = string.Format("?BeginDate={0}&EndDate={1}", dbeginDate, dendDate);
                JkInterface jk = new SqxmmzinfoOperator(base.jkcode,base.url,"getMZZlSqd", body);
                info = jk.Run(jkcode, jobj);
                //if (!info.ackflg)
                //{
                //    return info;
                //}
                string strmzmsg = "门诊:" + info.ackmsg;
                jk = new SqxmzyinfoOperator(base.jkcode,base.url,"getZYZlSqd", body);
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
                    JzxminfoList info = JsonConvert.DeserializeObject<JzxminfoList>(retInfo.ackmsg);
                    if (info != null)
                    {
                        if (info.flag)
                        {
                            DataTable dt = Tools.ToDataTable<Jzxminfo>(info.datas);
                            if (dt != null)
                            {
                                //string strsql = "INSERT INTO dbo.RIMS_ZLDXMLIST"
                                //           + "( blh,xtbz,patid,syxh,yzxh,qqlx,zfbz,qqxh,qqmxxh,qqksmc,ysmc,qqrq,itemcode,itemname,price,itemqty,itemunit,url,itemtype,sqdxh,jzbz,ysdm,lrrq,qrys,qrzt,memo,spbz,ybjszt,"
                                //           + "zxksdm,qrksdm,sftk,tsyfdm,sbid,lcsbid,sbmc,kfksmc,yqrsl,kqrsl,cxsl,fzxh1,ypgg,ypjl,yppc,ts,jldw,ktsl,lcxmdm,lcxmmc)"
                                //           + "SELECT blh,xtbz,patid,syxh,yzxh,qqlx,zfbz,qqxh,qqmxxh,qqksmc,ysmc,qqrq,itemcode,itemname,price,itemqty,itemunit,url,itemtype,sqdxh,jzbz,ysdm,lrrq,qrys,qrzt,t.memo,spbz,ybjszt,"
                                //           + "zxksdm,qrksdm,sftk,tsyfdm,sbid,lcsbid,sbmc,kfksmc,yqrsl,kqrsl,cxsl,fzxh1,ypgg,ypjl,yppc,ts,jldw,ktsl,lcxmdm,lcxmmc "
                                //           +"FROM tmp_RIMS_ZLDXMLIST t(nolock) "
                                //           +"inner join RIMS_XMFLDYK dy(nolock) on t.itemcode=dy.xmdm and dy.jlzt=0 "
                                //           + "WHERE NOT EXISTS(SELECT 1 FROM RIMS_ZLDXMLIST xm(nolock) WHERE xm.qqxh=t.qqxh AND xm.qqmxxh=t.qqmxxh AND xm.xtbz=t.xtbz)";

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
