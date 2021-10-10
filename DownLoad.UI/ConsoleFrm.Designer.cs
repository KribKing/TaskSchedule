namespace DownLoad.UI
{
    partial class ConsoleFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleFrm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.btnremove = new DevExpress.XtraEditors.SimpleButton();
            this.pconsole = new DevExpress.XtraEditors.PanelControl();
            this.rtblog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pconsole)).BeginInit();
            this.pconsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.toggleSwitch1);
            this.panelControl1.Controls.Add(this.btnremove);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(926, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(67, 6);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(97, 21);
            this.toggleSwitch1.TabIndex = 2;
            this.toggleSwitch1.ToolTip = "暂停日志输出";
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // btnremove
            // 
            this.btnremove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnremove.Image = ((System.Drawing.Image)(resources.GetObject("btnremove.Image")));
            this.btnremove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnremove.Location = new System.Drawing.Point(5, 5);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(38, 23);
            this.btnremove.TabIndex = 1;
            this.btnremove.ToolTip = "清空控制台日志";
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // pconsole
            // 
            this.pconsole.Controls.Add(this.rtblog);
            this.pconsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pconsole.Location = new System.Drawing.Point(0, 33);
            this.pconsole.Name = "pconsole";
            this.pconsole.Size = new System.Drawing.Size(926, 541);
            this.pconsole.TabIndex = 1;
            // 
            // rtblog
            // 
            this.rtblog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtblog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtblog.Location = new System.Drawing.Point(2, 2);
            this.rtblog.Name = "rtblog";
            this.rtblog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtblog.Size = new System.Drawing.Size(922, 537);
            this.rtblog.TabIndex = 0;
            this.rtblog.Text = "";
            // 
            // ConsoleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 574);
            this.Controls.Add(this.pconsole);
            this.Controls.Add(this.panelControl1);
            this.Name = "ConsoleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "日志监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleFrm_FormClosing);
            this.Load += new System.EventHandler(this.ConsoleFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pconsole)).EndInit();
            this.pconsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnremove;
        private DevExpress.XtraEditors.PanelControl pconsole;
        private System.Windows.Forms.RichTextBox rtblog;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
    }
}