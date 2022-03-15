﻿using BITServices.DAL;
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
        private int _contractorID;
        private string _skillName;
        private SQLHelper _db;

        public int ContractorID
        {
            get { return _contractorID; }
            set { _contractorID = value; }
        }
        public string SkillName
        {
            get { return _skillName; }
            set { _skillName = value; }
        }


        public Skill()
        {
            _db = new SQLHelper();
        }

        public Skill(DataRow dr)
        {
            this.ContractorID = Convert.ToInt32(dr["ContractorID"].ToString());
            this.SkillName = dr["SkillName"].ToString();

            _db = new SQLHelper();
        }

        public int InsertSkill()
        {
            int result = -1;
            string sql = "insert into ContractorSkills(contractorID, skillName) " +
                " values(@ContractorID, @SkillName)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorID", DbType.String);
            objParams[0].Value = this.ContractorID;
            objParams[1] = new SqlParameter("@SkillName", DbType.String);
            objParams[1].Value = this.SkillName;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int UpdateSkill()
        {
            int result = -1;
            string sql = "UPDATE ContractorSkills set " +
                "skillName = @SkillName, " +
                " WHERE contractorID = @ContractorID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorID", DbType.String);
            objParams[0].Value = this.ContractorID;
            objParams[1] = new SqlParameter("@SkillName", DbType.String);
            objParams[1].Value = this.SkillName;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        public int DeleteSkill()
        {
            int result = -1;
            string sql = "DELETE FROM ContractorSkills WHERE skillName = @SkillName AND contractorID = @ContractorID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
            objParams[0].Value = this.ContractorID; 
            objParams[1] = new SqlParameter("@SkillName", DbType.Int32);
            objParams[1].Value = this.SkillName;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}
