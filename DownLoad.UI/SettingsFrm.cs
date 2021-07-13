﻿using DownLoad.Business;
using DownLoad.Core;
using DownLoad.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownLoad.UI
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
            this.cbdbtype.SelectedIndex = Settings.Default.dbtype;
            this.cbisautostart.SelectedIndex = Settings.Default.isautostart ? 0 : 1;
            this.cbisdblog.SelectedIndex = Settings.Default.ismovefollow ? 0 : 1;
            this.cbisfilelog.SelectedIndex = Settings.Default.islog ? 0 : 1;
            this.txtconnectstring.Text = Settings.Default.connstring;
            this.txtappname.Text = Settings.Default.appname;
            this.cbtheme.SelectedItem = Settings.Default.theme;
            this.cbbody.SelectedIndex = Settings.Default.isbodyrecord ? 0 : 1;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.dbtype = this.cbdbtype.SelectedIndex;
                Settings.Default.connstring = this.cesjm.Checked ? this.txtconnectstring.Text.Trim() : EncodeAndDecode.Encode(this.txtconnectstring.Text.Trim());
                Settings.Default.appname = this.txtappname.Text.Trim();
                Settings.Default.isautostart = this.cbisautostart.SelectedIndex == 0 ? true : false;
                Settings.Default.islog = this.cbisfilelog.SelectedIndex == 0 ? true : false;
                Settings.Default.ismovefollow = this.cbisdblog.SelectedIndex == 0 ? true : false;
                Settings.Default.theme = this.cbtheme.SelectedItem.ToString();
                Settings.Default.isbodyrecord = this.cbbody.SelectedIndex == 0 ? true : false;
                Settings.Default.Save();
                Log4netUtil.IsLog = Settings.Default.islog;
                FrmBase.defaultLookAndFeel.LookAndFeel.SkinName = Settings.Default.theme;
                GlobalInstanceManager<JobInfoManager>.Intance.Cur_dbtype = this.cbdbtype.SelectedIndex;
                GlobalInstanceManager<JobInfoManager>.Intance.Cur_dbconstring = !this.cesjm.Checked ? this.txtconnectstring.Text.Trim() : EncodeAndDecode.Decode(this.txtconnectstring.Text.Trim());
                GlobalInstanceManager<RimsInterface>.Intance.IsRecordBody = Settings.Default.isbodyrecord;
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
            this.txtconnectstring.Text = !this.cesjm.Checked ? EncodeAndDecode.Decode(this.txtconnectstring.Text.Trim()) : EncodeAndDecode.Encode(this.txtconnectstring.Text.Trim()) ;
        }
    }
}
