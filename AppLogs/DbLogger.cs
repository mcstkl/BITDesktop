using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.AppLogs
{
    public class DbLogger : LogBase
    {
        public override void Log(string message)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "INSERT INTO LogTable(message) VALUES(@Message)";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Message", DbType.String);
            parameters[0].Value = message;
            helper.ExecuteNonQuery(sql, parameters);
        }
    }
}
