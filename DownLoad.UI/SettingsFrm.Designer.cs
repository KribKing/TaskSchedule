namespace DownLoad.UI
{
    partial class SettingsFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdblink = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbsjk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbautostart = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbfilelog = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbdblog = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfilelogpath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtappname = new System.Windows.Forms.TextBox();
            this.cbtheme = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbdblog);
            this.panel2.Controls.Add(this.cbtheme);
            this.panel2.Controls.Add(this.cbfilelog);
            this.panel2.Controls.Add(this.cbautostart);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbsjk);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtfilelogpath);
            this.panel2.Controls.Add(this.txtappname);
            this.panel2.Controls.Add(this.txtdblink);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 240);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库链接";
            // 
            // txtdblink
            // 
            this.txtdblink.Location = new System.Drawing.Point(121, 138);
            this.txtdblink.Name = "txtdblink";
            this.txtdblink.Size = new System.Drawing.Size(385, 21);
            this.txtdblink.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(517, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "加解密";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库类型";
            // 
            // cbsjk
            // 
            this.cbsjk.FormattingEnabled = true;
            this.cbsjk.Location = new System.Drawing.Point(121, 26);
            this.cbsjk.Name = "cbsjk";
            this.cbsjk.Size = new System.Drawing.Size(101, 20);
            this.cbsjk.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "是否开机启动";
            // 
            // cbautostart
            // 
            this.cbautostart.FormattingEnabled = true;
            this.cbautostart.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbautostart.Location = new System.Drawing.Point(405, 29);
            this.cbautostart.Name = "cbautostart";
            this.cbautostart.Size = new System.Drawing.Size(101, 20);
            this.cbautostart.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "日志是否写文件";
            // 
            // cbfilelog
            // 
            this.cbfilelog.FormattingEnabled = true;
            this.cbfilelog.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbfilelog.Location = new System.Drawing.Point(405, 65);
            this.cbfilelog.Name = "cbfilelog";
            this.cbfilelog.Size = new System.Drawing.Size(101, 20);
            this.cbfilelog.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "日志是否写数据库";
            // 
            // cbdblog
            // 
            this.cbdblog.FormattingEnabled = true;
            this.cbdblog.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbdblog.Location = new System.Drawing.Point(121, 65);
            this.cbdblog.Name = "cbdblog";
            this.cbdblog.Size = new System.Drawing.Size(101, 20);
            this.cbdblog.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "日志文件地址";
            // 
            // txtfilelogpath
            // 
            this.txtfilelogpath.Location = new System.Drawing.Point(121, 102);
            this.txtfilelogpath.Name = "txtfilelogpath";
            this.txtfilelogpath.Size = new System.Drawing.Size(385, 21);
            this.txtfilelogpath.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "程序名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "主题风格";
            // 
            // txtappname
            // 
            this.txtappname.Location = new System.Drawing.Point(121, 178);
            this.txtappname.Name = "txtappname";
            this.txtappname.Size = new System.Drawing.Size(385, 21);
            this.txtappname.TabIndex = 1;
            // 
            // cbtheme
            // 
            this.cbtheme.FormattingEnabled = true;
            this.cbtheme.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbtheme.Location = new System.Drawing.Point(121, 210);
            this.cbtheme.Name = "cbtheme";
            this.cbtheme.Size = new System.Drawing.Size(385, 20);
            this.cbtheme.TabIndex = 3;
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 287);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbdblog;
        private System.Windows.Forms.ComboBox cbfilelog;
        private System.Windows.Forms.ComboBox cbautostart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbsjk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdblink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfilelogpath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbtheme;
        private System.Windows.Forms.TextBox txtappname;
    }
}