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

        private void rgzxlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgzxlx.SelectedIndex==0)
            {
                this.gbontime.Enabled = false;
                this.pcagain.Enabled = true;
            }
            else
            {
                this.gbontime.Enabled = true;
                this.pcagain.Enabled = false;
            }
        }

        private void rgpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rgpl.SelectedIndex==0)
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
            if (this.rgmtpl.SelectedIndex==0)
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
            this.rgzxlx.SelectedIndex=0;
            this.rgpl.SelectedIndex = 0;
            this.rgmtpl.SelectedIndex = 0;
        }
    }
}
