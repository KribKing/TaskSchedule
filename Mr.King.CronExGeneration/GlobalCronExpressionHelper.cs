using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
namespace Mr.King.CronExGeneration
{
    public class GlobalCronExpressionHelper
    {
        public static string GetExpressionSummary(string strce)
        {
            CronExpression ce = new CronExpression(strce);
            return ce.GetExpressionSummary();
        }
    }
}
