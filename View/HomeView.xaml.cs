using BITServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private string date = DateTime.Now.Date.ToShortDateString();
        private string time = string.Empty;
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }



        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            time = string.Format("{0,8:hh:mm:ss tt}", d);
            tbClock.Text =  time + "\n " + date;
        }
    }
}

