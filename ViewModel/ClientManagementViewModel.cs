using BITServices.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.ViewModel
{
    public class ClientManagementViewModel : INotifyPropertyChanged
    {
        //list class in C# that listens to the events
        //OverservableCollection<T>

        private ObservableCollection<Client> _clients;
        private Client _selectedClient;


        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ClientManagementViewModel()
        {
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            OnPropertyChanged("Clients");
        }

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
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
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



        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public void UpdateMethod()
        {
            SelectedClient.UpdateClient();
        }
        public void AddMethod()
        {
            SelectedClient = new Client();
            this.Clients.Add(SelectedClient);
        }
        public void DeleteMethod()
        {
            SelectedClient?.DeleteClient();
            this.Clients.Remove(SelectedClient);
        }
        public void SearchMethod()
        {
            MessageBox.Show("Searching client");
        }
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
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
        }
    }
}
