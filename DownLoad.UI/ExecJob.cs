﻿using DownLoad.Business;
using DownLoad.Core;
using System;

namespace DownLoad.UI
{
    public partial class ExecJob : FrmBase
    {
        private JobInfo Cur_job;
        public ExecJob()
        {
            InitializeComponent();
        }
        public ExecJob(JobInfo info)
        {
            InitializeComponent();
            this.Cur_job = info;
            this.Text = "作业【" + this.Cur_job.name + "】的执行计划";
        }
        private void ExecJob_Load(object sender, EventArgs e)
        {
            this.InitCtrl();
            this.SetZxlx();        
        }

        private void InitCtrl()
        {
            this.deontime.DateTime = DateTime.Now;
            this.teontime.EditValue = DateTime.Now;
        }

        private void rgzxlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetZxlx();
        }

        private void SetZxlx()
        {
            if (this.rgzxlx.SelectedIndex==1)
            {
                this.pcagain.Enabled = false;
                this.gbontime.Enabled = true;
            }
            else
            {
                this.pcagain.Enabled = true;
                this.gbontime.Enabled = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

    }
}
