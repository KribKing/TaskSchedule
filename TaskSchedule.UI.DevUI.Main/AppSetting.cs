using Newtonsoft.Json;
using System;
using System.IO;
using TaskSchedule.Core;

namespace TaskSchedule.UI.DevUI
{
    [Serializable]
    public class AppSetting
    {
        private static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\AppSetting.json");
        static AppSetting()
        {
            try
            {
                string setting = File.ReadAllText(path);
                _settingsInfo = JsonConvert.DeserializeObject<AppSetting>(setting);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error(ex.Message, ex);
                _settingsInfo = new AppSetting();
            }
        }
        public AppSetting()
        {

        }
        private static AppSetting _settingsInfo = null;
        public static AppSetting Default { get { return _settingsInfo; } }
        public void Save()
        {
            if (Default == null) return;

            File.WriteAllText(path, JsonConvert.DeserializeObject(JsonConvert.SerializeObject(Default)).ToString());
        }
        public bool islog { get; set; }

        public string appname { get; set; }

        public string theme { get; set; }

        public bool ismovefollow { get; set; }

        public bool isautostart { get; set; }
    }
}
