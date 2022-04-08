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
        private ObservableCollection<ContractorSkill> _skills;
        private Contractor _selectedContractor;
        private ObservableCollection<ContractorSkill> _contractorSkills;

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        public ObservableCollection<ContractorSkill> Skills
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


        public ContractorSkillsViewModel()
        {
            ContractorSkills skills = new ContractorSkills();
            this.Skills = new ObservableCollection<ContractorSkill>(skills);
            OnPropertyChanged("Skills");
        }
        public ContractorSkillsViewModel(Contractor currentContractor)
        {
            SelectedContractor = currentContractor;
            ContractorSkills skills = new ContractorSkills();
            this.Skills = new ObservableCollection<ContractorSkill>(skills);
            ContractorSkills contractorSkills = new ContractorSkills(SelectedContractor.ContractorID);
            this.ContractorSkills = new ObservableCollection<ContractorSkill>(contractorSkills);
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

