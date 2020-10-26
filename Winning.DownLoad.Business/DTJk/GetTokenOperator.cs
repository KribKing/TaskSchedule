using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business.DTJk
{
    public class GetTokenOperator : JkInterface
    {
        public GetTokenOperator(string jkcode,string url)
            : base(jkcode,url, "getAccessToken", "")
        {

        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            ResultInfo retInfo = new ResultInfo();
            try
            {
                string uid = (jobj["uid"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                string appSecret = (jobj["appSecret"] ?? DateTime.Now.ToString("yyyy-MM-dd")).ToString();
                body = string.Format("?uid={0}&appSecret={1}", uid, appSecret);
                retInfo = base.GetResponse();
                if (retInfo.ackflg)
                {
                    DTToken token = JsonConvert.DeserializeObject<DTToken>(retInfo.ackmsg);
                    if (token.success)
                    {
                        JkInterface.TokenInfo = token;
                        retInfo.ackcode = "100.1";
                        retInfo.ackmsg = "获取token成功{access_token:" + token.access_token + "}";
                    }
                    else
                    {
                        retInfo.ackcode = "200.1";
                        retInfo.ackmsg = token.msg;
                        retInfo.ackflg = false;
                    }

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
