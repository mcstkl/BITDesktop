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
    public class CoordinatorManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Coordinator> _coordinators;
        private Coordinator _selectedCoordinator;
        private RelayCommand _updateCommand;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public Coordinator SelectedCoordinator
        {
            get { return _selectedCoordinator; }
            set
            {
                _selectedCoordinator = value;
                OnPropertyChanged("SelectedCoordinator");
            }
        }
        public ObservableCollection<Coordinator> Coordinators
        {
            get { return _coordinators; }
            set { _coordinators = value; }
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



        public CoordinatorManagementViewModel()
        {
            Coordinators allCoordinators = new Coordinators();
            this.Coordinators = new ObservableCollection<Coordinator>(allCoordinators);

        }


        public void UpdateMethod()
        {
            SelectedCoordinator.UpdateCoordinator();
            MessageBox.Show("Category Updated");
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
