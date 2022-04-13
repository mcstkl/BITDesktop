using BITServices.Model;
using BITServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ClientManagementView.xaml
    /// </summary>
    public partial class ClientManagementView : Page
    {
        public ClientManagementView()
        {
            InitializeComponent();
            this.DataContext = new ClientManagementViewModel();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgClients.IsEnabled = true;
            //btnSaveUpdate.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            dgClients.SelectedIndex = 0;
            tbName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            cboState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUser.IsEnabled = false;
            //tbPassword.IsEnabled = false;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgClients.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            cboState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUser.IsEnabled = false;
            //tbPassword.IsEnabled = false;

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //dgClients.IsEnabled = false;
            //btnSave.IsEnabled = true;
            //btnCancel.IsEnabled = true;
            //tbName.IsEnabled = true;
            //tbStreet.IsEnabled = true;
            //tbSuburb.IsEnabled = true;
            //tbPostCode.IsEnabled = true;
            //cboState.IsEnabled = true;
            //tbPhone.IsEnabled = true;
            //tbEmail.IsEnabled = true;
            //tbUser.IsEnabled = true;
            //tbPassword.IsEnabled = true;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgClients.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            tbName.IsEnabled = true;
            tbStreet.IsEnabled = true;
            tbSuburb.IsEnabled = true;
            tbPostCode.IsEnabled = true;
            cboState.IsEnabled = true;
            tbPhone.IsEnabled = true;
            tbEmail.IsEnabled = true;
            tbUser.IsEnabled = true;
            //tbPassword.IsEnabled = true;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           

        }
        //private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        //{
        //    dgClients.IsEnabled = true;
        //    btnSaveUpdate.IsEnabled = false;
        //    btnCancel.IsEnabled = false;
        //    tbName.IsEnabled = false;
        //    tbStreet.IsEnabled = false;
        //    tbSuburb.IsEnabled = false;
        //    tbPostCode.IsEnabled = false;
        //    cboState.IsEnabled = false;
        //    tbPhone.IsEnabled = false;
        //    tbEmail.IsEnabled = false;
        //    tbUser.IsEnabled = false;
        //    tbPassword.IsEnabled = false;
        //}
    }
}
