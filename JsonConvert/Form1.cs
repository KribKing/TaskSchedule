using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JsonConvertFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rbold_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strsrc = this.rbold.Text.Trim();
                if (string.IsNullOrEmpty(strsrc))
                {
                    this.rbnew.Text = "";
                    return;
                }
                JObject jobj = (JObject)JsonConvert.DeserializeObject(strsrc);
                this.rbnew.Text = jobj.ToString();
            }
            catch (Exception ex)
            {
                this.rbnew.Text = ex.Message;
            }
        }
    }
}
