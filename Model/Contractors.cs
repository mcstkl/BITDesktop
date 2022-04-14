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
    public class Contractors : List<Contractor>
    {
        private SQLHelper _db;
        public Contractors()
        {
            _db = new SQLHelper();
            string sql = "SELECT contractorID, firstName, lastName, street, suburb, postCode, state, " +
                               " phone, email, userName, password, " +
                               " contractorRating, payRate, profile, active " +
                         " FROM Contractor";
            DataTable dtContractors = _db.ExecuteSQL(sql);
            foreach (DataRow dataRow in dtContractors.Rows)
            {
                Contractor newContractor = new Contractor(dataRow);
                this.Add(newContractor);
            }
        }


        public int GetNumberOfContractors()
        {
            string sql = "select count(*) from Contractor";
            int rows = (int)_db.ExecuteSQLScalar(sql, null);
            return rows;
        }


        public Contractors(int jobID)
        {
            _db = new SQLHelper();
            DataTable dtSuitableContractors = new DataTable();
            //string sql = "SELECT DISTINCT j.JobID, c.FirstName + ' ' + c.LastName as FullName,  j.[Date], cs.SkillName, c.ContractorID" +
            //                " FROM Contractorskill cs, Job j, Contractor c, [Availability] a " +
            //                " WHERE c.ContractorID = cs.ContractorID " +
            //                " AND cs.SkillName = j.SkillName " +
            //                " AND a.AvailableDate = j.[Date] " +
            //                " AND a.ContractorID = c.ContractorID " +
            //                " AND a.StartTime < j.StartTime " +
            //                " AND j.JobID = @JobID";
            string sql = "SELECT DISTINCT c.contractorID, c.FirstName, c.LastName, c.street, c.suburb, c.postcode, c.state, " +
                         " c.phone, c.email, c.username, c.password, c.contractorrating, c.payrate, c.profile, c.active " +
                         " FROM Contractorskill cs, Job j, Contractor c, [Availability] a " +
                         " WHERE c.ContractorID = cs.ContractorID " +
                         " AND cs.SkillName = j.SkillName " +
                         " AND a.AvailableDate = j.[Date] " +
                         " AND a.ContractorID = c.ContractorID " +
                         " AND a.StartTime <= j.StartTime " +
                         " AND j.JobID = @JobID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobID", DbType.Int32);
            objParams[0].Value = jobID;
            dtSuitableContractors = _db.ExecuteSQL(sql, objParams);
            foreach (DataRow dataRow in dtSuitableContractors.Rows)
            {
                Contractor newContractor = new Contractor(dataRow);
                this.Add(newContractor);
            }
        }
    }
}
