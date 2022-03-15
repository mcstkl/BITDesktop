using BITServices.View;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BITServices.Model;


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
        }
        public MainWindow(string user)
        {
            InitializeComponent();
            contentFrame.Navigate(new HomeView());
            StaffList staffs = new StaffList();
            foreach(Staff staff in staffs)
            {
                if(staff.UserName == user)
                {
                    _currentUser = staff;
                }
            }
            tbUser.Text = $"{_currentUser.FirstName} {_currentUser.LastName} is signed in.";
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new HomeView());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ClientManagementView());
        }

        private void btnContractors_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ContractorManagementView());
        }

        private void btnJobs_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new JobManagementView());
        }

        private void btnAvailabilities_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new AvailabilityManagementView());
        }

        private void btnRecords_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new RecordManagementView());
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new SettingsManagementView());
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
