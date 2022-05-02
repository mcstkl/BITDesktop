using BITServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ContractorManagementView.xaml
    /// </summary>
    public partial class ContractorManagementView : Page
    {
        private DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private string date = DateTime.Now.Date.ToShortDateString();
        private string time = string.Empty;
        public ContractorManagementView()
        {
            InitializeComponent();
            this.DataContext = new ContractorManagementViewModel();
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


        //private void LoadSkillComboBox()
        //{
        //    cboSkillsList.DisplayMemberPath = "JobSkill_Type";
        //    cboSkillsList.SelectedValuePath = "JobSkill_ID";
        //    //Add a --Select a Skill--" message to the DataTable
        //    DataRow drSelectMsg;
        //    drSelectMsg = _dtSkillsList.NewRow();
        //    drSelectMsg["JobSkill_ID"] = "0";
        //    drSelectMsg["JobSkill_Type"] = "-- Select a Skill --";
        //    _dtSkillsList.Rows.InsertAt(drSelectMsg, 0);
        //    //Bind to the ComboBox
        //    cboSkillsList.ItemsSource = _dtSkillsList.DefaultView;
        //    cboSkillsList.SelectedIndex = 0;
        //}

        //private void GetSkillsList()
        //{
        //    SqlCommand cmd = new SqlCommand("usp_GetListOfSkills", _myDbConn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        _myDbConn.Open();
        //        _dtSkillsList = new DataTable();
        //        _dtSkillIDs = new DataTable();

        //        _dtSkillsList.Load(cmd.ExecuteReader());
        //        string skills = string.Empty;
        //        foreach (DataRow skill in _dtSkillsList.Rows)
        //        {
        //            skills += skill["JobSkill_Type"].ToString() + "\n";
        //        }
        //        MessageBox.Show(skills);
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("Something went wrong!");
        //    }
        //    finally
        //    {
        //        if (cmd.Connection.State == ConnectionState.Open)
        //        {
        //            cmd.Connection.Close();
        //        }
        //    }
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dgContractors.IsEnabled = true;
            //btnSave.IsEnabled = false;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            dgContractors.SelectedIndex = 0;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbRating.IsEnabled = false;
            tbPayrate.IsEnabled = false;
            btnSkills.IsEnabled = true;
            btnAvailabilities.IsEnabled = true;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDecimal(tbRating.Text) > 9.99M || Convert.ToDecimal(tbRating.Text) < 0.00M)
            {
                MessageBox.Show("Please enter a rating between 0.00 and 9.99");
                return;
            }
            dgContractors.IsEnabled = true;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbRating.IsEnabled = false;
            tbPayrate.IsEnabled = false;
            btnSkills.IsEnabled = true;
            btnAvailabilities.IsEnabled = true;

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //dgContractors.IsEnabled = false;
            //btnSave.IsEnabled = true;
            //btnCancel.IsEnabled = true;
            //tbFirstName.IsEnabled = true;
            //tbLastName.IsEnabled = true;
            //tbStreet.IsEnabled = true;
            //tbSuburb.IsEnabled = true;
            //tbPostCode.IsEnabled = true;
            //tbState.IsEnabled = true;
            //tbPhone.IsEnabled = true;
            //tbEmail.IsEnabled = true;
            //tbUsername.IsEnabled = true;
            //tbPassword.IsEnabled = true;
            //tbRating.IsEnabled = true;
            //tbPayrate.IsEnabled = true;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgContractors.IsEnabled = false;
            btnSaveUpdate.IsEnabled = true;
            btnCancel.IsEnabled = true;
            tbFirstName.IsEnabled = true;
            tbLastName.IsEnabled = true;
            tbStreet.IsEnabled = true;
            tbSuburb.IsEnabled = true;
            tbPostCode.IsEnabled = true;
            tbState.IsEnabled = true;
            tbPhone.IsEnabled = true;
            tbEmail.IsEnabled = true;
            tbUsername.IsEnabled = true;
            tbPassword.IsEnabled = true;
            tbRating.IsEnabled = true;
            tbPayrate.IsEnabled = true;
            btnSkills.IsEnabled = false;
            btnAvailabilities.IsEnabled = false;
            
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgContractors.IsEnabled = true;
            btnSaveUpdate.IsEnabled = false;
            btnCancel.IsEnabled = false;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbStreet.IsEnabled = false;
            tbSuburb.IsEnabled = false;
            tbPostCode.IsEnabled = false;
            tbState.IsEnabled = false;
            tbPhone.IsEnabled = false;
            tbEmail.IsEnabled = false;
            tbUsername.IsEnabled = false;
            tbPassword.IsEnabled = false;
            tbRating.IsEnabled = false;
            tbPayrate.IsEnabled = false;
            btnSkills.IsEnabled = true;
            btnAvailabilities.IsEnabled = true;
        }
    }
}

