using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.UI
{
    public partial class ConfigFrm : FrmBase
    {
        private JobInfo Cur_JobInfo;
        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(JobInfo info)
        {
            this.Cur_JobInfo = info;
            InitializeComponent();
        }
        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo != null)
            {
                this.Text = string.Format("作业【{0}】的属性", this.Cur_JobInfo.name);
                this.txturl.Text = this.Cur_JobInfo.weburl;
                this.txtexp.Text = this.Cur_JobInfo.expression;
                this.txttmpname.Text = this.Cur_JobInfo.tmpname;
                this.txttmp.Text = this.Cur_JobInfo.createtmp;
                this.txtsql.Text = this.Cur_JobInfo.sql;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cur_JobInfo.weburl = this.txturl.Text.Trim();
                this.Cur_JobInfo.expression = this.txtexp.Text.Trim();
                this.Cur_JobInfo.tmpname = this.txttmpname.Text.Trim();
                this.Cur_JobInfo.createtmp = this.txttmp.Text.Trim();
                this.Cur_JobInfo.sql = this.txtsql.Text.Trim();
                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                MessageBox.Show("保存成功","卫宁操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，异常原因："+ex.Message, "卫宁操作提示", MessageBoxButtons.OK);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
