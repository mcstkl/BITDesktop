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
    public class ContractorSkills : List<ContractorSkill>
    {
        private SQLHelper _db;
        public ContractorSkills()
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT * " +
                             " FROM ContractorSkill";
                DataTable dtSkills = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtSkills.Rows)
                {
                    ContractorSkill newSkill = new ContractorSkill(dataRow);
                    this.Add(newSkill);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get Contractor Skills", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public ContractorSkills(int contractorID)
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT * " +
                                " FROM ContractorSkill " +
                                " WHERE contractorID = @ContractorID";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("ContractorID", DbType.Int32);
                parameters[0].Value = contractorID;
                DataTable dtSkills = _db.ExecuteSQL(sql, parameters);

                foreach (DataRow dataRow in dtSkills.Rows)
                {
                    ContractorSkill newSkill = new ContractorSkill(dataRow);
                    this.Add(newSkill);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get Contractor Skills", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}