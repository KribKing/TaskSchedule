using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.CloudHis
{
    public class CloudHisSetting : IJobSettingInterface<JobInfo>
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\JobSettingForCloudHis.json");
        public void Save()
        {
            try
            {
                if (Default == null || Default.Count <= 0) return;
                List<JobInfoCloudHis> list = Tools.CloneByJson<List<JobInfoCloudHis>>(Default);
                foreach (JobInfoCloudHis job in list)
                {
                    job.createtmp = EncodeHelper.EncodeBase64(job.createtmp);
                    job.targetsql = EncodeHelper.EncodeBase64(job.targetsql);
                    job.targetdbstring = EncodeAndDecode.Encode(job.targetdbstring);
                    job.requestxml = EncodeHelper.EncodeBase64(job.requestxml);
                }
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
                List<JobInfoCloudHis> list = JsonConvert.DeserializeObject<List<JobInfoCloudHis>>(setting);
                if (list == null || list.Count <= 0) return;
                foreach (JobInfoCloudHis job in list)
                {
                    job.createtmp = EncodeHelper.DecodeBase64(job.createtmp);
                    job.targetsql = EncodeHelper.DecodeBase64(job.targetsql);
                    job.targetdbstring = EncodeAndDecode.Decode(job.targetdbstring);
                    job.requestxml = EncodeHelper.DecodeBase64(job.requestxml);
                    job.SettingInterface = this;
                    job.CreatJob();
                    _Default.Add(job);
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("加载定时同步任务配置失败，请检查,原因：" + ex.Message, ex);
            }
        }


        public void Add(JobInfo info)
        {
            this.Default.Add(info);
        }

        public void Delete(JobInfo info)
        {
            string name = info.name;
            try
            {
                this.Default.Remove(info);
                this.Save();
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + name + "】删除失败，请检查,原因：" + ex.Message, ex);
            }
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
