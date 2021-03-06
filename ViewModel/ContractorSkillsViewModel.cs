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
    public class ContractorSkillsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Skill> _skills;
        private Contractor _selectedContractor;
        private Skill _selectedSkill;
        private ContractorSkill _selectedContractorSkill;
        private ObservableCollection<ContractorSkill> _contractorSkills;

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        public ContractorSkill SelectedContractorSkill
        {
            get { return _selectedContractorSkill; }
            set
            {
                _selectedContractorSkill = value;
                OnPropertyChanged("SelectedContractorSkill");
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
        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }
        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get { return _contractorSkills; }
            set
            {
                _contractorSkills = value;
                OnPropertyChanged("ContractorSkills");
            }
        }

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;


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
        /// Constructors
        /// </summary>
        public ContractorSkillsViewModel()
        {
            Skills skills = new Skills();
            this.Skills = new ObservableCollection<Skill>(skills);
            OnPropertyChanged("Skills");
        }
        public ContractorSkillsViewModel(Contractor currentContractor)
        {
            SelectedContractor = currentContractor;
            Skills skills = new Skills();
            this.Skills = new ObservableCollection<Skill>(skills);
            ContractorSkills contractorSkills = new ContractorSkills(SelectedContractor.ContractorID);
            this.ContractorSkills = new ObservableCollection<ContractorSkill>(contractorSkills);
            OnPropertyChanged("Skills");
        }


        /// <summary>
        /// RelayCommands for MVVM
        /// </summary>
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
        public RelayCommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _removeCommand = new RelayCommand(this.RemoveMethod, true);
                }
                return _removeCommand;
            }
            set
            { _removeCommand = value; }
        }

        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void AddMethod()
        {
            if(SelectedSkill != null)
            {
                try
                {
                    ContractorSkill selectedContractorSkill = new ContractorSkill();
                    selectedContractorSkill.ContractorID = SelectedContractor.ContractorID;
                    selectedContractorSkill.SkillName = SelectedSkill.SkillName;
                    selectedContractorSkill.InsertSkill();
                    LoadGrid();
                }catch (Exception ex)
                {
                    MessageBox.Show("Skill already exists for this contractor", "Can not Add Skill", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a skill", "No skill selected");
            }

        }
        public void RemoveMethod()
        {
            if (SelectedContractorSkill != null)
            {

                try
                {
                    SelectedContractorSkill.DeleteSkill();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not remove skill.", "Unable to remove skill", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                LoadGrid();
            }
            else
            {
                MessageBox.Show("Please select a skill to remove");
            }
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        private void LoadGrid()
        {
            ContractorSkills allSkills = new ContractorSkills(SelectedContractor.ContractorID);
            this.ContractorSkills = new ObservableCollection<ContractorSkill>(allSkills);
        }
    }
}

