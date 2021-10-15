using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Core
{
    public class GetStrJsonHelper
    {
        /// <summary>
        /// 获取返回的JSON串
        /// </summary>
        /// <param name="strAckCode"></param>
        /// <param name="strAckMsg"></param>
        /// <returns></returns>
        public static string GetRetJson(string trancode,string transys,string strAckCode, string strAckMsg, string result = "[]")
        {
            string strresult = "";
            strresult = "{"
                + "\"Response\": {"
                    + "\"Head\": {"
                        + "\"Version\": \"1.1\","
                        + "\"TranCode\": \"" + trancode + "\","
                        + "\"TranSys\": \"" + transys + "\","
                        + "\"AckCode\": \"" + strAckCode + "\","
                        + "\"AckMessage\": \"" + strAckMsg + "\","
                        + "\"ContentType\": \"text/json\","
                        + "\"AppId\": \"RIMS\","
                        + "\"MessageId\": \"" + Guid.NewGuid() + "\""
                    + "},"
                    + "\"Body\":" + result
                 + "}"
               + "}";
            return strresult;
        }

        /// <summary>
        /// 获取请求的JSON串
        /// </summary>
        /// <param name="strAckCode"></param>
        /// <param name="strAckMsg"></param>
        /// <returns></returns>
        public static string GetReqJson(string TranCode,string TranSys, string strAckMsg, string result = "[]")
        {
            if (string.IsNullOrEmpty(result))
            {
                result = "{}";
            }
            string strresult = "";
            strresult = "{"
                        + "\"Request\":"
                            + "{"
                             + "\"Head\":"
                                + "{"
                                    + "\"AppId\":\"RIMS\","
                                    + "\"AppType\":\"WebApi\","
                                    + "\"LicKey\":\"\","
                                    + "\"MessageId\":\"" + Guid.NewGuid().ToString() + "\","
                                    + "\"OrgId\":\"\","
                                    + "\"SecurityContent\":\"\","
                                    + "\"SecurityPolicy\":\"\","
                                    + "\"Timestamp\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\","
                                    + "\"TranCode\":\"" + TranCode + "\","
                                    + "\"TranSys\":\"" + TranSys + "\","
                                    + "\"AckMsg\":\"" + strAckMsg + "\","
                                    + "\"TransferType\":\"\","
                                    + "\"Version\":\"1.1.5\""
                                + "},"
                             + "\"Body\":" + result
                            + "}"
                       + "}";
            return strresult;
        }
    }
}
