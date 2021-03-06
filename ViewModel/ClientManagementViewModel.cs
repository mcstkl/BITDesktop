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
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Client> _clients;
        private ObservableCollection<Job> _currentJobs;
        private Client _selectedClient;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _showAllCommand;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
                
                Jobs jobs = new Jobs();
                List<Job> currentJobs = new List<Job>();
                foreach(Job job in jobs)
                {
                    if (SelectedClient != null && job != null)
                    {
                        if (job.CompanyName == SelectedClient.CompanyName)
                        {
                            currentJobs.Add(job);
                        }
                    }
                }
                CurrentJobs = new ObservableCollection<Job>(currentJobs);
            
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
        public ObservableCollection<Job> CurrentJobs
        {
            get { return _currentJobs; }
            set
            {
                _currentJobs = value;
                OnPropertyChanged("CurrentJobs");
            }
        }


        /// <summary>
        /// Constructors
        /// </summary>
        public ClientManagementViewModel()
        {
            SelectedClient = new Client();
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            Jobs allJobs = new Jobs();
            this.CurrentJobs = new ObservableCollection<Job>(allJobs);
            //OnPropertyChanged("Clients");
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
        /// RelayCommands for MVVM
        /// </summary>
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
        public RelayCommand ShowAllCommand
        {
            get
            {
                if (_showAllCommand == null)
                {
                    //Remember RelayCommand is taking first parameter as Action
                    //Action is nothing but a Method. Only use the Method name
                    _showAllCommand = new RelayCommand(this.ShowAllMethod, true);
                }
                return _showAllCommand;
            }
            set
            { _showAllCommand = value; }
        }


        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void UpdateMethod()
        {
            
            SelectedClient?.UpdateClient();
            LoadGrid();
        }
        public void ShowAllMethod()
        {
            Jobs allJobs = new Jobs();
            this.CurrentJobs = new ObservableCollection<Job>(allJobs);
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
        public void CancelMethod()
        {
            LoadGrid();
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        public void LoadGrid()
        {
            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
        }
        public virtual ObservableCollection<Client> GetClients()
        {
            Clients allClients = new Clients();
            return new ObservableCollection<Client>(allClients);

        }
    }
}

