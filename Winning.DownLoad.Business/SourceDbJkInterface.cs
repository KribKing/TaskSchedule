using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public class SourceDbJkInterface : JkInterface
    {
        public SourceDbJkInterface(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = this.cur_JobInfo.TargetSql;
                string connstring = this.cur_JobInfo.IsSourceDbEncode ? EncodeAndDecode.Decode(this.cur_JobInfo.SourceDbString) : this.cur_JobInfo.SourceDbString;
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.cur_JobInfo.SourceDbType, connstring, this.cur_JobInfo.SourceSql);
                base.ExcuteDataBaseBulk(dt, ref retInfo);
            }
            catch (Exception ex)
            {
                retInfo.ackcode = "300.1";
                retInfo.ackmsg = ex.Message;
                retInfo.ackflg = false;
            }
            return retInfo;
        }
    }
}
