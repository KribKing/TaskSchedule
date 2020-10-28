using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
namespace Mr.King.CronExGeneration
{
    public class GlobalCronExpressionHelper
    {
        /// <summary>
        /// Cron表达式转换成中文描述
        /// </summary>
        /// <param name="cronExp"></param>
        /// <returns></returns>
        public static string TranslateToChinese(string cronExp)
        {
            if (cronExp == null || cronExp.Length < 1)
            {
                return "cron表达式为空";
            }
            string[] tmpCorns = cronExp.Split(' ');
            StringBuilder sBuffer = new StringBuilder();
            if (tmpCorns.Length == 7)
            {
                //解析年
                if (!tmpCorns[6].Equals("*"))
                {

                    sBuffer.Append(tmpCorns[6]).Append("");
                }
                else
                {
                    sBuffer.Append("每年");
                }
                //解析月
                if (!tmpCorns[4].Equals("*"))
                {
                    sBuffer.Append(tmpCorns[4]).Append("月");
                }
                else
                {
                    sBuffer.Append("每月");
                }
                //解析周
                if (!tmpCorns[5].Equals("*") && !tmpCorns[5].Equals("?"))
                {
                    char[] tmpArray = tmpCorns[5].ToCharArray();
                    foreach (char tmp in tmpArray)
                    {
                        switch (tmp)
                        {
                            case '1':
                                sBuffer.Append("星期天");
                                break;
                            case '2':
                                sBuffer.Append("星期一");
                                break;
                            case '3':
                                sBuffer.Append("星期二");
                                break;
                            case '4':
                                sBuffer.Append("星期三");
                                break;
                            case '5':
                                sBuffer.Append("星期四");
                                break;
                            case '6':
                                sBuffer.Append("星期五");
                                break;
                            case '7':
                                sBuffer.Append("星期六");
                                break;
                            case '-':
                                sBuffer.Append("至");
                                break;
                            default:
                                sBuffer.Append(tmp);
                                break;
                        }
                    }
                }

                //解析日
                if (!tmpCorns[3].Equals("?"))
                {
                    if (!tmpCorns[3].Equals("*"))
                    {
                        sBuffer.Append(tmpCorns[3]).Append("日");
                    }
                    else
                    {
                        sBuffer.Append("每日");
                    }
                }

                //解析时
                if (!tmpCorns[2].Equals("*"))
                {
                    sBuffer.Append(tmpCorns[2]).Append("时");
                }
                else
                {
                    sBuffer.Append("每时");
                }

                //解析分
                if (!tmpCorns[1].Equals("*"))
                {
                    sBuffer.Append(tmpCorns[1]).Append("分");
                }
                else
                {
                    sBuffer.Append("每分");
                }

                //解析秒
                if (!tmpCorns[0].Equals("*"))
                {
                    sBuffer.Append(tmpCorns[0]).Append("秒");
                }
                else
                {
                    sBuffer.Append("每秒");
                }

            }
            sBuffer.Append("执行一次");
            return sBuffer.ToString();
        }


        //public static DateTime GetNextDateTime(string cronExp)
        //{
        //    //CronExpression.ValidateExpression
        //}

    }
}
