using BITServices.Model;
using BITServices.View;
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
    public class RecordManagementViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Job> _jobs;
        private ObservableCollection<Skill> _skills;
        private ObservableCollection<Client> _clients;
        private Skill _selectedSkill;
        private Client _selectedClient;
        private Job _selectedJob;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _cancelCommand;
 
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                _selectedJob = value;
                OnPropertyChanged("SelectedJob");
            }
        }
        public string SelectedItemInFilter
        {
            get { return _selectedItemInFilter; }
            set
            {
                _selectedItemInFilter = value;
                OnPropertyChanged("SelectedItemInFilter");
            }
        }
        public string SearchValue
        {
            get { return _searchValue; }
            set
            {

                _searchValue = value;
                OnPropertyChanged("SearchValue");
            }
        }
        public ObservableCollection<Job> Records
        {
            get { return _jobs; }
            set
            {
                _jobs = value;
                OnPropertyChanged("Jobs");
            }
        }
        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");

            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public RecordManagementViewModel()
        {
            LoadGrid();
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
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);
                }
                return _updateCommand;
            }
            set
            { _updateCommand = value; }
        }
        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set
            { _addCommand = value; }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(this.DeleteMethod, true);
                }
                return _deleteCommand;
            }
            set
            { _deleteCommand = value; }
        }
        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(this.SearchMethod, true);
                }
                return _searchCommand;
            }
            set
            { _searchCommand = value; }
        }
        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(this.CancelMethod, true);
                }
                return _cancelCommand;
            }
            set
            { _cancelCommand = value; }
        }


        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void UpdateMethod()
        {

            SelectedJob?.UpdateJob();
            LoadGrid();
        }
        public void AddMethod()
        {
            SelectedJob = new Job();
            LoadGrid();
            AddJobView addJobView = new AddJobView();
            addJobView.ShowDialog();
            LoadGrid();
        }
        public void DeleteMethod()
        {
            if (SelectedJob != null)
            {
                SelectedJob?.DeleteJob();
            }
            else
            {
                MessageBox.Show("Please select a Job");
            }
            LoadGrid();
        }
        public void SearchMethod()
        {
    
        }
        public void CancelMethod()
        {
            LoadGrid();
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        public void LoadGrid()
        {
            Jobs allJobs = new Jobs();
            List<Job> records = new List<Job>();
            foreach(Job job in allJobs)
            {
                if(job.JobStatusID == 6)
                {
                    records.Add(job);
                }
            }
            this.Records = new ObservableCollection<Job>(records);
        }
    }
}

