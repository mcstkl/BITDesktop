using BITServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for StaffManagementView.xaml
    /// </summary>
    public partial class StaffManagementView : Page
    {
        public StaffManagementView()
        {
            InitializeComponent();
            this.DataContext = new StaffManagementViewModel();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgStaffs.IsEnabled = true;
            btnSaveUpdate.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            dgStaffs.SelectedIndex = 0;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbStaffType.IsEnabled = false;
            MessageBox.Show("Changes were not saved", "Changes discarded", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgStaffs.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbStaffType.IsEnabled = false;
            MessageBox.Show("Staff details saved", "Changes Saved", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //dgStaffs.IsEnabled = false;
            //btnSave.IsEnabled = true;
            //btnCancel.IsEnabled = true;
            //tbFirstName.IsEnabled = true;
            //tbLastName.IsEnabled = true;
            //tbStreet.IsEnabled = true;
            //tbSuburb.IsEnabled = true;
            //tbPostCode.IsEnabled = true;
            //tbState.IsEnabled = true;
            //tbPhone.IsEnabled = true;
            //tbEmail.IsEnabled = true;
            //tbUsername.IsEnabled = true;
            //tbPassword.IsEnabled = true;
            //tbStaffType.IsEnabled = true;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgStaffs.IsEnabled = false;
            btnSaveUpdate.IsEnabled = true;
            btnCancel.IsEnabled = true;
            tbFirstName.IsEnabled = true;
            tbLastName.IsEnabled = true;
            tbStreet.IsEnabled = true;
            tbSuburb.IsEnabled = true;
            tbPostCode.IsEnabled = true;
            tbState.IsEnabled = true;
            tbPhone.IsEnabled = true;
            tbEmail.IsEnabled = true;
            tbUsername.IsEnabled = true;
            tbPassword.IsEnabled = true;
            tbStaffType.IsEnabled = true;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgStaffs.IsEnabled = true;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbStaffType.IsEnabled = false;
            MessageBox.Show("Staff updated", "Record Updated", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

