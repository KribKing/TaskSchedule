using TaskSchedule.Business;
using TaskSchedule.Core;
using System;
using System.Windows.Forms;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.Config
{
    public partial class SettingsFrm : FrmBase
    {
        public SettingsFrm()
        {
            InitializeComponent();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void LoadSettings()
        {
            this.cbdbtype.SelectedIndex = DefaultSetting.Default.dbtype;
            this.cbisautostart.SelectedIndex = DefaultSetting.Default.isautostart ? 0 : 1;
            this.cbisfollow.SelectedIndex = DefaultSetting.Default.ismovefollow ? 0 : 1;
            this.cbisfilelog.SelectedIndex = DefaultSetting.Default.islog ? 0 : 1;
            this.txtconnectstring.Text = DefaultSetting.Default.connstring;
            this.txtappname.Text = DefaultSetting.Default.appname;
            this.cbtheme.SelectedItem = DefaultSetting.Default.theme;
            this.cbbody.SelectedIndex = DefaultSetting.Default.isbodyrecord ? 0 : 1;
            this.cbeformmode.SelectedIndex = DefaultSetting.Default.formmode;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DefaultSetting.Default.dbtype = this.cbdbtype.SelectedIndex;
                DefaultSetting.Default.connstring = this.cesjm.Checked ? this.txtconnectstring.Text.Trim() : EncodeAndDecode.Encode(this.txtconnectstring.Text.Trim());
                DefaultSetting.Default.appname = this.txtappname.Text.Trim();
                DefaultSetting.Default.isautostart = this.cbisautostart.SelectedIndex == 0;
                DefaultSetting.Default.islog = this.cbisfilelog.SelectedIndex == 0;
                DefaultSetting.Default.ismovefollow = this.cbisfollow.SelectedIndex == 0;
                DefaultSetting.Default.theme = this.cbtheme.SelectedItem.ToString();
                DefaultSetting.Default.isbodyrecord = this.cbbody.SelectedIndex == 0;
                DefaultSetting.Default.formmode = this.cbeformmode.SelectedIndex;
                DefaultSetting.Default.Save();
                Log4netUtil.IsLog = DefaultSetting.Default.islog;
                FrmBase.defaultLookAndFeel.LookAndFeel.SkinName = DefaultSetting.Default.theme;
                GlobalInstanceManager<JobInfoManager>.Intance.Cur_dbtype = this.cbdbtype.SelectedIndex;
                GlobalInstanceManager<JobInfoManager>.Intance.Cur_dbconstring = !this.cesjm.Checked ? this.txtconnectstring.Text.Trim() : EncodeAndDecode.Decode(this.txtconnectstring.Text.Trim());
                GlobalInstanceManager<RimsInterface>.Intance.IsRecordBody = DefaultSetting.Default.isbodyrecord;
                MessageBox.Show("保存成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存异常，请检查", "操作提示", MessageBoxButtons.OK);
            }

        }

        private void txtconnectstring_DoubleClick(object sender, EventArgs e)
        {
            using (DataConfigFrm frm = new DataConfigFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.txtconnectstring.Text = !this.cesjm.Checked ? EncodeAndDecode.Decode(frm.ConnectString) : frm.ConnectString; ;
                }
            }
        }

        private void btnyy_Click(object sender, EventArgs e)
        {
            FrmBase.defaultLookAndFeel.LookAndFeel.SkinName = this.cbtheme.SelectedText;
        }

        private void cesjm_CheckedChanged(object sender, EventArgs e)
        {
            this.txtconnectstring.Text = !this.cesjm.Checked ? EncodeAndDecode.Decode(this.txtconnectstring.Text.Trim()) : EncodeAndDecode.Encode(this.txtconnectstring.Text.Trim());
        }

        private void cbeformmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblisfollow.Visible = this.cbisfollow.Visible = this.cbeformmode.SelectedIndex == 0;
        }
    }
}
