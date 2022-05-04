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
        public class AvailabilityManagementViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Availability> _availabilities;
            private Availability _selectedAvailability;
            public string _selectedItemInFilter = string.Empty;
            public string _searchValue = string.Empty;

            private RelayCommand _updateCommand;
            private RelayCommand _addCommand;
            private RelayCommand _deleteCommand;
            private RelayCommand _searchCommand;
            private RelayCommand _saveCommand;
            private RelayCommand _cancelCommand;

            public AvailabilityManagementViewModel()
            {
                SelectedAvailability = new Availability();
                Availabilities allAvailabilities = new Availabilities();
                this.Availabilities = new ObservableCollection<Availability>(allAvailabilities);
                OnPropertyChanged("Availabilities");
            }

        public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string prop)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
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

        public Availability SelectedAvailability
            {
                get { return _selectedAvailability; }
                set
                {
                    _selectedAvailability = value;
                    OnPropertyChanged("SelectedAvailability");
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
            public ObservableCollection<Availability> Availabilities
            {
                get { return _availabilities; }
                set
                {
                    _availabilities = value;
                    OnPropertyChanged("Availabilities");
                }
            }
            

        public void SearchMethod()
        {
            string selectedSearch = SelectedItemInFilter.ToString();

            Availabilities allAvailabilities = new Availabilities();
            Availabilities searchedAvailabilities = new Availabilities();
            searchedAvailabilities.Clear();
            if (string.IsNullOrEmpty(SearchValue.ToString()))
            {
                LoadGrid();
                return;
            }
            foreach (Availability availability in allAvailabilities)
            {
                switch (selectedSearch)
                {
                    case "Date":
                        if (availability.AvailableDate.Contains(SearchValue))
                        {
                            searchedAvailabilities.Add(availability);
                        }
                        break;
                    case "Contractor":
                        if (availability.FullName.Contains(SearchValue))
                        {
                            searchedAvailabilities.Add(availability);
                        }
                        break;
                    default:
                        return;
                }
            }

            if (searchedAvailabilities.Count == 0)
            {
                this.Availabilities.Clear();
                MessageBox.Show("No results found.");
                return;
            }

            else if (searchedAvailabilities.Count > 0)
            {
                this.Availabilities = new ObservableCollection<Availability>(searchedAvailabilities);
            }
        }

        public void LoadGrid()
        {
            Availabilities allAvailabilities = new Availabilities();
            this.Availabilities = new ObservableCollection<Availability>(allAvailabilities);
        }

    }
}
