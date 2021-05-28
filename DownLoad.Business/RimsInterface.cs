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
            string trancode = "", tranname = "", transys = "", transysname = "";
            try
            {
                Log4netUtil.Info("原始数据:" + strjson);
                if (string.IsNullOrWhiteSpace(strjson))
                {
                    strackcode = "200.1";
                    strackmsg = "参数错误:参数为空";
                    strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = trancode, TranName = tranname, TranSys = transys, TranSysName = transysname, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                }
                else
                {
                    RequestMessage JObj = JsonConvert.DeserializeObject<RequestMessage>(strjson);
                    trancode = JObj.Request.Head.TranCode.ToString().Trim();
                    tranname = JObj.Request.Head.TranCode.ToString().Trim();
                    transys = JObj.Request.Head.TranSys.ToString().Trim();
                    transysname = JObj.Request.Head.TranSys.ToString().Trim();
                    JkInterface jk = JkFactoryManager.CreateInstance(new JobKey(trancode, transys));
                    if (jk == null)
                    {
                        strackcode = "200.1";
                        strackmsg = "参数错误:接口代码错误";
                        strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = trancode, TranName = tranname, TranSys = transys, TranSysName = transysname, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                    }
                    else
                    {
                        string jstr = JObj.Request.Body.ToString();
                        ResultInfo info = jk.Run(jstr);
                        strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = trancode, TranName = tranname, TranSys = transys, TranSysName = transysname, AckCode = info.ackcode, AckMessage = info.ackmsg }, Body = info.body } }.ToString();
                    }
                }
                Log4netUtil.Info("返回数据:" + strresult);
                return strresult;
            }
            catch (Exception ex)
            {
                strackcode = "300.1";
                strackmsg = ex.Message;
                strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { TranCode = trancode, TranName = tranname, TranSys = transys, TranSysName = transysname, AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
                Log4netUtil.Error("返回数据:" + strresult);
                return strresult;
            }
        }
    }
}
