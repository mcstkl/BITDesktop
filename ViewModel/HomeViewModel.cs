using BITServices.Model;
using System;
using System.Collections.Generic;
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
        }
    }
}
