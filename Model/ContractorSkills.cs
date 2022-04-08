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
    public class ContractorSkills : List<ContractorSkill>
    {
        private SQLHelper _db;
        public ContractorSkills()
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



        public ContractorSkills(int contractorID)
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
    }
}