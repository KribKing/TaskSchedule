using TaskSchedule.Core;
using System;
using System.Data;
using TaskSchedule.UI.Base;
namespace TaskSchedule.UI.Config.Dev
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
