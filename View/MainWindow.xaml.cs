using BITServices.View;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


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
            contentFrame.Navigate(new DashboardView());
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new DashboardView());
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
            contentFrame.Navigate(new AccountManagementView());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
