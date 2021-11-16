using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Business.PushMessage.Impl;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.PushMessage
{
    public class PushMessageTaskStarter : ITaskStarterInterface
    {
        public IRunInterface CreateInstance(JobInfo info)
        {
            IRunInterface iface = null;
            iface = info.id == "WeChat_Doc" ? (IRunInterface)new RunInterfaceForFszyyWechatToDoctor(info) ://微信推送-治疗师
                info.id == "WeChat_Pat" ? (IRunInterface)new RunInterfaceForFszyyWeChatToPatient(info) ://微信推送-患者
                info.id == "Sms_Pat" ? (IRunInterface)new RunInterfaceForHaSmsToPat(info) ://短信推送-患者
                null;     
            return iface;
        }
    }
}
