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
    public class Skills : List<Skill>
    {
        private SQLHelper _db;
        public Skills()
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT * " +
                             " FROM Skill";
                DataTable dtSkills = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtSkills.Rows)
                {
                    Skill newSkill = new Skill(dataRow);
                    this.Add(newSkill);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Skills", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public Skills(string skillName)
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT SkillName " +
                                " FROM ContractorSkill " +
                                " WHERE contractorID = @ContractorID";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("ContractorID", DbType.Int32);
                parameters[0].Value = skillName;
                DataTable dtSkills = _db.ExecuteSQL(sql, parameters);

                foreach (DataRow dataRow in dtSkills.Rows)
                {
                    Skill newSkill = new Skill(dataRow);
                    this.Add(newSkill);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get Skills", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int GetNumberOfSkills()
        {
            try
            {
                string sql = "select count(*) from ContractorSkill";
                int rows = (int)_db.ExecuteSQLScalar(sql, null);
                return rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get number of Skills", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
    }
}
