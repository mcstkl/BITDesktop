using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Contractors : List<Contractor>
    {
        private SQLHelper _db;
        public Contractors()
        {
            _db = new SQLHelper();
            string sql = "SELECT contractorID, FirstName, LastName, Street, Suburb, PostCode, State, " +
                               " Email, ContractorRating, UserName, Password, Deleted " +
                         " FROM Contractor";
            DataTable dtContractors = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtContractors.Rows)
            {
                Contractor newContractor = new Contractor(dataRow);
                this.Add(newContractor);
            }
        }


        public int GetNumberOfContractors()
        {
            string sql = "select count(*) from Contractor";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;

        }
    }
}
