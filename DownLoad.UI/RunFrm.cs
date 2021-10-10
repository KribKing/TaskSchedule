using DownLoad.Core;
using System;
using System.Windows.Forms;

namespace DownLoad.UI
{
    public partial class RunFrm : FrmBase
    {
        public string StrConditon { get; set; }
        public RunFrm()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.StrConditon = this.txtmsg.Text.Trim();
            base.DialogResult = DialogResult.OK;
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void RunFrm_Load(object sender, EventArgs e)
        {
            this.txtmsg.Text = "{"+Environment.NewLine
                                  + "\"dbeginDate\":\"" + DateTime.Now.ToString("yyyy-MM-dd") + "\"," + Environment.NewLine
                                  + "\"dendDate\":\"" + DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd") + "\"" + Environment.NewLine
                              + "}";
        }
    }
}
