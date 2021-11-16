using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TaskSchedule.Core
{
    
    public delegate void NoticeConsoleLog(LogMessage message);
    public class ConsoleLogHelper
    { 
        public event NoticeConsoleLog noticeConsoleLog;
        public void SetLog(LogMessage message)
        {
            message.Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "==》" + message.Message;
            if (noticeConsoleLog != null)
                noticeConsoleLog(message);
        }
        public Color GetCtrlColor(Color color,LogLevel loglevel)
        {
            Color ctrlColor = Color.Black;
            switch (loglevel)
            {
                case LogLevel.Info:
                    ctrlColor = Color.Black;
                    break;
                case LogLevel.Debug:
                    ctrlColor = Color.DarkBlue;
                    break;
                case LogLevel.Error:
                    ctrlColor = Color.Red;
                    break;
                case LogLevel.Warn:
                    ctrlColor = Color.OrangeRed;
                    break;
                case LogLevel.Fatal:
                    ctrlColor = Color.DarkRed;
                    break;
                default:              
                    break;
            }
            return ctrlColor;
        }
    }
}
