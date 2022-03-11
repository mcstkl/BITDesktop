using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Customers : List<Customer>
    {
        private SQLHelper _db;
        public Customers()
        {
            _db = new SQLHelper();
            string sql = "SELECT CustomerID, CompanyName, Street, Suburb, PostCode, State, " +
                               " Phone, Email, Deleted " +
                         " FROM Customer";
            DataTable dtCustomers = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtCustomers.Rows)
            {
                Customer newCoordinator = new Customer(dataRow);
                this.Add(newCoordinator);
            }
        }


        public int GetNumberOfCustomers()
        {
            string sql = "select count(*) from Customer";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;

        }
    }
}

