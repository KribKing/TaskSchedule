using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Interface
{
    public class AddinsSetting
    {
        static AddinsSetting()
        {
            try
            {
                string setting = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\AddinsSetting.json"));
                _settingsInfo = JsonConvert.DeserializeObject<List<AddinsInfo>>(setting);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message, ex);
                _settingsInfo = new List<AddinsInfo>();
            }
        }
        private static List<AddinsInfo> _settingsInfo = null;
        public static List<AddinsInfo> Default { get { return _settingsInfo; } }
    }
    [Serializable]
    public class AddinsInfo
    {
        public string AssemblyName { get; set; }

        public string TaskStarter { get; set; }
        public string SettingInterface { get; set; }
    }
}
