using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSchedule.Core;

namespace TaskSchedule.Business.JobManager
{
    [Serializable]
    public class JobNewInfo
    {
        public Job job { get; set; }
    }
    [Serializable]
    public class Job
    {
        public BaseSetting basetting { get; set; }
        public SourceSetting sourcesetting { get; set; }
        public TargetSetting targetsetting { get; set; }
    }
    [Serializable]
    public class BaseSetting
    {
        public string id { get; set; }
        public string name { get; set; }
        public string system { get; set; }
        public string sysname { get; set; }
        private string _expression;
        /// <summary>
        /// 表达式
        /// </summary>
        public string expression
        {
            get
            {
                return _expression;
            }
            set
            {
                if (_expression == null)
                {
                    _expression = value;
                }
                else
                {
                    string oldexp = _expression;
                    if (oldexp != value && !string.IsNullOrWhiteSpace(value))
                    {
                        _expression = value;
                        if (jlzt == "0" && !string.IsNullOrWhiteSpace(this.id))
                        {
                            this.RefreshTrigger();
                        }
                    }
                }

            }
        }
        private string _jlzt = "0";
        /// <summary>
        /// 记录状态 0：执行 1：停止
        /// </summary>
        public string jlzt
        {
            get
            {
                return _jlzt;
            }
            set
            {
                if (_jlzt == null)
                {
                    _jlzt = value;
                }
                else
                {
                    string old = _jlzt;
                    if (old != value && !string.IsNullOrWhiteSpace(value))
                    {
                        _jlzt = value;
                        if (!string.IsNullOrWhiteSpace(this.id))
                        {
                            this.RefreshJlzt();
                        }
                    }
                }

            }
        }
        public void CreatJob()
        {
            //GlobalInstanceManager<SchedulerManager>.Intance.CreatJob(this);
        }
        private void RefreshTrigger()
        {
            //GlobalInstanceManager<SchedulerManager>.Intance.RefreshTrigger(this);
        }

        private void RefreshJlzt()
        {
            //GlobalInstanceManager<SchedulerManager>.Intance.RefreshJlzt(this);
        }
    }
    [Serializable]
    public class SourceSetting
    {
        public BaseSetting basetting { get; set; }
        public SourceSetting sourcesetting { get; set; }
        public TargetSetting targetsetting { get; set; }
    }
    [Serializable]
    public class TargetSetting
    {
        public BaseSetting basetting { get; set; }
        public SourceSetting sourcesetting { get; set; }
        public TargetSetting targetsetting { get; set; }
    }
}
