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
    /// 佛山中医院微信推送-患者
    /// </summary>
    public class RunInterfaceForFszyyWeChatToPatient : RunInterface
    {
        public RunInterfaceForFszyyWeChatToPatient(JobInfo job) :
            base(job)
        {

        }
        public override void Run()
        {
            string strsql = "exec usp_rims_wx_notifypatient";
            DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);
            if (dt == null || dt.Rows.Count <= 0) return;
            var list = dt.AsEnumerable().GroupBy(a => new
            {
                patid = a["patid"].ToString(),
                yydm = a["yydm"].ToString(),
                xtbz = a["xtbz"].ToString(),
                idNo = a["wxsbh"].ToString(),
                idType = a["wxklx"].ToString(),
                hzxm = a["hzxm"].ToString()
            }).Select(a => new
            {
                hzxm = a.Key.hzxm,
                patid = a.Key.patid,
                yydm = a.Key.yydm,
                xtbz = a.Key.xtbz,
                idNo = a.Key.idNo,
                idType = a.Key.idType,
                list = a.ToList()
            });
            foreach (var item in list)
            {
                FszyyWeChatMessage msg = new FszyyWeChatMessage();
                string content = "您好，"+item.hzxm+":您有新治疗需要预约，点击此消息，即可进入预约界面";
                //msg.url = "https://wx.fshtcm.com.cn/pat-web/s/oauth/authorize?entry=rims&client=wx";
                msg.url = string.Format("http://rims.fshtcm.com.cn/medicalAppointments/orderRecod?PATIENTID={0}&HOSPITALCODE={1}&XTBZ={2}", item.patid, item.yydm, item.xtbz);
                msg.content = content;
                msg.idNo = item.idNo;
                msg.idType = item.idType;
                this.PostRequest(JsonConvert.SerializeObject(msg));
                strsql = "exec usp_rims_wx_notifypatient @cxlb=1,@txxh='" + string.Join(",", item.list.Select(a => a["xh"].ToString())) + "'";
                DataTable redt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.dbtype, this.Cur_Job.dbstring, strsql);

            }
        }
    }
}
