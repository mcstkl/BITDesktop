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

        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new HomeView());
        }
        public MainWindow(string user)
        {
            InitializeComponent();
            contentFrame.Navigate(new HomeView());
            Coordinators coordinators = new Coordinators();
            foreach(Coordinator coordinator in coordinators)
            {
               if(coordinator.UserName == user)
                {
                    lblUser.Content = "Logged in as " + user;
                }
            }
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new HomeView());
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new CustomerManagementView());
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
            contentFrame.Navigate(new CoordinatorManagementView());
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

    }
}
