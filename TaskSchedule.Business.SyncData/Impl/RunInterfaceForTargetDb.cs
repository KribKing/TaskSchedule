using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData.Impl
{
    public class RunInterfaceForTargetDb : RunInterface
    {
        public RunInterfaceForTargetDb(JobInfo info)
            : base(info)
        {

        }
        public override void Run()
        {
            if (this.Cur_Job == null) return;           
            try
            {
                int renum = GlobalInstanceManager<GlobalSqlManager>.Intance.ExecuteNoneQuery(this.Cur_Job.targetdbtype, this.Cur_Job.targetdbstring, this.Cur_Job.targetsql);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_Job.name + "】JkInterfaceByTargetDb执行异常:" + ex.Message, ex);
            }
        }
    }
}
