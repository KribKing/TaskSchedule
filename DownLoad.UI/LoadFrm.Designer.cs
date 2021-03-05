namespace DownLoad.UI
{
    partial class LoadFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadFrm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tileControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(520, 84);
            this.panelControl1.TabIndex = 0;
            // 
            // tileControl1
            // 
            this.tileControl1.AppearanceText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tileControl1.AppearanceText.Options.UseBackColor = true;
            this.tileControl1.AppearanceText.Options.UseImage = true;
            this.tileControl1.AppearanceText.Options.UseTextOptions = true;
            this.tileControl1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tileControl1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Location = new System.Drawing.Point(2, 2);
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.ShowText = true;
            this.tileControl1.Size = new System.Drawing.Size(516, 80);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "正在加载，请稍后...";
            // 
            // LoadFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 84);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "康复下载程序";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TileControl tileControl1;
    }
}