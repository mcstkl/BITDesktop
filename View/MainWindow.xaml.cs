using BITServices.View;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BITServices.Model;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Text;
using BITServices.AppLogs;
using System.Data;

namespace BITServices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Staff _currentUser;

        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new HomeView());
            btnHome.IsChecked = true;

        }
        public MainWindow(string user)
        {
            InitializeComponent();
            contentFrame.Navigate(new HomeView());
            Staffs staffs = new Staffs();
            foreach(Staff staff in staffs)
            {
                if(staff.UserName == user)
                {
                    _currentUser = staff;
                }
            }
            LogHelper.Log(LogTarget.File, $"[Login]: {_currentUser.UserName}");
            tbUser.Text = $"{_currentUser.FirstName} {_currentUser.LastName} is signed in.";
            btnHome.IsChecked = true;
            if(_currentUser.StaffType != "Admin")
            {
                btnAccounts.IsEnabled = false;
            }
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new HomeView());
        }
        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new ClientManagementView());
        }
        private void btnContractors_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new ContractorManagementView());
        }
        private void btnJobs_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new JobManagementView());
        }
        private void btnAvailabilities_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new AvailabilityManagementView());
        }
        private void btnRecords_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnSettings.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new RecordManagementView());
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnAccounts.IsChecked = false;
            contentFrame.Navigate(new SettingsManagementView());
        }
        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            btnHome.IsChecked = false;
            btnClients.IsChecked = false;
            btnContractors.IsChecked = false;
            btnJobs.IsChecked = false;
            btnAvailabilities.IsChecked = false;
            btnRecords.IsChecked = false;
            btnSettings.IsChecked = false;
            contentFrame.Navigate(new StaffManagementView());
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void btnMinimizeMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnCloseMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("" + _currentUser.FirstName + " " + _currentUser.LastName + " is signed in",
                            "Currently logged in as " + _currentUser.UserName, 
                            MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnMaximizeMainWindow_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {

                this.WindowState = WindowState.Normal;
            }
            else
            {
                
                this.WindowState=WindowState.Maximized;
            }
        }
    }
}
