using BITServices.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace BITServices.ViewModel
{
    public class AddJobViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private Client _selectedClient;
        private Job _selectedJob;
        private Skill _selectedSkill;
        private ObservableCollection<Client> _clients;
        private ObservableCollection<Job> _jobs;
        private ObservableCollection<Skill> _skills;

        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public ObservableCollection<Job> Jobs
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

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                _selectedJob = value;
                OnPropertyChanged("SelectedJob");
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
        /// Constructor
        /// </summary>
        public AddJobViewModel()
        {
            SelectedClient = new Client();
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            SelectedJob = new Job();
            Jobs allJobs = new Jobs();
            this.Jobs = new ObservableCollection<Job>(allJobs);
            SelectedSkill = new Skill();
            Skills allSkills = new Skills();
            this.Skills = new ObservableCollection<Skill>(allSkills);
            OnPropertyChanged("Jobs");
        }


        /// <summary>
        /// RelayCommands for MVVM
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _saveCommand = new RelayCommand(this.SaveMethod, true);
                }
                return _saveCommand;
            }
            set
            { _saveCommand = value; }
        }
        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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
        public void SaveMethod()
        {
            try
            {
                SelectedJob.CompanyName = SelectedClient.CompanyName;
                SelectedJob.ClientID = SelectedClient.ClientID;
                SelectedJob.SkillName = SelectedSkill.SkillName;
                SelectedJob.AddNewJob();

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save Client. Please fill in complete client details.", "Unable to Save Client", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void CancelMethod()
        {
        }


    }
}
