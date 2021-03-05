using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DownLoad.Core;

namespace DownLoad.Business
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
                    //strresult = GetStrJsonHelper.GetRetJson(strcode,strsys, strackcode, strackmsg);
                    strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = strcode, TranSys = strsys, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                    Tools.log("返回数据:" + strresult);
                    return strresult;
                }
                else
                {
                    RequestMessage JObj = JsonConvert.DeserializeObject<RequestMessage>(strjson);
                    strcode = JObj.Request.Head.TranCode.ToString().Trim();
                    strsys = JObj.Request.Head.TranSys.ToString().Trim();
                    JkInterface jk = JkFactoryManager.CreateInstance(new JobKey(strcode, strsys));
                    if (jk == null)
                    {
                        strackcode = "200.1";
                        strackmsg = "参数错误:接口代码错误";
                        strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = strcode, TranSys = strsys, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                        Tools.log("返回数据:" + strresult);
                        return strresult;
                    }
                    string jstr = JObj.Request.Body.ToString();
                    ResultInfo info = jk.Run(jstr);
                    strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = strcode, TranSys = strsys, AckCode = info.ackcode, AckMessage = info.ackmsg }, Body = info.body } }.ToString();
                    Tools.log("返回数据:" + strresult);
                    return strresult;
                }
            }
            catch (Exception ex)
            {
                strackcode = "300.1";
                strackmsg = ex.Message;
                strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = strcode, TranSys = strsys, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                Tools.log("返回数据:" + strresult);
                return strresult;
            }
        }
    }
}
