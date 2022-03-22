using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Availabilities : List<Availability>
    {
        private SQLHelper _db;
        public Availabilities()
        {
            _db = new SQLHelper();
                string sql = "SELECT c.FirstName, c.LastName, a.AvailableDate, a.StartTime, a.FinishTime, c.ContractorRating, c.PayRate " +
                             " FROM Contractor AS c " +
                             " INNER JOIN Availability AS a ON c.ContractorID = a.ContractorID";
            DataTable dtAvailabilities = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtAvailabilities.Rows)
            {
                Availability newAvailability = new Availability(dataRow);
                this.Add(newAvailability);
            }
        }


        public int GetNumberOfClients()
        {
            string sql = "select count(*) from Availability";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;
        }

        //public DataTable GetContractorAvailabilities()
        //{
        //    string sql = "SELECT c.FirstName, c.LastName, a.AvailableDate, a.StartTime, a.FinishTime " +
        //                 " FROM Contractor AS c " +
        //                 " INNER JOIN Availability AS a ON c.ContractorID = a.ContractorID";
        //    DataTable dtAvailabilities = _db.ExecuteSQL(sql);
        //    return dtAvailabilities;
        //}

        //public DataTable GetContractorAvailability(int contractorID)
        //{
        //    string sql = "SELECT c.FirstName, c.LastName, a.AvailableDate, a.StartTime, a.FinishTime " +
        //                 " FROM Contractor AS c " +
        //                 " INNER JOIN Availability AS a ON c.ContractorID = a.ContractorID" +
        //                 " WHERE a.ContractorID = @ContractorID";
        //    SqlParameter[] objParams;
        //    objParams = new SqlParameter[1];
        //    objParams[0] = new SqlParameter("@ContractorID", DbType.String);
        //    objParams[0].Value = contractorID;
        //    DataTable dtAvailabilities = _db.ExecuteSQL(sql);
        //    return dtAvailabilities;
        //}
    }
}
