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
    /// Interaction logic for UserStatsAddEdit.xaml
    /// </summary>
    public partial class AddEditUserStats : Window
    {
        private UserStatsManager _userStatsManager = null;
        private User _user = null;
        public AddEditUserStats(UserStatsManager userStatsManager, User user)
        {
            InitializeComponent();
            _userStatsManager = userStatsManager;
            _user = user;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtBodyFat.Text == "" || int.Parse(txtBodyFat.Text) < 0)
            {
                MessageBox.Show("Invalid bodyfat");
                txtBodyFat.Focus();
                return;
            }
            if(txtCalIntake.Text == "" || int.Parse(txtCalIntake.Text) < 0)
            {
                MessageBox.Show("Invalid Calorie Intake");
                txtBodyFat.Focus();
                return;
            }
            if(txtUserWeight.Text == "" || decimal.Parse(txtUserWeight.Text) < 0)
            {
                MessageBox.Show("Invalid User Weight");
                txtBodyFat.Focus();
                return;
            }
            int bodyFat = int.Parse(txtBodyFat.Text);
            int calIntake = int.Parse(txtCalIntake.Text);
            decimal weight = decimal.Parse(txtUserWeight.Text);


            try
            {
                if (_userStatsManager.AddUserStats(_user,bodyFat,calIntake,weight))
                {
                    // success
                    MessageBox.Show("Stats Added");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Failed");
                    this.DialogResult = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
