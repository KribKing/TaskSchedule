namespace Winning.DownLoad.UI
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.tPatKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnaddjob = new DevExpress.XtraEditors.SimpleButton();
            this.btnPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnrefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnremove = new DevExpress.XtraEditors.SimpleButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnrunjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnstopjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnjzjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnpro = new DevExpress.XtraBars.BarButtonItem();
            this.btnqyjob = new DevExpress.XtraBars.BarButtonItem();
            this.btnFast = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtmsg = new System.Windows.Forms.RichTextBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("297d692a-0686-40a8-9eaa-80d5be22147d");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(273, 200);
            this.dockPanel1.Size = new System.Drawing.Size(273, 576);
            this.dockPanel1.Text = "作业调度器";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeList1);
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(265, 549);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tPatKey});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 29);
            this.treeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList1.LookAndFeel.UseWindowsXPTheme = true;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowCopyToClipboard = false;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(265, 520);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 1;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnaddjob);
            this.panelControl1.Controls.Add(this.btnPause);
            this.panelControl1.Controls.Add(this.btnStart);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(265, 29);
            this.panelControl1.TabIndex = 0;
            // 
            // btnaddjob
            // 
            this.btnaddjob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddjob.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnaddjob.Image = ((System.Drawing.Image)(resources.GetObject("btnaddjob.Image")));
            this.btnaddjob.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnaddjob.Location = new System.Drawing.Point(233, 3);
            this.btnaddjob.Name = "btnaddjob";
            this.btnaddjob.Size = new System.Drawing.Size(27, 23);
            this.btnaddjob.TabIndex = 0;
            this.btnaddjob.ToolTip = "新增作业";
            this.btnaddjob.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnPause
            // 
            this.btnPause.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPause.Location = new System.Drawing.Point(39, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(27, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.ToolTip = "暂停作业调度器";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStart.Location = new System.Drawing.Point(6, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(27, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.ToolTip = "重启作业调度器";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnrefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Image")));
            this.btnrefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnrefresh.Location = new System.Drawing.Point(7, 5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(27, 23);
            this.btnrefresh.TabIndex = 0;
            this.btnrefresh.ToolTip = "刷新历史记录";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnremove
            // 
            this.btnremove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnremove.Image = ((System.Drawing.Image)(resources.GetObject("btnremove.Image")));
            this.btnremove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnremove.Location = new System.Drawing.Point(5, 3);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(27, 23);
            this.btnremove.TabIndex = 0;
            this.btnremove.ToolTip = "清空消息框";
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
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
            this.btnstopjob,
            this.btnjzjob,
            this.btnpro,
            this.btnqyjob,
            this.btnFast});
            this.barManager1.MaxItemId = 6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1099, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 576);
            this.barDockControlBottom.Size = new System.Drawing.Size(1099, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1099, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 576);
            // 
            // btnrunjob
            // 
            this.btnrunjob.Caption = "执行服务";
            this.btnrunjob.Id = 0;
            this.btnrunjob.Name = "btnrunjob";
            this.btnrunjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnrunjob_ItemClick);
            // 
            // btnstopjob
            // 
            this.btnstopjob.Caption = "停止作业";
            this.btnstopjob.Id = 1;
            this.btnstopjob.Name = "btnstopjob";
            this.btnstopjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnstopjob_ItemClick);
            // 
            // btnjzjob
            // 
            this.btnjzjob.Caption = "禁用";
            this.btnjzjob.Id = 2;
            this.btnjzjob.Name = "btnjzjob";
            this.btnjzjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnjzjob_ItemClick);
            // 
            // btnpro
            // 
            this.btnpro.Caption = "属性";
            this.btnpro.Id = 3;
            this.btnpro.Name = "btnpro";
            this.btnpro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnpro_ItemClick);
            // 
            // btnqyjob
            // 
            this.btnqyjob.Caption = "启用";
            this.btnqyjob.Id = 4;
            this.btnqyjob.Name = "btnqyjob";
            this.btnqyjob.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnqyjob_ItemClick);
            // 
            // btnFast
            // 
            this.btnFast.Caption = "快速执行";
            this.btnFast.Id = 5;
            this.btnFast.Name = "btnFast";
            this.btnFast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFast_ItemClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(822, 161);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "执行状态";
            this.gridColumn5.FieldName = "zxzt";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "时间";
            this.gridColumn1.DisplayFormat.FormatString = "G";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "sj";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "作业编码";
            this.gridColumn2.FieldName = "id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 140;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "作业名称";
            this.gridColumn3.FieldName = "name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 374;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "作业大类";
            this.gridColumn4.FieldName = "system";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(273, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl4);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(826, 576);
            this.splitContainerControl1.SplitterPosition = 376;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.panelControl3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(826, 376);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "作业监测";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtmsg);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 52);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(822, 322);
            this.panelControl2.TabIndex = 10;
            // 
            // txtmsg
            // 
            this.txtmsg.BackColor = System.Drawing.Color.Black;
            this.txtmsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtmsg.ForeColor = System.Drawing.Color.Yellow;
            this.txtmsg.Location = new System.Drawing.Point(2, 2);
            this.txtmsg.Name = "txtmsg";
            this.txtmsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtmsg.ShowSelectionMargin = true;
            this.txtmsg.Size = new System.Drawing.Size(818, 318);
            this.txtmsg.TabIndex = 0;
            this.txtmsg.Text = "";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnremove);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 22);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(822, 30);
            this.panelControl3.TabIndex = 11;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.gridControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 30);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(826, 165);
            this.panelControl5.TabIndex = 11;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnrefresh);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(826, 30);
            this.panelControl4.TabIndex = 10;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnrunjob, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnqyjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnjzjob),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnpro)});
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 576);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "康复下载程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnrunjob;
        private DevExpress.XtraBars.BarButtonItem btnstopjob;
        private DevExpress.XtraBars.BarButtonItem btnjzjob;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tPatKey;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private DevExpress.XtraBars.BarButtonItem btnpro;
        private DevExpress.XtraEditors.SimpleButton btnPause;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnremove;
        private DevExpress.XtraEditors.SimpleButton btnaddjob;
        private DevExpress.XtraEditors.SimpleButton btnrefresh;
        private DevExpress.XtraBars.BarButtonItem btnqyjob;
        private System.Windows.Forms.RichTextBox txtmsg;
        private DevExpress.XtraBars.BarButtonItem btnFast;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;

    }
}