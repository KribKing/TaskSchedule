using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class RimsInterface
    {
        public string Run(string strjson)
        {
            string strresult = "";
            string strackcode = "";
            string strackmsg = "";
            string strcode = "";
            string strsys = "";
            try
            {
                Tools.log("原始数据:" + strjson);
                if (string.IsNullOrWhiteSpace(strjson))
                {
                    strackcode = "200.1";
                    strackmsg = "参数错误:参数为空";
                    strresult = GetStrJsonHelper.GetRetJson(strcode,strsys, strackcode, strackmsg);
                    Tools.log("返回数据:" + strresult);
                    return strresult;
                }
                else
                {
                    JObject JObj = (JObject)JsonConvert.DeserializeObject(strjson);
                    strcode = (JObj["Request"]["Head"]["TranCode"] ?? "").ToString().Trim();
                    strsys = (JObj["Request"]["Head"]["TranSys"] ?? "").ToString().Trim();                 
                    JkInterface jk = JkFactoryManager.CreateInstance(new JobKey(strcode,strsys));
                    if (jk == null)
                    {
                        strackcode = "200.1";
                        strackmsg = "参数错误:接口代码错误";
                        strresult = GetStrJsonHelper.GetRetJson(strcode,strsys, strackcode, strackmsg);
                        Tools.log("返回数据:" + strresult);
                        return strresult;
                    }
                    JObj = (JObject)JsonConvert.DeserializeObject(JObj["Request"]["Body"].ToString());
                    ResultInfo info = jk.Run(JObj);
                    strresult = GetStrJsonHelper.GetRetJson(strcode,strsys, info.ackcode, info.ackmsg, info.body);
                    Tools.log("返回数据:" + strresult);
                    return strresult;
                }
            }
            catch (Exception ex)
            {
                strackcode = "300.1";
                strackmsg = ex.Message;
                strresult = GetStrJsonHelper.GetRetJson(strcode, strsys, strackcode, strackmsg);
                Tools.log("返回数据:" + strresult);
                return strresult;
            }
        }
    }
}
