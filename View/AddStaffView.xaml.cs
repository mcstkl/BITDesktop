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
    /// Interaction logic for AddStaffView.xaml
    /// </summary>
    public partial class AddStaffView : Window
    {

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public AddStaffView()
        {
            InitializeComponent();
            DataContext = new AddStaffViewModel();

        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataChangedEventHandler handler = DataChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
