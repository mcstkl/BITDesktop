using BITServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
