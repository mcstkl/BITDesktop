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
    public class AddClientViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;

        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

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
        /// Constructor
        /// </summary>
        public AddClientViewModel()
        {
            SelectedClient = new Client();
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            OnPropertyChanged("Clients");
        }

        /// <summary>
        /// RelayCommands for MVVM
        /// </summary>
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

        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void SaveMethod()
        {
            try
            {
                SelectedClient.InsertClient();

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save Client. Please fill in complete client details.", "Unable to Save Client", MessageBoxButton.OK, MessageBoxImage.Error);
            }
      
        }
        public void CancelMethod()
        {
            LoadGrid();
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        private void LoadGrid()
        {
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
        }


    }
}
