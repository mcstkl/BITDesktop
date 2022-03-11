using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class is a helper class - sometimes also known as DAL (data access layer) class/layer
//It is a class that has all the methods that will physically attempt to access the dB and
//execute the queries (passed as parameters) and return the required results.

namespace BITServices.DAL
{
    public class SQLHelper
    {
        private string _connectionString;
        //Having multiple versions of constructors is allowed in C# due to
        //Overloading of constructors.
        //In C# as long as your methods have different signatures (different parameters)
        //and because constructor n a class is a special method, constructors can also
        //be overloaded 

        //default constructor
        public SQLHelper() //If we always know that we are connecting to "NW"
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BitServices"].ConnectionString;
        }
        //parameterised constructor
        public SQLHelper(string cnnStr)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[cnnStr].ConnectionString;
        }

        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if(storedProcedure == true)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(cmd, parameters);
            }
            try
            {
            connection.Open();
            SqlDataReader drResults = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dataTable.Load(drResults);
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return dataTable;
        }
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            int returnValue = -1;

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (storedProcedure == true)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(cmd, parameters);
            }
            try
            {
                connection.Open();
                returnValue = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return returnValue;
        }
        public Object ExecuteSQLScalar(string sql, SqlParameter[] parameters = null, bool storedProcedure = false)
        {
            Object returnValue = null;

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (storedProcedure == true)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(cmd, parameters);
            }
            try
            {
                connection.Open();
                //Scalar - Count, Min, Max kind of select statement where the query returns a single value
                returnValue = cmd.ExecuteScalar();
                connection.Close();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return returnValue;
        }


        private void AddParameters(SqlCommand cmd, SqlParameter[] parameters)
        {
            foreach(SqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }
        }
    }
}
