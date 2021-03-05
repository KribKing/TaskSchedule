using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownLoad.Core
{
    public class ResultInfo
    {
        private bool _ackflg=false;

        public bool ackflg
        {
            get { return _ackflg; }
            set { _ackflg = value; }
        }
        private string _ackcode="100.0";

        public string ackcode
        {
            get { return _ackcode; }
            set { _ackcode = value; }
        }

        private string _ackmsg;

        public string ackmsg
        {
            get { return _ackmsg; }
            set { _ackmsg = value; }
        }
        private string _body="[]";

        public string body
        {
            get { return _body; }
            set { _body = value; }
        }

    }
}
