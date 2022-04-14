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
    public class Job : INotifyPropertyChanged
    {
        private int _jobStatusID;
        private int _contractorID;
        private string _companyName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _date;
        private TimeSpan _startTime;
        private int _travelDistance;
        private int _estimatedHours;
        private int _actualHours;
        private string _skillName;
        private int _clientID;
        private int _jobID;
        private string _jobStatus;
        private string _userName;
        private string _fullName;
        private SQLHelper _db;

        public int JobID
        {
            get { return _jobID; }
            set
            {
                _jobID = value;
                OnPropertyChanged("JobID");
            }
        }
        public int JobStatusID
        {
            get { return _jobStatusID; }
            set
            {
                _jobStatusID = value;
                OnPropertyChanged("JobStatusID");
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
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public int TravelDistance
        {
            get { return _travelDistance; }
            set
            {
                _travelDistance = value;
                OnPropertyChanged("TravelDistance");
            }
        }
        public int EstimatedHours
        {
            get { return _estimatedHours; }
            set
            {
                _estimatedHours = value;
                OnPropertyChanged("EstimatedHours");
            }
        }
        public int ActualHours
        {
            get { return _actualHours; }
            set
            {
                _actualHours = value;
                OnPropertyChanged("ActualHours");
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
        public int ClientID
        {
            get { return _clientID; }
            set
            {
                _clientID = value;
                OnPropertyChanged("ClientID");
            }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string JobStatus
        {
            get { return _jobStatus; }
            set { _jobStatus = value; }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



        public Job()
        {
            _db = new SQLHelper();
        }

        public Job(DataRow dr)
        {
            this.JobID = Convert.ToInt32(dr["JobID"].ToString());
            this.ClientID = Convert.ToInt32(dr["ClientID"].ToString());
            this.CompanyName = dr["CompanyName"].ToString();
            this.Street = dr["Street"].ToString();
            this.Suburb = dr["Suburb"].ToString();
            this.PostCode = dr["PostCode"].ToString();
            this.State = dr["State"].ToString();
            this.Date = ((DateTime)dr["Date"]).ToShortDateString();
            this.StartTime = (TimeSpan)dr["StartTime"];
            this.TravelDistance = Convert.ToInt32(dr["TravelDistance"].ToString());
            this.EstimatedHours = Convert.ToInt32(dr["EstimatedHours"].ToString());
            this.ActualHours = Convert.ToInt32(dr["ActualHours"].ToString());
            this.SkillName = dr["SkillName"].ToString();
            this.JobStatus = dr["JobStatus"].ToString();
            this.JobStatusID = Convert.ToInt32(dr["JobStatusID"].ToString());
            this.ContractorID = dr["ContractorID"] as int? ?? default(int);
            this.UserName = dr["UserName"].ToString();
            this.FullName = dr["FullName"].ToString();
            _db = new SQLHelper();
        }


        public int AddNewJob()
        {
            try
            {
                string sql = "insert into job(jobStatusID, street, suburb, postCode, state, date, startTime, travelDistance, estimatedHours, actualHours, skillName, clientID) " +
                    " values(@JobStatusID, @Street, @Suburb, @PostCode, @State, @Date, @StartTime, @TravelDistance, @EstimatedHours, @ActualHours, @SkillName, @ClientID)";
                DateTime dtime = Convert.ToDateTime(this.Date);
                SqlParameter[] objParams;
                objParams = new SqlParameter[12];
                objParams[0] = new SqlParameter("@JobStatusID", DbType.Int32);
                objParams[0].Value = 1;
                objParams[1] = new SqlParameter("@Street", DbType.String);
                objParams[1].Value = this.Street;
                objParams[2] = new SqlParameter("@Suburb", DbType.String);
                objParams[2].Value = this.Suburb;
                objParams[3] = new SqlParameter("@PostCode", DbType.String);
                objParams[3].Value = this.PostCode;
                objParams[4] = new SqlParameter("@State", DbType.String);
                objParams[4].Value = this.State;
                objParams[5] = new SqlParameter("@Date", DbType.DateTime);
                objParams[5].Value = dtime;
                objParams[6] = new SqlParameter("@StartTime", DbType.Time);
                objParams[6].Value = this.StartTime;
                objParams[7] = new SqlParameter("@TravelDistance", DbType.Int32);
                objParams[7].Value = 0;
                objParams[8] = new SqlParameter("@EstimatedHours", DbType.Int32);
                objParams[8].Value = this.EstimatedHours;
                objParams[9] = new SqlParameter("@ActualHours", DbType.Int32);
                objParams[9].Value = 0;
                objParams[10] = new SqlParameter("@SkillName", DbType.String);
                objParams[10].Value = this.SkillName;
                objParams[11] = new SqlParameter("@ClientID", DbType.Int32);
                objParams[11].Value = this.ClientID;
                int result = _db.ExecuteNonQuery(sql, objParams);
                return result;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not add client", "Could not add client", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }


        }

        public int DeleteJob()
        {
            int result = -1;
            string sql = "DELETE FROM Job WHERE JobID = @JobID";
            SqlParameter[] objParams;
            objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@JobID", DbType.Int32);
            objParams[0].Value = this.JobID;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

        public int UpdateJob()
        {
            string sql = "UPDATE job SET " +
                "jobStatusID = @JobStatusID, " +
                "street = @Street, " +
                "suburb = @Suburb, " +
                "postCode = @PostCode, " +
                "state = @State, " +
                "date = @Date, " +
                "startTime = @StartTime, " +
                "travelDistance = @TravelDistance, " +
                "estimatedHours = @EstimatedHours, " +
                "actualHours = @ActualHours, " +
                "skillName = @SkillName, " +
                "clientID = @ClientID, " +
                "contractorID = @ContractorID " +
                 " WHERE jobID = @JobID";
            DateTime dtime = Convert.ToDateTime(this.Date);
            SqlParameter[] objParams;
            objParams = new SqlParameter[14];
            objParams[0] = new SqlParameter("@JobStatusID", DbType.String);
            objParams[0].Value = this.JobStatusID;
            objParams[1] = new SqlParameter("@Street", DbType.String);
            objParams[1].Value = this.Street;
            objParams[2] = new SqlParameter("@Suburb", DbType.String);
            objParams[2].Value = this.Suburb;
            objParams[3] = new SqlParameter("@PostCode", DbType.String);
            objParams[3].Value = this.PostCode;
            objParams[4] = new SqlParameter("@State", DbType.String);
            objParams[4].Value = this.State;
            objParams[5] = new SqlParameter("@Date", DbType.DateTime);
            objParams[5].Value = dtime;
            objParams[6] = new SqlParameter("@StartTime", DbType.Time);
            objParams[6].Value = this.StartTime;
            objParams[7] = new SqlParameter("@TravelDistance", DbType.Int32);
            objParams[7].Value = this.TravelDistance;
            objParams[8] = new SqlParameter("@EstimatedHours", DbType.Int32);
            objParams[8].Value = this.EstimatedHours;
            objParams[9] = new SqlParameter("@ActualHours", DbType.Int32);
            objParams[9].Value = this.ActualHours;
            objParams[10] = new SqlParameter("@SkillName", DbType.String);
            objParams[10].Value = this.SkillName;
            objParams[11] = new SqlParameter("@ClientID", DbType.Int32);
            objParams[11].Value = this.ClientID;
            objParams[12] = new SqlParameter("@JobID", DbType.Int32);
            objParams[12].Value = this.JobID;
            objParams[13] = new SqlParameter("@ContractorID", DbType.Int32);
            objParams[13].Value = this.ContractorID;
            int result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
    }
}
