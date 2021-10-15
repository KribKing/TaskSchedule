using TaskSchedule.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.Config
{
    public partial class ConsoleFrm : FrmBase
    {
        private bool StopFlag = false;
        public FollowMainWinHelper MainWin { get; set; }

        public ConsoleFrm()
        {
            InitializeComponent();
        }
        public ConsoleFrm(FollowMainWinHelper mainWin)
        {
            InitializeComponent();
            this.MainWin = mainWin;
        }
        private void ConsoleFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainWin != null)
                MainWin.RemoveWinHandle("ConsoleFrm");
            GlobalInstanceManager<ConsoleLogHelper>.Intance.noticeConsoleLog -= Intance_noticeConsoleLog;
        }

        private void ConsoleFrm_Load(object sender, EventArgs e)
        {
            GlobalInstanceManager<ConsoleLogHelper>.Intance.noticeConsoleLog += Intance_noticeConsoleLog;
            Log4netUtil.Debug("控制台日志开启");
        }

        private void Intance_noticeConsoleLog(LogMessage message)
        {
            this.SetLog(message);
        }

        private void SetLog(LogMessage message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<LogMessage>(SetLog), message);
            }
            else
            {
                if (StopFlag)
                    return;
                if (this.rtblog.Lines.Length >= 10000)
                {
                    this.rtblog.Clear();
                }
                this.rtblog.SelectionColor = GlobalInstanceManager<ConsoleLogHelper>.Intance.GetCtrlColor(this.rtblog.BackColor, message.LogLevel);
                this.rtblog.AppendText(message.Message + Environment.NewLine);
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            this.rtblog.Clear();
            Tools.FlushMemory();
        } 

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            this.StopFlag = !this.StopFlag;
            this.toggleSwitch1.ToolTip = this.StopFlag ? "恢复日志输出" : "暂停日志输出";
        }
    }
}
