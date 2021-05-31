using DownLoad.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinfrmTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            IntPtr handle = WinApiHelper.FindWindow(null, this.textBox1.Text);
            WinApiHelper.MoveWindow(handle, this.Location.X + this.Width, this.Location.Y, 100, this.Height,true);
        }
    }
}
