using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotelRoom.Models
{
    public class DataProvider
    {
        public static SqlConnection sqlConnection = null;
        public SqlConnection GetSqlConnectionProvider()
        {
            if ((sqlConnection == null) || (sqlConnection.State != ConnectionState.Open))
            {
                try
                {
                    SqlConnection conn = sqlConnection = new SqlConnection(Startup.ConnectionString);
                    sqlConnection = conn;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return sqlConnection;
        }
    }
}
