using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            Bitmap picpath = ThumbnailHelper.GetInstance().GetBitMapThumbnail(path,32,32);
            this.pictureBox1.Image = picpath;
            this.imageList1.Images.Add(openFileDialog1.FileName, picpath);
            //int index = this.imageList1.Images.Add(picpath);
            ListViewItem lvi = new ListViewItem(openFileDialog1.FileName, openFileDialog1.FileName);
            this.listView1.Items.Add(lvi);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.imageList1.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem("sub"+i.ToString(),i);
                this.listView1.Items.Add(lvi);
            }
        }
    }
}
