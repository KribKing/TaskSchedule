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
    public class RunInterfaceForFszyyWechatToDoctorSwitchBed : RunInterface
    {
        public RunInterfaceForFszyyWechatToDoctorSwitchBed(JobInfo job) :
            base(job)
        {

        }
        public override void Run()
        {
            string strsql = "exec usp_rims_wx_notifydoctor @cxlb=2";
            DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
            if (dt == null || dt.Rows.Count <= 0) return;

            var list = dt.AsEnumerable().GroupBy(a => new { ysdm = a["ysdm"].ToString(), ysmc = a["ysmc"].ToString(), 
                idNo = a["wxsbh"].ToString(), idType = a["wxklx"].ToString(),content=a["txnr"].ToString() }).
                Select(a => new { ysdm = a.Key.ysdm, ysmc = a.Key.ysmc, idNo = a.Key.idNo, idType = a.Key.idType,content=a.Key.content, list = a.ToList() });

            foreach (var item in list)
            {
                FszyyWeChatMessage msg = new FszyyWeChatMessage();             
                msg.url = "";
                msg.content = item.content;
                msg.idNo = item.idNo;
                msg.idType = item.idType;
                string result = this.PostRequest(JsonConvert.SerializeObject(msg));
                Log4netUtil.Info("作业【" + this.Cur_Job.name + "】返回值：" + result);
                FszyyWeChatResult fr = JsonConvert.DeserializeObject<FszyyWeChatResult>(result);
                if (fr != null && fr.code == "0")
                {
                    strsql = "exec usp_rims_wx_notifydoctor @cxlb=1,@txxh='" + string.Join(",", item.list.Select(a => a["xh"].ToString())) + "'";
                    DataTable redt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
                }
            }
        }
    }
}
