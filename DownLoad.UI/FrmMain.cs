using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DownLoad.UI.Properties;
using Newtonsoft.Json;
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
using DownLoad.Business;
using DownLoad.Core;
using System.Runtime.InteropServices;

namespace DownLoad.UI
{
    public partial class FrmMain : FrmBase
    {
        private JobInfo Cur_Job;
        private Dictionary<string, IntPtr> WinHandle = new Dictionary<string, IntPtr>();
        public FrmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Init()
        {
            try
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance = new FollowMainWinHelper(this);
                this.LoadConsole();
                Log4netUtil.IsLog = Settings.Default.islog;
                GlobalInstanceManager<JobInfoManager>.Intance = new JobInfoManager(Settings.Default.dbtype, EncodeAndDecode.Decode(Settings.Default.connstring));
                GlobalInstanceManager<SchedulerManager>.Intance = new SchedulerManager();
                this.LoadJobInfo();
                Log4netUtil.Info("初始化加载完成");
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("初始化发生异常：" + ex.Message,ex);
            }
        }
        private void LoadJobInfo()
        {
            this.treeList1.Nodes.Clear();//清空所有节点，以便重新加载
            var list = GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Values.GroupBy(a => a.sysname);
            string patkey = "";
            foreach (var item in list)
            {
                if (patkey == item.Key)
                    continue;
                patkey = item.Key;
                TreeListNode node = this.treeList1.AppendNode(null, -1);
                node.SetValue(this.tPatKey, item.Key);
                node.Tag = patkey;
                node.StateImageIndex = 5;
                LoadTreeCtrl(node, item.Key);
            }
            this.treeList1.CollapseAll();
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
                    node.StateImageIndex = rv.jlzt == "0" ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业列表加载失败：" + ex.Message, ex);
            }
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

                if (tree.FocusedNode == null)
                    return;
                this.Cur_Job = tree.FocusedNode.Tag as JobInfo;
                if (this.Cur_Job != null)
                {
                    this.SetPop(this.Cur_Job);
                    this.popupMenu1.ShowPopup(p);
                }
                else
                {
                    string systemname = tree.FocusedNode.Tag as string;
                    this.SetPop(null, systemname);
                    this.popupMenu1.ShowPopup(p);
                }
            }
        }

        private void SetPop(JobInfo Cur_Job, string systemname = "")
        {

            this.btnnewjob.Visibility = this.btnallqyjob.Visibility = this.btnalljzjob.Visibility = Cur_Job != null ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnrunjob.Visibility = this.btnFast.Visibility = this.btnqyjob.Visibility = this.btnjzjob.Visibility = this.btnpro.Visibility = this.btncopyjob.Visibility = this.btndeletejob.Visibility = Cur_Job != null ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnjzjob.Enabled = Cur_Job != null ? !(Cur_Job.jlzt == "1") : false;
            this.btnqyjob.Enabled = Cur_Job != null ? Cur_Job.jlzt == "1" : false;
            List<JobInfo> list = GlobalInstanceManager<JobInfoManager>.Intance.GetJobInfoListBySystemName(systemname);
            this.btnallqyjob.Enabled = list == null || list.Count <= 0 ? false : list.All(a => a.jlzt == "0") && !list.All(a => a.jlzt == "1") ? false : true;
            this.btnalljzjob.Enabled = list == null || list.Count <= 0 ? false : list.All(a => a.jlzt == "1") && !list.All(a => a.jlzt == "0") ? false : true;

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
            if (node == null || node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            info.jlzt = "1";
            node.StateImageIndex = 0;
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }

        private void btnpro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WatchConfigFrm();
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
                    return;
                else
                    cur_excutereq = frm.StrConditon;
            }
            this.QuickExcute(info, cur_excutereq);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalInstanceManager<SchedulerManager>.Intance.ResumeAll();
                Log4netUtil.Debug("重启调度器成功");
                foreach (TreeListNode item in this.treeList1.Nodes)
                {
                    item.StateImageIndex = 5;
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Debug("重启调度器失败" + ex.Message, ex);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalInstanceManager<SchedulerManager>.Intance.PauseAll();
                Log4netUtil.Debug("暂停调度器成功");
                foreach (TreeListNode item in this.treeList1.Nodes)
                {
                    item.StateImageIndex = 6;
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Debug("暂停调度器失败：" + ex.Message);
            }

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            this.AddJob(new JobInfo());
        }

        private void AddJob(JobInfo addinfo)
        {
            using (ConfigFrm config = new ConfigFrm(addinfo, null, this))
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.AddWinHandle("AddJob", config.Handle);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWinByKey("AddJob");
                config.ShowDialog();
            }
            GlobalInstanceManager<FollowMainWinHelper>.Intance.RemoveWinHandle("AddJob");
            this.LoadJobInfo();
        }

        private void btnqyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            info.jlzt = "0";
            node.StateImageIndex = 1;
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            this.WatchConfigFrm();
        }

        private void WatchConfigFrm()
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null || node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            if (GlobalInstanceManager<FollowMainWinHelper>.Intance.IsExistsKey(info.id))
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.SetTopMost(info.id);
            }
            else
            {
                ConfigFrm frm = new ConfigFrm(info, node, this);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.AddWinHandle(info.id, frm.Handle);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWinByKey(info.id);
                frm.Show();
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
            this.QuickExcute(info, strrequest);
        }

        public void QuickExcute(JobInfo jobInfo, string request)
        {
            Task task = new Task(() =>
            {
                request = new RequestMessage() { Request = new Request() { Head = new Head() { TranCode = jobInfo.id, TranName = jobInfo.name, TranSys = jobInfo.system, TranSysName = jobInfo.sysname, AckMessage = "请求访问" }, Body = request } }.ToString();
                string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(request);
                Tools.FlushMemory();
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

        private void btnnewjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            string systemname = node.Tag as string;
            JobInfo firstjob = GlobalInstanceManager<JobInfoManager>.Intance.GetFirstJobBySystemName(systemname);
            this.AddJob(new JobInfo() { system = firstjob.system, sysname = firstjob.sysname });
        }

        private void btnallqyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            if (!node.HasChildren)
                return;
            foreach (TreeListNode cnode in node.Nodes)
            {
                JobInfo job = cnode.Tag as JobInfo;
                if (job.jlzt == "0")
                    continue;
                job.jlzt = "0";
                cnode.StateImageIndex = 1;
            }
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }

        private void btnalljzjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            if (!node.HasChildren)
                return;
            foreach (TreeListNode cnode in node.Nodes)
            {
                JobInfo job = cnode.Tag as JobInfo;
                if (job.jlzt == "1")
                    continue;
                job.jlzt = "1";
                cnode.StateImageIndex = 0;
            }
            GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
        }



        private void btncopyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cur_Job = this.treeList1.FocusedNode != null ? this.treeList1.FocusedNode.Tag as JobInfo : null;
            if (this.Cur_Job == null)
                return;
            JobInfo newjob = this.Cur_Job.Copy();
            this.AddJob(newjob);
        }

        private void btndeletejob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            JobInfo removejob = this.treeList1.FocusedNode != null ? this.treeList1.FocusedNode.Tag as JobInfo : null;
            if (removejob == null)
                return;
            if (MessageBox.Show("确认删除作业吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                GlobalInstanceManager<JobInfoManager>.Intance.RemoveJobInfo(removejob);
            }
            this.LoadJobInfo();
        }

        private void btnconfig_Click(object sender, EventArgs e)
        {
            using (SettingsFrm frm = new SettingsFrm())
            {
                frm.ShowDialog();
            }
        }


        private void btnlog_Click(object sender, EventArgs e)
        {
            this.LoadConsole();
        }

        private void LoadConsole()
        {
            if (GlobalInstanceManager<FollowMainWinHelper>.Intance.IsExistsKey("ConsoleFrm"))
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.SetTopMost("ConsoleFrm");
            }
            else
            {
                ConsoleFrm frm = new ConsoleFrm(GlobalInstanceManager<FollowMainWinHelper>.Intance);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.AddWinHandle("ConsoleFrm", frm.Handle);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWinByKey("ConsoleFrm");
                frm.Show();
            }
        }

        private void FrmMain_Move(object sender, EventArgs e)
        {
            if (Settings.Default.ismovefollow)
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWin();
            }           
        }

    }
}
