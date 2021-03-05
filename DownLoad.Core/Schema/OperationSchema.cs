using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownLoad.Core.Schema
{
    [Serializable]
    public class OperationSchema
    {
        public string CreateTmp { get; set; }

        public string TmpName { get; set; }

        public string OpSql { get; set; }
        public int SqlType { get; set; }
        public string ConnectStr { get; set; }
    }
}
