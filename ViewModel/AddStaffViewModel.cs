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
    public class AddStaffViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Staff> _staffs;
        private Staff _selectedStaff;


        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public ObservableCollection<Staff> Staffs
        {
            get { return _staffs; }
            set
            {
                _staffs = value;
                OnPropertyChanged("Staffs");
            }
        }
        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set
            {
                _selectedStaff = value;
                OnPropertyChanged("SelectedStaff");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public AddStaffViewModel()
        {
            SelectedStaff = new Staff();
            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
            //OnPropertyChanged("Staffs");
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
            LoadGrid();
        }


        private void LoadGrid()
        {
            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
        }


    }
}
