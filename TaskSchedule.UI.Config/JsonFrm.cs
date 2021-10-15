﻿using TaskSchedule.Business;
using TaskSchedule.Core;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using TaskSchedule.UI.Base;


namespace TaskSchedule.UI.Config
{
    public partial class JsonFrm : FrmBase
    {
        private JobInfo cur_jobinfo;
        private string cur_xh = "";
        public JsonFrm()
        {
            InitializeComponent();
        }
        public JsonFrm(JobInfo jobInfo, string xh)
        {
            InitializeComponent();
            this.cur_xh = xh;
            this.cur_jobinfo = jobInfo;
        }
        private void JsonFrm_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
            ProcessBarFrm.Instance.ShowDialog();
        }

        private void JsonFrm_Shown(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Cursor.Position);
            }
        }

        private void btnexportjson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Json文件(*.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, this.txtjson.Text);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bgWorker = sender as BackgroundWorker;
                bgWorker.ReportProgress(0, "1");
                string strsql = "select rawtext from CronJob_JOBHISTORY (nolock) where xh=" + this.cur_xh;
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(DefaultSetting.Default.dbtype, EncodeAndDecode.Decode(DefaultSetting.Default.connstring), strsql);
                string rawtxt = "";
                bgWorker.ReportProgress(10, "2");
                if (dt != null && dt.Rows.Count > 0)
                {
                    rawtxt = EncodeHelper.DecodeBase64(dt.Rows[0][0].ToString());
                }
                bgWorker.ReportProgress(30, "3");
                rawtxt = Tools.ConvertJsonString(rawtxt);
                bgWorker.ReportProgress(60, "4");
                Thread.Sleep(100);
                this.txtjson.Invoke(new Action<string>(a =>
                {
                    this.txtjson.Text = a;
                }), rawtxt);
                bgWorker.ReportProgress(99, "5");
                Thread.Sleep(200);
                bgWorker.ReportProgress(100, "6");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0 && e.ProgressPercentage <= 100)
            {
                ProcessBarFrm.Instance.ProcessCommand(ProcessBarFrm.SplashScreenCommand.processvalue, e.ProgressPercentage.ToString());
                string showtxt = "";
                if (e.UserState.ToString() == "1")
                {
                    showtxt = "数据库加载开始，请稍等...";
                }
                else if (e.UserState.ToString() == "2")
                {
                    showtxt = "原始数据解密开始，请稍等...";
                }
                else if (e.UserState.ToString() == "3")
                {
                    showtxt = "解密串格式化开始，请稍等...";
                }
                else if (e.UserState.ToString() == "4")
                {
                    showtxt = "Json串加载开始，请稍等...";
                }
                else if (e.UserState.ToString() == "5")
                {
                    showtxt = "加载完毕";
                }
                ProcessBarFrm.Instance.ProcessCommand(ProcessBarFrm.SplashScreenCommand.notify, showtxt);
                Console.WriteLine(e.ProgressPercentage.ToString() + ":" + showtxt);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProcessBarFrm.Instance.Dispose();
        }

        private void btnexportxml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ResponseMessage Response = JsonConvert.DeserializeObject<ResponseMessage>(this.txtjson.Text.Trim());
                StringWriter sw = new StringWriter();
                DataTable dt = new DataTable();
                if (this.cur_jobinfo.nodelx == 0)
                {
                    //string json = Tools.GetJsonNodeValue(this.txtjson.Text.Trim(), "Response|Body" + "|" + this.cur_jobinfo.node, "[]").ToString();                  
                    string json = Tools.GetJsonNodeValue(Response.Response.Body, this.cur_jobinfo.sourcetype ==1?"[]":this.cur_jobinfo.node, "[]").ToString();
                    dt = Tools.JsonToDataTable(json);
                }
                else if (this.cur_jobinfo.nodelx == 1)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(Response.Response.Body);
                    XmlNode node = XmlHelper.GetNode(this.cur_jobinfo.node, xml);
                    dt = XmlHelper.XmlToDataTable(this.cur_jobinfo.xmlconfig, node);
                }
                dt.TableName = this.cur_jobinfo.tmpname;
                dt.WriteXmlSchema(sw, true);
                using (XFrm frm = new XFrm(this.cur_jobinfo, sw.ToString()))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出发生异常：" + ex.Message);
            }

        }
    }
}
