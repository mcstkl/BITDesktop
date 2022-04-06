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
        private ObservableCollection<Skill> _skills;
        private Contractor _selectedContractor;
        private ObservableCollection<Skill> _contractorSkills;

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
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
        public ObservableCollection<Skill> ContractorSkills
        {
            get { return _contractorSkills; }
            set
            {
                _contractorSkills = value;
                OnPropertyChanged("ContractorSkills");
            }
        }


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
            this.ContractorSkills = new ObservableCollection<Skill>(contractorSkills);
            OnPropertyChanged("Skills");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

