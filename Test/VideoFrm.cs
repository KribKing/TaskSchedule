using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class VideoFrm : Form
    {
        public VideoFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    this.axWindowsMediaPlayer1.URL = this.openFileDialog1.FileName;
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = "\\\\172.17.17.182\\emr\\b5aa273f65baa5f8adaa7fba6a525884.mp4";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FtpHelper ftp = new FtpHelper("172.17.17.182", "21", "ftpuser", "qwe123");
            bool isok;
            ftp.RelatePath = "/" + "b5aa273f65baa5f8adaa7fba6a525884.mp4";
            ftp.DownLoad("D:\\Emr\\test.mp4", out isok);
            if (isok)
            {
                this.axWindowsMediaPlayer1.URL = "D:\\Emr\\test.mp4";
            }
        }
    }
}
