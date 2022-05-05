using BITServices.Model;
using BITServices.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.ViewModel
{
    public class StaffManagementViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Staff> _staffs;
        private Staff _selectedStaff;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _loginsCommand;

        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set
            {
                _selectedStaff = value;
                OnPropertyChanged("SelectedStaff");
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
        public ObservableCollection<Staff> Staffs
        {
            get { return _staffs; }
            set
            {
                _staffs = value;
                OnPropertyChanged("Staffs");
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
        public StaffManagementViewModel()
        {
            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
            OnPropertyChanged("Staffs");
        }

        /// <summary>
        /// Relay Commands for MVVM
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
        public RelayCommand LoginsCommand
        {
            get
            {
                if (_loginsCommand == null)
                {
                    _loginsCommand = new RelayCommand(this.LoginsMethod, true);
                }
                return _loginsCommand;
            }
            set
            { _loginsCommand = value; }
        }


        /// <summary>
        /// MVVM Methods
        /// </summary>
        public void UpdateMethod()
        {
            SelectedStaff.UpdateStaff();
        }
        private void Window1_DataChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Client Added", "Client Added");
        }
        public void AddMethod()
        {
            AddStaffView addStaffView = new AddStaffView();
            addStaffView.DataChanged += Window1_DataChanged;
            addStaffView.ShowDialog();
            LoadGrid();
        }
        public void DeleteMethod()
        {
            SelectedStaff?.DeleteStaff();
            this.Staffs.Remove(SelectedStaff);
        }
        public void SearchMethod()
        {
            string selectedSearch = SelectedItemInFilter.ToString();

            Staffs allStaffs = new Staffs();
            Staffs searchedStaffs = new Staffs();
            searchedStaffs.Clear();
            foreach (Staff Staff in allStaffs)
            {
                switch (selectedSearch)
                {
                    case "Firstname":
                        if (Staff.FirstName.StartsWith(SearchValue))
                        {
                            searchedStaffs.Add(Staff);
                        }
                        break;
                    case "Lastname":
                        if (Staff.LastName.StartsWith(SearchValue))
                        {
                            searchedStaffs.Add(Staff);
                        }
                        break;
                    case "Staff Type":
                        if (Staff.StaffType.StartsWith(SearchValue))
                        {
                            searchedStaffs.Add(Staff);
                        }
                        break;
                    case "Phone":
                        if (Staff.Phone.StartsWith(SearchValue))
                        {
                            searchedStaffs.Add(Staff);
                        }
                        break;
                    case "Email":
                        if (Staff.Email.StartsWith(SearchValue))
                        {
                            searchedStaffs.Add(Staff);
                        }
                        break;
                    default:
                        return;
                }
            }
            if (SearchValue.ToString() == "")
            {
                LoadGrid();
            }
            else if (searchedStaffs.Count == 0)
            {
                this.Staffs.Clear();
                MessageBox.Show("No results found.");
            }

            else if (searchedStaffs.Count > 0)
            {
                this.Staffs = new ObservableCollection<Staff>(searchedStaffs);
            }
        }
        public void SaveMethod()
        {
            try
            {
                SelectedStaff.InsertStaff();

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save Staff. Please fill in complete Staff details.", "Unable to Save Staff", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void CancelMethod()
        {
            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
        }
        public void LoginsMethod()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            List<string> allLinesText = File.ReadAllLines(fileName).ToList();
            List<string> allUserLogins = new List<string>();
            foreach (string line in allLinesText)
            {
                if (line.Contains(SelectedStaff.UserName))
                {
                    allUserLogins.Add(line);
                }
            }
            allUserLogins.Reverse();

            string lastUserLogins = string.Empty;
            int numberOfLogins = 10;
            if(allUserLogins.Count < numberOfLogins)
            {
                numberOfLogins = allUserLogins.Count;
            }
            for(int i = 0; i < numberOfLogins; i++)
            {
                    lastUserLogins += allUserLogins[i] + "\n";
            }



            if (string.IsNullOrEmpty(lastUserLogins))
            {
                MessageBox.Show("No Logins for this user", "No Logins", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(lastUserLogins, "Last 10 Logins for " + SelectedStaff.FirstName + " " + SelectedStaff.LastName, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        private void LoadGrid()
        {
            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
        }

    }
}

