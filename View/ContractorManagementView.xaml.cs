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

namespace BITServices.View
{
    /// <summary>
    /// Interaction logic for ContractorManagementView.xaml
    /// </summary>
    public partial class ContractorManagementView : Page
    {
        public ContractorManagementView()
        {
            InitializeComponent();
            this.DataContext = new ContractorManagementViewModel();
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
            btnSaveUpdate.IsEnabled = false;
            btnSave.IsEnabled = false;
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
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDecimal(tbRating.Text) > 9.99M || Convert.ToDecimal(tbRating.Text) < 0.00M)
            {
                MessageBox.Show("Please enter a rating between 0.00 and 9.99");
                return;
            }
            dgContractors.IsEnabled = true;
            btnSave.IsEnabled = false;
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

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dgContractors.IsEnabled = false;
            btnSave.IsEnabled = true;
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
        }
    }
}

