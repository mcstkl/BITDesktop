using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Clients : List<Client>
    {
        private SQLHelper _db;
        public Clients()
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
        }


        public int GetNumberOfClients()
        {
            string sql = "select count(*) from Client";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;

        }
    }
}

