using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.UI
{
    public partial class JsonFrm : FrmBase
    {
        private string cur_xh = "";
        public JsonFrm()
        {
            InitializeComponent();
        }
        public JsonFrm(string xh)
        {
           
            InitializeComponent();
            this.cur_xh = xh;
        }
        private void JsonFrm_Load(object sender, EventArgs e)
        {
            

        }

        private void JsonFrm_Shown(object sender, EventArgs e)
        {
            try
            {                            
                //this.pbc.Text = "数据库加载开始，请稍等...";
                //System.Windows.Forms.Application.DoEvents();
                //string strsql = "select rawtext from RIMS_JOBHISTORY (nolock) where xh=" + this.cur_xh;
                //DataTable dt = TSqlHelper.ExecuteDataTableByRims(strsql);
                //string rawtxt = "";
                //this.pbc.Text = "字符串解密开始，请稍等...";
                //System.Windows.Forms.Application.DoEvents();
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    rawtxt = EncodeHelper.DecodeBase64(dt.Rows[0][0].ToString());
                //    //this.pbc.Text = "数据库加载结束，请稍等...";
                //}
                //this.pbc.Text = "字符串格式化开始，请稍等...";
                //System.Windows.Forms.Application.DoEvents();
                //rawtxt = Tools.ConvertJsonString(rawtxt);
                //this.pbc.Text = "字符串加载开始，请稍等...";
                //System.Windows.Forms.Application.DoEvents();
                //this.textBox1.Text = rawtxt;
                //this.pbc.Visible = false;
                ////this.progressPanel1.Visible = false;
                ////System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }    
        private void ShowProgress(string txt)
        {
          
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                Point pt = new Point(Cursor.Position.X, Cursor.Position.Y);
                this.popupMenu1.ShowPopup(pt);
            }
        }

        private void btnexportjson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter="Json文件(*.json)|*.json";
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, this.textBox1.Text);
            }
        }
    }
}
