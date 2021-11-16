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
    /// 佛山中医院微信推送-治疗师
    /// </summary>
    public class RunInterfaceForFszyyWechatToDoctor : RunInterface
    {
        public RunInterfaceForFszyyWechatToDoctor(JobInfo job) :
            base(job)
        {

        }
        public override void Run()
        {
            string strsql = "exec usp_rims_wx_notifydoctor @cxlb=0";
            DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
            if (dt == null || dt.Rows.Count <= 0) return;

            var list = dt.AsEnumerable().GroupBy(a => new { ysdm = a["ysdm"].ToString(), ysmc = a["ysmc"].ToString(), idNo = a["wxsbh"].ToString(), idType = a["wxklx"].ToString() }).
                 Select(a => new { ysdm = a.Key.ysdm, ysmc = a.Key.ysmc, idNo = a.Key.idNo, idType = a.Key.idType, list = a.ToList() });

            foreach (var item in list)
            {
                FszyyWeChatMessage msg = new FszyyWeChatMessage();
                string content = "您好，你有新治疗任务，点击此消息，即可进入详情界面";
                msg.url = "http://rims.fshtcm.com.cn/medicalDoc/task?ysdm=" + item.ysdm;
                msg.content = content;
                msg.idNo = item.idNo;
                msg.idType = item.idType;
                this.PostRequest(JsonConvert.SerializeObject(msg));
                strsql = "exec usp_rims_wx_notifydoctor @cxlb=1,@txxh='" + string.Join(",", item.list.Select(a => a["xh"].ToString())) + "'";
                DataTable redt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);

            }
        }
    }
}
