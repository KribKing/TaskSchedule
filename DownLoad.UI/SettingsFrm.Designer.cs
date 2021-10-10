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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFrm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnsave = new DevExpress.XtraEditors.SimpleButton();
            this.btnclose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cesjm = new DevExpress.XtraEditors.CheckEdit();
            this.btnyy = new DevExpress.XtraEditors.SimpleButton();
            this.txtappname = new DevExpress.XtraEditors.TextEdit();
            this.txtconnectstring = new DevExpress.XtraEditors.TextEdit();
            this.cbisfilelog = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbtheme = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbbody = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbeformmode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbisfollow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbisautostart = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbdbtype = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblisfollow = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cesjm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtappname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtconnectstring.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisfilelog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtheme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbody.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeformmode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisfollow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisautostart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdbtype.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnsave);
            this.panelControl1.Controls.Add(this.btnclose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 269);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(616, 50);
            this.panelControl1.TabIndex = 2;
            // 
            // btnsave
            // 
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(431, 15);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "保存";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(523, 15);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "关闭";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cesjm);
            this.panelControl2.Controls.Add(this.btnyy);
            this.panelControl2.Controls.Add(this.txtappname);
            this.panelControl2.Controls.Add(this.txtconnectstring);
            this.panelControl2.Controls.Add(this.cbisfilelog);
            this.panelControl2.Controls.Add(this.cbtheme);
            this.panelControl2.Controls.Add(this.cbbody);
            this.panelControl2.Controls.Add(this.cbeformmode);
            this.panelControl2.Controls.Add(this.cbisfollow);
            this.panelControl2.Controls.Add(this.cbisautostart);
            this.panelControl2.Controls.Add(this.cbdbtype);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.lblisfollow);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(616, 269);
            this.panelControl2.TabIndex = 3;
            // 
            // cesjm
            // 
            this.cesjm.AutoSizeInLayoutControl = true;
            this.cesjm.EditValue = true;
            this.cesjm.Location = new System.Drawing.Point(549, 101);
            this.cesjm.Name = "cesjm";
            this.cesjm.Properties.AutoWidth = true;
            this.cesjm.Properties.Caption = "加密";
            this.cesjm.Size = new System.Drawing.Size(42, 15);
            this.cesjm.TabIndex = 8;
            this.cesjm.CheckedChanged += new System.EventHandler(this.cesjm_CheckedChanged);
            // 
            // btnyy
            // 
            this.btnyy.Location = new System.Drawing.Point(549, 185);
            this.btnyy.Name = "btnyy";
            this.btnyy.Size = new System.Drawing.Size(49, 23);
            this.btnyy.TabIndex = 0;
            this.btnyy.Text = "应用";
            this.btnyy.Click += new System.EventHandler(this.btnyy_Click);
            // 
            // txtappname
            // 
            this.txtappname.Location = new System.Drawing.Point(148, 141);
            this.txtappname.Name = "txtappname";
            this.txtappname.Size = new System.Drawing.Size(395, 20);
            this.txtappname.TabIndex = 2;
            // 
            // txtconnectstring
            // 
            this.txtconnectstring.Location = new System.Drawing.Point(148, 102);
            this.txtconnectstring.Name = "txtconnectstring";
            this.txtconnectstring.Size = new System.Drawing.Size(395, 20);
            this.txtconnectstring.TabIndex = 2;
            this.txtconnectstring.DoubleClick += new System.EventHandler(this.txtconnectstring_DoubleClick);
            // 
            // cbisfilelog
            // 
            this.cbisfilelog.Location = new System.Drawing.Point(413, 64);
            this.cbisfilelog.Name = "cbisfilelog";
            this.cbisfilelog.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbisfilelog.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbisfilelog.Size = new System.Drawing.Size(130, 20);
            this.cbisfilelog.TabIndex = 1;
            // 
            // cbtheme
            // 
            this.cbtheme.Location = new System.Drawing.Point(148, 186);
            this.cbtheme.Name = "cbtheme";
            this.cbtheme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbtheme.Properties.Items.AddRange(new object[] {
            "Default",
            "WindowsXP",
            "Office2000",
            "Office2003",
            "DevExpress Style",
            "DevExpress Dark Style",
            "VS2010",
            "Seven Classic",
            "Office 2010 Blue",
            "Office 2010 Black",
            "Office 2010 Silver",
            "Office 2013",
            "Office 2013 Dark Gray",
            "Office 2013 Light Gray",
            "Visual Studio 2013 Blue",
            "Visual Studio 2013 Light",
            "Visual Studio 2013 Dark",
            "Coffee",
            "Liquid Sky",
            "London Liquid Sky",
            "Glass Oceans",
            "Stardust",
            "Xmas 2008 Blue",
            "Valentine",
            "McSkin",
            "Summer 2008",
            "Pumpkin",
            "Dark Side",
            "Springtime",
            "Foggy",
            "High Contrast",
            "Seven",
            "Sharp",
            "Sharp Plus",
            "The Asphalt World",
            "Whiteprint",
            "Caramel",
            "Money Twins",
            "Lilian",
            "iMaginary",
            "Black",
            "Office 2007 Blue",
            "Office 2007 Black",
            "Office 2007 Silver",
            "Office 2007 Green",
            "Office 2007 Pink",
            "Blue",
            "Darkroom",
            "Blueprint",
            "Metropolis Dark",
            "Metropolis"});
            this.cbtheme.Size = new System.Drawing.Size(395, 20);
            this.cbtheme.TabIndex = 1;
            // 
            // cbbody
            // 
            this.cbbody.Location = new System.Drawing.Point(148, 64);
            this.cbbody.Name = "cbbody";
            this.cbbody.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbody.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbbody.Size = new System.Drawing.Size(130, 20);
            this.cbbody.TabIndex = 1;
            // 
            // cbeformmode
            // 
            this.cbeformmode.Location = new System.Drawing.Point(148, 230);
            this.cbeformmode.Name = "cbeformmode";
            this.cbeformmode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeformmode.Properties.Items.AddRange(new object[] {
            "主从",
            "Tab页"});
            this.cbeformmode.Size = new System.Drawing.Size(130, 20);
            this.cbeformmode.TabIndex = 1;
            this.cbeformmode.SelectedIndexChanged += new System.EventHandler(this.cbeformmode_SelectedIndexChanged);
            // 
            // cbisfollow
            // 
            this.cbisfollow.Location = new System.Drawing.Point(413, 230);
            this.cbisfollow.Name = "cbisfollow";
            this.cbisfollow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbisfollow.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbisfollow.Size = new System.Drawing.Size(130, 20);
            this.cbisfollow.TabIndex = 1;
            // 
            // cbisautostart
            // 
            this.cbisautostart.Location = new System.Drawing.Point(413, 17);
            this.cbisautostart.Name = "cbisautostart";
            this.cbisautostart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbisautostart.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbisautostart.Size = new System.Drawing.Size(130, 20);
            this.cbisautostart.TabIndex = 1;
            // 
            // cbdbtype
            // 
            this.cbdbtype.Location = new System.Drawing.Point(148, 17);
            this.cbdbtype.Name = "cbdbtype";
            this.cbdbtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbdbtype.Properties.Items.AddRange(new object[] {
            "SqlServer",
            "MsAccess",
            "SqlServer9",
            "Oracle",
            "Sqlite3",
            "MySql"});
            this.cbdbtype.Size = new System.Drawing.Size(130, 20);
            this.cbdbtype.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 190);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(48, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "主题风格";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(25, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "程序名称";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(25, 105);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "数据库链接";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(111, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "返回串Body是否记录";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(25, 233);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "子窗体模式";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(313, 67);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "日志是否输出";
            // 
            // lblisfollow
            // 
            this.lblisfollow.Location = new System.Drawing.Point(290, 233);
            this.lblisfollow.Name = "lblisfollow";
            this.lblisfollow.Size = new System.Drawing.Size(108, 14);
            this.lblisfollow.TabIndex = 0;
            this.lblisfollow.Text = "子窗体是否移动跟随";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(313, 20);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "是否开机启动";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据库类型";
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(616, 319);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cesjm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtappname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtconnectstring.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisfilelog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbtheme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbody.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeformmode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisfollow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbisautostart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdbtype.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnsave;
        private DevExpress.XtraEditors.SimpleButton btnclose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtappname;
        private DevExpress.XtraEditors.TextEdit txtconnectstring;
        private DevExpress.XtraEditors.ComboBoxEdit cbisfilelog;
        private DevExpress.XtraEditors.ComboBoxEdit cbtheme;
        private DevExpress.XtraEditors.ComboBoxEdit cbisfollow;
        private DevExpress.XtraEditors.ComboBoxEdit cbisautostart;
        private DevExpress.XtraEditors.ComboBoxEdit cbdbtype;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblisfollow;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit cesjm;
        private DevExpress.XtraEditors.SimpleButton btnyy;
        private DevExpress.XtraEditors.ComboBoxEdit cbbody;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbeformmode;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}