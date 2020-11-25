using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;
using Winning.DownLoad.UI.Properties;

namespace Winning.DownLoad.UI
{
    public partial class FrmMain : FrmBase
    {
        private JobInfo Cur_Job;
        public FrmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void Init()
        {
            try
            {
                GlobalInstanceManager<JobInfoManager>.Intance = new JobInfoManager(Settings.Default.dbtype,EncodeAndDecode.Decode(Settings.Default.connstring));
                GlobalInstanceManager<SchedulerManager>.Intance = new SchedulerManager();
                GlobalInstanceManager<SchedulerManager>.Intance.OnScheduleLog += Intance_OnScheduleLog;
                GlobalInstanceManager<SchedulerManager>.Intance.OnScheduleLogWithJob += Intance_OnScheduleLogWithJob;
                this.LoadJobInfo();
                this.AddLogText("初始化加载完成");
            }
            catch (Exception ex)
            {
                this.AddLogText("初始化发生异常：" + ex.Message);
            }
        }
        private void LoadJobInfo()
        {
            this.treeList1.Nodes.Clear();//清空所有节点，以便重新加载
            var list = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.GroupBy(a => a.sysname);
            string patkey = "";
            foreach (var item in list)
            {
                if (patkey != item.Key)
                {
                    patkey = item.Key;
                    TreeListNode node = this.treeList1.AppendNode(null, -1);
                    node.SetValue(this.tPatKey, item.Key);
                    node.Tag = patkey;
                    node.StateImageIndex = 5;
                    LoadTreeCtrl(node, item.Key);
                }
            }
            this.treeList1.ExpandAll();
            this.treeList1.Refresh();
        }

        private void LoadTreeCtrl(TreeListNode pnode, string parentkey)
        {
            try
            {
                List<JobInfo> dv = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.Where(o => o.sysname.Trim() == parentkey.Trim()).ToList();//根据父级id获取子节点循环加载
                foreach (JobInfo rv in dv)
                {
                    TreeListNode node = pnode.TreeList.AppendNode(rv.sysname, pnode);
                    node.SetValue(0, rv.name);
                    node.Tag = rv;
                    if (rv.jlzt == "0")
                    {
                        node.StateImageIndex = 1;
                    }
                    else
                    {
                        node.StateImageIndex = 0;
                    }
                    //LoadTreeCtrl(node, Command.Instance.Getstring(rv.table_key));
                }
            }
            catch (Exception ex)
            {
                this.AddLogText("作业列表加载失败：" + ex.Message);
            }
        }

        private void Intance_OnScheduleLog(string msg)
        {
            this.AddLogText(msg);
        }
        private void Intance_OnScheduleLogWithJob(JobInfo info, string msg)
        {
            this.AddLogText(msg);
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.notifyIcon1.Visible = true;
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果               
                this.Hide();
                return;
            }
            else
            {
                try
                {
                    GlobalInstanceManager<SchedulerManager>.Intance.ShutDown();
                    GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AddLogText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AddLogText), text);
                return;
            }
            if (this.txtmsg.Lines.Length > 500)
            {
                this.txtmsg.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (text.Contains("Response"))
                {
                    try
                    {

                        string strresult = Tools.GetJsonNodeValue(text, "Response|Head|AckCode", "100").ToString();
                        string strjobid = Tools.GetJsonNodeValue(text, "Response|Head|TranCode", "00").ToString();
                        string strjobsys = Tools.GetJsonNodeValue(text, "Response|Head|TranSys", "00").ToString();
                        if (strresult.Contains("100"))
                        {
                            this.InsertJobHistory(0, strjobid, strjobsys, text);
                            this.txtmsg.SelectionColor = Color.Yellow;
                            text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(strjobid, strjobsys).name + "】执行成功";
                        }
                        else
                        {
                            this.InsertJobHistory(1, strjobid, strjobsys, text);
                            string strmsg = Tools.GetJsonNodeValue(text, "Response|Head|AckMessage", "异常错误").ToString();
                            this.txtmsg.SelectionColor = Color.Red;
                            text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(strjobid, strjobsys).name + "】执行异常：" + strmsg;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.txtmsg.AppendText(DateTime.Now.ToString() + "==》Reponse解析失败：" + ex.Message + text);
                    }
                }
                else if (text.Contains("Request"))
                {
                    try
                    {

                        string strjobid = Tools.GetJsonNodeValue(text, "Request|Head|TranCode", "00").ToString();
                        string strjobsys = Tools.GetJsonNodeValue(text, "Request|Head|TranSys", "00").ToString();
                        this.txtmsg.SelectionColor = Color.Yellow;
                        text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(strjobid, strjobsys).name + "】执行开始";

                    }
                    catch (Exception ex)
                    {
                        this.txtmsg.AppendText(DateTime.Now.ToString() + "==》Request解析失败：" + ex.Message + text);
                    }
                }
                this.txtmsg.AppendText(DateTime.Now.ToString() + "==》" + text + Environment.NewLine);
            }
        }

        private void InsertJobHistory(int zxzt, string strjobid, string strjobsys, string text)
        {
            string strsql = "insert into CronJob_JOBHISTORY(id,system,zxzt,rawtext,oper_date) values('" + strjobid + "','" + strjobsys + "'," + zxzt + ",'" + EncodeHelper.EncodeBase64(text) + "','" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "')";
            int retnum = GlobalInstanceManager<GlobalSqlManager>.Intance.ExecuteNoneQuery(Settings.Default.dbtype, EncodeAndDecode.Decode(Settings.Default.connstring), strsql);
            if (retnum > 0)
            {
                this.AddLogText("作业【" + GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(strjobid, strjobsys).name + "】执行记录插入数据库成功");
            }
            else
            {
                this.AddLogText("作业【" + GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfo(strjobid, strjobsys).name + "】执行记录插入数据库失败");
            }
        }


        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && this.treeList1.State == TreeListState.Regular)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    tree.SetFocusedNode(hitInfo.Node);
                    TreeListNode node = hitInfo.Node;

                }
                else
                {
                    tree.SetFocusedNode(null);
                }

                if (tree.FocusedNode != null)
                {
                    this.Cur_Job = tree.FocusedNode.Tag as JobInfo;
                    if (this.Cur_Job != null)
                    {
                        this.SetPop(this.Cur_Job);
                        this.popupMenu1.ShowPopup(p);
                    }

                }

            }
        }

        private void SetPop(JobInfo Cur_Job)
        {
            if (Cur_Job.jlzt == "1")
            {
                this.btnjzjob.Enabled = false;
                this.btnqyjob.Enabled = true;
            }
            else
            {
                this.btnjzjob.Enabled = true;
                this.btnqyjob.Enabled = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出本程序吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;
            GlobalInstanceManager<SchedulerManager>.Intance.ShutDown();
            Application.Exit();

        }

        private void btnjzjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node != null && node.Tag != null)
            {
                JobInfo info = node.Tag as JobInfo;
                if (info != null)
                {
                    info.jlzt = "1";
                    node.StateImageIndex = 0;
                }
            }
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }

        private void btnpro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node != null && node.Tag != null)
            {
                JobInfo info = node.Tag as JobInfo;
                if (info != null)
                {
                    using (ConfigFrm frm = new ConfigFrm(info, node,this))
                    {
                        frm.ShowDialog();
                    }
                }
            }
            this.LoadJobInfo();
        }

        private void btnrunjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            string cur_excutereq = "";
            using (RunFrm frm = new RunFrm())
            {
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    cur_excutereq = frm.StrConditon;
                }
            }

            this.QuickExcute(info, cur_excutereq);

        }

        private void btnstopjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalInstanceManager<SchedulerManager>.Intance.ResumeAll();
                this.AddLogText("重启调度器成功");
                foreach (TreeListNode item in this.treeList1.Nodes)
                {
                    item.StateImageIndex = 5;
                }
            }
            catch (Exception ex)
            {
                this.AddLogText("重启调度器失败：" + ex.Message);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalInstanceManager<SchedulerManager>.Intance.PauseAll();
                this.AddLogText("暂停调度器成功");
                foreach (TreeListNode item in this.treeList1.Nodes)
                {
                    item.StateImageIndex = 6;
                }
            }
            catch (Exception ex)
            {
                this.AddLogText("暂停调度器失败：" + ex.Message);
            }

        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            this.txtmsg.Clear();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            using (ConfigFrm config = new ConfigFrm(null,null,this))
            {
                config.ShowDialog();
            }
            this.LoadJobInfo();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.LoadHistory();
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                TreeListNode node = this.treeList1.FocusedNode;
                if (node != null && node.Tag != null)
                {
                    JobInfo info = node.Tag as JobInfo;
                    if (info != null)
                    {
                        string strsql = "exec usp_jk_getjobhistory @id='" + info.id + "',@sys='" + info.system + "'";
                        DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(Settings.Default.dbtype, EncodeAndDecode.Decode(Settings.Default.connstring), strsql);
                        this.gridControl1.DataSource = dt;
                    }
                }
                else
                {
                    this.gridControl1.DataSource = null;
                }
                this.gridControl1.RefreshDataSource();
            }
            catch
            {
                this.gridControl1.DataSource = null;
            }
        }

        private void btnqyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node != null && node.Tag != null)
            {
                JobInfo info = node.Tag as JobInfo;
                if (info != null)
                {
                    info.jlzt = "0";
                    node.StateImageIndex = 1;
                }
            }
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node != null && node.Tag != null)
            {
                JobInfo info = node.Tag as JobInfo;
                if (info != null)
                {
                    ConfigFrm frm = new ConfigFrm(info, node,this);
                    frm.Show();
                }
            }
        }

        private void btnFast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            string strrequest = GlobalInstanceManager<JobInfoManager>.Intance.GetExcuteCondition(info);
            Stopwatch s = new Stopwatch();
            s.Start();
            this.QuickExcute(info, strrequest);
            s.Stop();
            Console.WriteLine("快速断点：" + s.ElapsedMilliseconds);
        }

        public void QuickExcute(JobInfo jobInfo, string request)
        {
            Task task = new Task(() =>
            {
                request = GetStrJsonHelper.GetReqJson(jobInfo.id, jobInfo.system, "请求访问", request);
                string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(request);
                Tools.FlushMemory();
                this.AddLogText(strret);               
            });
            task.Start();
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            defaultLookAndFeel.LookAndFeel.SkinName = Settings.Default.theme;
            this.notifyIcon1.Visible = false;
            this.Text = Settings.Default.appname;
            this.Init();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = this.gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                JobInfo cur_Job = this.treeList1.FocusedNode.Tag as JobInfo;
                JsonFrm frm = new JsonFrm(cur_Job, dr["xh"].ToString());
                frm.Show();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DataRow dr = this.gridView1.GetDataRow(e.RowHandle);
            if (dr != null)
                e.Appearance.ForeColor = dr["zxzt"].ToString() == "1" ? Color.Red : Color.Black;
        }
    }
}
