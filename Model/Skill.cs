using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Skill : INotifyPropertyChanged
    {
        //private int _contractorID;
        private string _skillName;
        private SQLHelper _db;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        //public int ContractorID
        //{
        //    get { return _contractorID; }
        //    set { _contractorID = value;
        //        OnPropertyChanged("ContractorID");
        //    }
        //}
        public string SkillName
        {
            get { return _skillName; }
            set { _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }


        public Skill()
        {
            _db = new SQLHelper();
        }

        public Skill(DataRow dr)
        {
            //this.ContractorID = Convert.ToInt32(dr["ContractorID"].ToString());
            this.SkillName = dr["SkillName"].ToString();

            _db = new SQLHelper();
        }
        public Skill(string skillName)
        {
            //this.ContractorID = Convert.ToInt32(dr["ContractorID"].ToString());
            this.SkillName = skillName;

            _db = new SQLHelper();
        }


        public int InsertSkill()
        {
            int result = -1;
            string sql = "insert into Skill(skillName) " +
                " values(@SkillName)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@SkillName", DbType.String);
            objParams[0].Value = this.SkillName;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
        //public int UpdateSkill()
        //{
        //    int result = -1;
        //    string sql = "UPDATE Skill set " +
        //        "skillName = @SkillName, " +
        //        " WHERE contractorID = @ContractorID";
        //    SqlParameter[] objParams;
        //    objParams = new SqlParameter[2];
        //    objParams[0] = new SqlParameter("@ContractorID", DbType.String);
        //    objParams[0].Value = this.ContractorID;
        //    objParams[1] = new SqlParameter("@SkillName", DbType.String);
        //    objParams[1].Value = this.SkillName;
        //    result = _db.ExecuteNonQuery(sql, objParams);
        //    return result;
        //}
        public int DeleteSkill()
        {
            int result = -1;
            string sql = "DELETE FROM Skill WHERE skillName = @SkillName";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@SkillName", DbType.String);
            objParams[0].Value = this.SkillName;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

    }
}
