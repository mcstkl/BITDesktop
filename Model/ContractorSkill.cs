using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.Model
{
    public class ContractorSkill : INotifyPropertyChanged
    {
        private int _contractorID;
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
        public int ContractorID
        {
            get { return _contractorID; }
            set
            {
                _contractorID = value;
                OnPropertyChanged("ContractorID");
            }
        }
        public string SkillName
        {
            get { return _skillName; }
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }


        public ContractorSkill()
        {
            _db = new SQLHelper();
        }

        public ContractorSkill(DataRow dr)
        {
            this.ContractorID = Convert.ToInt32(dr["ContractorID"].ToString());
            this.SkillName = dr["SkillName"].ToString();

            _db = new SQLHelper();
        }

        public int InsertSkill()
        {
            try
            {
                int result = -1;
                string sql = "insert into ContractorSkill(contractorID, skillName) " +
                    " values(@ContractorID, @SkillName)";
                SqlParameter[] objParams;
                objParams = new SqlParameter[2];
                objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
                objParams[0].Value = this.ContractorID;
                objParams[1] = new SqlParameter("@SkillName", DbType.String);
                objParams[1].Value = this.SkillName;
                result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not insert Skill", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
        public int UpdateSkill()
        {
            int result = -1;
            string sql = "UPDATE ContractorSkill set " +
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
            try
            {
                int result = -1;
                string sql = "DELETE FROM ContractorSkill WHERE skillName = @SkillName AND contractorID = @ContractorID";
                SqlParameter[] objParams;
                objParams = new SqlParameter[2];
                objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
                objParams[0].Value = this.ContractorID;
                objParams[1] = new SqlParameter("@SkillName", DbType.String);
                objParams[1].Value = this.SkillName;
                result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }catch (Exception ex)
            {
                MessageBox.Show("Could not delete skill", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
    }
}