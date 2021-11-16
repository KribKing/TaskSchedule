using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Business.SyncData.Impl;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData
{
    [Serializable]
    public class SyncDataTaskStarter : ITaskStarterInterface
    {
        public IRunInterface CreateInstance(JobInfo info)
        {
            IRunInterface iface = null;
            JobInfoSyncData job = info as JobInfoSyncData;
            if (job == null) return iface;
            iface = !job.isbulkop ? (IRunInterface)new RunInterfaceForTargetDb(info) ://目标库单操作
                job.sourcetype == 1 ? (IRunInterface)new RunInterfaceBySourceDb(info) ://源数据库批量操作
                job.servertype == 0 ? (IRunInterface)new RunInterfaceByHttp(info) ://源Http服务批量操作
                job.servertype == 1 ? (IRunInterface)new RunInterfaceByWebService(info) ://源webservice批量操作
                job.servertype == 2 ? (IRunInterface)new RunInterfaceByRest(info) ://源Rest服务批量操作
                null;
            return iface;
        }
    }
}
