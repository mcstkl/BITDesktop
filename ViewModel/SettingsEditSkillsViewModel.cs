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
    public class SettingsEditSkillsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Skill> _skills;
        private Skill _selectedSkill;
        private Skill _newSkill = new Skill();



        private RelayCommand _saveCommand;
        private RelayCommand _removeCommand;

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
        public Skill NewSkill
        {
            get { return _newSkill; }
            set
            {
                _newSkill = value;
                OnPropertyChanged("NewSkill");
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

        public SettingsEditSkillsViewModel()
        {
            SelectedSkill = new Skill();
            Skills allSkills = new Skills();
            this.Skills = new ObservableCollection<Skill>(allSkills);
            OnPropertyChanged("Skills");
        }


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


        public void SaveMethod()
        {
            try
            {
                
                NewSkill.InsertSkill();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not save. Skill already exists.", "Unable to Save Skill", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadGrid();

        }
        public void RemoveMethod()
        {
            
            try
            {
                SelectedSkill?.DeleteSkill();

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save Skill. Please fill in complete Skill details.", "Unable to Save Skill", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadGrid();
        }


        private void LoadGrid()
        {
            Skills allSkills = new Skills();
            this.Skills = new ObservableCollection<Skill>(allSkills);
        }


    }
}
