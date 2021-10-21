using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace TaskSchedule.Core
{
    public class DapperManager
    {
        public static DataTable GetTable(DatabaseType type,string constr,string strsql)
        {
            DataTable dt = new DataTable();
            using (IDbConnection conn = GetConnection(type, constr))
            {           
                var reader= conn.ExecuteReader(strsql);
                dt.Load(reader);
            }
            return dt;
        }

        private static IDbConnection GetConnection(DatabaseType type, string constr)
        {
            IDbConnection conn = null;
            switch (type)
            {
                case DatabaseType.SqlServer:
                    conn = new SqlConnection(constr);
                    break;
                case DatabaseType.MsAccess:
                    break;
                case DatabaseType.SqlServer9:
                    conn = new SqlConnection(constr);
                    break;
                case DatabaseType.Oracle:
                    conn = new OracleConnection(constr);
                    break;
                case DatabaseType.Sqlite3:
                    break;
                case DatabaseType.MySql:
                    break;
                default:
                    break;
            }
            conn.Open();
            return conn;
        }
    }
}
