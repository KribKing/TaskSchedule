namespace DownLoad.UI
{
    partial class XFrm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.btnreset = new DevExpress.XtraEditors.SimpleButton();
            this.txtDt = new System.Windows.Forms.RichTextBox();
            this.btnresettemp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnclose);
            this.panelControl1.Controls.Add(this.btnresettemp);
            this.panelControl1.Controls.Add(this.btnreset);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(555, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(464, 10);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "关闭";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(368, 10);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(90, 23);
            this.btnreset.TabIndex = 0;
            this.btnreset.Text = "重置xml结构";
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // txtDt
            // 
            this.txtDt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDt.Location = new System.Drawing.Point(0, 39);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(555, 394);
            this.txtDt.TabIndex = 1;
            this.txtDt.Text = "";
            // 
            // btnresettemp
            // 
            this.btnresettemp.Location = new System.Drawing.Point(252, 10);
            this.btnresettemp.Name = "btnresettemp";
            this.btnresettemp.Size = new System.Drawing.Size(110, 23);
            this.btnresettemp.TabIndex = 0;
            this.btnresettemp.Text = "重置临时表结构";
            this.btnresettemp.Click += new System.EventHandler(this.btnresettemp_Click);
            // 
            // XFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 433);
            this.ControlBox = false;
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "XFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据表结构XML";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.SimpleButton btnreset;
        private System.Windows.Forms.RichTextBox txtDt;
        private DevExpress.XtraEditors.SimpleButton btnresettemp;
    }
}