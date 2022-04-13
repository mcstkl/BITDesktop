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
    public class JobAssignViewModel : INotifyPropertyChanged
    {

        private Job _selectedJob;
        private ObservableCollection<Contractor> _contractors;
        private Decimal _selectedPayRate;
        private Decimal _selectedRating;
        private ObservableCollection<Contractor> _filteredContractors;
        private Contractor _selectedContractor;

        private RelayCommand _assignCommand;
        private RelayCommand _refreshCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
            }
        }
        public ObservableCollection<Contractor> FilteredContractors
        {
            get { return _filteredContractors; }
            set
            {
                _filteredContractors = value;
                OnPropertyChanged("FilteredContractors");
            }
        }
        public Job SelectedJob { get { return _selectedJob; } set { _selectedJob = value; } }
        public Decimal SelectedPayRate
        {
            get { return _selectedPayRate; }
            set
            {
                _selectedPayRate = value;
                OnPropertyChanged("SelectedPayRate");
            }
        }
        public Decimal SelectedRating
        {
            get { return _selectedRating; }
            set
            {
                _selectedRating = value;
                OnPropertyChanged("SelectedRating");
            }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }



        public RelayCommand AssignCommand
        {
            get
            {
                if (_assignCommand == null)
                {
                    _assignCommand = new RelayCommand(this.AssignMethod, true);
                }
                return _assignCommand;
            }
            set
            { _assignCommand = value; }
        }
        public RelayCommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(this.RefreshMethod, true);
                }
                return _refreshCommand;
            }
            set
            { _refreshCommand = value; }
        }


        public JobAssignViewModel()
        {

        }
        public JobAssignViewModel(Job selectedJob)
        {
            Contractors contractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(contractors);

            SelectedJob = selectedJob;
        }


        public void AssignMethod()
        {
            SelectedJob.ContractorID = SelectedContractor.ContractorID;
            SelectedJob.JobStatusID = 2;
            SelectedJob.UpdateJob();
        }

        public void RefreshMethod()
        {
            Contractors allContractors = new Contractors();
            ObservableCollection<Contractor> AllContractors = new ObservableCollection<Contractor>(allContractors);
            List<Contractor> filteredContractors = new List<Contractor>();
            foreach (Contractor contractor in AllContractors)
            {
                if (SelectedPayRate >= contractor.PayRate && SelectedRating <= contractor.ContractorRating)
                {
                    filteredContractors.Add(contractor);
                }
            }
            this.Contractors = new ObservableCollection<Contractor>(filteredContractors);
        }
    }
}
