using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.DownLoad.Business.RimsJk;
using Winning.DownLoad.Business.WnDataJk;
using Winning.DownLoad.Core;

namespace Winning.DownLoad.Business
{
    public class JkFactoryManager
    {
        public static JkInterface CreateInstance(string jkcode)
        {
            string strurl=GlobalInstanceManager<JobInfoManager>.Intance.JobInfoDic[jkcode.ToLower()].weburl;
                     
            #region 卫宁数据接口
            if (jkcode.ToLower() == "wndata00")//卫宁数据-获取医院信息
            {
                return new WnDataHospitalOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata01")//卫宁数据-获取科室信息
            {
                return new WnDataKsOperator(jkcode.ToLower(), strurl);

            }
            else if (jkcode.ToLower() == "wndata02")//卫宁数据-获取人员信息
            {
                return new WnDataZgOperator(jkcode.ToLower(), strurl);

            }
            else if (jkcode.ToLower() == "wndata03")//卫宁数据-获取病区信息
            {
                return new WnDataBqbmkOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata04")//卫宁数据-获取收费项目信息
            {
                return new WnDataSfxmOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata05")//卫宁数据-获取临床项目信息
            {
                return new WnDataLcxmOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata06")//卫宁数据-获取临床收费项目对应信息
            {
                return new WnDataLcxmdyOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata07")//卫宁数据-获取诊断基础信息
            {
                return new WnDataZddmkOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata08")//卫宁数据-获取患者基本信息
            {
                return new WnDataPatOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata09")//卫宁数据-获取患者就诊信息
            {
                return new WnDataBrlistOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata10")//卫宁数据获取患者项目信息
            {
                return new WnDataXmlistOperator(jkcode.ToLower(), strurl);
            }
            else if (jkcode.ToLower() == "wndata11")//卫宁数据获取患者诊断信息
            {
                return new WnDataBrzdqkOperator(jkcode.ToLower(), strurl);
            } 
            #endregion
            #region 康复业务
            else if (jkcode.ToLower() == "rims00")//康复业务-定时清理作业记录
            {
                return new RimsClearHistoryOperator(jkcode.ToLower(), strurl);
            } 
            #endregion
            else
            {
                return null;
            }
        }
    }
}
