
using TaskSchedule.Core;
using System;
using System.Windows.Forms;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.DevUI
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
            this.cbisautostart.SelectedIndex = AppSetting.Default.isautostart ? 0 : 1;
            this.cbisfollow.SelectedIndex = AppSetting.Default.ismovefollow ? 0 : 1;
            this.cbisfilelog.SelectedIndex = AppSetting.Default.islog ? 0 : 1;         
            this.txtappname.Text = AppSetting.Default.appname;
            this.cbtheme.SelectedItem = AppSetting.Default.theme;         
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
               
                AppSetting.Default.appname = this.txtappname.Text.Trim();
                AppSetting.Default.isautostart = this.cbisautostart.SelectedIndex == 0;
                AppSetting.Default.islog = this.cbisfilelog.SelectedIndex == 0;
                AppSetting.Default.ismovefollow = this.cbisfollow.SelectedIndex == 0;
                AppSetting.Default.theme = this.cbtheme.SelectedItem.ToString();        
                AppSetting.Default.Save();
                Log4netUtil.IsLog = AppSetting.Default.islog;
                FrmBase.defaultLookAndFeel.LookAndFeel.SkinName = AppSetting.Default.theme;              
                MessageBox.Show("保存成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存异常，请检查", "操作提示", MessageBoxButtons.OK);
            }

        }

        private void txtconnectstring_DoubleClick(object sender, EventArgs e)
        {
            //using (DataConfigFrm frm = new DataConfigFrm())
            //{
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        this.txtconnectstring.Text = !this.cesjm.Checked ? EncodeAndDecode.Decode(frm.ConnectString) : frm.ConnectString; ;
            //    }
            //}
        }

        private void btnyy_Click(object sender, EventArgs e)
        {
            FrmBase.defaultLookAndFeel.LookAndFeel.SkinName = this.cbtheme.SelectedText;
        }

        private void cbeformmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblisfollow.Visible = this.cbisfollow.Visible = this.cbeformmode.SelectedIndex == 0;
        }
    }
}
