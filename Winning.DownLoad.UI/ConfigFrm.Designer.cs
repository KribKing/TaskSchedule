namespace Winning.DownLoad.UI
{
    partial class ConfigFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigFrm));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txttmpname = new DevExpress.XtraEditors.TextEdit();
            this.txtexp = new DevExpress.XtraEditors.TextEdit();
            this.txturl = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnsave = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.临时表 = new DevExpress.XtraEditors.GroupControl();
            this.txttmp = new System.Windows.Forms.RichTextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtsql = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttmpname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtexp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txturl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.临时表)).BeginInit();
            this.临时表.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txttmpname);
            this.panelControl2.Controls.Add(this.txtexp);
            this.panelControl2.Controls.Add(this.txturl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(844, 97);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "临时表名";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "作业表达式";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "weburl:";
            // 
            // txttmpname
            // 
            this.txttmpname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttmpname.Location = new System.Drawing.Point(82, 61);
            this.txttmpname.Name = "txttmpname";
            this.txttmpname.Size = new System.Drawing.Size(741, 20);
            this.txttmpname.TabIndex = 0;
            // 
            // txtexp
            // 
            this.txtexp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtexp.Location = new System.Drawing.Point(82, 35);
            this.txtexp.Name = "txtexp";
            this.txtexp.Size = new System.Drawing.Size(741, 20);
            this.txtexp.TabIndex = 0;
            this.txtexp.DoubleClick += new System.EventHandler(this.txtexp_DoubleClick);
            // 
            // txturl
            // 
            this.txturl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txturl.Location = new System.Drawing.Point(82, 10);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(741, 20);
            this.txturl.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnclose);
            this.panelControl3.Controls.Add(this.btnsave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 458);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(844, 47);
            this.panelControl3.TabIndex = 2;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(748, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "关闭";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(638, 12);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "保存";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 97);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.临时表);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(844, 361);
            this.splitContainerControl2.SplitterPosition = 426;
            this.splitContainerControl2.TabIndex = 3;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // 临时表
            // 
            this.临时表.Controls.Add(this.txttmp);
            this.临时表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.临时表.Location = new System.Drawing.Point(0, 0);
            this.临时表.Name = "临时表";
            this.临时表.Size = new System.Drawing.Size(426, 361);
            this.临时表.TabIndex = 0;
            this.临时表.Text = "临时表";
            // 
            // txttmp
            // 
            this.txttmp.AutoWordSelection = true;
            this.txttmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttmp.Location = new System.Drawing.Point(2, 22);
            this.txttmp.Name = "txttmp";
            this.txttmp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txttmp.Size = new System.Drawing.Size(422, 337);
            this.txttmp.TabIndex = 1;
            this.txttmp.Text = "";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtsql);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(413, 361);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "操作SQL";
            // 
            // txtsql
            // 
            this.txtsql.AutoWordSelection = true;
            this.txtsql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtsql.Location = new System.Drawing.Point(2, 22);
            this.txtsql.Name = "txtsql";
            this.txtsql.Size = new System.Drawing.Size(409, 337);
            this.txtsql.TabIndex = 1;
            this.txtsql.Text = "";
            // 
            // ConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 505);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "属性";
            this.Load += new System.EventHandler(this.ConfigFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttmpname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtexp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txturl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.临时表)).EndInit();
            this.临时表.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txttmpname;
        private DevExpress.XtraEditors.TextEdit txtexp;
        private DevExpress.XtraEditors.TextEdit txturl;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnsave;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl 临时表;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.RichTextBox txttmp;
        private System.Windows.Forms.RichTextBox txtsql;
    }
}