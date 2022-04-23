using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.Model
{
    public class Availability : INotifyPropertyChanged
    {

        private int _contractorID;
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private string _availableDate;
        private TimeSpan _startTime;
        private TimeSpan _finishTime = new TimeSpan(19,0,0);
        private Decimal _contractorRating;
        private Decimal _payRate;
        private bool _available;





        public int ContractorID
        {
            get { return _contractorID; }
            set { _contractorID = value;
                OnPropertyChanged("ContractorID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FullName
        {
            get { return _firstName + " " +_lastName; }
            set { _fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string AvailableDate
        {
            get { return _availableDate; }
            set {_availableDate = value;
                OnPropertyChanged("AvailableDate");
            }
        }
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public TimeSpan FinishTime
        {
            get { return _finishTime; }
            set { _finishTime = value;
                OnPropertyChanged("EndTime");
            }
        }
        public Decimal ContractorRating
        {
            get { return _contractorRating; }
            set { _contractorRating = value;
                OnPropertyChanged("ContractorRating");
            }
        }
        public Decimal PayRate
        {
            get { return _payRate; }
            set { _payRate = value;
                OnPropertyChanged("PayRate");
            }
        }
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }



        SQLHelper _db = new SQLHelper();
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public Availability()
        {
            SQLHelper _db = new SQLHelper();
        }

        public Availability(DataRow dr)
        {
            this.ContractorID = (int)dr["ContractorID"];
            this.FirstName = (string)dr["FirstName"];
            this.LastName = (string)dr["LastName"];
            this.AvailableDate = ((DateTime)dr["AvailableDate"]).ToShortDateString();
            this.StartTime = (TimeSpan)dr["StartTime"];
            this.FinishTime = (TimeSpan)dr["FinishTime"];
            this.ContractorRating = (Decimal)dr["ContractorRating"];
            this.PayRate = (Decimal)dr["PayRate"];
            this.Available = Convert.ToBoolean(dr["Available"]);
           
            _db = new SQLHelper();
        }


        public int InsertAvailability()
        {
            int result = -1;
            string sql = "insert into Availability(ContractorID, StartTime, AvailableDate, FinishTime) " +
                " values(@ContractorID, @StartTime, @AvailableDate, @FinishTime)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
            objParams[0].Value = this.ContractorID;
            objParams[1] = new SqlParameter("@StartTime", DbType.Time);
            objParams[1].Value = this.StartTime;
            objParams[2] = new SqlParameter("@AvailableDate", DbType.DateTime);
            objParams[2].Value = this.AvailableDate;
            objParams[3] = new SqlParameter("@FinishTime", DbType.Time);
            objParams[3].Value = this.FinishTime;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }

        public int DeleteAvailability()
        {
            int result = -1;
            string sql = "DELETE FROM Availability" +
                " WHERE contractorID = @ContractorID" +
                " AND startTime = @StartTime" +
                " AND availableDate = @AvailableDate " +
                " AND finishTime = @FinishTime";
            DateTime availableDate = Convert.ToDateTime(this.AvailableDate);
            SqlParameter[] objParams;
            objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@ContractorID", DbType.Int32);
            objParams[0].Value = this.ContractorID;
            objParams[1] = new SqlParameter("@StartTime", DbType.Time);
            objParams[1].Value = this.StartTime;
            objParams[2] = new SqlParameter("@AvailableDate", DbType.Date);
            objParams[2].Value = availableDate;
            objParams[3] = new SqlParameter("@FinishTime", DbType.Time);
            objParams[3].Value = this.FinishTime;
            result = _db.ExecuteNonQuery(sql, objParams);
            return result;
        }
    }
}
