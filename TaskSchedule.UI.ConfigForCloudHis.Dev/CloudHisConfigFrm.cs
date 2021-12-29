using DevExpress.XtraEditors;
using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Business.CloudHis;
using TaskSchedule.UI.Config.Dev;

namespace TaskSchedule.UI.ConfigForCloudHis.Dev
{
    public partial class CloudHisConfigFrm : ConfigFrm
    {
        public CloudHisConfigFrm()
        {
            InitializeComponent();
        }

        private void CloudHisConfigFrm_Load(object sender, EventArgs e)
        {
            this.txttmp.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rttscript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rtbxml.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
        }

        public override void LoadChildInfo()
        {
            JobInfoCloudHis job = this.Cur_JobInfo as JobInfoCloudHis;         
            this.txttstr.Text = job.targetdbstring;
            this.txttmpname.Text = job.tmpname;
            this.txttmp.Text = job.createtmp;
            this.rttscript.Text = job.targetsql;
            this.txturl.Text = job.weburl;
            this.txtuserid.Text = job.CloudUserId;
            this.txtpassword.Text = job.CloudUserPassword;
            this.isencode.Checked = job.isencode;
            this.txtkey.Text = job.Key;
            this.rtbxml.Text = job.requestxml;
            this.txtbzcode.Text = job.businesscode;
            this.txtbztable.Text = job.businesstable;
            this.isdbpara.Checked = job.isdbpara;
        }
        public override bool CollectChildJobInfo()
        {
            JobInfoCloudHis job = this.Cur_JobInfo as JobInfoCloudHis;
            job.targetdbstring = this.txttstr.Text.Trim();
            job.tmpname = this.txttmpname.Text.Trim();
            job.createtmp = this.txttmp.Text.Trim();
            job.targetsql = this.rttscript.Text.Trim();         
            job.weburl = this.txturl.Text.Trim();
            job.CloudUserId = this.txtuserid.Text.Trim();
            job.CloudUserPassword = this.txtpassword.Text.Trim();
            job.isencode = this.isencode.Checked;
            job.Key = this.txtkey.Text.Trim();
            job.requestxml = this.rtbxml.Text.Trim();
            job.businesscode = this.txtbzcode.Text.Trim();
            job.businesstable = this.txtbztable.Text.Trim();
            job.isdbpara = this.isdbpara.Checked;
            return true;
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            this.splitctrl.PanelVisibility = btn == this.btnright ? SplitPanelVisibility.Panel1 :
                                            btn == this.btnleft ? SplitPanelVisibility.Panel2 :
                                            SplitPanelVisibility.Both;
        }
        private void btnCreateTemp_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null || string.IsNullOrEmpty(this.Cur_JobInfo.id))
            {
                MessageBox.Show("当前作业内容无效，请检查", "操作提示", MessageBoxButtons.OK);
                return;
            }
            try
            {
                this.Cur_JobInfo.SetTmpTableSchema();
                this.LoadChildInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出发生异常：" + ex.Message);
            }
        }
    }
}
