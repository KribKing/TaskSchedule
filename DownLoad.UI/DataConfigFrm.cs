using DownLoad.Core;
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
    public partial class DataConfigFrm : FrmBase
    {
        public string ConnectString { get; set; }
        public DataConfigFrm()
        {
            InitializeComponent();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
			if (this.tabControl1.SelectedIndex == 0)
			{
				this.ConnectString = string.Concat(new string[]
				{
					"User ID=",
					this.txtyh.Text,
					";Password=",
					this.txtpassword.Text,
					";Persist Security Info=True;Initial Catalog=",
					this.txtdatabase.Text,
					";Data Source=",
					this.txtfwq.Text
				});
			}
			else
			{
				this.ConnectString = string.Concat(new string[]
				{
					" Data Source=",
					this.txtsjy.Text,
					" ;User ID=",
					this.txtuser.Text,
					" ;Password=",
					this.txtpwd.Text
				});
			}
			try
			{
				GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.tabControl1.SelectedIndex == 1?3:0, this.ConnectString, "select 1");
				MessageBox.Show("连接串成功，请将加密后的字符串拷贝到相应的配置文件中");
			}
			catch (Exception ex)
			{
				MessageBox.Show("连接数据库失败：" + ex.Message);
				return;
			}
			this.txtresult.Text = EncodeAndDecode.Encode(this.ConnectString);
			this.txtresult.Focus();
			this.txtresult.SelectAll();
			this.ConnectString = this.txtresult.Text;
		}  
        private void btncancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            base.DialogResult = DialogResult.OK;
        }

        private void DataConfigFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
