using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Business.ShortMessageNotify.Model;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.ShortMessageNotify.Impl
{
    public class RunInterfaceForNotifyPat : RunInterface
    {
        public RunInterfaceForNotifyPat(JobInfo job) :
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
                Message msg = new Message();
                SendPara para = new SendPara();
                para.recive = new List<string>();
                para.contentMap = "请合理安排到院治疗时间，厦门弘爱康复医院关心您！ 注意：因疫情防控需要，厦门弘爱康复医院治疗中心（综合楼3楼）实行封闭管理，长期门诊康复治疗患者持15天内核酸报告进入治疗。家属陪护谢绝入内，感谢您的支持和理解，祝您早日康复！";
                para.recive.Add(item.lxdh);
                para.alarmType = "0";
                para.sender = "Rims";
                para.org = "kfsmskey";
                para.url = "";         
                this.PostRequest(JsonConvert.SerializeObject(msg));
                strsql = "exec usp_rims_sms_notifypat @cxlb=1,@txxh='" + string.Join(",", item.list.Select(a => a["xh"].ToString())) + "'";
                DataTable redt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);

            }
        }
    }
}
