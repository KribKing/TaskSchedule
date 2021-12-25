using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
//using TaskSchedule.Properties;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using TaskSchedule.Business;
using TaskSchedule.Core;
using TaskSchedule.UI.Base;
using TaskSchedule.Interface;
using TaskSchedule.UI.Log.Dev;

namespace TaskSchedule.UI.DevUI
{
    public partial class FrmMain : FrmBase
    {
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
                Log4netUtil.IsLog = AppSetting.Default.islog;
                GlobalInstanceManager<SchedulerManager>.Intance.InitTask();
                this.LoadJobInfo();
                this.SetJobBaseInfo();
                Log4netUtil.Info("初始化加载完成");
                Tools.FlushMemory();
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("初始化发生异常：" + ex.Message, ex);
            }
        }

        private void SetJobBaseInfo()
        {
            this.lbjob.Items.AddRange(GlobalInstanceManager<SchedulerManager>.Intance.JobInfoManager.BaseJob.ToArray());
        }
        private void LoadJobInfo()
        {
            this.treeList1.Nodes.Clear();//清空所有节点，以便重新加载
            var list = GlobalInstanceManager<SchedulerManager>.Intance.JobInfoManager.JobInfoDic.Values.GroupBy(a => a.sysname).Select(a => new { key = a.Key, list = a.ToList() });
            foreach (var item in list)
            {
                TreeListNode node = this.treeList1.AppendNode(null, -1);
                node.SetValue(this.tPatKey, item.key);
                node.Tag = item.list;
                node.StateImageIndex = 5;
                this.LoadChildTreeNode(node, item.list);
            }
            this.treeList1.ExpandAll();
            this.treeList1.Refresh();
        }
        private void LoadChildTreeNode(TreeListNode pnode, List<JobInfo> dv)
        {
            try
            {
                if (dv == null) return;
                foreach (JobInfo rv in dv)
                {
                    TreeListNode node = pnode.TreeList.AppendNode(rv.sysname, pnode);
                    node.SetValue(0, rv.name);
                    node.Tag = rv;
                    rv.onJobInfoChanged -= onJobInfoChanged;
                    rv.onJobInfoChanged += onJobInfoChanged;
                    node.StateImageIndex = rv.jlzt == "0" ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业列表加载失败：" + ex.Message, ex);
            }
        }

        public void onJobInfoChanged(JobInfoOp opType, JobInfo info)
        {
            if (opType == JobInfoOp.Delete)
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.CloseWin(info.GuId.ToString());
            }
            this.LoadJobInfo();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果               
                this.Hide();
                GlobalInstanceManager<FollowMainWinHelper>.Intance.SetShow(0);
                return;
            }
            else
            {
                try
                {
                    GlobalInstanceManager<SchedulerManager>.Intance.ShutDown();
                }
                catch (Exception ex)
                {
                    Log4netUtil.Error("停止作业调度器异常：" + ex.Message, ex);
                }
            }
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || ModifierKeys != Keys.None || this.treeList1.State != TreeListState.Regular) return;
            TreeList tree = sender as TreeList;
            Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            tree.SetFocusedNode(hitInfo.HitInfoType == HitInfoType.Cell ? hitInfo.Node : null);
            if (tree.FocusedNode == null) return;
            this.SetPop(tree.FocusedNode);
            this.popupMenu1.ShowPopup(p);
        }

        private void SetPop(TreeListNode Node)
        {
            this.btnnewjob.Visibility = this.btnallqyjob.Visibility = this.btnalljzjob.Visibility
                = !Node.HasChildren ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnrunjob.Visibility = this.btnFast.Visibility = this.btnqyjob.Visibility
                = this.btnjzjob.Visibility = this.btnpro.Visibility = this.btncopyjob.Visibility = this.btndeletejob.Visibility
                = !Node.HasChildren ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnjzjob.Enabled = !Node.HasChildren && (Node.Tag as JobInfo).jlzt == "0";
            this.btnqyjob.Enabled = !Node.HasChildren && (Node.Tag as JobInfo).jlzt == "1";
            this.btnallqyjob.Enabled = Node.HasChildren && (Node.Tag as List<JobInfo>).Exists(a => a.jlzt == "1");
            this.btnalljzjob.Enabled = Node.HasChildren && (Node.Tag as List<JobInfo>).Exists(a => a.jlzt == "0");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            GlobalInstanceManager<FollowMainWinHelper>.Intance.SetShow(5);
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
            this.SetJobJlzt("1", this.treeList1.FocusedNode);
        }

        private void btnpro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WatchProperty();
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

        private void AddJob(JobInfo addinfo)
        {
            if (addinfo == null) return;
            JobInfo newinfo = addinfo.Create();
            if (newinfo == null) return;
            newinfo.onJobInfoChanged += onJobInfoChanged;
            this.WatchConfigFrm(newinfo);
        }

        private void btnqyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.SetJobJlzt("0", this.treeList1.FocusedNode);
        }

        private void SetJobJlzt(string jlzt, TreeListNode node)
        {
            if (node == null && node.Tag == null) return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null || info.jlzt == jlzt) return;
            info.jlzt = jlzt;
            info.Save();
            node.StateImageIndex = jlzt == "0" ? 1 : 0;
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            this.WatchProperty();
        }

        private void WatchProperty()
        {
            this.treeList1.Columns[0].OptionsColumn.AllowEdit = false;
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null || node.Tag == null || node.HasChildren) return;
            this.WatchConfigFrm(node.Tag as JobInfo);
        }

        private void WatchConfigFrm(JobInfo info)
        {
            if (info == null) return;
            if (GlobalInstanceManager<FollowMainWinHelper>.Intance.IsExistsKey(info.GuId.ToString()))
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.SetTopMost(info.GuId.ToString());
            }
            else
            {
                IConfigUIInterface frm = info.Config();
                if (frm == null) return;
                GlobalInstanceManager<FollowMainWinHelper>.Intance.AddWinHandle(info.GuId.ToString(), (IntPtr)frm.UIIndex);
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWinByKey(info.GuId.ToString());
                frm.ShowConfig();
            }
        }

        private void btnFast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null || node.Tag == null || node.HasChildren) return;
            JobInfo info = node.Tag as JobInfo;
            Task task = new Task(() =>
              {
                  info.Run();
              });
            task.Start();
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            defaultLookAndFeel.LookAndFeel.SkinName = AppSetting.Default.theme;
            this.notifyIcon1.Visible = false;
            this.Text = AppSetting.Default.appname;
            this.Init();
        }

        private void btnnewjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null || node.Tag == null || !node.HasChildren) return;

            this.AddJob((node.Tag as List<JobInfo>).FirstOrDefault());
        }

        private void btnallqyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (!node.HasChildren) return;
            foreach (TreeListNode cnode in node.Nodes)
            {
                this.SetJobJlzt("0", cnode);
            }
        }

        private void btnalljzjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (!node.HasChildren) return;
            foreach (TreeListNode cnode in node.Nodes)
            {
                this.SetJobJlzt("1", cnode);
            }
        }



        private void btncopyjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node.HasChildren) return;
            JobInfo job = (node.Tag as JobInfo).Copy();
            job.onJobInfoChanged -= onJobInfoChanged;
            job.onJobInfoChanged += onJobInfoChanged;
            this.WatchConfigFrm(job);
        }

        private void btndeletejob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node.HasChildren) return;
            if (MessageBox.Show("确认删除作业吗？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            (node.Tag as JobInfo).Delete();
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
            if (AppSetting.Default.ismovefollow && this.WindowState != FormWindowState.Minimized)
            {
                GlobalInstanceManager<FollowMainWinHelper>.Intance.MoveWin();
            }
        }

        private void btnrename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.treeList1.Columns[0].OptionsColumn.AllowEdit = true;
            this.treeList1.ShowEditor();
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.treeList1.Columns[0].OptionsColumn.AllowEdit = false;
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            TreeListNode node = e.Node;
            if (node == null && node.Tag == null) return;
            if (!node.HasChildren)
            {
                JobInfo info = node.Tag as JobInfo;
                info.name = e.Value as string;
                info.Save();
            }
            else
            {
                foreach (var item in (node.Tag as List<JobInfo>))
                {
                    item.sysname = e.Value as string;
                    item.Save();
                }
            }
        }

        private void lbjob_Click(object sender, EventArgs e)
        {
            JobInfo job = this.lbjob.SelectedItem as JobInfo;
            if (job == null) return;
            this.pop_job.ClosePopup();
            this.AddJob(job);
        }

        private void btnflushmemory_Click(object sender, EventArgs e)
        {
            Tools.FlushMemory();
        }
    }
}
