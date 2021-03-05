using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using DownLoad.Core;

namespace DownLoad.Business
{
    /// <summary>
    /// Web服务Json接口
    /// </summary>
    public class JkInterfaceByHttp : JkInterface
    {
        public JkInterfaceByHttp(JobInfo jkinfo)
            : base(jkinfo, "", "")
        {

        }
        public override ResultInfo Run(string jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                base.body = jobj;
                if (this.cur_JobInfo.servermethod.ToLower() == "get")
                {
                    retInfo = base.GetResponse();
                }
                else
                {
                    retInfo = base.PostResponse();
                }
                if (retInfo.ackflg)
                {
                    DataTable dt = null;
                    if (this.cur_JobInfo.nodelx == 0)
                    {
                        string jarray = Tools.GetJsonNodeValue(retInfo.body, this.cur_JobInfo.node, "[]").ToString();
                        dt = Tools.JsonToDataTable(jarray);
                    }
                    else if (this.cur_JobInfo.nodelx == 1)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(retInfo.body);
                        XmlNode node = XmlHelper.GetNode(this.cur_JobInfo.node, xml);
                        dt = XmlHelper.XmlToDataTable(this.cur_JobInfo.xmlconfig, node);
                    }

                    base.ExcuteDataBaseBulk(dt, ref retInfo);
                }
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
