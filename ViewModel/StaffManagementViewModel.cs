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
    public class StaffManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Staff> _staffList;
        private Staff _selectedStaff;
        private RelayCommand _updateCommand;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set
            {
                _selectedStaff = value;
                OnPropertyChanged("SelectedStaff");
            }
        }
        public ObservableCollection<Staff> StaffList
        {
            get { return _staffList; }
            set { _staffList = value; }
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



        public StaffManagementViewModel()
        {
            StaffList allStaff = new StaffList();
            this.StaffList = new ObservableCollection<Staff>(allStaff);

        }


        public void UpdateMethod()
        {
            SelectedStaff.UpdateStaff();
            MessageBox.Show("Staff Updated");
        }

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



    }
}
