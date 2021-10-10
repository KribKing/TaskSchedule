using DownLoad.UI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DownLoad.Core;


namespace DownLoad.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                DevExpress.UserSkins.BonusSkins.Register();
                //DevExpress.UserSkins.OfficeSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainFrm());
                Tools.AutoStart(Settings.Default.isautostart, Settings.Default.appname, true);
                bool flag;
                Mutex mutex = new Mutex(true, Settings.Default.appname, out flag);
                if (flag)
                {
                    Application.Run((Settings.Default.formmode == 1 ? (Form)new NewMainFrm() : (Form)new FrmMain()));
                }
                else
                {
                    MessageBox.Show("本程序不能同时运行两个", "操作提醒", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("系统出现未知异常,原因：" + ex.Message, ex);
            }

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Log4netUtil.Error("系统出现未知异常，原因：" + e.Exception.Message, e.Exception);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("捕获系统异常发生错误，原因：" + ex.Message, ex);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Log4netUtil.Error("非UI线程出现未知异常，原因：" + e.ExceptionObject);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("捕获系统非UI线程异常发生错误，原因：" + ex.Message, ex);
            }
        }
    }
}
