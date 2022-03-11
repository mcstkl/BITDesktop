using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Coordinators : List<Coordinator>
    {
        private SQLHelper _db;
        public Coordinators()
        {
            _db = new SQLHelper();
            string sql = "SELECT coordinatorID, FirstName, LastName, Street, Suburb, PostCode, Phone, " +
                               " UserName, Password, DateOfBirth, Email, Admin, Deleted " +
                         " FROM Coordinator";
            DataTable dtCoordinators = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtCoordinators.Rows)
            {
                Coordinator newCoordinator = new Coordinator(dataRow);
                this.Add(newCoordinator);
            }
        }


        public int GetNumberOfCoordinators()
        {
            string sql = "select count(*) from Coordinator";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;

        }
    }
}
