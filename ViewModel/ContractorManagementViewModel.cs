﻿using BITServices.Model;
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
        ////list class in C# that listens to the events
        ////OverservableCollection<T>

        //private ObservableCollection<Contractor> _Contractors;
        //private Contractor _selectedContractor;
        ////private ObservableCollection<Skill> _skills;


        //private RelayCommand _updateCommand;

        //public event PropertyChangedEventHandler PropertyChanged;

        //public RelayCommand UpdateCommand
        //{
        //    get
        //    {
        //        if (_updateCommand == null)
        //        {
        //            //Remember RelayCommand is taking first parameter as Action
        //            //Action is nothing but a Method. Only use the Method name
        //            _updateCommand = new RelayCommand(this.UpdateMethod, true);
        //        }
        //        return _updateCommand;
        //    }
        //    set
        //    { _updateCommand = value; }
        //}
        //public void UpdateMethod()
        //{
        //    SelectedContractor.UpdateContractor();
        //    MessageBox.Show("Contractor Updated");
        //}


        //private void OnPropertyChanged(string prop)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //    }
        //}
        //public Contractor SelectedContractor
        //{
        //    get { return _selectedContractor; }
        //    set
        //    {
        //        _selectedContractor = value;
        //        OnPropertyChanged("SelectedContractor");
        //        //Skills allSkills = new Skills(SelectedContractor.ContractorID);
        //        //this.Skills = new ObservableCollection<Skill>(allSkills);
        //    }
        //}

        //public ObservableCollection<Contractor> Contractors
        //{
        //    get { return _Contractors; }
        //    set { _Contractors = value; }
        //}
        ////public ObservableCollection<Skill> Skills
        ////{
        ////    get { return _skills; }
        ////    set
        ////    {
        ////        _skills = value;
        ////        OnPropertyChanged("Skills");
        ////    }
        ////}


        //public ContractorManagementViewModel()
        //{
        //    Contractors allContractors = new Contractors();
        //    this.Contractors = new ObservableCollection<Contractor>(allContractors);

        //}



        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;


        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
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
        public event PropertyChangedEventHandler PropertyChanged;

        public ContractorManagementViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            OnPropertyChanged("Contractors");
        }

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
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
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
                    _cancelCommand = new RelayCommand(this.CancelMethod, true);
                }
                return _cancelCommand;
            }
            set
            { _cancelCommand = value; }
        }



        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public void UpdateMethod()
        {
            SelectedContractor.UpdateContractor();
        }
        public void AddMethod()
        {
            SelectedContractor = new Contractor();
            this.Contractors.Add(SelectedContractor);
        }
        public void DeleteMethod()
        {
            SelectedContractor?.DeleteContractor();
            this.Contractors.Remove(SelectedContractor);
        }
        public void SearchMethod()
        {
            MessageBox.Show("Searching Contractor");
        }
        public void SaveMethod()
        {
            try
            {
                SelectedContractor.InsertContractor();

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save Contractor. Please fill in complete Contractor details.", "Unable to Save Contractor", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void CancelMethod()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }
    }
}

