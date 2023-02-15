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
    /// Interaction logic for AddExerciseStatsWindow.xaml
    /// </summary>
    public partial class AddExerciseStatsWindow : Window
    {
        private Workout _workout = null;
        private User _user = null;
        private List<Exercise> _exercises = null;
        private ExerciseStatsManager _exerciseStatsManager = null;
        private int exercisestatID = 0;
        private bool _editMode = false;
        private ExerciseStatsVM _exerciseStat = null;
        private Exercise _selectedExercise = null;
        public AddExerciseStatsWindow(Workout currentWorkout, User currentUser, List<Exercise> exercises, ExerciseStatsManager exerciseStatsManager)
        {
            InitializeComponent();
            _workout = currentWorkout;
            _user = currentUser;
            _exercises = exercises;
            _exerciseStatsManager = exerciseStatsManager;
        }

        // Edit Exercise window
        public AddExerciseStatsWindow(ExerciseStatsVM selectedExerciseStatVM, List<Exercise> exercises, ExerciseStatsManager exerciseStatsManager)
        {
            InitializeComponent();
            _editMode = true;
            _exerciseStat = selectedExerciseStatVM;
            _exercises = exercises;
            _exerciseStatsManager = exerciseStatsManager;
            foreach (var exercise in _exercises)
            {
                if(exercise.exerciseName == _exerciseStat.ExerciseName)
                {
                    _selectedExercise = exercise;
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboExercises.ItemsSource = _exercises;
            cboExercises.DisplayMemberPath = "exerciseName";
            cboExercises.SelectedValuePath = "exerciseID";
            if (_editMode == true)
            {
                cboExercises.SelectedItem = _selectedExercise;
                txtWeight.Text = _exerciseStat.Weight.ToString();
                txtSets.Text = _exerciseStat.Sets.ToString();
                txtReps.Text = _exerciseStat.Reps.ToString();
            }
            else
            {
                cboExercises.SelectedItem = _exercises[0];
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;

            if (cboExercises.SelectedItem == null)
            {
                MessageBox.Show("Invalid Exercise");
                cboExercises.Focus();
                return;
            }

            if (txtWeight.Text == "" || !int.TryParse(txtWeight.Text, out num))
            {
                MessageBox.Show("Invalid Weight");
                txtWeight.Focus();
                return;
            }

            if (txtSets.Text == "" || !int.TryParse(txtSets.Text, out num))
            {
                MessageBox.Show("Invalid Sets");
                txtSets.Focus();
                return;
            }

            if (txtReps.Text == "" || !int.TryParse(txtReps.Text, out num))
            {
                MessageBox.Show("Invalid Reps");
                txtReps.Focus();
                return;
            }

            int selectedExercise = Convert.ToInt32(cboExercises.SelectedValue);
            int weight = int.Parse(txtWeight.Text);
            int sets = int.Parse(txtSets.Text);
            int reps = int.Parse(txtReps.Text);

            if (_editMode)
            {
                int oldWeight = _exerciseStat.Weight;
                int oldSets = _exerciseStat.Sets;
                int oldReps = _exerciseStat.Reps;
                try
                {
                    if (_exerciseStatsManager.EditExerciseStats(oldWeight, oldSets, oldReps, weight, sets, reps, _exerciseStat))
                    {
                        // success
                        MessageBox.Show("Exercise set updated");
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
            else
            {
                try
                {
                    exercisestatID = _exerciseStatsManager.AddExerciseStats(weight, sets, reps);

                    if (exercisestatID != 0)
                    {
                        if (_exerciseStatsManager.AddUserExercise(_user.UserID, _workout.WorkoutID, selectedExercise, exercisestatID))
                        {
                            // success
                            MessageBox.Show("Exercise set added");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                            this.DialogResult = false;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?",
                                       "Really cancel?", MessageBoxButton.YesNo,
                                       MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

    }
}
