using BITServices.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private TimeSpan _finishTime;
        private Decimal _contractorRating;
        private Decimal _payRate;








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
            //this.ContractorID = (int)dr["ContractorID"];
            this.FirstName = (string)dr["FirstName"];
            this.LastName = (string)dr["LastName"];
            this.AvailableDate = ((DateTime)dr["AvailableDate"]).ToShortDateString();
            this.StartTime = (TimeSpan)dr["StartTime"];
            this.FinishTime = (TimeSpan)dr["FinishTime"];
            this.ContractorRating = (Decimal)dr["ContractorRating"];
            this.PayRate = (Decimal)dr["PayRate"];
           
            _db = new SQLHelper();
        }


  

    }
}
