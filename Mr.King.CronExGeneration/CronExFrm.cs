using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mr.King.CronExGeneration
{
    public partial class CronExFrm : Form
    {
        public CronExFrm()
        {
            InitializeComponent();
        }

        private void rbplmy1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbplmy1.Checked)
            {
                this.pcplmyt.Enabled = true;
                this.pcplmyxq.Enabled = false;
            }
            else
            {
                this.pcplmyt.Enabled = false;
                this.pcplmyxq.Enabled = true;
            }
        }

        private void rgpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgpl.SelectedIndex == 0)
            {
                this.pcplmt.Enabled = true;
                this.pcplmz.Enabled = false;
                this.pcplmy.Enabled = false;
            }
            else if (this.rgpl.SelectedIndex == 1)
            {
                this.pcplmt.Enabled = false;
                this.pcplmz.Enabled = true;
                this.pcplmy.Enabled = false;
            }
            else
            {
                this.pcplmt.Enabled = false;
                this.pcplmz.Enabled = false;
                this.pcplmy.Enabled = true;
            }
        }

        private void rgmtpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgmtpl.SelectedIndex == 0)
            {
                this.pcmtplzxyc.Enabled = true;
                this.pcmtplzxjg.Enabled = false;
            }
            else
            {
                this.pcmtplzxyc.Enabled = false;
                this.pcmtplzxjg.Enabled = true;
            }
        }

        private void CronExFrm_Load(object sender, EventArgs e)
        {

        }

        private void txtce_EditValueChanged(object sender, EventArgs e)
        {
            this.txtsummary.Text = GlobalCronExpressionHelper.TranslateToChinese(this.txtce.Text.Trim());
        }

        private void rgcxsj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgcxsj.SelectedIndex == 0)
            {
                this.dejscxsj.Enabled = true;
            }
            else
            {
                this.dejscxsj.Enabled = false;
            }
        }
        private void BuildCron()
        {
            string year = "*";
            if (this.rgcxsj.SelectedIndex == 1)
            {
                year = this.dekscxsj.DateTime.ToString("yyyy") + "-" + this.dejscxsj.DateTime.ToString("yyyy");
            }
            string month = "*";
            string week = "*";
            string day = "*";
            if (this.rgpl.SelectedIndex == 0)//每天
            {
                month = "*";
                week = "*";
                day = "1/" + this.sezqplmt.EditValue.ToString();
            }
            else if (this.rgpl.SelectedIndex == 1)//每周
            {
                month = "*";
                week = "*";
                day = "*";
            }
            else if (this.rgpl.SelectedIndex == 2)//每月
            {
                month = "*";
                week = "*";
                day = "1/" + this.sezqplmt.EditValue.ToString();
            }

            string hour = "*";
            string minute = "*";
            string second = "*";
            if (this.rgmtpl.SelectedIndex == 0)//执行一次
            {
                string time = this.temtzxyc.EditValue.ToString();
                string[] times = time.Split(':');
                hour = times[0];
                minute = times[1];
                second = times[2];
            }
            else if (this.rgmtpl.SelectedIndex == 1)//执行间隔
            {

            }
            string cron = string.Format("{0} {1} {2} {3} {4} {5} {6}", second, minute, hour, day, month, week, year);
            this.txtce.Text = cron;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sezqplmt_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            if (e.IsSpinUp)
            {
                if (this.sezqplmt.EditValue.ToString() == "31")
                {
                    this.sezqplmt.EditValue = 0;
                }
            }
            else
            {
                if (this.sezqplmt.EditValue.ToString() == "1")
                {
                    this.sezqplmt.EditValue = 32;
                }
            }
        }

        private void cbmtzxjg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbmtzxjg.SelectedIndex == 0)//时
            {
                this.tekssj.Properties.EditMask = "HH";
            }
            else if (this.cbmtzxjg.SelectedIndex == 1)//分
            {

            }
            else if (this.cbmtzxjg.SelectedIndex == 2)//秒
            {

            }
        }
    }
}
