using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

using System.Windows.Threading;

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        public Splash()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            dt.Stop();
            this.Close();
        }
    }
}
