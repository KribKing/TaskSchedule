using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Winning.DownLoad.Business;
using Winning.DownLoad.Core;

namespace Winning.Interface.DTWebApi.Controllers
{
    public class RimsController : ApiController
    {
        [HttpPost]
        public JObject RIMSInterface([FromBody]JObject JObj)
        {
            string strresult;
            try
            {
                string strjson = JObj.ToString();
                strresult = new RimsInterface().Run(strjson);
            }
            catch (Exception ex)
            {
                string strackcode = "300.1";
                string strackmsg = ex.Message;
                //strresult = GetStrJsonHelper.GetRetJson(strackcode, strackmsg);
                strresult = new ResponseMessage() { Response = new Response() { Head = new Head() { AckCode = strackcode, AckMessage = strackmsg } } }.ToString();
            }
            return (JObject)JsonConvert.DeserializeObject(strresult);
        }

    }
}
