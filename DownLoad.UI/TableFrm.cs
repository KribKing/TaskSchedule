using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DownLoad.Core;
namespace DownLoad.UI
{
    public partial class TableFrm : FrmBase
    {
        public ISwitchDataInterface<DataTable> Cur_Switch { get; set; }
        public TableFrm()
        {
            InitializeComponent();
        }
        public TableFrm(ISwitchDataInterface<DataTable> switchdata)
        {
            InitializeComponent();
            Cur_Switch = switchdata;
        }
        private void TableFrm_Load(object sender, EventArgs e)
        {
            if (Cur_Switch != null)
                this.Cur_Switch.OnSwitchData += new SwitchData<DataTable>(LoadGrid);       
        }
        public void LoadGrid(DataTable dt)
        {
            this.gridControl1.DataSource = dt;
            this.gridControl1.Refresh();
        }
    }
}
