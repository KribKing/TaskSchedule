using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            try
            {
                if (Tools.islog)
                {
                    Tools.log("原始数据:" + strjson);
                }
                if (string.IsNullOrWhiteSpace(strjson))
                {
                    strackcode = "200.1";
                    strackmsg = "参数错误:参数为空";
                    strresult = GetStrJsonHelper.GetRetJson(strcode,strackcode, strackmsg);
                    if (Tools.islog)
                    {
                        Tools.log("返回数据:" + strresult);
                    }
                    return strresult;
                }
                else
                {
                    JObject JObj = (JObject)JsonConvert.DeserializeObject(strjson);
                    strcode = (JObj["Request"]["Head"]["TranCode"] ?? "").ToString().Trim();
                    //string weburl = (JObj["Request"]["Head"]["WebUrl"] ?? "").ToString().Trim();
                    JkInterface jk = JkFactoryManager.CreateInstance(strcode);
                    if (jk == null)
                    {
                        strackcode = "200.1";
                        strackmsg = "参数错误:接口代码错误";
                        strresult = GetStrJsonHelper.GetRetJson(strcode,strackcode, strackmsg);
                        if (Tools.islog)
                        {
                            Tools.log("返回数据:" + strresult);
                        }
                        return strresult;
                    }
                    JObj = (JObject)JsonConvert.DeserializeObject(JObj["Request"]["Body"].ToString());

                    ResultInfo info = jk.Run(strcode, JObj);
                    strresult = GetStrJsonHelper.GetRetJson(strcode,info.ackcode, info.ackmsg,info.body);
                    if (Tools.islog)
                    {
                        Tools.log("返回数据:" + strresult);
                    }
                    return strresult;
                }
            }
            catch (Exception ex)
            {
                strackcode = "300.1";
                strackmsg = ex.Message;
                strresult = GetStrJsonHelper.GetRetJson(strcode,strackcode, strackmsg);
                if (Tools.islog)
                {
                    Tools.log("返回数据:" + strresult);
                }
                return strresult;
            }
        }
    }
}
