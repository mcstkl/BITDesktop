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
    public class CustomerManagementViewModel : INotifyPropertyChanged
    {
        //list class in C# that listens to the events
        //OverservableCollection<T>

        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        //private ObservableCollection<Product> _products;


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
            SelectedCustomer.UpdateCustomer();
            MessageBox.Show("Customer Updated");
        }


        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
                //Products allProducts = new Products(SelectedCoordinator.CategoryID);
                //this.Products = new ObservableCollection<Product>(allProducts);
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }


        //public ObservableCollection<Product> Products
        //{
        //    get { return _products; }
        //    set
        //    {
        //        _products = value;
        //        OnPropertyChanged("Products");
        //    }
        //}


        public CustomerManagementViewModel()
        {
            Customers allCustomers = new Customers();
            this.Customers = new ObservableCollection<Customer>(allCustomers);

        }
    }
}
