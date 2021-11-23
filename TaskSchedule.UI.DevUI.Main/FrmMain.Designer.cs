namespace TaskSchedule.UI.DevUI
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnrunjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnjzjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnpro = new DevExpress.XtraBars.BarButtonItem();
            this.btnqyjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnFast = new DevExpress.XtraBars.BarButtonItem();
            this.btnnewjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnallqyjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnalljzjob = new DevExpress.XtraBars.BarButtonItem();
            this.btncopyjob = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btndeletejob = new DevExpress.XtraBars.BarButtonItem();
            this.btnrename = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.tPatKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.phead = new DevExpress.XtraEditors.PanelControl();
            this.pop_ctrl_job = new DevExpress.XtraEditors.PopupContainerControl();
            this.lbjob = new DevExpress.XtraEditors.ListBoxControl();
            this.pop_job = new DevExpress.XtraEditors.PopupContainerEdit();
            this.btnlog = new DevExpress.XtraEditors.SimpleButton();
            this.btnconfig = new DevExpress.XtraEditors.SimpleButton();
            this.btnPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnflushmemory = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phead)).BeginInit();
            this.phead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pop_ctrl_job)).BeginInit();
            this.pop_ctrl_job.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbjob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop_job.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "forbiddon16x16.png");
            this.imageList1.Images.SetKeyName(1, "start16x16.png");
            this.imageList1.Images.SetKeyName(2, "main16x16.png");
            this.imageList1.Images.SetKeyName(3, "error16x16.png");
            this.imageList1.Images.SetKeyName(4, "success16x16.png");
            this.imageList1.Images.SetKeyName(5, "dbopen16x16.png");
            this.imageList1.Images.SetKeyName(6, "dbpause16x16.png");
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnrunjob,
            this.btnjzjob,
            this.btnpro,
            this.btnqyjob,
            this.btnFast,
            this.btnnewjob,
            this.btnallqyjob,
            this.btnalljzjob,
            this.btncopyjob,
            this.barButtonItem1,
            this.btndeletejob,
            this.btnrename});
            this.barManager1.MaxItemId = 14;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(290, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 576);
            this.barDockControlBottom.Size = new System.Drawing.Size(290, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 576);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(290, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 576);
            // 
            // btnrunjob
            // 
            this.btnrunjob.Id = 13;
            this.btnrunjob.Name = "btnrunjob";
            // 
            // btnjzjob
            // 
            this.btnjzjob.Caption = "禁用";
            this.btnjzjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btnjzjob.Glyph")));
            this.btnjzjob.Id = 2;
            this.btnjzjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnjzjob.LargeGlyph")));
            this.btnjzjob.Name = "btnjzjob";
            this.btnjzjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnjzjob_ItemClick);
            // 
            // btnpro
            // 
            this.btnpro.Caption = "属性";
            this.btnpro.Glyph = ((System.Drawing.Image)(resources.GetObject("btnpro.Glyph")));
            this.btnpro.Id = 3;
            this.btnpro.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnpro.LargeGlyph")));
            this.btnpro.Name = "btnpro";
            this.btnpro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnpro_ItemClick);
            // 
            // btnqyjob
            // 
            this.btnqyjob.Caption = "启用";
            this.btnqyjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btnqyjob.Glyph")));
            this.btnqyjob.Id = 4;
            this.btnqyjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnqyjob.LargeGlyph")));
            this.btnqyjob.Name = "btnqyjob";
            this.btnqyjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqyjob_ItemClick);
            // 
            // btnFast
            // 
            this.btnFast.Caption = "快速执行";
            this.btnFast.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFast.Glyph")));
            this.btnFast.Id = 5;
            this.btnFast.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFast.LargeGlyph")));
            this.btnFast.Name = "btnFast";
            this.btnFast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFast_ItemClick);
            // 
            // btnnewjob
            // 
            this.btnnewjob.Caption = "新增作业";
            this.btnnewjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btnnewjob.Glyph")));
            this.btnnewjob.Id = 6;
            this.btnnewjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnnewjob.LargeGlyph")));
            this.btnnewjob.Name = "btnnewjob";
            this.btnnewjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnnewjob_ItemClick);
            // 
            // btnallqyjob
            // 
            this.btnallqyjob.Caption = "全部启用";
            this.btnallqyjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btnallqyjob.Glyph")));
            this.btnallqyjob.Id = 7;
            this.btnallqyjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnallqyjob.LargeGlyph")));
            this.btnallqyjob.Name = "btnallqyjob";
            this.btnallqyjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnallqyjob_ItemClick);
            // 
            // btnalljzjob
            // 
            this.btnalljzjob.Caption = "全部禁用";
            this.btnalljzjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btnalljzjob.Glyph")));
            this.btnalljzjob.Id = 8;
            this.btnalljzjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnalljzjob.LargeGlyph")));
            this.btnalljzjob.Name = "btnalljzjob";
            this.btnalljzjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnalljzjob_ItemClick);
            // 
            // btncopyjob
            // 
            this.btncopyjob.Caption = "复制作业";
            this.btncopyjob.Glyph = ((System.Drawing.Image)(resources.GetObject("btncopyjob.Glyph")));
            this.btncopyjob.Id = 9;
            this.btncopyjob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btncopyjob.LargeGlyph")));
            this.btncopyjob.Name = "btncopyjob";
            this.btncopyjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btncopyjob_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "删除作业";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btndeletejob
            // 
            this.btndeletejob.Caption = "删除作业";
            this.btndeletejob.Glyph = ((System.Drawing.Image)(resources.GetObject("btndeletejob.Glyph")));
            this.btndeletejob.Id = 11;
            this.btndeletejob.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btndeletejob.LargeGlyph")));
            this.btndeletejob.Name = "btndeletejob";
            this.btndeletejob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btndeletejob_ItemClick);
            // 
            // btnrename
            // 
            this.btnrename.Caption = "重命名";
            this.btnrename.Glyph = ((System.Drawing.Image)(resources.GetObject("btnrename.Glyph")));
            this.btnrename.Id = 12;
            this.btnrename.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnrename.LargeGlyph")));
            this.btnrename.Name = "btnrename";
            this.btnrename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnrename_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnnewjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btncopyjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btndeletejob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnallqyjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnalljzjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnqyjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnjzjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnpro),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnrename)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "康复管理系统数据下载程序";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出程序ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.pop_ctrl_job);
            this.groupControl1.Controls.Add(this.treeList1);
            this.groupControl1.Controls.Add(this.phead);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(290, 576);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "作业调度器";
            // 
            // treeList1
            // 
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tPatKey});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 51);
            this.treeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList1.LookAndFeel.UseWindowsXPTheme = true;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowCopyToClipboard = false;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(286, 523);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 2;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            this.treeList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseUp);
            // 
            // tPatKey
            // 
            this.tPatKey.FieldName = "treeListColumn1";
            this.tPatKey.MinWidth = 33;
            this.tPatKey.Name = "tPatKey";
            this.tPatKey.Visible = true;
            this.tPatKey.VisibleIndex = 0;
            // 
            // phead
            // 
            this.phead.Controls.Add(this.pop_job);
            this.phead.Controls.Add(this.btnflushmemory);
            this.phead.Controls.Add(this.btnlog);
            this.phead.Controls.Add(this.btnconfig);
            this.phead.Controls.Add(this.btnPause);
            this.phead.Controls.Add(this.btnStart);
            this.phead.Dock = System.Windows.Forms.DockStyle.Top;
            this.phead.Location = new System.Drawing.Point(2, 22);
            this.phead.Name = "phead";
            this.phead.Size = new System.Drawing.Size(286, 29);
            this.phead.TabIndex = 1;
            // 
            // pop_ctrl_job
            // 
            this.pop_ctrl_job.Controls.Add(this.lbjob);
            this.pop_ctrl_job.Location = new System.Drawing.Point(124, 91);
            this.pop_ctrl_job.Margin = new System.Windows.Forms.Padding(0);
            this.pop_ctrl_job.Name = "pop_ctrl_job";
            this.pop_ctrl_job.Padding = new System.Windows.Forms.Padding(1);
            this.pop_ctrl_job.Size = new System.Drawing.Size(99, 86);
            this.pop_ctrl_job.TabIndex = 2;
            // 
            // lbjob
            // 
            this.lbjob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbjob.Location = new System.Drawing.Point(1, 1);
            this.lbjob.Name = "lbjob";
            this.lbjob.Size = new System.Drawing.Size(97, 84);
            this.lbjob.TabIndex = 0;
            this.lbjob.Click += new System.EventHandler(this.lbjob_Click);
            // 
            // pop_job
            // 
            this.pop_job.Location = new System.Drawing.Point(232, 3);
            this.pop_job.MenuManager = this.barManager1;
            this.pop_job.Name = "pop_job";
            this.pop_job.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pop_job.Properties.Appearance.Options.UseBackColor = true;
            this.pop_job.Properties.AutoHeight = false;
            this.pop_job.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("pop_job.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.pop_job.Properties.PopupControl = this.pop_ctrl_job;
            this.pop_job.Properties.PopupFormMinSize = new System.Drawing.Size(80, 80);
            this.pop_job.Properties.PopupFormSize = new System.Drawing.Size(100, 100);
            this.pop_job.Properties.ShowPopupCloseButton = false;
            this.pop_job.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.pop_job.Size = new System.Drawing.Size(20, 23);
            this.pop_job.TabIndex = 1;
            this.pop_job.ToolTip = "新增作业";
            // 
            // btnlog
            // 
            this.btnlog.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnlog.Image = ((System.Drawing.Image)(resources.GetObject("btnlog.Image")));
            this.btnlog.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnlog.Location = new System.Drawing.Point(86, 2);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(20, 23);
            this.btnlog.TabIndex = 0;
            this.btnlog.ToolTip = "查看控制台日志";
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // btnconfig
            // 
            this.btnconfig.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnconfig.Image = ((System.Drawing.Image)(resources.GetObject("btnconfig.Image")));
            this.btnconfig.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnconfig.Location = new System.Drawing.Point(8, 2);
            this.btnconfig.Name = "btnconfig";
            this.btnconfig.Size = new System.Drawing.Size(20, 23);
            this.btnconfig.TabIndex = 0;
            this.btnconfig.ToolTip = "参数配置";
            this.btnconfig.Click += new System.EventHandler(this.btnconfig_Click);
            // 
            // btnPause
            // 
            this.btnPause.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPause.Location = new System.Drawing.Point(60, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(20, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.ToolTip = "暂停作业调度器";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStart.Location = new System.Drawing.Point(33, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(20, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.ToolTip = "重启作业调度器";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnflushmemory
            // 
            this.btnflushmemory.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnflushmemory.Image = ((System.Drawing.Image)(resources.GetObject("btnflushmemory.Image")));
            this.btnflushmemory.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnflushmemory.Location = new System.Drawing.Point(261, 3);
            this.btnflushmemory.Name = "btnflushmemory";
            this.btnflushmemory.Size = new System.Drawing.Size(20, 23);
            this.btnflushmemory.TabIndex = 0;
            this.btnflushmemory.ToolTip = "清理缓存";
            this.btnflushmemory.Click += new System.EventHandler(this.btnflushmemory_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 576);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "康复下载程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phead)).EndInit();
            this.phead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pop_ctrl_job)).EndInit();
            this.pop_ctrl_job.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbjob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pop_job.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnrunjob;
        private DevExpress.XtraBars.BarButtonItem btnstopjob;
        private DevExpress.XtraBars.BarButtonItem btnjzjob;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnpro;
        private DevExpress.XtraBars.BarButtonItem btnqyjob;
        private DevExpress.XtraBars.BarButtonItem btnFast;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btnnewjob;
        private DevExpress.XtraBars.BarButtonItem btnallqyjob;
        private DevExpress.XtraBars.BarButtonItem btnalljzjob;
        private DevExpress.XtraBars.BarButtonItem btncopyjob;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btndeletejob;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tPatKey;
        private DevExpress.XtraEditors.PanelControl phead;
        private DevExpress.XtraEditors.SimpleButton btnlog;
        private DevExpress.XtraEditors.SimpleButton btnconfig;
        private DevExpress.XtraEditors.SimpleButton btnPause;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraBars.BarButtonItem btnrename;
        private DevExpress.XtraEditors.PopupContainerControl pop_ctrl_job;
        private DevExpress.XtraEditors.PopupContainerEdit pop_job;
        private DevExpress.XtraEditors.ListBoxControl lbjob;
        private DevExpress.XtraEditors.SimpleButton btnflushmemory;
    }
}