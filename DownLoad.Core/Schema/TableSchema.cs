using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DownLoad.Core.Schema
{
    [Serializable]
    public class TableSchema
    {
        public string column { get; set; }
        public string maptype { get; set; }
        public string attr { get; set; }
        public string map { get; set; }
        public string relemap { get; set; }
    }
}
