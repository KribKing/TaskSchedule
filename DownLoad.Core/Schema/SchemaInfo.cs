using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownLoad.Core.Schema
{
    [Serializable]
    public class SchemaInfo
    {
        public List<TableSchema> TableSchema { get; set; }
        public OperationSchema OperationSchema { get; set; }
    }
}
