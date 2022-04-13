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
    public class ContractorAvailabilityViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Availability> _availabilities;
        private Availability _selectedAvailability;
        private Availability _newAvailability = new Availability();
        private Contractor _selectedContractor;
        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        public ObservableCollection<Availability> Availabilities
        {
            get { return _availabilities; }
            set { _availabilities = value;
                OnPropertyChanged("Availabilities");
            }
        }
        public Availability SelectedAvailability
        {
            get { return _selectedAvailability; }
            set { _selectedAvailability = value;
                OnPropertyChanged("SelectedAvailability"); 
            }
        }
        public Availability NewAvailability
        {
            get { return _newAvailability; }
            set
            {
                _newAvailability = value;
                OnPropertyChanged("NewAvailability");
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

        public ContractorAvailabilityViewModel()
        {
            Availabilities allAvailabilities = new Availabilities();
            Availabilities = new ObservableCollection<Availability>(allAvailabilities);
        }
        public ContractorAvailabilityViewModel(Contractor currentContractor)
        {
            SelectedAvailability = new Availability();
            SelectedContractor = currentContractor;
            Availabilities availabilities = new Availabilities();
            List<Availability> contractorAvailabilities = new List<Availability>();
            foreach(Availability availability in availabilities)
            {
                if(availability.ContractorID == SelectedContractor.ContractorID)
                {
                    contractorAvailabilities.Add(availability);
                }
            }
            this.Availabilities = new ObservableCollection<Availability>(contractorAvailabilities);
            OnPropertyChanged("Availabilities");
        }


        public void AddMethod()
        {
            if (NewAvailability != null)
            {
                try
                {
                    NewAvailability.ContractorID = SelectedContractor.ContractorID;
                    NewAvailability.FinishTime = new TimeSpan(19, 0, 0);
                    NewAvailability.InsertAvailability();
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Availability already exists for this date", "Cannot Add Availability");
                }
            }
            else
            {
                MessageBox.Show("Please fill in Availability details", "No availability selected");
            }

        }

        public void RemoveMethod()
        {
            if (SelectedAvailability != null)
            {
                try
                {
                    Availability selectedAvailability = new Availability();
                    selectedAvailability.StartTime = SelectedAvailability.StartTime;
                    selectedAvailability.AvailableDate = SelectedAvailability.AvailableDate;
                    selectedAvailability.ContractorID = SelectedContractor.ContractorID;
                    selectedAvailability.DeleteAvailability();
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Availability already exists for this date", "Cannot Add Availability");
                }
            }
            else
            {
                MessageBox.Show("Please fill in Availability details", "No availability selected");
            }
        }


        private void LoadGrid()
        {
            Availabilities availabilities = new Availabilities();
            List<Availability> contractorAvailabilities = new List<Availability>();
            foreach (Availability availability in availabilities)
            {
                if (availability.ContractorID == SelectedContractor.ContractorID)
                {
                    contractorAvailabilities.Add(availability);
                }
            }
            this.Availabilities = new ObservableCollection<Availability>(contractorAvailabilities);
            OnPropertyChanged("Availabilities");
        }
    }

}
