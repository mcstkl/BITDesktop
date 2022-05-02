using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.Model
{
    public class Staffs : List<Staff>
    {
        private SQLHelper _db;
        public Staffs()
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT staffID, FirstName, LastName, Street, Suburb, PostCode, State, " +
                                   " Phone, Email, UserName, Password, StaffType, Active " +
                             " FROM Staff";
                DataTable dtStaff = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtStaff.Rows)
                {
                    Staff newStaff = new Staff(dataRow);
                    this.Add(newStaff);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Staff", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int GetNumberOfStaff()
        {
            try
            {
                string sql = "select count(*) from Staff";
                int rows = (int)_db.ExecuteSQLScalar(sql, null);
                return rows;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get number of staff", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }

        }
    }
}
