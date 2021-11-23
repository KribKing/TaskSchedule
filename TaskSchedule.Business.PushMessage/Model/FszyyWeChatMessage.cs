using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Business.PushMessage.Model
{
    /// <summary>
    /// 佛山中医院微信推送
    /// </summary>
    public class FszyyWeChatMessage
    {
        public string content { get; set; }
        public string url { get; set; }
        private string _remark="佛山市中医院";

        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _clientId="wx";

        public string clientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public string idNo { get; set; }
        public string idType { get; set; }

    }
    [Serializable]
    public class FszyyWeChatResult
    {
        public string code { get; set; }
        public string msg { get; set; }
    }
}
