using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Business.PushMessage.Model;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.PushMessage.Impl
{
    /// <summary>
    /// 厦门弘爱短信提醒
    /// </summary>
    public class RunInterfaceForHaSmsToPat : RunInterface
    {
        public RunInterfaceForHaSmsToPat(JobInfo job) :
            base(job)
        {

        }
        public override void Run()
        {
            string strsql = "exec usp_rims_sms_notifypat @cxlb=0";
            DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
            if (dt == null || dt.Rows.Count <= 0) return;

            var list = dt.AsEnumerable().GroupBy(a => new { lxdh = a["lxdh"].ToString() }).
                 Select(a => new { lxdh = a.Key.lxdh, list = a.ToList() });

            foreach (var item in list)
            {
                HaSmsMessage msg = new HaSmsMessage();
                SendPara para = new SendPara();
                para.recive = new List<string>();
                para.contentMap.content = "请合理安排到院治疗时间，厦门弘爱康复医院关心您！ 注意：因疫情防控需要，厦门弘爱康复医院治疗中心（综合楼3楼）实行封闭管理，长期门诊康复治疗患者持15天内核酸报告进入治疗。家属陪护谢绝入内，感谢您的支持和理解，祝您早日康复！";
                para.recive.Add(item.lxdh);
                msg.alermMsgInfo.Add(para);
                string result = this.PostRequest(JsonConvert.SerializeObject(msg));
                Log4netUtil.Info("作业【" + this.Cur_Job.name + "】返回值" + result);
                HaResult r = JsonConvert.DeserializeObject<HaResult>(result);
                if (r != null && r.code == "0")
                {
                    strsql = "exec usp_rims_sms_notifypat @cxlb=1,@txxh='" + string.Join(",", item.list.Select(a => a["xh"].ToString())) + "'";
                    DataTable redt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
                }

            }
        }

        public override string PostRequest(string body)
        {
            string result = "";
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                // header.Add("Content-Type", "application/x-www-form-urlencoded");
                header.Add("Authorization", "Basic c21zc2VydmVyLWFwaTpiYTVjOTYzNjkxYjM5ZjlkZWQwZDI2OGZkMWI5ZTNkYjgyYTI1M2RlZmMx");

                string hresult = GlobalWebRequestHelper.HttpPostRequestWithHeader(this.Cur_Job.tokenweburl, "", "json", "x-www-form-urlencoded", header);
                Log4netUtil.Info("作业【" + this.Cur_Job.name + "】获取token值：" + hresult);
                HaToken token = JsonConvert.DeserializeObject<HaToken>(hresult);
                if (token != null && !string.IsNullOrEmpty(token.access_token))
                {
                    header.Clear();
                    //header.Add("Content-Type", "application/json");
                    header.Add("Authorization", token.token_type + " " + token.access_token);
                    result = GlobalWebRequestHelper.HttpPostRequestWithHeader(this.Cur_Job.weburl, body, "json", "json", header);
                }

            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】PostRequest推送异常:" + ex.Message + "|参数：" + body, ex);
            }
            return result;
        }
    }
}
