using BITServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.ViewModel
{
    public class JobAssignViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private Job _selectedJob;
        private ObservableCollection<Contractor> _contractors;
        private Decimal _selectedPayRate;
        private Decimal _selectedRating;
        private ObservableCollection<Contractor> _filteredContractors;
        private ObservableCollection<Contractor> _skilledContractors;
        private Contractor _selectedContractor;

        private RelayCommand _assignCommand;
        private RelayCommand _refreshCommand;

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
        public ObservableCollection<Contractor> SkilledContractors
        {
            get { return _skilledContractors; }
            set
            {
                _skilledContractors = value;
                OnPropertyChanged("SkilledContractors");
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


        /// <summary>
        /// OnPropertyChanged Boilerplate
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        /// <summary>
        /// RelayCommands for MVVM
        /// </summary>
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


        /// <summary>
        /// Constructor
        /// </summary>
        public JobAssignViewModel()
        {

        }
        public JobAssignViewModel(Job selectedJob)
        {
            //Contractors contractors = new Contractors();
            //this.Contractors = new ObservableCollection<Contractor>(contractors);
            SelectedJob = selectedJob;
            LoadSkilledContractors();
        }


        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void AssignMethod()
        {
            if (SelectedJob != null)
            {
                if (SelectedJob.ContractorID == 0)
                {
                    try
                    {
                        SelectedJob.ContractorID = SelectedContractor.ContractorID;
                        SelectedJob.JobStatusID = 2;
                        SelectedJob.UpdateJobStatus();
                        MessageBox.Show("Contractor assigned to job", "Contractor assigned", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot Assign Job", "Cannot Assign Job", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This Job is already assigned to a contractor", "Job is already assigned", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void RefreshMethod()
        {
            LoadSkilledContractors();
            List<Contractor> filteredContractors = new List<Contractor>();
            foreach (Contractor contractor in this.SkilledContractors)
            {
                if (SelectedPayRate >= contractor.PayRate && SelectedRating <= contractor.ContractorRating)
                {
                    filteredContractors.Add(contractor);
                }
            }
            this.SkilledContractors = new ObservableCollection<Contractor>(filteredContractors);
        }
        public void LoadSkilledContractors()
        {
            Contractors skilledContractors = new Contractors(SelectedJob.JobID);
            this.SkilledContractors = new ObservableCollection<Contractor>(skilledContractors);
        }
    }
}
