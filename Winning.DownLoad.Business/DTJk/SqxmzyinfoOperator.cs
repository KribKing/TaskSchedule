using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.DTModel;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class SqxmzyinfoOperator : SqxminfoOperator
    {
        public SqxmzyinfoOperator(string jkcode, string url, string cur_method, string cur_body)
            : base(jkcode,url,cur_method, cur_body)
        {
           
        }
        public override ResultInfo Run(string jkcode, Newtonsoft.Json.Linq.JObject jobj)
        {
            return base.GetResult(jkcode, jobj);
        }
    }
}
