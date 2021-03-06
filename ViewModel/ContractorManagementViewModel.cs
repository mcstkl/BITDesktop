using BITServices.Model;
using BITServices.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITServices.ViewModel
{
    public class ContractorManagementViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fields and Properties
        /// </summary>
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;
        public string _selectedItemInFilter = string.Empty;
        public string _searchValue = string.Empty;

        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _skillsCommand;
        private RelayCommand _availabilitiesCommand;

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }
        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
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
        public ContractorManagementViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            OnPropertyChanged("Contractors");
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
        public RelayCommand SkillsCommand
        {
            get
            {
                if (_skillsCommand == null)
                {
                    _skillsCommand = new RelayCommand(this.SkillsMethod, true);
                }
                return _skillsCommand;
            }
            set
            { _skillsCommand = value; }
        }
        public RelayCommand AvailabilitiesCommand
        {
            get
            {
                if (_availabilitiesCommand == null)
                {
                    _availabilitiesCommand = new RelayCommand(this.AvailabilitiesMethod, true);
                }
                return _availabilitiesCommand;
            }
            set
            { _availabilitiesCommand = value; }
        }


        /// <summary>
        /// MVVM Methods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window1_DataChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Contractor Added", "Contractor Added", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void AddMethod()
        {
            //SelectedContractor = new Contractor();
            //this.Contractors.Add(SelectedContractor);
            AddContractorView addContractorView = new AddContractorView();
            addContractorView.DataChanged += Window1_DataChanged;
            addContractorView.ShowDialog();
            LoadGrid();
        }
        public void DeleteMethod()
        {
            SelectedContractor?.DeleteContractor();
            this.Contractors.Remove(SelectedContractor);
        }
        public void SearchMethod()
        {
            string selectedSearch = SelectedItemInFilter.ToString();

            Contractors allContractors = new Contractors();
            Contractors searchedContractors = new Contractors();
            searchedContractors.Clear();
            if (string.IsNullOrEmpty(SearchValue))
            {
                LoadGrid();
                return;
            }
            foreach (Contractor contractor in allContractors)
            {
                switch (selectedSearch)
                {
                    case "Firstname":
                        if (contractor.FirstName.StartsWith(SearchValue))
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    case "Lastname":
                        if (contractor.LastName.StartsWith(SearchValue))
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    case "Payrate":
                        bool isPayrateNumber = Decimal.TryParse(SearchValue.ToString(), out Decimal payrate);
                        if (isPayrateNumber && contractor.PayRate <= payrate)
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    case "Rating":
                        bool isRatingNumber = Decimal.TryParse(SearchValue.ToString(), out Decimal rating);
                        if (isRatingNumber && contractor.ContractorRating >= rating)
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    case "Phone":
                        if (contractor.Phone.StartsWith(SearchValue))
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    case "Email":
                        if (contractor.Email.StartsWith(SearchValue))
                        {
                            searchedContractors.Add(contractor);
                        }
                        break;
                    default:
                        return;
                }
            }
    
            if (searchedContractors.Count == 0)
            {
                this.Contractors.Clear();
                MessageBox.Show("No results found.");
            }

            else if (searchedContractors.Count > 0)
            {
                this.Contractors = new ObservableCollection<Contractor>(searchedContractors);
            }
        }
        public void CancelMethod()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }
        public void UpdateMethod()
        {
            SelectedContractor.UpdateContractor();
        }
        public void SkillsMethod()
        {
            if(SelectedContractor != null)
            {
                ContractorSkillsView skillsView = new ContractorSkillsView(SelectedContractor);
                //skillsView.DataChanged += Window1_DataChanged;
                skillsView.ShowDialog();
                LoadGrid();
            }
            else
            {
                MessageBox.Show("Please select a contractor to view skills");
            }
        }
        public void AvailabilitiesMethod()
        {
            if (SelectedContractor != null)
            {
                ContractorAvailabilityView contractorAvailabilityView = new ContractorAvailabilityView(SelectedContractor);
                contractorAvailabilityView.ShowDialog();
                LoadGrid();
            }
            else
            {
                MessageBox.Show("Please select a contractor to view availabilities");
            }
        }


        /// <summary>
        /// HELPER Methods
        /// </summary>
        private void LoadGrid()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }

        public virtual ObservableCollection<Contractor> GetContractors()
        {
            Contractors allContractors = new Contractors();
            return new ObservableCollection<Contractor>(allContractors);

        }

    }
}

