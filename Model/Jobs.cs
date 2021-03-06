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
    public class Jobs : List<Job>
    {
        private SQLHelper _db;
        public Jobs()
        {
            try
            {
                _db = new SQLHelper();
                //string sql = "SELECT DISTINCT j.jobID, j.jobStatusID, cl.ClientID, cl.CompanyName, j.Street, j.Suburb, j.PostCode, j.[state], j.[date], j.startTime, j.travelDistance, j.estimatedHours, j.actualHours,  cs.SkillName, js.JobStatus" +
                //    " FROM Job j, Contractor c, JobStatus js, ContractorSkill cs, Client cl " +
                //    " WHERE j.ClientID = cl.ClientID " +
                //    " AND j.JobStatusID = js.JobStatusID " +
                //    " AND j.SkillName = cs.SkillName";
                string sql = "SELECT DISTINCT j.jobID, j.jobStatusID, cl.ClientID, cl.CompanyName, j.Street, j.Suburb, j.PostCode, j.[state], " +
                    "j.[date], j.startTime, j.travelDistance, j.estimatedHours, j.actualHours,  j.SkillName, js.JobStatus, c.ContractorID, c.Username, c.FirstName + ' ' + c.LastName as FullName " +
                    " FROM Job j LEFT OUTER JOIN  Contractor c ON j.ContractorID = c.ContractorID " +
                    " LEFT JOIN  Client cl ON j.ClientID = cl.ClientID " +
                    " LEFT JOIN  JobStatus js ON js.JobStatusID = j.JobStatusID " +
                    " LEFT JOIN  ContractorSkill cs ON j.SkillName = cs.SkillName";
                DataTable dtJobs = _db.ExecuteSQL(sql);
                foreach (DataRow dataRow in dtJobs.Rows)
                {
                    Job newJob = new Job(dataRow);
                    this.Add(newJob);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Could not get Jobs", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public Jobs(int jobID)
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT * " +
                                " FROM Job " +
                                " WHERE JobID = @JobID";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("JobID", DbType.Int32);
                parameters[0].Value = jobID;
                DataTable dtJobs = _db.ExecuteSQL(sql, parameters);

                foreach (DataRow dataRow in dtJobs.Rows)
                {
                    Job newJob = new Job(dataRow);
                    this.Add(newJob);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Could not get Jobs", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Jobs(string jobStatus, int jobStatusID)
        {
            try
            {
                _db = new SQLHelper();
                string sql = "SELECT * " +
                                " FROM Job " +
                                " WHERE JobStatusID = @JobStatusID";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@JobStatusID", DbType.Int32);
                parameters[0].Value = jobStatusID;
                DataTable dtJobs = _db.ExecuteSQL(sql, parameters);

                foreach (DataRow dataRow in dtJobs.Rows)
                {
                    Job newJob = new Job(dataRow);
                    this.Add(newJob);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get Jobs", "An Error Has Occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
