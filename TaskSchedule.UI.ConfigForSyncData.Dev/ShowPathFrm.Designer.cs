namespace TaskSchedule.UI.ConfigForSyncData.Dev
{
    partial class ShowPathFrm
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
            this.gljdlj_text = new System.Windows.Forms.TextBox();
            this.yslj_text = new System.Windows.Forms.TextBox();
            this.sxzd_text = new System.Windows.Forms.TextBox();
            this.yszd_text = new System.Windows.Forms.TextBox();
            this.yslx_text = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // gljdlj_text
            // 
            this.gljdlj_text.Location = new System.Drawing.Point(103, 172);
            this.gljdlj_text.Name = "gljdlj_text";
            this.gljdlj_text.Size = new System.Drawing.Size(676, 22);
            this.gljdlj_text.TabIndex = 27;
            // 
            // yslj_text
            // 
            this.yslj_text.Location = new System.Drawing.Point(103, 135);
            this.yslj_text.Name = "yslj_text";
            this.yslj_text.Size = new System.Drawing.Size(676, 22);
            this.yslj_text.TabIndex = 26;
            // 
            // sxzd_text
            // 
            this.sxzd_text.Location = new System.Drawing.Point(102, 98);
            this.sxzd_text.Name = "sxzd_text";
            this.sxzd_text.Size = new System.Drawing.Size(677, 22);
            this.sxzd_text.TabIndex = 25;
            // 
            // yszd_text
            // 
            this.yszd_text.Location = new System.Drawing.Point(103, 27);
            this.yszd_text.Name = "yszd_text";
            this.yszd_text.Size = new System.Drawing.Size(676, 22);
            this.yszd_text.TabIndex = 24;
            // 
            // yslx_text
            // 
            this.yslx_text.FormattingEnabled = true;
            this.yslx_text.Items.AddRange(new object[] {
            "文本值",
            "属性值",
            "关联文本值",
            "关联属性值"});
            this.yslx_text.Location = new System.Drawing.Point(103, 62);
            this.yslx_text.Name = "yslx_text";
            this.yslx_text.Size = new System.Drawing.Size(677, 22);
            this.yslx_text.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "关联节点路径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "映射路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "属性字段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "映射类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "映射字段";
            // 
            // btncancle
            // 
            this.btncancle.Location = new System.Drawing.Point(704, 214);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(75, 23);
            this.btncancle.TabIndex = 28;
            this.btncancle.Text = "关闭";
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(612, 214);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 29;
            this.btnok.Text = "确认";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // ShowPathFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.gljdlj_text);
            this.Controls.Add(this.yslj_text);
            this.Controls.Add(this.sxzd_text);
            this.Controls.Add(this.yszd_text);
            this.Controls.Add(this.yslx_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShowPathFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowPathFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gljdlj_text;
        private System.Windows.Forms.TextBox yslj_text;
        private System.Windows.Forms.TextBox sxzd_text;
        private System.Windows.Forms.TextBox yszd_text;
        private System.Windows.Forms.ComboBox yslx_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btncancle;
        private DevExpress.XtraEditors.SimpleButton btnok;
    }
}