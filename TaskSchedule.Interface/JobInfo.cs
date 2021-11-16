using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Core;

namespace TaskSchedule.Interface
{
    public delegate void JobInfoChanged(JobInfoOp OpType,JobInfo info);
    [Serializable]
    public class JobInfo
    {
        public event JobInfoChanged onJobInfoChanged;
        private Guid _guid;
        public Guid GuId
        {
            get
            {
                if (_guid == new Guid() || string.IsNullOrEmpty(_guid.ToString()))
                {
                    _guid = Guid.NewGuid();
                }
                return _guid;
            }
            set { _guid = value; }
        }

        /// <summary>
        /// 作业ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 作业名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 作业大类
        /// </summary>
        public string system { get; set; }
        /// <summary>
        /// 作业大类名称
        /// </summary>
        public string sysname { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string memo { get; set; }
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
        [Newtonsoft.Json.JsonIgnore]
        public ITaskStarterInterface TaskStarter { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public IJobSettingInterface SettingInterface { get; set; }
        public void CreatJob()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.CreatJob(this);
        }
        private void RefreshTrigger()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.RefreshTrigger(this);
        }

        private void RefreshJlzt()
        {
            GlobalInstanceManager<SchedulerManager>.Intance.RefreshJlzt(this);
        }


        public virtual void Run()
        {
            try
            {
                IRunInterface irun = this.TaskStarter.CreateInstance(this);
                if (irun == null)
                {
                    Log4netUtil.Warn("作业【" + this.name + "】未找到对应的执行接口");
                    return;
                }
                Log4netUtil.Debug("作业【" + this.name + "】开始执行");
                irun.Run();
                Tools.FlushMemory();
                Log4netUtil.Debug("作业【" + this.name + "】执行结束");
            }
            catch (Exception ex)
            {
                Tools.FlushMemory();
                Log4netUtil.Error("作业【" + this.name + "】执行发生异常"+ex.Message,ex);
            }
        }
        public virtual string GetExcuteCondition()
        {
            return "";
        }
        public virtual Form Config()
        {
            return null;
        }
        public virtual void Add()
        {
            if(GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Keys.ToList().Exists(a=>a==GuId))return;
            this.SettingInterface.Add(this);
            GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Add(GuId, this);
            this.CreatJob();
            if (onJobInfoChanged != null)
                onJobInfoChanged(JobInfoOp.Add,this);
        }
        public virtual JobInfo Create()
        {
            Log4netUtil.Warn("请注意，未发现新增接口");
            return null;
        }
        public virtual JobInfo Copy()
        {
            Log4netUtil.Warn("请注意，作业【" + name + "】未实现复制接口");
            return null;
        }
        public void Save()
        {
            if (SettingInterface != null)
                SettingInterface.Save();
        }

        public void Delete()
        {
            GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic.Remove(GuId);
            GlobalInstanceManager<SchedulerManager>.Intance.DeleteJob(this);
            if (SettingInterface != null)
                SettingInterface.Delete(this);
            if (onJobInfoChanged != null)
                onJobInfoChanged(JobInfoOp.Delete,this);
        }
    }

    public enum JobInfoOp
    {
        Add,
        Delete
    }

}
