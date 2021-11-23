using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskSchedule.Core;
using TaskSchedule.Interface;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.Config.Dev
{
    public partial class ConfigFrm : FrmBase, IConfigUIInterface
    {
        private JobInfo _cur_job = new JobInfo();

        public JobInfo Cur_JobInfo
        {
            get { return _cur_job; }
            set { _cur_job = value; }
        }

        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(JobInfo info)
        {
            InitializeComponent();
            this.Cur_JobInfo = info;
        }

        private void ConfigFrm_Shown(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null) return;
            this.Text = string.Format("作业【{0}】的属性", this.Cur_JobInfo.name);
            this.teid.Text = this.Cur_JobInfo.id;
            this.tename.Text = this.Cur_JobInfo.name;
            this.tesystem.Text = this.Cur_JobInfo.system;
            this.tesysname.Text = this.Cur_JobInfo.sysname;
            this.txtexp.Text = this.Cur_JobInfo.expression;
            this.cejlzt.SelectedIndex = int.Parse(this.Cur_JobInfo.jlzt);
            this.LoadChildInfo();
        }
        public virtual void LoadChildInfo()
        {
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
                if (!this.CollectChildJobInfo()) return;
                this.Cur_JobInfo.Save();
                MessageBox.Show("保存成功", "卫宁操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.Cur_JobInfo.name + "】保存异常，请检查" + ex.Message, ex);
                MessageBox.Show("保存异常，请检查", "卫宁操作提示", MessageBoxButtons.OK);
            }
        }

        public virtual bool CollectChildJobInfo()
        {
            return true;
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

        public void ShowConfig()
        {
            this.Show();
        }

        public object UIIndex
        {
            get { return this.Handle; }
        }


        public void SetJobInfo(JobInfo info)
        {
            this.Cur_JobInfo = info;
        }
    }
}
