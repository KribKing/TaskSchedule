using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownLoad.Business
{
    [Serializable]
    public class ResponseMessage
    {
        public Response Response { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    [Serializable]
    public class Response
    {
        public Head Head { get; set; }
        private string _Body="[]";

        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
    }
    [Serializable]
    public class Head
    {
        private string _Version="1.1";

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        private string _TranCode;

        public string TranCode
        {
            get { return _TranCode; }
            set { _TranCode = value; }
        }
        private string _TranName;

        public string TranName
        {
            get { return _TranName; }
            set { _TranName = value; }
        }
        private string _TranSys;

        public string TranSys
        {
            get { return _TranSys; }
            set { _TranSys = value; }
        }
        private string _TranSysName;

        public string TranSysName
        {
            get { return _TranSysName; }
            set { _TranSysName = value; }
        }
        private string _AckCode;

        public string AckCode
        {
            get { return _AckCode; }
            set { _AckCode = value; }
        }
        private string _AckMessage;

        public string AckMessage
        {
            get { return _AckMessage; }
            set { _AckMessage = value; }
        }
        private string _ContentType = "text/json";

        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }
        private string _AppId="RIMS";

        public string AppId
        {
            get { return _AppId; }
            set { _AppId = value; }
        }    
        private string _MessageId=Guid.NewGuid().ToString();

        public string MessageId
        {
            get { return _MessageId; }
            set { _MessageId = value; }
        }

    }
}
