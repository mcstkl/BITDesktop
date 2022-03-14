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
    public class Skill
    {
        //    private int _skillID;
        //    private string _skillName;
        //    private SQLHelper _db;

        //    public int SkillID
        //    {
        //        get { return _skillID; }
        //        set { _skillID = value; }
        //    }
        //    public string SkillName
        //    {
        //        get { return _skillName; }
        //        set { _skillName = value; }
        //    }


        //    public Skill()
        //    {
        //        _db = new SQLHelper();
        //    }

        //    public Skill(DataRow dr)
        //    {
        //        this.SkillID = (int)dr["SkillID"];
        //        this.SkillName = dr["Name"].ToString();

        //        _db = new SQLHelper();
        //    }

        //    public int InsertSkill()
        //    {
        //        int result = -1;
        //        string sql = "insert into skills(skillName) " +
        //            " values(@SkillName)";
        //        SqlParameter[] objParams;
        //        objParams = new SqlParameter[1];
        //        objParams[0] = new SqlParameter("@SkillName", DbType.String);
        //        objParams[0].Value = this.SkillName;
        //        result = _db.ExecuteNonQuery(sql, objParams);
        //        return result;
        //    }
        //    public int UpdateSkill()
        //    {
        //        int result = -1;
        //        string sql = "UPDATE Skills set " +
        //            "skillName = @SkillName, " +
        //            " WHERE skillID = @skillID";
        //        SqlParameter[] objParams;
        //        objParams = new SqlParameter[12];
        //        objParams[0] = new SqlParameter("@SkillID", DbType.String);
        //        objParams[0].Value = this.SkillID;
        //        objParams[1] = new SqlParameter("@SkillName", DbType.String);
        //        objParams[1].Value = this.SkillName;
        //        result = _db.ExecuteNonQuery(sql, objParams);
        //        return result;
        //    }
        //    public int DeleteSkill()
        //    {
        //        int result = -1;
        //        string sql = "DELETE FROM Skills WHERE skillID = @SkillID";
        //        SqlParameter[] objParams;
        //        objParams = new SqlParameter[1];
        //        objParams[0] = new SqlParameter("@SkillID", DbType.Int32);
        //        objParams[0].Value = this.SkillID;
        //        result = _db.ExecuteNonQuery(sql, objParams);
        //        return result;
        //    }

        //}
    }
}
