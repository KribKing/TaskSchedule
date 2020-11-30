using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Winning.DownLoad.Core;

namespace Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result=GlobalWebRequestHelper.HttpGetRequest(this.textBox1.Text.Trim(), "");
            this.textBox2.Text = result;
        }
    }
}
