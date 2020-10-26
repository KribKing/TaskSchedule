using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Core
{
    public class TSqlHelper
    {
        private static string contr_rims = "";
        private static string contr_common = "";
        public static void Init(string strrims, string srcom)
        {
            contr_rims = EncodeAndDecode.Decode(strrims);
            contr_common = EncodeAndDecode.Decode(srcom);
        }
        public static int ExecuteNonQueryByRims(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(contr_rims, sqlText, parameters);
        }
        public static int ExecuteNonQueryByCommon(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(contr_common, sqlText, parameters);
        }
        public static int ExecuteNonQuery(string connstr, string sqlText, params SqlParameter[] parameters)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();　　//打开数据库
                        cmd.CommandText = sqlText;　　//对CommandText进行赋值
                        cmd.Parameters.AddRange(parameters);　　//对数据库使用参数进行赋值
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                GC.Collect();
            }
        }
        public static object ExecuteScalarByRims(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteScalar(contr_rims, sqlText, parameters);
        }
        public static object ExecuteScalarByCommon(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteScalar(contr_common, sqlText, parameters);
        }
        public static object ExecuteScalar(string connstr, string sqlText, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = sqlText;
                        cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ExecuteDataTableByRims(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteDataTable(contr_rims, sqlText, parameters);
        }
        public static DataTable ExecuteDataTableByCommon(string sqlText, params SqlParameter[] parameters)
        {
            return ExecuteDataTable(contr_common, sqlText, parameters);
        }
        public static DataTable ExecuteDataTable(string connstr, string sqlText, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connstr))
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        private static dynamic GetCreateTableSql(DataTable table, string tmptableName, string tableName)
        {
            var colList = new List<string>();
            var fieldNames = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                fieldNames.Add(col.ColumnName);
            }

            var sql = string.Format(@" if object_id('{0}') is not null begin drop table {0} end 
                select top 0 {1} into {0} from {2};
                    ", tmptableName, string.Join(",", fieldNames), tableName);

            return new { Sql = sql, Fields = fieldNames };
        }
        public static ResultInfo SqlBulkCopyByRims(string createtmp, string tmpname, DataTable table, string strSql,ref ResultInfo retInfo)
        {
            return SqlBulkCopy(contr_rims, createtmp, tmpname, strSql, table, ref retInfo);
        }
        public static ResultInfo SqlBulkCopyByComm(string createtmp, string tmpname, DataTable table, string strSql, ref ResultInfo retInfo)
        {
            return SqlBulkCopy(contr_common, createtmp, tmpname, strSql, table,ref retInfo);
        }
        public static ResultInfo SqlBulkCopy(string connectionString, string creatTmp, string tmpname, string strSql, DataTable table, ref ResultInfo retInfo)
        {       
            bool isSucc = false;
            //var tmpTableName = "tmp_" + tableName;
            try
            {
                #region 1.创建临时表
                //var filedObj = GetCreateTableSql(table, tmpTableName, tableName);
                //ExecuteNonQuery(connectionString, creatTmp);
                string strtmpsql = "";
                if (!string.IsNullOrEmpty(creatTmp))
                {
                    strtmpsql = creatTmp;
                }
                else
                {
                    strtmpsql = "truncate table " + tmpname;
                }
                ExecuteNonQuery(connectionString, strtmpsql);
                #endregion
                //LogHandler("新建临时表"+ tmpTableName+ "成功....");

                #region 2.将数据使用sqlbulk导入到临时表
                //开始数据保存逻辑

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();//开启事务
                    //在插入数据的同时检查约束，如果发生错误调用sqlbulkTransaction事务
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, tran);
                    bulkCopy.DestinationTableName = tmpname;//代表要插入数据的表名
                    foreach (DataColumn dc in table.Columns)  //传入上述table
                    {
                        bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);//将table中的列与数据库表这的列一一对应
                    }
                    try
                    {
                        bulkCopy.WriteToServer(table);
                        tran.Commit();
                        isSucc = true;
                    }
                    catch (Exception ex)
                    {

                        tran.Rollback();
                        retInfo.ackcode = "300.2";
                        retInfo.ackflg = false;
                        retInfo.ackmsg = "histoTmp" + ex.Message;
                        return retInfo;
                    }
                    finally
                    {
                        bulkCopy.Close();
                        conn.Close();
                    }
                    if (!isSucc)
                    {
                        retInfo.ackcode = "300.2";
                        retInfo.ackflg = false;
                        retInfo.ackmsg = "Tmp失败{" + tmpname + "}";
                        return retInfo;
                    }

                    //LogHandler("histoTmp" + tmpTableName + "成功....");

                }
                #endregion

                #region 3.将临时表数据，批量插入到正式表

                // var fieldStr = string.Join(",", filedObj.Fields);
                var sqlList = new List<string>();
             
                sqlList.Add(strSql);
                string strmsg = "";
                isSucc = ExecuteSqlTran(connectionString, sqlList,out strmsg) > 0;
                if (!isSucc)
                {
                    retInfo.ackcode = "300.2";
                    retInfo.ackflg = false;
                    retInfo.ackmsg = "TmpToMiddle失败{" + tmpname + "}--{"+strmsg+"}";
                    //throw new Exception("TmpToMiddle失败{" + tableName + "}");
                }
                else
                {
                    retInfo.ackcode = "100.1";
                    retInfo.ackflg = true;
                    retInfo.ackmsg = "数据库操作成功";
                }
                #endregion
            }
            catch (Exception e)
            {
                retInfo.ackcode = "300.2";
                retInfo.ackflg = false;
                retInfo.ackmsg = e.Message;
                //LogHandler(e.Message);
            }
            finally
            {
                //GC.Collect();
            }
            return retInfo;
        }

        #region QueryMult

        //public DataTable ReieveTableBySql(string connectionStr,string sql)
        //{
        //    DataSet ds = SQLHelper.Query(sql, connectionStr);

        //    if (ds == null || ds.Tables.Count == 0) return null;
        //    var dt = ds.Tables[0];

        //    return dt;

        //}
        public static int ExecuteSqlTran(string connectionStr, List<SqlExeInfo> SQLStringList,out string msg)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;

                var currentSql = "";
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        var info = SQLStringList[n];
                        string strsql = info.ExeSql;
                        if (string.IsNullOrEmpty(strsql))
                            continue;
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            currentSql = strsql;
                            //cmd.CommandType = CommandType.Text;
                            if (info.SqlParameters != null)
                            {
                                foreach (SqlParameter parm in info.SqlParameters)
                                    cmd.Parameters.Add(parm);
                            }

                            cmd.ExecuteNonQuery();
                            count++;
                        }
                    }
                    tx.Commit();
                    msg = "成功";
                    return count;
                }
                catch (Exception ee)
                {
                    var a = currentSql;
                    tx.Rollback();
                    //LogHandler("执行trans报错：sql:" + currentSql + Environment.NewLine+"问题："+ ee.Message);
                    msg = ee.Message;
                    return 0;//throw;
                }
            }
        }


        public static int ExecuteSqlTran(string connectionStr, List<string> SQLStringList,out string msg)
        {
            var infos = new List<SqlExeInfo>();
            for (var i = 0; i < SQLStringList.Count; i++)
            {
                infos.Add(new SqlExeInfo() { ExeSql = SQLStringList[i] });
            }
            return ExecuteSqlTran(connectionStr, infos,out msg);
        }

        #endregion
    }
    public class SqlExeInfo
    {
        public string ExeSql { get; set; }
        public List<SqlParameter> SqlParameters { get; set; }
    }
}
