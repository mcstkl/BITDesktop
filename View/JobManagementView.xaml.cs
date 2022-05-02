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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for JobManagementView.xaml
    /// </summary>
    public partial class JobManagementView : Page
    {
        private DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private string date = DateTime.Now.Date.ToShortDateString();
        private string time = string.Empty;
        public JobManagementView()
        {
            InitializeComponent();
            this.DataContext = new JobManagementViewModel();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            time = string.Format("{0,8:hh:mm:ss tt}", d);
            tbClock.Text = time + "\n " + date;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgJobs.IsEnabled = false;
            btnSaveUpdate.IsEnabled = true;
            btnCancel.IsEnabled = true;
            tbDate.IsEnabled = true;
            tbCompany.IsEnabled = true;
            tbSuburb.IsEnabled = true;
            tbState.IsEnabled = true;
            tbSkill.IsEnabled = true;
            tbStartTime.IsEnabled = true;
            tbStreet.IsEnabled = true;
            tbPostCode.IsEnabled = true;
            tbEstimatedHours.IsEnabled = true;
            tbJobStatus.IsEnabled = true;
            btnAssign.IsEnabled = false;
            btnVerify.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgJobs.IsEnabled = true;
            dgJobs.SelectedIndex = 0;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbDate.IsEnabled = false;
            tbCompany.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbState.IsEnabled = false;
            tbSkill.IsEnabled = false;
            tbStartTime.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbEstimatedHours.IsEnabled = false;
            tbJobStatus.IsEnabled = false;
            btnAssign.IsEnabled = true;
            btnVerify.IsEnabled = true;
        }

        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgJobs.IsEnabled = true;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbDate.IsEnabled = false;
            tbCompany.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbState.IsEnabled = false;
            tbSkill.IsEnabled = false;
            tbStartTime.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbEstimatedHours.IsEnabled = false;
            tbJobStatus.IsEnabled = false;
            btnAssign.IsEnabled = true;
            btnVerify.IsEnabled = true;
        }
    }
}
