using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Winning.DownLoad.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainFrm());
            bool flag;
            Mutex mutex = new Mutex(true, "RIMS数据下载程序", out flag);
            if (flag)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                MessageBox.Show("本程序不能同时运行两个", "操作提醒", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
    }
}
