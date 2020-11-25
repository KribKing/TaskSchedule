using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class JkFactoryManager
    {
        public static JkInterface CreateInstance(JobKey key)
        {
            JkInterface iface = null;
            JobInfo jobInfo = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(key);
            if (!jobInfo.IsBulkOp)
            {
                 iface = new TargetDbJkInterface(jobInfo);
            }
            else
            {
                if (jobInfo.SourceType == 0)//web服务批量操作作业
                {
                    if (jobInfo.ServerType == 0)
                    {
                        iface = new HttpJkInterface(jobInfo);
                    }
                    else if (jobInfo.ServerType == 1)
                    {
                        iface = new WsJkInterface(jobInfo);
                    }
                }
                else if (jobInfo.SourceType ==1)//数据库操作
                {
                    iface = new SourceDbJkInterface(jobInfo);
                }
            }
           
            return iface;
        }
    }
}
