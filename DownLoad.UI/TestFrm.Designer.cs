namespace DownLoad.UI
{
    partial class TestFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestFrm));
            this.txttest = new System.Windows.Forms.RichTextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btntablefrm = new DevExpress.XtraEditors.SimpleButton();
            this.btnlog = new DevExpress.XtraEditors.SimpleButton();
            this.cbstop = new DevExpress.XtraEditors.CheckEdit();
            this.cblogfollow = new DevExpress.XtraEditors.CheckEdit();
            this.btntest = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbstop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblogfollow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txttest
            // 
            this.txttest.AutoWordSelection = true;
            this.txttest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttest.Location = new System.Drawing.Point(0, 0);
            this.txttest.Name = "txttest";
            this.txttest.ShowSelectionMargin = true;
            this.txttest.Size = new System.Drawing.Size(290, 514);
            this.txttest.TabIndex = 3;
            this.txttest.Text = "";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btntablefrm);
            this.panelControl1.Controls.Add(this.btnlog);
            this.panelControl1.Controls.Add(this.cbstop);
            this.panelControl1.Controls.Add(this.cblogfollow);
            this.panelControl1.Controls.Add(this.btntest);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 514);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(290, 62);
            this.panelControl1.TabIndex = 0;
            // 
            // btntablefrm
            // 
            this.btntablefrm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btntablefrm.Image = ((System.Drawing.Image)(resources.GetObject("btntablefrm.Image")));
            this.btntablefrm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btntablefrm.Location = new System.Drawing.Point(63, 8);
            this.btntablefrm.Name = "btntablefrm";
            this.btntablefrm.Size = new System.Drawing.Size(27, 23);
            this.btntablefrm.TabIndex = 2;
            this.btntablefrm.ToolTip = "查看表数据输出";
            this.btntablefrm.Click += new System.EventHandler(this.btntablefrm_Click);
            // 
            // btnlog
            // 
            this.btnlog.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnlog.Image = ((System.Drawing.Image)(resources.GetObject("btnlog.Image")));
            this.btnlog.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnlog.Location = new System.Drawing.Point(12, 8);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(27, 23);
            this.btnlog.TabIndex = 2;
            this.btnlog.ToolTip = "查看控制台日志";
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // cbstop
            // 
            this.cbstop.EditValue = true;
            this.cbstop.Location = new System.Drawing.Point(140, 37);
            this.cbstop.Name = "cbstop";
            this.cbstop.Properties.AutoWidth = true;
            this.cbstop.Properties.Caption = "是否阻断目标库";
            this.cbstop.Size = new System.Drawing.Size(102, 15);
            this.cbstop.TabIndex = 1;
            // 
            // cblogfollow
            // 
            this.cblogfollow.EditValue = true;
            this.cblogfollow.Location = new System.Drawing.Point(12, 37);
            this.cblogfollow.Name = "cblogfollow";
            this.cblogfollow.Properties.AutoWidth = true;
            this.cblogfollow.Properties.Caption = "子窗体跟随";
            this.cblogfollow.Size = new System.Drawing.Size(78, 15);
            this.cblogfollow.TabIndex = 1;
            // 
            // btntest
            // 
            this.btntest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btntest.Image = ((System.Drawing.Image)(resources.GetObject("btntest.Image")));
            this.btntest.Location = new System.Drawing.Point(140, 8);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(62, 23);
            this.btntest.TabIndex = 0;
            this.btntest.Text = "测试";
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // TestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 576);
            this.Controls.Add(this.txttest);
            this.Controls.Add(this.panelControl1);
            this.Name = "TestFrm";
            this.Text = "测试串测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestFrm_FormClosing);
            this.Load += new System.EventHandler(this.TestFrm_Load);
            this.Shown += new System.EventHandler(this.TestFrm_Shown);
            this.Move += new System.EventHandler(this.TestFrm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbstop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cblogfollow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RichTextBox txttest;
        private DevExpress.XtraEditors.SimpleButton btntest;
        private DevExpress.XtraEditors.CheckEdit cblogfollow;
        private DevExpress.XtraEditors.SimpleButton btnlog;
        private DevExpress.XtraEditors.SimpleButton btntablefrm;
        private DevExpress.XtraEditors.CheckEdit cbstop;
    }
}