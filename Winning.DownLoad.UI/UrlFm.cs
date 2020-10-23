using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winning.DownLoad.UI.Properties;

namespace Winning.DownLoad.UI
{
    public partial class UrlFm : Form
    {
        public UrlFm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.weburl = this.txturl.Text.Trim();
                Settings.Default.Save();
                MessageBox.Show("修改成功", "配置操作", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败", "配置操作", MessageBoxButtons.OK);              
            }
        }

        private void UrlFm_Load(object sender, EventArgs e)
        {
            this.txturl.Text = Settings.Default.weburl;
        }
    }
}
