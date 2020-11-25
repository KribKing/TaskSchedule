using DevExpress.XtraTreeList.Nodes;
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
        private TreeListNode Cur_JobNode;
        private FrmMain ParentFrm;
        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(JobInfo info, TreeListNode node, FrmMain Pat)
        {
            this.Cur_JobInfo = info;
            this.Cur_JobNode = node;
            this.ParentFrm = Pat;
            InitializeComponent();
        }
        private void ConfigFrm_Load(object sender, EventArgs e)
        {

            if (this.Cur_JobInfo != null)
            {
                this.Text = string.Format("作业【{0}】的属性", this.Cur_JobInfo.name);
                this.teid.Text = this.Cur_JobInfo.id;
                this.tename.Text = this.Cur_JobInfo.name;
                this.tesystem.Text = this.Cur_JobInfo.system;
                this.tesysname.Text = this.Cur_JobInfo.sysname;
                this.txtexp.Text = this.Cur_JobInfo.expression;
                this.cejlzt.SelectedIndex = int.Parse(this.Cur_JobInfo.jlzt);
                this.cbtop.SelectedIndex = this.Cur_JobInfo.IsBulkOp ? 0 : 1;
                if (this.cbtop.SelectedIndex == 0)
                {
                    this.gsource.Enabled = true;
                }
                else
                {
                    this.gsource.Enabled = false;
                }
                this.cbetdbtype.SelectedIndex = this.Cur_JobInfo.TargetDbType;
                this.txttstr.Text = this.Cur_JobInfo.TargetDbString;
                this.cetjm.Checked = this.Cur_JobInfo.IsTargetDbEncode;
                this.txttmpname.Text = this.Cur_JobInfo.tmpname;
                this.txttmp.Text = this.Cur_JobInfo.createtmp;
                this.rttscript.Text = this.Cur_JobInfo.TargetSql;

                this.rbsweb.Checked = this.Cur_JobInfo.SourceType == 0 ? true : false;
                this.cbstype.SelectedIndex = this.Cur_JobInfo.ServerType;
                this.txturl.Text = this.Cur_JobInfo.weburl;
                this.cbejxlx.SelectedIndex = this.Cur_JobInfo.nodelx;
                this.tenode.Text = this.Cur_JobInfo.node;


                this.rbsdb.Checked = this.Cur_JobInfo.SourceType == 1 ? true : false;
                this.cbesdbtype.SelectedIndex = this.Cur_JobInfo.SourceDbType;
                this.txtsstr.Text = this.Cur_JobInfo.SourceDbString;
                this.cesjm.Checked = this.Cur_JobInfo.IsSourceDbEncode;
                this.rtsscript.Text = this.Cur_JobInfo.SourceSql;


                this.teid.Enabled = false;
                this.tesystem.Enabled = false;
                this.tesysname.Enabled = false;
                this.btnnew.Visible = false;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.teid.Text.Trim()))
                {
                    MessageBox.Show("作业编码不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tename.Text.Trim()))
                {
                    MessageBox.Show("作业名称不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tesystem.Text.Trim()))
                {
                    MessageBox.Show("大类编码不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tesysname.Text.Trim()))
                {
                    MessageBox.Show("大类名称不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                    return;
                }
                //if (string.IsNullOrEmpty(this.txtexp.Text.Trim()))
                //{
                //    MessageBox.Show("作业表达式不能为空，请检查", "卫宁操作提示", MessageBoxButtons.OK);
                //    return;
                //}
                if (this.Cur_JobInfo == null)
                {
                    this.Cur_JobInfo = new JobInfo();
                }

                this.Cur_JobInfo.id = this.teid.Text.Trim();
                this.Cur_JobInfo.name = this.tename.Text.Trim();
                this.Cur_JobInfo.system = this.tesystem.Text.Trim();
                this.Cur_JobInfo.sysname = this.tesysname.Text.Trim();
                this.Cur_JobInfo.expression = this.txtexp.Text.Trim();
                this.Cur_JobInfo.jlzt = this.cejlzt.SelectedIndex.ToString();

                this.Cur_JobInfo.TargetDbType = this.cbetdbtype.SelectedIndex;
                this.Cur_JobInfo.IsBulkOp = this.cbtop.SelectedIndex == 0 ? true : false;
                this.Cur_JobInfo.TargetDbString = this.txttstr.Text.Trim();
                this.Cur_JobInfo.IsTargetDbEncode = this.cetjm.Checked;
                this.Cur_JobInfo.tmpname = this.txttmpname.Text.Trim();
                this.Cur_JobInfo.createtmp = this.txttmp.Text.Trim();
                this.Cur_JobInfo.TargetSql = this.rttscript.Text.Trim();


                this.Cur_JobInfo.SourceType = this.rbsweb.Checked ? 0 : 1;

                this.Cur_JobInfo.ServerType = this.cbstype.SelectedIndex;
                this.Cur_JobInfo.weburl = this.txturl.Text.Trim();
                this.Cur_JobInfo.nodelx = this.cbejxlx.SelectedIndex;
                this.Cur_JobInfo.node = this.tenode.Text.Trim();

                this.Cur_JobInfo.SourceDbType = this.cbesdbtype.SelectedIndex;
                this.Cur_JobInfo.SourceDbString = this.txtsstr.Text.Trim();
                this.Cur_JobInfo.IsSourceDbEncode = this.cesjm.Checked;
                this.Cur_JobInfo.SourceSql = this.rtsscript.Text.Trim();


                GlobalInstanceManager<JobInfoManager>.Intance.AddJobInfo(Cur_JobInfo);
                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                MessageBox.Show("保存成功", "卫宁操作提示", MessageBoxButtons.OK);
                this.teid.Enabled = false;
                this.tesystem.Enabled = false;
                this.tesysname.Enabled = false;
                if (this.Cur_JobNode != null)
                {
                    this.Cur_JobNode.SetValue(0, this.Cur_JobInfo.name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，异常原因：" + ex.Message, "卫宁操作提示", MessageBoxButtons.OK);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtexp_DoubleClick(object sender, EventArgs e)
        {
            using (ExecJob frm = new ExecJob(Cur_JobInfo))
            {
                frm.ShowDialog();
            }
        }


        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Cur_JobInfo = null;
            this.teid.Enabled = true;
            this.tesystem.Enabled = true;
            this.tesysname.Enabled = true;
            this.teid.Text = "";
            this.tename.Text = "";
            this.tesystem.Text = "";
            this.tesysname.Text = "";
            this.txtexp.Text = "";
            this.cejlzt.SelectedIndex = 0;
            this.rbsweb.Checked = true; ;
            this.txturl.Text = "";
            this.txttmpname.Text = "";
            this.txttmp.Text = "";
            this.rttscript.Text = "";
            this.rtsscript.Text = "";
            this.tenode.Text = "";
        }

        private void rbsweb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbsweb.Checked)
            {
                this.pswb.Enabled = true;
                this.psdb.Enabled = false;
            }
            else
            {
                this.pswb.Enabled = false;
                this.psdb.Enabled = true;
            }
        }

        private void cbtop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbtop.SelectedIndex == 0)
            {
                this.gsource.Enabled = true;
            }
            else
            {
                this.gsource.Enabled = false;
            }
        }

        private void btnquick_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo != null)
            {
                string strrequest = GlobalInstanceManager<JobInfoManager>.Intance.GetExcuteCondition(this.Cur_JobInfo);
                this.ParentFrm.QuickExcute(this.Cur_JobInfo, strrequest);
            }
        }
    }
}
