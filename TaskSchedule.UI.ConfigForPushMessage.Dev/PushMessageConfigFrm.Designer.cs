namespace TaskSchedule.UI.ConfigForPushMessage.Dev
{
    partial class PushMessageConfigFrm
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
            this.txttokenurl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtweburl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txttstr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cbetdbtype = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pmain)).BeginInit();
            this.pmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttokenurl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtweburl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttstr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbetdbtype.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pmain
            // 
            this.pmain.Controls.Add(this.txttokenurl);
            this.pmain.Controls.Add(this.labelControl3);
            this.pmain.Controls.Add(this.txtweburl);
            this.pmain.Controls.Add(this.labelControl1);
            this.pmain.Controls.Add(this.txttstr);
            this.pmain.Controls.Add(this.labelControl17);
            this.pmain.Controls.Add(this.labelControl11);
            this.pmain.Controls.Add(this.cbetdbtype);
            this.pmain.Size = new System.Drawing.Size(898, 267);
            // 
            // pbottom
            // 
            this.pbottom.Location = new System.Drawing.Point(0, 331);
            // 
            // txttokenurl
            // 
            this.txttokenurl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttokenurl.Location = new System.Drawing.Point(98, 94);
            this.txttokenurl.Name = "txttokenurl";
            this.txttokenurl.Size = new System.Drawing.Size(752, 20);
            this.txttokenurl.TabIndex = 10;
            this.txttokenurl.ToolTip = "数据库链接字符串，可双击进行配置";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Token获取地址";
            // 
            // txtweburl
            // 
            this.txtweburl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtweburl.Location = new System.Drawing.Point(98, 133);
            this.txtweburl.Name = "txtweburl";
            this.txtweburl.Size = new System.Drawing.Size(752, 20);
            this.txtweburl.TabIndex = 11;
            this.txtweburl.ToolTip = "数据库链接字符串，可双击进行配置";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 136);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "推送地址";
            // 
            // txttstr
            // 
            this.txttstr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttstr.Location = new System.Drawing.Point(98, 56);
            this.txttstr.Name = "txttstr";
            this.txttstr.Size = new System.Drawing.Size(752, 20);
            this.txttstr.TabIndex = 12;
            this.txttstr.ToolTip = "数据库链接字符串，可双击进行配置";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(32, 59);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 14);
            this.labelControl17.TabIndex = 15;
            this.labelControl17.Text = "数据源地址";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(32, 20);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 8;
            this.labelControl11.Text = "目标库类型";
            // 
            // cbetdbtype
            // 
            this.cbetdbtype.EditValue = "SqlServer";
            this.cbetdbtype.Location = new System.Drawing.Point(98, 17);
            this.cbetdbtype.Name = "cbetdbtype";
            this.cbetdbtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbetdbtype.Properties.Items.AddRange(new object[] {
            "SqlServer",
            "MsAccess",
            "SqlServer9",
            "Oracle",
            "SqlLite3",
            "MySql",
            ""});
            this.cbetdbtype.Size = new System.Drawing.Size(93, 20);
            this.cbetdbtype.TabIndex = 9;
            // 
            // PushMessageConfigFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 366);
            this.Name = "PushMessageConfigFrm";
            this.Text = "作业【】的属性";
            ((System.ComponentModel.ISupportInitialize)(this.pmain)).EndInit();
            this.pmain.ResumeLayout(false);
            this.pmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttokenurl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtweburl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttstr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbetdbtype.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txttokenurl;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtweburl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txttstr;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit cbetdbtype;
    }
}