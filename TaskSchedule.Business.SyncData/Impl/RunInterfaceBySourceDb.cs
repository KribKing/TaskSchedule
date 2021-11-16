using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData.Impl
{
    public class RunInterfaceBySourceDb : RunInterface
    {
        public RunInterfaceBySourceDb(JobInfo info)
            : base(info)
        {

        }
        public override void Run()
        {
            try
            {
                string strsql = this.Cur_Job.targetsql;
                string connstring = this.Cur_Job.sourcedbstring;
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.Cur_Job.sourcedbtype, this.Cur_Job.sourcedbstring, this.Cur_Job.sourcesql);
                base.ExcuteDataBaseBulk(dt);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("【" + this.Cur_Job.name + "】RunInterfaceBySourceDb执行异常:" + ex.Message, ex);
            }
        }
    }
}
