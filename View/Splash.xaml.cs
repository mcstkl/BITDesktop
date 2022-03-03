using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            ProgressBar pb = new ProgressBar();
            //pb.Foreground = new SolidColorBrush(Colors.Yellow);
            pb.Height = 5;
            Duration duration = new Duration(TimeSpan.FromSeconds(3.5));
            DoubleAnimation db = new DoubleAnimation(100, duration);
            pb.BeginAnimation(ProgressBar.ValueProperty, db);
            spSplash.Children.Add(pb);

            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 4);
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
