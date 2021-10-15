using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace TaskSchedule.UI.Base
{
    public partial class ProcessBarFrm : SplashScreen
    {
        #region 单例实现
        private static string _lockFlag = "FrmProgressBarLock";
        private static ProcessBarFrm _instance = null;

        /// <summary>
        /// 进度条窗口实例
        /// </summary>
        public static ProcessBarFrm Instance
        {
            get
            {
                lock (_lockFlag)
                {
                    if (_instance == null)
                    {
                        _instance = new ProcessBarFrm(true);
                    }
                    else if (_instance.IsDisposed)
                    {
                        _instance = null;
                        _instance = new ProcessBarFrm(true);
                    }
                    return _instance;
                }
            }
        }

        #endregion
        #region 字段定义

        private bool _isShowTitle = false;

        #endregion
        public ProcessBarFrm()
        {
            InitializeComponent();
        }
        private ProcessBarFrm(bool isShowTitle)
        {
            InitializeComponent();
            this._isShowTitle = isShowTitle;
            this.marqueeProgressBarControl1.Properties.ShowTitle = this._isShowTitle;
        }

        #region 属性定义

        /// <summary>
        /// 是否显示标题
        /// </summary>
        public bool IsShowTitle
        {
            get
            {
                return this._isShowTitle;
            }
            set
            {
                this._isShowTitle = value;
                this.marqueeProgressBarControl1.Properties.ShowTitle = this._isShowTitle;
            }
        }

        /// <summary>
        /// 提示文本
        /// </summary>
        public string NotifyText
        {
            get
            {
                return this.lbltxt.Text;
            }
        }

        /// <summary>
        /// 进度值
        /// </summary>
        public int ProgressValue
        {
            get
            {
                return (int)this.marqueeProgressBarControl1.EditValue;
            }
        }

        #endregion

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {

            switch ((SplashScreenCommand)cmd)
            {
                case SplashScreenCommand.notify:
                    {
                        this.lbltxt.Invoke(new Action<string>(a =>
                        {
                            this.lbltxt.Text = a;
                        }), arg);
                    }
                    break;
                case SplashScreenCommand.processvalue:
                    this.marqueeProgressBarControl1.Invoke(new Action<string>(a =>
                    {
                        this.marqueeProgressBarControl1.Text = String.Format("{0}%", a);
                    }), arg);
                    break;
                default:
                    break;
            }
        }

        #endregion

        public enum SplashScreenCommand
        {
            notify = 0,
            processvalue = 1
        }
    }
}