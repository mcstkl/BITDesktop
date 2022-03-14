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
    public class ClientManagementViewModel : INotifyPropertyChanged
    {
        //list class in C# that listens to the events
        //OverservableCollection<T>

        private ObservableCollection<Client> _clients;
        private Client _selectedClient;


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
            SelectedClient.UpdateClient();
            MessageBox.Show("Client Updated");
        }


        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }



        public ClientManagementViewModel()
        {
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);

        }
    }
}
