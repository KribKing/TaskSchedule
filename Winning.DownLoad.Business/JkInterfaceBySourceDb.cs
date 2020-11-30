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
    public class JkInterfaceBySourceDb : JkInterface
    {
        public JkInterfaceBySourceDb(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string strsql = this.cur_JobInfo.targetsql;
                string connstring = this.cur_JobInfo.issourcedbencode ? EncodeAndDecode.Decode(this.cur_JobInfo.sourcedbstring) : this.cur_JobInfo.sourcedbstring;
                DataTable dt = GlobalInstanceManager<GlobalSqlManager>.Intance.GetDataTable(this.cur_JobInfo.sourcedbtype, connstring, this.cur_JobInfo.sourcesql);
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
