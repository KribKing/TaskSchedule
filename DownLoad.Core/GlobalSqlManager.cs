using Dos.ORM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DownLoad.Core
{
    public class GlobalSqlManager
    {
        //public DataTable GetDataTable(string connectstring, string commandsql)
        //{
        //    try
        //    {
        //        DataSet ds = GetDataSet(dbstyle, connectstring, commandsql);
        //        DataTable dt = null;
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            dt = ds.Tables[0];
        //        }
        //        return dt;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public DataTable GetDataTable(int dbstyle, string connectstring, string commandsql)
        {
            try
            {
                var db = new DbSession(GetDbTyle(dbstyle), connectstring);
                return db.FromSql(commandsql).ToDataTable();
            }
            catch 
            {             
                throw;
            }
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public DataTable GetDataTableFrmProc(int dbstyle, string connectstring, string commandsql, params System.Data.Common.DbParameter[] parameters)
        {
            try
            {
                var db = new DbSession(GetDbTyle(dbstyle), connectstring);
                return db.FromProc(commandsql).AddParameter(parameters).ToDataTable();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public DataSet GetDataSetFromProc(int dbstyle, string connectstring, string commandsql,params System.Data.Common.DbParameter[] parameters)
        {
            try
            {
                var db = new DbSession(GetDbTyle(dbstyle), connectstring);
                return db.FromProc(commandsql).AddParameter(parameters).ToDataSet();            
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public DataSet GetDataSet(int dbstyle, string connectstring, string commandsql)
        {
            try
            {
                var db = new DbSession(GetDbTyle(dbstyle), connectstring);
                return db.FromSql(commandsql).ToDataSet();
            }
            catch 
            {               
                throw;
            }
           
        }
        public DatabaseType GetDbTyle(int dbstyle)
        {
            DatabaseType dbt = DatabaseType.SqlServer;
            if (dbstyle == 1)
            {
                dbt = DatabaseType.MsAccess;
            }
            else if (dbstyle == 2)
            {
                dbt = DatabaseType.SqlServer9;
            }
            else if (dbstyle == 3)
            {
                dbt = DatabaseType.Oracle;
            }
            else if (dbstyle == 4)
            {
                dbt = DatabaseType.Sqlite3;
            }
            else if (dbstyle == 5)
            {
                dbt = DatabaseType.MySql;
            }

            return dbt;
        }
        public int ExecuteNoneQuery(int dbstyle, string connectstring, string commandsql)
        {
            var db = new DbSession(GetDbTyle(dbstyle), connectstring);
            return db.FromSql(commandsql).ExecuteNonQuery();
        }
        public ResultInfo BulkDb(int dbtype,string connectionString, string creatTmp, string tmpname, string strSql, DataTable table, ref ResultInfo retInfo)
        {
            try
            {
                switch (GetDbTyle(dbtype))
                {
                    case DatabaseType.MsAccess:
                        break;
                    case DatabaseType.MySql:
                        break;
                    case DatabaseType.Oracle:
                        this.BulkDbByOracle(connectionString, creatTmp, tmpname, strSql, table, ref retInfo);
                        break;
                    case DatabaseType.SqlServer:
                        this.BulkDbBySqlServer(connectionString,creatTmp,tmpname,strSql,table,ref retInfo);
                        break;
                    case DatabaseType.SqlServer9:
                        break;
                    case DatabaseType.Sqlite3:
                        break;
                    default:
                        break;
                }
               
            }
            catch (Exception e)
            {
                retInfo.ackcode = "300.2";
                retInfo.ackflg = false;
                retInfo.ackmsg = e.Message;
            }
            finally
            {
                //GC.Collect();
            }
            return retInfo;
        }
        public ResultInfo BulkDbBySqlServer(string connectionString, string creatTmp, string tmpname, string strSql, DataTable table, ref ResultInfo retInfo)
        {
            #region 1.创建临时表
            string strtmpsql = "";
            if (!string.IsNullOrEmpty(creatTmp))
            {
                strtmpsql = creatTmp;
            }
            else
            {
                strtmpsql = "truncate table " + tmpname;
            }
            #endregion
            #region 2.将数据使用sqlbulk导入到临时表
            //开始数据保存逻辑

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strtmpsql;
                cmd.ExecuteNonQuery();
                //在插入数据的同时检查约束，如果发生错误调用sqlbulkTransaction事务
                SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName = tmpname;//代表要插入数据的表名
                foreach (DataColumn dc in table.Columns)  //传入上述table
                {
                    bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);//将table中的列与数据库表这的列一一对应
                }
                try
                {
                    bulkCopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    retInfo.ackcode = "300.2";
                    retInfo.ackflg = false;
                    retInfo.ackmsg = "批量导入临时表发生异常：" + ex.Message;
                    return retInfo;
                }
                finally
                {
                    bulkCopy.Close();
                }
                SqlTransaction tran = conn.BeginTransaction();//开启事务                
                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    retInfo.ackcode = "300.2";
                    retInfo.ackflg = false;
                    retInfo.ackmsg = "批量导入发生异常：" + ee.Message;
                    return retInfo;
                }
                retInfo.ackcode = "100.1";
                retInfo.ackflg = true;
                retInfo.ackmsg = "数据库操作成功";
                tran.Commit();
            }
            return retInfo;
            #endregion
        }
        public ResultInfo BulkDbByOracle(string connectionString, string creatTmp, string tmpname, string strSql, DataTable table, ref ResultInfo retInfo)
        {
            #region 1.创建临时表
            string strtmpsql = "";
            if (!string.IsNullOrEmpty(creatTmp))
            {
                strtmpsql = creatTmp;
            }
            else
            {
                strtmpsql = "truncate table " + tmpname;
            }
            #endregion
            #region 2.将数据使用sqlbulk导入到临时表
            //开始数据保存逻辑

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = strtmpsql;
                cmd.ExecuteNonQuery();
                //在插入数据的同时检查约束，如果发生错误调用sqlbulkTransaction事务
                OracleBulkCopy bulkCopy = new OracleBulkCopy(conn);
                bulkCopy.DestinationTableName = tmpname;//代表要插入数据的表名
                foreach (DataColumn dc in table.Columns)  //传入上述table
                {
                    bulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);//将table中的列与数据库表这的列一一对应
                }
                try
                {
                    bulkCopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    retInfo.ackcode = "300.2";
                    retInfo.ackflg = false;
                    retInfo.ackmsg = "批量导入临时表发生异常：" + ex.Message;
                    return retInfo;
                }
                finally
                {
                    bulkCopy.Close();
                }
                OracleTransaction tran = conn.BeginTransaction();//开启事务                
                try
                {
                    cmd.Transaction = tran;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    retInfo.ackcode = "300.2";
                    retInfo.ackflg = false;
                    retInfo.ackmsg = "批量导入发生异常：" + ee.Message;
                    return retInfo;
                }
                retInfo.ackcode = "100.1";
                retInfo.ackflg = true;
                retInfo.ackmsg = "数据库操作成功";
                tran.Commit();
            }
            return retInfo;
            #endregion
        }


        public class DbParas
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int MyProperty { get; set; }
        }

    }
}
