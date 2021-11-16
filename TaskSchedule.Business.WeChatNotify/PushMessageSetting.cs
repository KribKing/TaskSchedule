using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.PushMessage
{
    public class PushMessageSetting : IJobSettingInterface
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\JobSettingForPushMessage.json");
        public void Save()
        {
            try
            {
                if (Default == null || Default.Count <= 0) return;
                List<JobInfoPushMessage> list = Tools.CloneByJson<List<JobInfoPushMessage>>(Default);
                foreach (JobInfoPushMessage job in list)
                {
                    job.dbstring = EncodeHelper.EncodeBase64(job.dbstring);
                }
                File.WriteAllText(path, JsonConvert.DeserializeObject(JsonConvert.SerializeObject(list)).ToString());
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("消息推送任务配置保存失败，请检查,原因：" + ex.Message, ex);
            }
        }

        public void Init()
        {
            try
            {
                string setting = File.ReadAllText(path);
                List<JobInfoPushMessage> list = JsonConvert.DeserializeObject<List<JobInfoPushMessage>>(setting);
                if (list == null || list.Count <= 0) return;
                foreach (var item in list)
                {
                    item.dbstring = EncodeHelper.DecodeBase64(item.dbstring);
                    item.SettingInterface = this;
                    item.CreatJob();
                    _Default.Add(item);
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("加载消息推送任务配置失败，请检查,原因：" + ex.Message, ex);
            }
        }


        public void Add(JobInfo info)
        {
            Log4netUtil.Warn("作业【" + info.name + "】未实现新增接口");
        }

        public void Delete(JobInfo info)
        {
            Log4netUtil.Warn("作业【" + info.name + "】未实现删除接口");
        }
        private List<JobInfo> _Default = new List<JobInfo>();
        public List<JobInfo> Default
        {
            get
            {
                return _Default;
            }
        }
    }
}
