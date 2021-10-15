using TaskSchedule.Business;
using TaskSchedule.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.Config
{
    public partial class TestFrm : FrmBase, ISwitchDataInterface<DataTable>
    {
        public JobInfo Cur_JobInfo { get; set; }
        private FollowMainWinHelper FollowWin;
        public event SwitchData<DataTable> OnSwitchData;
        public TestFrm()
        {
            InitializeComponent();
        }
        public TestFrm(JobInfo jobinfo)
        {
            InitializeComponent();
            this.Cur_JobInfo = jobinfo;
            this.Text = "【" + this.Cur_JobInfo.name + "】测试串验证";
        }

        private void TestFrm_Load(object sender, EventArgs e)
        {

        }
        private void LoadConsole()
        {
            if (FollowWin.IsExistsKey("ConsoleFrm"))
            {
                FollowWin.SetTopMost("ConsoleFrm");
            }
            else
            {
                ConsoleFrm frm = new ConsoleFrm(FollowWin);
                //frm.TopMost = true;
                FollowWin.AddWinHandle("ConsoleFrm", frm.Handle);
                FollowWin.MoveWinByKey("ConsoleFrm");
                frm.Show();
            }
        }
        private void TestFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FollowWin != null)
            {
                FollowWin.CloseWin("ConsoleFrm");
                FollowWin.CloseWin("TableFrm");
            }
        }

        private void TestFrm_Move(object sender, EventArgs e)
        {
            if (this.cblogfollow.Checked)
            {
                if (FollowWin != null)
                {
                    //FollowWin.SetTopMost("ConsoleFrm");
                    FollowWin.MoveWin();

                }

            }
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            if (this.Cur_JobInfo == null)
            {
                Log4netUtil.Error("当前作业信息为空，无法继续");
                return;
            }
            if (string.IsNullOrEmpty(this.txttest.Text.Trim()))
            {
                Log4netUtil.Error("测试串为空，无法继续");
                return;
            }
            JkInterface jk = new JkInterface(this.Cur_JobInfo, "", "");
            ResultInfo retinfo = new ResultInfo();
            DataTable dt = jk.RunWithBody(this.txttest.Text.Trim(), ref retinfo);
            if (this.OnSwitchData != null)
                this.OnSwitchData(dt);
            if (!this.cbstop.Checked)
                jk.ExcuteDataBaseBulk(dt, ref retinfo);
            Log4netUtil.Debug(JsonConvert.SerializeObject(retinfo));
        }

        private void TestFrm_Shown(object sender, EventArgs e)
        {
            FollowWin = new FollowMainWinHelper(this);
            this.LoadConsole();
            // this.LoadTableFrm();
        }

        private void LoadTableFrm()
        {
            if (FollowWin.IsExistsKey("TableFrm"))
            {
                FollowWin.SetTopMost("TableFrm");
            }
            else
            {
                TableFrm frm = new TableFrm(this);
                FollowWin.AddWinHandle("TableFrm", frm.Handle);
                FollowWin.MoveWinByKey("TableFrm");
                frm.Show();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            this.LoadConsole();
        }

        private void btntablefrm_Click(object sender, EventArgs e)
        {
            this.LoadTableFrm();
        }
    }
}
