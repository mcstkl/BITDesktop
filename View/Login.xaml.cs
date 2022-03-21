using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using BITServices.Model;
using BITServices.View;

namespace BITServices
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUsername.Text) && txtUsername.Text.Length > 0)
            {
                textUsername.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUsername.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }


        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }




        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //string pw = txtPassword.Password;
            //using (var sha256 = new SHA256Managed())
            //{
            //    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pw));
            //    var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            //    MessageBox.Show(hash);
            //}


            string connectionString = ConfigurationManager.ConnectionStrings["BitServices"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string query = "Select count(1) from staff where username=@username AND password=@password";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", txtPassword.Password);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 1)
                {
                    string userName = txtUsername.Text;
                    MainWindow mainWindow = new MainWindow(userName);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Couldn't log in. Please try again", "Wrong Username or Password!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.GetKeyStates(Key.Return) & KeyStates.Down) > 0)
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnMinimizeLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCloseLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
