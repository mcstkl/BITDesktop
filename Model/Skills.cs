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
    public class Skills : List<Skill>
    {
        //private SQLHelper _db;
        //public Skills()
        //{
        //    _db = new SQLHelper();
        //    string sql = "SELECT SkillID, SkillName " +
        //                 " FROM Skills";
        //    DataTable dtSkills = _db.ExecuteSQL(sql);
        //    foreach (DataRow dataRow in dtSkills.Rows)
        //    {
        //        Skill newSkill = new Skill(dataRow);
        //        this.Add(newSkill);
        //    }
        //}



        //public Skills(int contractorID)
        //{
        //    _db = new SQLHelper();
        //    string sql = "SELECT SkillID, SkillName " +
        //                    " FROM Skills " +
        //                    " WHERE contractorID = @ContractorID";
        //    SqlParameter[] parameters = new SqlParameter[1];
        //    parameters[0] = new SqlParameter("ContractorID", DbType.Int32);
        //    parameters[0].Value = contractorID;
        //    DataTable dtSkills = _db.ExecuteSQL(sql, parameters);

        //    foreach (DataRow dataRow in dtSkills.Rows)
        //    {
        //        Skill newSkill = new Skill(dataRow);
        //        this.Add(newSkill);
        //    }
        //}


        //public int GetNumberOfSkills()
        //{
        //    string sql = "select count(*) from Skills";
        //    int rows = (int)_db.ExecuteSQLScalar(sql, null);
        //    return rows;

        //}
    }
}
