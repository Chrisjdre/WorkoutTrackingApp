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
    /// Interaction logic for AddEditExercise.xaml
    /// </summary>
    public partial class AddEditExercise : Window
    {
        ExerciseManager _exerciseManager = null;
        
        public AddEditExercise(ExerciseManager exerciseManager)
        {
            InitializeComponent();
            _exerciseManager = exerciseManager;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string exerciseName = txtExerciseName.Text;
            string exerciseType = txtExerciseType.Text;
            string exerciseDescription = txtExerciseDescription.Text;


            try
            {
                if (_exerciseManager.AddExercise(exerciseType,exerciseName,exerciseDescription))
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

        private void btnCanel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
