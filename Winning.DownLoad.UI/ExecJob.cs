using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winning.DownLoad.UI
{
    public partial class ExecJob : FrmBase
    {
        public ExecJob()
        {
            InitializeComponent();
        }

        private void CbkOnce_CheckedChanged(object sender, EventArgs e)
        {
            if(CbkOnce.Checked == true)
            {
                CbkDaySeq.Checked = false;
                CbkZd.Checked = false;
            }
          
        }

        private void CbkDaySeq_CheckedChanged(object sender, EventArgs e)
        {
            if (CbkDaySeq.Checked == true)
            {
                CbkOnce.Checked = false;
                CbkZd.Checked = false;
            }
        }

        private void CbkZd_CheckedChanged(object sender, EventArgs e)
        {
            if (CbkZd.Checked == true)
            {
                CbkOnce.Checked = false;
                CbkDaySeq.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(CbkOnce.Checked)
            {
                string StrCron = dtpOnceTime.Value.Second.ToString().Replace("00", "0") + " " + dtpOnceTime.Value.Minute.ToString().Replace("00", "0") + " " + dtpOnceTime.Value.Hour.ToString() + " " + dtpdata.Value.Day.ToString() + " " + dtpdata.Value.Month.ToString() + " ? " + dtpdata.Value.Year.ToString() + "-" + dtpdata.Value.Year.ToString();
                txtMemo.Text = StrCron;
            }

            else if(CbkDaySeq.Checked)
            {
                string StrCron = "";
                if(txtHour.Text == "" && txtMin.Text == "" && txtSec.Text == "")
                {
                    StrCron = dtpBegTime.Value.Second.ToString().Replace("00", "0") + "-" + dtpEndTime.Value.Second.ToString().Replace("00", "0") + " " + dtpBegTime.Value.Minute.ToString().Replace("00", "0") + "-" + dtpEndTime.Value.Minute.ToString().Replace("00", "0") + " " + dtpBegTime.Value.Hour + "-" + dtpEndTime.Value.Hour + " " + dtpBegDate.Value.Day + "-" + dtpEndDate.Value.Day + " " + dtpBegDate.Value.Month + "-" + dtpEndDate.Value.Month + " ? " + dtpBegDate.Value.Year + "-" + dtpEndDate.Value.Year;
                }
                else
                {
                    string strhour = "";
                    string strmin = "";
                    string strsec = "";
                    if(txtHour.Text == "")
                    {
                        strhour = "*";
                    }
                    else
                    {
                        strhour = dtpBegTime.Value.Hour + "/" + txtHour.Text;
                    }
                    if (txtMin.Text == "")
                    {
                        strmin = "*";
                    }
                    else
                    {
                        strmin = dtpBegTime.Value.Minute.ToString().Replace("00", "0") + "/" + txtMin.Text;
                    }
                    if (txtSec.Text == "")
                    {
                        strsec = "*";
                    }
                    else
                    {
                        strsec = dtpBegTime.Value.Second.ToString().Replace("00", "0") + "/" + txtSec.Text;
                    }

                    StrCron = strsec + " " + strmin + " " + strhour + " " + dtpBegDate.Value.Day + "-" + dtpEndDate.Value.Day + " " + dtpBegDate.Value.Month + "-" + dtpEndDate.Value.Month + " ? " + dtpBegDate.Value.Year + "-" + dtpEndDate.Value.Year;

                }


                txtMemo.Text = StrCron;
                
               
            }

            else if(CbkZd.Checked)
            {
                string StrCron = sec.Text + " " + minute.Text + " " + hour.Text + " " + day.Text + " " + month.Text + " ? " + year.Text;
                txtMemo.Text = StrCron;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
