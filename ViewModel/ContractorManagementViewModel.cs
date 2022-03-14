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
    public class ContractorManagementViewModel : INotifyPropertyChanged
    {
        //list class in C# that listens to the events
        //OverservableCollection<T>

        private ObservableCollection<Contractor> _Contractors;
        private Contractor _selectedContractor;
        //private ObservableCollection<Skill> _skills;


        private RelayCommand _updateCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);
                }
                return _updateCommand;
            }
            set
            { _updateCommand = value; }
        }
        public void UpdateMethod()
        {
            SelectedContractor.UpdateContractor();
            MessageBox.Show("Contractor Updated");
        }


        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
                //Skills allSkills = new Skills(SelectedContractor.ContractorID);
                //this.Skills = new ObservableCollection<Skill>(allSkills);
            }
        }

        public ObservableCollection<Contractor> Contractors
        {
            get { return _Contractors; }
            set { _Contractors = value; }
        }
        //public ObservableCollection<Skill> Skills
        //{
        //    get { return _skills; }
        //    set
        //    {
        //        _skills = value;
        //        OnPropertyChanged("Skills");
        //    }
        //}


        public ContractorManagementViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);

        }
    }
}
