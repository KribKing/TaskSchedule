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
            if (jobInfo.zylx == 0)//web服务批量操作作业
            {
                if (jobInfo.nodelx==0)
                {
                    iface = new JsonWsJkInterface(jobInfo);
                }
                else if (jobInfo.nodelx==1)
                {
                    iface = new XmlWsJkInterface(jobInfo);
                }             
            }
            else if (jobInfo.zylx == 1)//数据库操作
            {
                iface = new DbJkInterface(jobInfo);
            }
            return iface;
        }
    }
}
