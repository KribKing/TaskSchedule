using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"E:\Mr.King.Prj\山西大同\Winning.DownLoad.UI\Winning.Rims.EmrViewer\bin\Debug";
                string processName = path + "\\Winning.Rims.EmrViewer.exe";//读取配置

                string startInfo = "5177668 1 1275  ";//测试人员
           
                Process myprocess = new Process();
                ProcessStartInfo Info = new ProcessStartInfo(processName, startInfo);
                myprocess.StartInfo = Info;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.StartInfo.WorkingDirectory = path;
                myprocess.Start();
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
