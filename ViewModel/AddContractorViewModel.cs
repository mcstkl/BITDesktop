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
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BITServices.ViewModel
{
    public class AddContractorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;


        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public AddContractorViewModel()
        {
            SelectedContractor = new Contractor();
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            //OnPropertyChanged("Contractors");
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
            LoadGrid();
        }


        private void LoadGrid()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }


    }
}
