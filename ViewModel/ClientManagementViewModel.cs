using BITServices.DAL;
using BITServices.Model;
using BITServices.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BITServices.ViewModel
{
    public class ClientManagementViewModel : INotifyPropertyChanged
    {

        // --------------------- FIELDS -------------------------
        // ------------------------------------------------------
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        // ------------------------------------------------------


        // ---------------------- PROPS -------------------------
        // ------------------------------------------------------
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
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
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        // -------------------------------------------------------


        // ------------------- CONSTRUCTOR -----------------------
        // -------------------------------------------------------
        public ClientManagementViewModel()
        {
            SelectedClient = new Client();
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            //OnPropertyChanged("Clients");
        }
        // -------------------------------------------------------





        // ----------------- PROPCHANGED BP ---------------------
        // ------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        // ------------------------------------------------------


        // ------------------- RELAY BOILERPLATE -------------------
        // ---------------------------------------------------------

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
        // ----------------------------------------------------------




        // --------------------- METHODS --------------------------
        // --------------------------------------------------------
        public void UpdateMethod()
        {
            
            SelectedClient?.UpdateClient();
            LoadGrid();
        }

        private void Window1_DataChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Client Added", "Client Added");
        }
        public void AddMethod()
        {
            //SelectedClient = new Client();
            //LoadGrid();
            AddClientView addClientView = new AddClientView();
            addClientView.DataChanged += Window1_DataChanged;
            addClientView.ShowDialog();
            LoadGrid();
        }
        public void DeleteMethod()
        {
            if(SelectedClient != null)
            {
                SelectedClient?.DeleteClient();
            }
            else
            {
                MessageBox.Show("Please select a client");
            }
            LoadGrid();
        }
        public void SearchMethod()
        {
            string selectedSearch = SelectedItemInFilter.ToString();

            Clients allClients = new Clients();
            Clients searchedClients = new Clients();
            searchedClients.Clear();
            if (string.IsNullOrEmpty(SearchValue.ToString()))
            {
                LoadGrid();
                return;
            }
            foreach (Client client in allClients)
            {
                switch (selectedSearch)
                {
                    case "Company":
                        if (client.CompanyName.StartsWith(SearchValue))
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case "Phone":
                        if (client.Phone.StartsWith(SearchValue))
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    case "Postcode":
                        if (client.PostCode.StartsWith(SearchValue))
                        {
                            searchedClients.Add(client);
                        }
                        break;
                    default:
                        return;
                }
            }
  
            if (searchedClients.Count == 0)
            {
                this.Clients.Clear();
                MessageBox.Show("No results found.");
                return;
            }

            else if (searchedClients.Count > 0)
            {
                this.Clients = new ObservableCollection<Client>(searchedClients);
            }
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
            LoadGrid();
        }
        public void CancelMethod()
        {
            LoadGrid();
        }
        // ---------------------------------------------------------





        // ------------------------ HELPERS -------------------------
        // ----------------------------------------------------------
        public void LoadGrid()
        {
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
        }

        // ----------------------------------------------------------

    }
}

