using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalInstanceManager<ConsoleLogHelper>.Intance.noticeConsoleLog += Intance_noticeConsoleLog;       
            GlobalInstanceManager<JobInfoManager>.Intance.Init();
            GlobalInstanceManager<SchedulerManager>.Intance.Start();
            GlobalInstanceManager<JobInfoManager>.Intance.Save();
        }

        private static void Intance_noticeConsoleLog(LogMessage message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
