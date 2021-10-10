using DownLoad.Core;
using System;
using System.Windows.Forms;

namespace DownLoad.UI
{
    public partial class ShowPathFrm : FrmBase
    {
        public DataGridViewRow Cur_dr { get; set; }
        public ShowPathFrm(DataGridViewRow dr)
        {
            InitializeComponent();
            this.Cur_dr = dr;
            this.yszd_text.Text = dr.Cells[0].Value == null ? "" : dr.Cells[0].Value.ToString();
            this.yslx_text.Text = dr.Cells[1].Value == null ? "" : dr.Cells[1].Value.ToString();
            this.sxzd_text.Text = dr.Cells[2].Value == null ? "" : dr.Cells[2].Value.ToString();
            this.yslj_text.Text = dr.Cells[3].Value == null ? "" : dr.Cells[3].Value.ToString();
            this.gljdlj_text.Text = dr.Cells[4].Value == null ? "" : dr.Cells[4].Value.ToString();
        }


        private void btncancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            this.Cur_dr.Cells[0].Value = this.yszd_text.Text.Trim();
            this.Cur_dr.Cells[1].Value = this.yslx_text.Text.Trim();
            this.Cur_dr.Cells[2].Value = this.sxzd_text.Text.Trim();
            this.Cur_dr.Cells[3].Value = this.yslj_text.Text.Trim();
            this.Cur_dr.Cells[4].Value = this.gljdlj_text.Text.Trim();
            base.DialogResult = DialogResult.OK;
        }
    }
}
