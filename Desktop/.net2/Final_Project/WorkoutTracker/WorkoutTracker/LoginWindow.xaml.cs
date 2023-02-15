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
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace WorkoutTracker
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User _user = null;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager();

            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (email.Length < 6)
            {
                MessageBox.Show("Invalid email address.");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            if (password == "")
            {
                MessageBox.Show("You must enter a password");
                txtPassword.Focus();
                return;
            }

            try
            {   
                _user = userManager.LoginUser(email, password);
                // MessageBox.Show("Welcome " + _user.GivenName + "\n" + "you are Logged in as " + _user.Roles[0]);
                
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
