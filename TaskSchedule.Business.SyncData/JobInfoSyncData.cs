﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSchedule.Core;
using TaskSchedule.Core.Schema;
using TaskSchedule.Interface;

namespace TaskSchedule.Business.SyncData
{
    [Serializable]
    public class JobInfoSyncData : JobInfo
    {
        /// <summary>
        /// 创建临时表脚本
        /// </summary>
        public string createtmp { get; set; }
        /// <summary>
        /// 临时表名
        /// </summary>
        public string tmpname { get; set; }
        /// <summary>
        /// 解析数据类型 0：json 1：xml
        /// </summary>
        public int nodelx { get; set; }
        /// <summary>
        /// 解析节点
        /// </summary>
        public string node { get; set; }
        /// <summary>
        /// xml解析配置
        /// </summary>
        public string xmlconfig { get; set; }
        /// <summary>
        /// 数据源类型 0:服务 1:数据库
        /// </summary>
        public int sourcetype { get; set; }
        /// <summary>
        /// 源数据库类型
        /// </summary>
        public int sourcedbtype { get; set; }
        /// <summary>
        /// 源数据库地址
        /// </summary>
        public string sourcedbstring { get; set; }
        /// <summary>
        /// 数据源脚本
        /// </summary>
        public string sourcesql { get; set; }
        /// <summary>
        /// 目标数据库类型
        /// </summary>
        public int targetdbtype { get; set; }
        /// <summary>
        /// 目标数据库地址
        /// </summary>
        public string targetdbstring { get; set; }
        /// <summary>
        /// 目标库脚本
        /// </summary>
        public string targetsql { get; set; }
        /// <summary>
        /// 是否批量操作
        /// </summary>
        public bool isbulkop { get; set; }
        /// <summary>
        /// 服务类型 0:http 1:ws 2:rest
        /// </summary>
        public int servertype { get; set; }
        /// <summary>
        /// 服务方法
        /// </summary>
        public string servermethod { get; set; }
        /// <summary>
        /// web地址
        /// </summary>
        public string weburl { get; set; }
        /// <summary>
        /// 条件数据库类型
        /// </summary>
        public int tjdbtype { get; set; }
        /// <summary>
        /// 条件数据库地址
        /// </summary>
        public string tjdbconnect { get; set; }

        public override string GetExcuteCondition()
        {
            string strexcute = "";
            try
            {
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(tjdbtype, tjdbconnect, "exec usp_jk_getjobzxtj @id='" + id + "',@system='" + system + "'");
                strexcute = dt == null || dt.Rows.Count <= 0 ? "" : dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Log4netUtil.Error("作业【" + name + "】执行条件获取异常:" + ex.Message, ex);
                strexcute = "";
            }
            return strexcute;
        }
        public override JobInfo Create()
        {
            return new JobInfoSyncData()
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
            JobInfoSyncData newinfo = Tools.CloneByJson<JobInfoSyncData>(this);
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
            DataTable dt = new DataTable();
            if (this.sourcetype == 0)
            {
                if (this.nodelx == 0)
                {
                    dt = ((RunInterface)this.TaskStarter.CreateInstance(this)).GetTmpTable();
                    Tools.FlushMemory();
                }
                else if (this.nodelx == 1)
                {
                    SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(this.xmlconfig);
                    if (info == null) return;
                    dt = info.ToDt();
                }
            }
            else if (this.sourcetype == 1)
            {
                dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.sourcedbtype, this.sourcedbstring, this.sourcesql);
            }
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

        public override string ToString()
        {
            return "同步数据作业";
        }
    }
}
