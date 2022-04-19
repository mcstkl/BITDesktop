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
    public class JobManagementViewModel : INotifyPropertyChanged
    {
        // --------------------- FIELDS -------------------------
        // ------------------------------------------------------
        private ObservableCollection<Job> _jobs;
        private ObservableCollection<Skill> _skills;
        private Skill _selectedSkill;
        private Job _selectedJob;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        //private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _verifyCommand;
        private RelayCommand _assignCommand;
        // ------------------------------------------------------


        // ---------------------- PROPS -------------------------
        // ------------------------------------------------------
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
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }
        // -------------------------------------------------------


        // ------------------- CONSTRUCTOR -----------------------
        // -------------------------------------------------------
        public JobManagementViewModel()
        {
            SelectedJob = new Job();
            Jobs allJobs = new Jobs();
            this.Jobs = new ObservableCollection<Job>(allJobs);
            Skills allSkills = new Skills();
            this.Skills = new ObservableCollection<Skill>(allSkills);
            SelectedSkill = new Skill(SelectedJob.SkillName);
            //OnPropertyChanged("Jobs");
            
        }
        // -------------------------------------------------------





        // ----------------- PROPCHANGED BP ---------------------
        // ------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        // ------------------------------------------------------


        // ------------------- RELAY BOILERPLATE -------------------
        // ---------------------------------------------------------

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
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _cancelCommand = new RelayCommand(this.CancelMethod, true);
                }
                return _cancelCommand;
            }
            set
            { _cancelCommand = value; }
        }
        public RelayCommand VerifyCommand
        {
            get
            {
                if (_verifyCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _verifyCommand = new RelayCommand(this.VerifyMethod, true);
                }
                return _verifyCommand;
            }
            set
            { _verifyCommand = value; }
        }
        public RelayCommand AssignCommand
        {
            get
            {
                if (_assignCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _assignCommand = new RelayCommand(this.AssignMethod, true);
                }
                return _assignCommand;
            }
            set
            { _assignCommand = value; }
        }
        // ----------------------------------------------------------




        // --------------------- METHODS --------------------------
        // --------------------------------------------------------
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
            //string selectedSearch = SelectedItemInFilter.ToString();

            //Jobs allJobs = new Jobs();
            //Jobs searchedJobs = new Jobs();
            //searchedJobs.Clear();
            //if (string.IsNullOrEmpty(SearchValue.ToString()))
            //{
            //    LoadGrid();
            //    return;
            //}
            //foreach (Job Job in allJobs)
            //{
            //    switch (selectedSearch)
            //    {
            //        case "Company":
            //            if (Job.CompanyName.StartsWith(SearchValue))
            //            {
            //                searchedJobs.Add(Job);
            //            }
            //            break;
            //        case "Phone":
            //            if (Job.Phone.StartsWith(SearchValue))
            //            {
            //                searchedJobs.Add(Job);
            //            }
            //            break;
            //        case "Postcode":
            //            if (Job.PostCode.StartsWith(SearchValue))
            //            {
            //                searchedJobs.Add(Job);
            //            }
            //            break;
            //        default:
            //            return;
            //    }
            //}

            //if (searchedJobs.Count == 0)
            //{
            //    this.Jobs.Clear();
            //    MessageBox.Show("No results found.");
            //    return;
            //}

            //else if (searchedJobs.Count > 0)
            //{
            //    this.Jobs = new ObservableCollection<Job>(searchedJobs);
            //}
        }
        public void CancelMethod()
        {
            LoadGrid();
        }
        public void VerifyMethod()
        {
            if(SelectedJob.JobStatus == "Completed")
            {
                SelectedJob.JobStatusID = 6;
                SelectedJob.UpdateJob();
                LoadGrid();
            }
            else if ( SelectedJob.JobStatus == "Verified")
            {
                MessageBox.Show("Job has already been verified", "Cannot verify job");
            }
            else
            {
                MessageBox.Show("Job has not yet been completed", "Cannot verify job");
            }

        }
        public void AssignMethod()
        {
            if (SelectedJob != null)
            {
                JobAssignView assignView = new JobAssignView(SelectedJob);
                assignView.ShowDialog();
                LoadGrid();
            }
            else
            {
                MessageBox.Show("Please select a job to assign");
            }
        }
        // ---------------------------------------------------------





        // ------------------------ HELPERS -------------------------
        // ----------------------------------------------------------
        public void LoadGrid()
        {
            Jobs allJobs = new Jobs();
            this.Jobs = new ObservableCollection<Job>(allJobs);
        }

        // ----------------------------------------------------------


    }
}
