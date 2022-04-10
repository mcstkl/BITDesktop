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
using System.Windows.Shapes;

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for AddJobView.xaml
    /// </summary>
    public partial class AddJobView : Window
    {
        public AddJobView()
        {
            InitializeComponent();
            this.DataContext = new AddJobViewModel();
        }

        private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void spTopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
