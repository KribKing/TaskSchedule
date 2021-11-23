using DevExpress.XtraEditors;
using ICSharpCode.TextEditor.Document;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Business.SyncData;
using TaskSchedule.Core;
using TaskSchedule.Core.Schema;
using TaskSchedule.Interface;

namespace TaskSchedule.UI.Config.Dev
{
    public partial class SyncDataConfigFrm : ConfigFrm
    {
        private PopupContainerEdit Cur_popc;
        public SyncDataConfigFrm()
        {
            InitializeComponent();
        }
        public SyncDataConfigFrm(JobInfo info)
            : base(info)
        {
            InitializeComponent();
        }
        public override void LoadChildInfo()
        {
            JobInfoSyncData job = this.Cur_JobInfo as JobInfoSyncData;
            this.cbtop.SelectedIndex = job.isbulkop ? 0 : 1;
            this.gsource.Enabled = job.isbulkop;
            this.cbetdbtype.SelectedIndex = job.targetdbtype;
            this.txttstr.Text = job.targetdbstring;
            this.txttmpname.Text = job.tmpname;
            this.txttmp.Text = job.createtmp;
            this.rttscript.Text = job.targetsql;
            this.rbsweb.Checked = job.sourcetype == 0;
            this.rbsdb.Checked = job.sourcetype == 1;
            this.cbstype.SelectedIndex = job.servertype;
            this.txtMethod.Text = job.servermethod;
            this.txturl.Text = job.weburl;
            this.cbejxlx.SelectedIndex = job.nodelx;
            this.tenode.Text = job.node;
            this.rtbxml.Text = job.xmlconfig;
            this.cbesdbtype.SelectedIndex = job.sourcedbtype;
            this.txtsstr.Text = job.sourcedbstring;
            this.rtsscript.Text = job.sourcesql;
        }
        public override bool CollectChildJobInfo()
        {
            JobInfoSyncData job = this.Cur_JobInfo as JobInfoSyncData;
            job.targetdbtype = this.cbetdbtype.SelectedIndex;
            job.isbulkop = this.cbtop.SelectedIndex == 0 ? true : false;
            job.targetdbstring = this.txttstr.Text.Trim();
            job.tmpname = this.txttmpname.Text.Trim();
            job.createtmp = this.txttmp.Text.Trim();
            job.targetsql = this.rttscript.Text.Trim();
            job.sourcetype = this.rbsweb.Checked ? 0 : 1;
            job.servertype = this.cbstype.SelectedIndex;
            job.servermethod = this.txtMethod.Text.Trim();
            job.weburl = this.txturl.Text.Trim();
            job.nodelx = this.cbejxlx.SelectedIndex;
            job.node = this.tenode.Text.Trim();
            job.xmlconfig = this.rtbxml.Text.Trim();
            job.sourcedbtype = this.cbesdbtype.SelectedIndex;
            job.sourcedbstring = this.txtsstr.Text.Trim();
            job.sourcesql = this.rtsscript.Text.Trim();
            return true;
        }
        private void SyncDataConfigFrm_Shown(object sender, EventArgs e)
        {
            this.txttmp.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rtsscript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rttscript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSql");
            this.rtbxml.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
        }

        private void rbsweb_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPageIndex = this.rbsweb.Checked ? 0 : 1;
            this.xtraTabPage2.PageVisible = !this.rbsweb.Checked;
            this.xtraTabPage1.PageVisible = this.rbsweb.Checked;
        }

        private void cbtop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gsource.Enabled = this.cbtop.SelectedIndex == 0;
        }
        private void btngeneratexml_Click(object sender, EventArgs e)
        {
            using (MapXmlFrm frm = new MapXmlFrm(this.rtbxml.Text.Trim(), this.Cur_JobInfo.name))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.rtbxml.Text = frm.MapJson;
                }
            }
        }
        private void btnxml_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "json文件|*.json|所有文件(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                this.rtbxml.Text = File.ReadAllText(fName);
            }
        }
        private void cbejxlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pxml.Visible = this.cbejxlx.SelectedIndex == 0 ? false : true;
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
        private void btntest_Click(object sender, EventArgs e)
        {
            TestFrm frm = new TestFrm(this.Cur_JobInfo);
            frm.Show();
        }

        private void popctarget_QueryPopUp(object sender, CancelEventArgs e)
        {
            this.Cur_popc = sender as PopupContainerEdit;
            this.Cur_popc.Properties.PopupControl = this.pop_ctrl_combox;
            this.LoadPopCtrl();
        }

        private void LoadPopCtrl()
        {
            List<JobInfo> list = this.Cur_JobInfo.SettingInterface.Default;
            this.gcjob.DataSource = list;
            this.gcjob.RefreshDataSource();
            foreach (JobInfo item in list.Where(a => a.system == this.Cur_JobInfo.system))
            {
                int rowhanlde = this.gvjob.GetRowHandle(list.IndexOf(item));
                this.gvjob.SelectRow(rowhanlde);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> list = this.gvjob.GetSelectedRows().Where(a => a >= 0).ToList();
                if (this.Cur_popc == null || list == null || list.Count <= 0) return;
                foreach (int rowhanlde in list)
                {
                    JobInfoSyncData info = this.gvjob.GetRow(rowhanlde) as JobInfoSyncData;
                    if (this.Cur_popc == this.popctarget)
                    {
                        info.targetdbtype = this.cbetdbtype.SelectedIndex;
                        info.targetdbstring = this.txttstr.Text.Trim();
                    }
                    else
                    {
                        info.sourcedbtype = this.cbesdbtype.SelectedIndex;
                        info.sourcedbstring = this.txtsstr.Text.Trim();
                    }
                }
                this.Cur_JobInfo.Save();
                MessageBox.Show("配置传递成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("配置传递失败", ex);
            }
        }

        private void btnclosepop_Click(object sender, EventArgs e)
        {
            if (this.Cur_popc == null) return;
            this.Cur_popc.ClosePopup();
        }

        private void btnright_Click(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            this.splitctrl.PanelVisibility = btn == this.btnright ? SplitPanelVisibility.Panel1 :
                                            btn == this.btnleft ? SplitPanelVisibility.Panel2 :
                                            SplitPanelVisibility.Both;
        }
    }
}
