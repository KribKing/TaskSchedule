using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winning.DownLoad.UI
{
    public partial class FrmBase : DevExpress.XtraEditors.XtraForm
    {
        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        public FrmBase()
        {
            InitializeComponent();
        }
    }
}
