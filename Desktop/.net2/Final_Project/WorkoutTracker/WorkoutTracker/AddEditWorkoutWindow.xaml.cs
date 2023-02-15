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

namespace WorkoutTracker
{
    /// <summary>
    /// Interaction logic for AddEditWorkoutWindow.xaml
    /// </summary>
    public partial class AddEditWorkoutWindow : Window
    {
        WorkoutManager _workoutManager = null;
        User _user = null;
        public AddEditWorkoutWindow(WorkoutManager workoutManager, User user)
        {
            _workoutManager = workoutManager;
            _user = user;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtWorkoutName.Text == "")
            {
                MessageBox.Show("Invalid Name");
                txtWorkoutName.Focus();
                return;
            }
            if(txtWorkoutType.Text == "")
            {
                MessageBox.Show("Invalid Workout Type");
                txtWorkoutType.Focus();
                return;
            }
            string workoutName = txtWorkoutName.Text;
            string workoutTypeName = txtWorkoutType.Text;
            try
            {
                if (_workoutManager.AddWorkout(_user, workoutName, workoutTypeName))
                {
                    // success
                    MessageBox.Show("Workout Added");
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
