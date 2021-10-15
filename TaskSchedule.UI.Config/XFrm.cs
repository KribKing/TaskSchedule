using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TaskSchedule.Business;
using TaskSchedule.Core;
using System.IO;
using TaskSchedule.UI.Base;

namespace TaskSchedule.UI.Config
{
    public partial class XFrm : FrmBase
    {
        private JobInfo Cur_Job;
        public XFrm()
        {
            InitializeComponent();
        }
        public XFrm(JobInfo job,string xml)
        {
            InitializeComponent();
            this.txtDt.Text = xml;
            this.Cur_Job = job;
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cur_Job.xmlschema = this.txtDt.Text.Trim();
                //DataTable dt = new DataTable();
                //dt.ReadXmlSchema(this.Cur_Job.xmlschema);
                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                MessageBox.Show("重置成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败:"+ex.Message,"操作提示",MessageBoxButtons.OK);
            }                     
        }

        private void btnresettemp_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.ReadXmlSchema(new StringReader(this.txtDt.Text.Trim()));
                string strtmp = "create table " + this.Cur_Job.tmpname + Environment.NewLine+"("+ Environment.NewLine;
                foreach (DataColumn dc in dt.Columns)
                {
                    strtmp += "   " + dc.ColumnName + "   varchar(32) null,"+Environment.NewLine;
                }
                strtmp=strtmp.Remove(strtmp.LastIndexOf(','), 1);
                strtmp+=")";
                this.Cur_Job.createtmp = strtmp;             
                GlobalInstanceManager<JobInfoManager>.Intance.SaveJobInfo();
                MessageBox.Show("重置成功", "操作提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置失败:" + ex.Message, "操作提示", MessageBoxButtons.OK);
            }        
        }
    }
}