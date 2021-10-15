using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TaskSchedule.Core
{
    public class LogMessage
    {
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }

    }
    public enum LogLevel
    {
        Info,
        Debug,
        Error,
        Warn,
        Fatal
    }
}
