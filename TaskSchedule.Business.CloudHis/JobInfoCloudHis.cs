using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TaskSchedule.Core;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.CloudHis
{
    [Serializable]
    public class JobInfoCloudHis : JobInfo
    {
        public string weburl { get; set; }
        public bool isencode { get;  set; }
        public string CloudUserId { get;  set; }
        public string CloudUserPassword { get;  set; }
        public string requestxml { get;  set; }
        public string businesscode { get;  set; }
        public string businesstable { get;  set; }
        public string targetdbstring { get;  set; }
        public string createtmp { get;  set; }
        public string tmpname { get; set; }
        public string targetsql { get;  set; }
        public string Key { get; set; }

        public override JobInfo Create()
        {
            return new JobInfoCloudHis()
            {
                system = system,
                sysname = sysname,
                jlzt = "0",
                TaskStarter = TaskStarter,
                SettingInterface = SettingInterface,
                AddinsInfo = AddinsInfo
            };
        }
        public override JobInfo Copy()
        {
            JobInfoCloudHis newinfo = Tools.CloneByJson<JobInfoCloudHis>(this);
            newinfo.GuId = Guid.NewGuid();
            newinfo.id = "";
            newinfo.jlzt = "1";
            newinfo.TaskStarter = TaskStarter;
            newinfo.SettingInterface = SettingInterface;
            newinfo.AddinsInfo = AddinsInfo;
            return newinfo;
        }
        public override void SetTmpTableSchema()
        {
            try
            {
                DataTable dt = ((RunInterface)this.TaskStarter.CreateInstance(this)).GetTmpTable();
                Tools.FlushMemory();
                if (dt != null)
                {
                    string strtmp = "create table " + this.tmpname + Environment.NewLine + "(" + Environment.NewLine;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        strtmp += "   " + dc.ColumnName + "   varchar(256) null," + Environment.NewLine;
                    }
                    strtmp = strtmp.Remove(strtmp.LastIndexOf(','), 1);
                    strtmp += ")";
                    this.createtmp = strtmp;
                }
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + this.name + "】创建临时表发生异常：" + ex.Message, ex);
            }
        }
        public override string ToString()
        {
            return "云His作业";
        }
    }
}
