namespace DownLoad.UI
{
    partial class MapXmlFrm
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
            this.btncancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            this.btngenerate = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maptype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.attr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relemap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtns = new DevExpress.XtraEditors.TextEdit();
            this.txtnode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtjson = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtns.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btncancle);
            this.panelControl1.Controls.Add(this.btnok);
            this.panelControl1.Controls.Add(this.btngenerate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 421);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(898, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // btncancle
            // 
            this.btncancle.Location = new System.Drawing.Point(799, 14);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(75, 23);
            this.btncancle.TabIndex = 0;
            this.btncancle.Text = "关闭";
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(699, 14);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "确认";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btngenerate
            // 
            this.btngenerate.Location = new System.Drawing.Point(604, 14);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(75, 23);
            this.btngenerate.TabIndex = 0;
            this.btngenerate.Text = "生成";
            this.btngenerate.Click += new System.EventHandler(this.btngenerate_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(898, 421);
            this.splitContainerControl1.SplitterPosition = 529;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl3);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(529, 421);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "表设计";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.dataGridView1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 88);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(525, 331);
            this.panelControl3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column,
            this.maptype,
            this.attr,
            this.map,
            this.relemap});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(521, 327);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // column
            // 
            this.column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.column.HeaderText = "映射字段";
            this.column.Name = "column";
            this.column.Width = 80;
            // 
            // maptype
            // 
            this.maptype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maptype.HeaderText = "映射类型";
            this.maptype.Items.AddRange(new object[] {
            "文本值",
            "属性值",
            "关联文本值",
            "关联属性值"});
            this.maptype.Name = "maptype";
            this.maptype.Width = 61;
            // 
            // attr
            // 
            this.attr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.attr.HeaderText = "属性字段";
            this.attr.Name = "attr";
            this.attr.Width = 80;
            // 
            // map
            // 
            this.map.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.map.HeaderText = "映射路径";
            this.map.Name = "map";
            this.map.Width = 80;
            // 
            // relemap
            // 
            this.relemap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.relemap.HeaderText = "关联节点路径";
            this.relemap.Name = "relemap";
            this.relemap.Width = 104;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtns);
            this.panelControl2.Controls.Add(this.txtnode);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 22);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(525, 66);
            this.panelControl2.TabIndex = 2;
            // 
            // txtns
            // 
            this.txtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtns.Location = new System.Drawing.Point(88, 40);
            this.txtns.Name = "txtns";
            this.txtns.Size = new System.Drawing.Size(421, 20);
            this.txtns.TabIndex = 1;
            this.txtns.TextChanged += new System.EventHandler(this.txtnode_TextChanged);
            // 
            // txtnode
            // 
            this.txtnode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnode.Location = new System.Drawing.Point(88, 7);
            this.txtnode.Name = "txtnode";
            this.txtnode.Size = new System.Drawing.Size(421, 20);
            this.txtnode.TabIndex = 1;
            this.txtnode.TextChanged += new System.EventHandler(this.txtnode_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "命名空间";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "解析节点";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtjson);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(364, 421);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "映射脚本";
            // 
            // txtjson
            // 
            this.txtjson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtjson.Location = new System.Drawing.Point(2, 22);
            this.txtjson.Multiline = true;
            this.txtjson.Name = "txtjson";
            this.txtjson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtjson.Size = new System.Drawing.Size(360, 397);
            this.txtjson.TabIndex = 1;
            // 
            // MapXmlFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 470);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "MapXmlFrm";
            this.Text = "Xml映射";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtns.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column;
        private System.Windows.Forms.DataGridViewComboBoxColumn maptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn attr;
        private System.Windows.Forms.DataGridViewTextBoxColumn map;
        private System.Windows.Forms.DataGridViewTextBoxColumn relemap;
        private System.Windows.Forms.TextBox txtjson;
        private DevExpress.XtraEditors.SimpleButton btncancle;
        private DevExpress.XtraEditors.SimpleButton btnok;
        private DevExpress.XtraEditors.SimpleButton btngenerate;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtns;
        private DevExpress.XtraEditors.TextEdit txtnode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}