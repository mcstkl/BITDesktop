using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.Model
{
    public class Availabilities : List<Availability>
    {
        private SQLHelper _db;
        public Availabilities()
        {
            try
            {
                _db = new SQLHelper();
                    string sql = "SELECT c.ContractorID, c.FirstName, c.LastName, a.AvailableDate, a.StartTime, a.FinishTime, a.Available, c.ContractorRating, c.PayRate " +
                                 " FROM Contractor AS c " +
                                 " INNER JOIN Availability AS a ON c.ContractorID = a.ContractorID";
                DataTable dtAvailabilities = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtAvailabilities.Rows)
                {
                    Availability newAvailability = new Availability(dataRow);
                    this.Add(newAvailability);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Availabilities", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int GetNumberOfClients()
        {
            try { 
                string sql = "select count(*) from Availability";
                int rows = (int)_db.ExecuteSQLScalar(sql, null);
                return rows;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Number of Clients", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
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
