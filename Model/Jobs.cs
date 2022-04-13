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
    public class Jobs : List<Job>
    {
        private SQLHelper _db;
        public Jobs()
        {
            _db = new SQLHelper();
            string sql = "SELECT DISTINCT j.jobID, j.jobStatusID, cl.ClientID, cl.CompanyName, j.Street, j.Suburb, j.PostCode, j.[state], j.[date], j.startTime, j.travelDistance, j.estimatedHours, j.actualHours,  cs.SkillName, js.JobStatus" +
                " FROM Job j, Contractor c, JobStatus js, ContractorSkill cs, Client cl " +
                " WHERE j.ClientID = cl.ClientID " +
                " AND j.JobStatusID = js.JobStatusID " +
                " AND j.SkillName = cs.SkillName";
            DataTable dtJobs = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtJobs.Rows)
            {
                Job newJob = new Job(dataRow);
                this.Add(newJob);
            }
        }

        public Jobs(int jobID)
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
        }
    }
}
