using BITServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private int _numberOfClients;
        private int _numberOfContractors;
        private int _numberOfActiveJobs;
        private int _numberOfCompletedJobs;
        private ObservableCollection<Contractor> _topContractors;
        private Contractor _contractorOne;
        private Contractor _contractorTwo;
        private Contractor _contractorThree;
        private ObservableCollection<Job> _upcomingJobs;
        private Job _upcomingOne;
        private Job _upcomingTwo;
        private Job _upcomingThree;


        public Contractor ContractorOne
        {
            get { return _topContractors[0]; }
            set { _contractorOne = value;
                OnPropertyChanged("ContractorOne");
            }
        }
        public Contractor ContractorTwo
        {
            get { return _topContractors[1]; }
            set { _contractorTwo = value;
                OnPropertyChanged("ContractorTwo");
            }
        }
        public Contractor ContractorThree
        {
            get { return _topContractors[2]; }
            set { _contractorThree = value;
                OnPropertyChanged("ContractorThree");
            }
        }
        public Job UpcomingOne
        {
            get { return _upcomingJobs[0]; }
            set
            {
                _upcomingOne = value;
                OnPropertyChanged("UpcomingOne");
            }
        }
        public Job UpcomingTwo
        {
            get { return _upcomingJobs[1]; }
            set
            {
                _upcomingTwo = value;
                OnPropertyChanged("UpcomingTwo");
            }
        }
        public Job UpcomingThree
        {
            get { return _upcomingJobs[2]; }
            set
            {
                _upcomingThree = value;
                OnPropertyChanged("UpcomingThree");
            }
        }

        public int NumberOfClients
        {
            get { return _numberOfClients; }
            set { _numberOfClients = value;
                OnPropertyChanged("NumberOfClients");
            }
        }
        public int NumberOfContractors
        {
            get { return _numberOfContractors; }
            set { _numberOfContractors = value;
                OnPropertyChanged("NumberOfContractors");
            }
        }
        public int NumberOfActiveJobs
        {
            get { return _numberOfActiveJobs; }
            set { _numberOfActiveJobs = value;
                OnPropertyChanged("NumberOfActiveJobs");
            }
        }
        public int NumberOfCompletedJobs
        {
            get { return _numberOfCompletedJobs; }
            set { _numberOfCompletedJobs = value;
                OnPropertyChanged("NumberOfCompletedJobs");
            }
        }
        public ObservableCollection<Contractor> TopContractors
        {
            get { return _topContractors; }
            set { _topContractors = value;
                OnPropertyChanged("TopContractors");
            }
        }
        public ObservableCollection<Job> UpcomingJobs
        {
            get { return _upcomingJobs; }
            set
            {
                _upcomingJobs = value;
                OnPropertyChanged("UpcomingJobs");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        
        public HomeViewModel()
        {
            //Number of Contractors
            Contractors contractors = new Contractors();
            NumberOfContractors = contractors.Count;

            //Number of clients
            Clients clients = new Clients();
            NumberOfClients = clients.Count;

            //Number of active jobs
            Jobs allJobs = new Jobs();
            List<Job> activeJobs = new List<Job>();
            foreach(var job in allJobs)
            {
                if (job.JobStatus != "Completed" || job.JobStatus != "Verified")
                {
                    activeJobs.Add(job);
                }
            }
            NumberOfActiveJobs = activeJobs.Count;


            //number of completed jobs
            allJobs = new Jobs();
            List<Job> completedJobs = new List<Job>();
            foreach(Job job in allJobs)
            {
                if (job.JobStatus == "Completed" || job.JobStatus == "Verified")
                {
                    completedJobs.Add(job);
                }
            }
            NumberOfCompletedJobs = completedJobs.Count;
            
            
            //top contractors
            TopContractors = GetTopContractors();


            //upcoming jobs
            //Jobs sortedJobs = new Jobs();
            //sortedJobs.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            //foreach(Job job in sortedJobs)
            //{
            //    if(job.Date > DateTime.Now)
            //    {
            //        UpcomingJobs.Add(job);
            //    }
            //}
            UpcomingJobs = GetUpcomingJobs();
        }


        public ObservableCollection<Contractor> GetTopContractors()
        {
            Contractors topContractors = new Contractors();
            topContractors.Sort();
            topContractors.Reverse();
            return new ObservableCollection<Contractor>(topContractors);
        }

        public ObservableCollection<Job> GetUpcomingJobs()
        {
            Jobs sortedJobs = new Jobs();
            List<Job> upcomingJobs = new List<Job>();
            sortedJobs.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            foreach (Job job in sortedJobs)
            {
                if (job.Date > DateTime.Now)
                {
                    upcomingJobs.Add(job);
                }
            }
            return new ObservableCollection<Job>(upcomingJobs);
        }
    }
}
