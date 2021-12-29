using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Business.PushMessage;
using TaskSchedule.Interface;
using TaskSchedule.UI.Config.Dev;

namespace TaskSchedule.UI.ConfigForPushMessage.Dev
{
    public partial class PushMessageConfigFrm : ConfigFrm
    {
        public PushMessageConfigFrm()
        {
            InitializeComponent();
        }
        public PushMessageConfigFrm(JobInfo info)
            : base(info)
        {
            InitializeComponent();
        }

        public override bool CollectChildJobInfo()
        {
            JobInfoPushMessage job = this.Cur_JobInfo as JobInfoPushMessage;
            job.dbtype = this.cbetdbtype.SelectedIndex;
            job.dbstring = this.txttstr.Text.Trim();
            job.weburl = this.txtweburl.Text.Trim();
            job.tokenweburl = this.txttokenurl.Text.Trim();
            return true;
        }
        public override void LoadChildInfo()
        {
            JobInfoPushMessage job = this.Cur_JobInfo as JobInfoPushMessage;
            this.cbetdbtype.SelectedIndex = job.dbtype;
            this.txttstr.Text = job.dbstring;
            this.txtweburl.Text = job.weburl;
            this.txttokenurl.Text = job.tokenweburl;
        }
    }
}
