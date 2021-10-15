using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Business
{

    public class DefaultSetting
    {
        static DefaultSetting()
        {
            try
            {
                string setting = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json"));
                _settingsInfo = JsonConvert.DeserializeObject<SettingsInfo>(setting);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message, ex);
                _settingsInfo = new SettingsInfo();
            }
        }
        private static SettingsInfo _settingsInfo = null;
        public static SettingsInfo Default { get { return _settingsInfo; } }

    }
    [Serializable]
    public class SettingsInfo
    {
        private string _theme = "DevExpress Style";

        public string theme
        {
            get { return _theme; }
            set { _theme = value; }
        }
        private bool _isautostart=false;

        public bool isautostart
        {
            get { return _isautostart; }
            set { _isautostart = value; }
        }

        private string _appname="任务调度";

        public string appname
        {
            get { return _appname; }
            set { _appname = value; }
        }
        private bool _islog=true;

        public bool islog
        {
            get { return _islog; }
            set { _islog = value; }
        }

        private bool _ismovefollow=true;

        public bool ismovefollow
        {
            get { return _ismovefollow; }
            set { _ismovefollow = value; }
        }

        private int _dbtype=0;

        public int dbtype
        {
            get { return _dbtype; }
            set { _dbtype = value; }
        }

        private string _connstring="";

        public string connstring
        {
            get { return _connstring; }
            set { _connstring = value; }
        }

        private bool _isbodyrecord=true;

        public bool isbodyrecord
        {
            get { return _isbodyrecord; }
            set { _isbodyrecord = value; }
        }

        private int _formmode=0;

        public int formmode
        {
            get { return _formmode; }
            set { _formmode = value; }
        }
        public bool Save()
        {
            try
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppSettings.json"), JsonConvert.DeserializeObject(JsonConvert.SerializeObject(DefaultSetting.Default)).ToString());
                return true;
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
