using DownLoad.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownLoad.UI
{
    public partial class ConsoleFrm : FrmBase
    {
        private bool StopFlag = false;

        public ConsoleFrm()
        {
            InitializeComponent();
        }

        private void ConsoleFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalInstanceManager<FollowMainWinHelper>.Intance.RemoveWinHandle("ConsoleFrm");
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

        private void btnstop_Click(object sender, EventArgs e)
        {
            this.StopFlag = !this.StopFlag;
            this.btnstop.ToolTip = this.StopFlag ? "恢复输出" : "暂停输出";
        }
    }
}
