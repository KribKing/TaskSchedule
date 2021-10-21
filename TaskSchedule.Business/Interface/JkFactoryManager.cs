using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Business
{
    public class JkFactoryManager
    {
        public static JkInterface CreateInstance(JobKey key)
        {
            JkInterface iface = null;
            JobInfo jobInfo = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(key);
            if (!jobInfo.isbulkop)
            {
                iface = new JkInterfaceByTargetDb(jobInfo);
            }
            else
            {
                if (jobInfo.sourcetype == 0)//web服务批量操作作业
                {
                    if (jobInfo.servertype == 0)//Http
                    {
                        iface = (JkInterface)new JkInterfaceByHttp(jobInfo);
                    }
                    else if (jobInfo.servertype == 1)//Ws
                    {
                        iface = (JkInterface)new JkInterfaceByWs(jobInfo);
                    }
                    else if (jobInfo.servertype ==2)//Rest
                    {
                        iface = (JkInterface)new JkInterfaceByRest(jobInfo);
                    }
                     
                }
                else if (jobInfo.sourcetype == 1)//数据库操作
                {
                    iface = new JkInterfaceBySourceDb(jobInfo);
                }
               
            }

            return iface;
        }
    }
}
