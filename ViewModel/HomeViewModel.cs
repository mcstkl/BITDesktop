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
            set { _contractorOne = value;
                OnPropertyChanged("ContractorTwo");
            }
        }
        public Contractor ContractorThree
        {
            get { return _topContractors[2]; }
            set { _contractorOne = value;
                OnPropertyChanged("ContractorThree");
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
            Contractors contractors = new Contractors();
            NumberOfContractors = contractors.Count;

            Clients clients = new Clients();
            NumberOfClients = clients.Count;

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
            TopContractors = GetTopContractors();
        }


        public ObservableCollection<Contractor> GetTopContractors()
        {
            Contractors topContractors = new Contractors();
            topContractors.Sort();
            topContractors.Reverse();
            return new ObservableCollection<Contractor>(topContractors);
        }

 
    }
}
