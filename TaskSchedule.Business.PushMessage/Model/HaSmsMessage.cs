using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Business.PushMessage.Model
{

    /// <summary>
    /// 厦门弘爱短信推送消息
    /// </summary>
    [Serializable]
    public class HaSmsMessage
    {
        private List<SendPara> _SendPara = new List<SendPara>();

        public List<SendPara> alermMsgInfo
        {
            get { return _SendPara; }
            set { _SendPara = value; }
        }

    }
    [Serializable]
    public class SendPara
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> recive { get; set; }
      
        private contentMap _contentMap = new contentMap();

        public contentMap contentMap
        {
            get { return _contentMap; }
            set { _contentMap = value; }
        }

        private string _bizType = "HIS";

        public string bizType
        {
            get { return _bizType; }
            set { _bizType = value; }
        }

    }
    [Serializable]
    public class contentMap
    {
        public string content { get; set; }
    }

    [Serializable]
    public class HaResult
    {
        public string code { get; set; }
        public string msg { get; set; }
    }

    public class HaToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }

    }
}
