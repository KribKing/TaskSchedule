using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskSchedule.Core;
using TaskSchedule.Interface;
using TaskSchedule.UI.Base;

namespace TaskSchedule.Business.PushMessage
{
    public partial class ConfigFrm : FrmBase
    {
        private JobInfoPushMessage Cur_JobInfo = new JobInfoPushMessage();
        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(JobInfo info)
        {
            InitializeComponent();
            this.Cur_JobInfo = info as JobInfoPushMessage;
        }

        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null) return;
            this.Text = string.Format("作业【{0}】的属性", this.Cur_JobInfo.name);
            this.teid.Text = this.Cur_JobInfo.id;
            this.tename.Text = this.Cur_JobInfo.name;
            this.tesystem.Text = this.Cur_JobInfo.system;
            this.tesysname.Text = this.Cur_JobInfo.sysname;
            this.txtexp.Text = this.Cur_JobInfo.expression;
            this.cejlzt.SelectedIndex = int.Parse(this.Cur_JobInfo.jlzt);
            this.cbetdbtype.SelectedIndex = this.Cur_JobInfo.dbtype;
            this.txttstr.Text = this.Cur_JobInfo.dbstring;
            this.txtweburl.Text = this.Cur_JobInfo.weburl;
            this.txttokenurl.Text = this.Cur_JobInfo.tokenweburl;

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalInstanceManager<FollowMainWinHelper>.Intance.RemoveWinHandle(this.Cur_JobInfo.GuId.ToString());
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Cur_JobInfo == null) return;
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
                this.Cur_JobInfo.id = this.teid.Text;
                this.Cur_JobInfo.name = this.tename.Text.Trim();
                this.Cur_JobInfo.system = this.tesystem.Text;
                this.Cur_JobInfo.sysname = this.tesysname.Text.Trim();
                this.Cur_JobInfo.expression = this.txtexp.Text.Trim();
                this.Cur_JobInfo.jlzt = this.cejlzt.SelectedIndex.ToString();
                this.Cur_JobInfo.dbtype = this.cbetdbtype.SelectedIndex;
                this.Cur_JobInfo.dbstring = this.txttstr.Text.Trim();
                this.Cur_JobInfo.weburl = this.txtweburl.Text.Trim();
                this.Cur_JobInfo.tokenweburl = this.txttokenurl.Text.Trim();
                this.Cur_JobInfo.Save();
                MessageBox.Show("保存成功", "卫宁操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_JobInfo.name + "】保存异常，请检查" + ex.Message, ex);
                MessageBox.Show("保存异常，请检查", "卫宁操作提示", MessageBoxButtons.OK);
            }
        }

        private void btnquick_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null) return;
            Task task = new Task(() =>
            {
                this.Cur_JobInfo.Run();
            });
            task.Start();

        }
    }
}
