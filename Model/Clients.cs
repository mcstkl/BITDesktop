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
    public class Clients : List<Client>
    {
        private SQLHelper _db;
        public Clients()
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT ClientID, CompanyName, Street, Suburb, PostCode, State, " +
                                   " Phone, Email, UserName, Password, Active " +
                             " FROM Client";
                DataTable dtClients = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtClients.Rows)
                {
                    Client newClient = new Client(dataRow);
                    this.Add(newClient);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Client List", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int GetNumberOfClients()
        {
            try
            {
                string sql = "select count(*) from Client";
                int rows = (int)_db.ExecuteSQLScalar(sql, null);
                return rows;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Number of Clients", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }

        }
    }
}

