using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;
using Winning.DownLoad.UI.Properties;

namespace Winning.DownLoad.UI
{
    public partial class FrmMain : FrmBase
    {
        private JobInfo Cur_Job;
        private string cur_excutereq;
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
                TSqlHelper.Init(Settings.Default.contr_rims, Settings.Default.contr_common);
                GlobalInstanceManager<JobInfoManager>.Intance = new JobInfoManager();
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
                this.WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                this.notifyIcon1.Visible = true;
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
                        JObject jobj = (JObject)JsonConvert.DeserializeObject(text);
                        if (jobj != null)
                        {
                            string strresult = (jobj["Response"]["Head"]["AckCode"] ?? "100").ToString();
                            string strjobid = (jobj["Response"]["Head"]["TranCode"] ?? "00").ToString();
                            string strjobsys = (jobj["Response"]["Head"]["System"] ?? "00").ToString();
                            if (strresult.Contains("100"))
                            {                              
                                this.InsertJobHistory(0, strjobid, strjobsys, text);
                                this.txtmsg.SelectionColor = Color.Yellow;
                                text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[strjobid.ToLower()].name + "】执行成功";
                            }
                            else
                            {                                                     
                                this.InsertJobHistory(1, strjobid, strjobsys, text);
                                string strmsg = (jobj["Response"]["Head"]["AckMessage"] ?? "异常错误").ToString();
                                this.txtmsg.SelectionColor = Color.Red;
                                text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[strjobid.ToLower()].name + "】执行异常：" + strmsg;
                            }
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
                        JObject jobj = (JObject)JsonConvert.DeserializeObject(text);
                        if (jobj != null)
                        {
                            string strjobid = (jobj["Request"]["Head"]["TranCode"] ?? "00").ToString();                         
                            this.txtmsg.SelectionColor = Color.Yellow;                           
                            text = "接口【" + GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[strjobid.ToLower()].name + "】执行开始";
                        }
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
            string strsql = "insert into RIMS_JOBHISTORY(id,system,zxzt,rawtext,oper_date) values('" + strjobid + "','" + strjobsys + "'," + zxzt + ",'" + EncodeHelper.EncodeBase64(text) + "','" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "')";
            int retnum = TSqlHelper.ExecuteNonQueryByRims(strsql);
            if (retnum > 0)
            {
                this.AddLogText("作业【"+GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[strjobid.ToLower()].name+"】执行记录插入数据库成功");
            }
            else
            {
                this.AddLogText("作业【" + GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[strjobid.ToLower()].name + "】执行记录插入数据库失败");
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

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                this.notifyIcon1.Visible = true;    //显示托盘图标
                this.Hide();    //隐藏窗口
            }
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
                    using (ConfigFrm frm = new ConfigFrm(info))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnrunjob_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = this.treeList1.FocusedNode;
            if (node == null && node.Tag == null)
                return;
            JobInfo info = node.Tag as JobInfo;
            if (info == null)
                return;
            this.cur_excutereq = "";
            using (RunFrm frm = new RunFrm())
            {
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    this.cur_excutereq = frm.StrConditon;
                }
            }
            Thread t = new Thread(new ThreadStart(ExcuteJob));
            t.Start();
        }
        public void ExcuteJob()
        {
            string strreq = GetStrJsonHelper.GetReqJson(this.Cur_Job.id, "", this.cur_excutereq);
            string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(strreq);
            this.AddLogText(strret);
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
            this.Init();
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
                        string strsql = "exec usp_rims_jk_getjobhistory @id='" + info.id + "',@sys='" + info.system + "'";
                        DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
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
                    ConfigFrm frm = new ConfigFrm(info);
                    frm.Show();
                    //frm.Dispose();
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
            Thread t = new Thread(new ThreadStart(QuickExcute));
            t.Start();

        }
        private void QuickExcute()
        {
            string strreq = "{\"dbeginDate\":\"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"dendDate\":\"" + DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd") + "\"}";
            strreq = GetStrJsonHelper.GetReqJson(this.Cur_Job.id, "", strreq);
            string strret = GlobalInstanceManager<RimsInterface>.Intance.Run(strreq);
            this.AddLogText(strret);
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            defaultLookAndFeel.LookAndFeel.SkinName = Settings.Default.theme;
            this.Init();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = this.gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                using (JsonFrm frm = new JsonFrm(dr["xh"].ToString()))
                {
                    frm.ShowDialog();
                }
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
