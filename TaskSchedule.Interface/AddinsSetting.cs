using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Interface
{
    public class AddinsSetting:IJobSettingInterface<AddinsInfo>
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\AddinsSetting.json");
        public AddinsSetting()
        {
            this.Init();
        }
        public void Save()
        {
            try
            {
                if (Default == null || Default.Count <= 0) return;
                List<AddinsInfo> list = Tools.CloneByJson<List<AddinsInfo>>(Default);         
                File.WriteAllText(path, JsonConvert.DeserializeObject(JsonConvert.SerializeObject(list)).ToString());
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("定时同步任务配置保存失败，请检查,原因：" + ex.Message, ex);
            }
        }

        public void Init()
        {
            try
            {
                string setting = File.ReadAllText(path);
                List<AddinsInfo> list = JsonConvert.DeserializeObject<List<AddinsInfo>>(setting);
                _settingsInfo.AddRange(list);
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("加载插件配置失败，请检查,原因：" + ex.Message, ex);
            }
        }


        public void Add(AddinsInfo info)
        {
            this.Default.Add(info);
            this.Save();
        }

        public void Delete(AddinsInfo info)
        {
            try
            {
                this.Default.Remove(info);
                this.Save();
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("插件删除失败，请检查,原因：" + ex.Message, ex);
            }
        }
        private List<AddinsInfo> _settingsInfo = new List<AddinsInfo>();
        public List<AddinsInfo> Default { get { return _settingsInfo; } }
    }
    [Serializable]
    public class AddinsInfo
    {
        public string AssemblyName { get; set; }

        public string TaskStarter { get; set; }
        public string SettingInterface { get; set; }

        public string JobInfo { get; set; }

        public string ConfigUI { get; set; }
    }
}
