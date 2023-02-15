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
    /// Interaction logic for WorkoutWindow.xaml
    /// </summary>
    public partial class WorkoutWindow : Window
    {
        private Workout _workout = null;
        private WorkoutManager _workoutManager = null;
        private ExerciseStatsManager _exerciseStatsManager = new ExerciseStatsManager();
        private User _user = null;
        private List<Exercise> _exercises = null;

        public WorkoutWindow(Workout selectedWorkout, WorkoutManager workoutManager, User currentUser, List<Exercise> exercises)
        {
            InitializeComponent();
            _workout = selectedWorkout;
            _workoutManager = workoutManager;
            _user = currentUser;
            _exercises = exercises;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblWorkoutName.Content = _workout.WorkoutName;
            updateUI();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addExerciseStats = new AddExerciseStatsWindow(_workout, _user, _exercises, _exerciseStatsManager);

            if ((bool)addExerciseStats.ShowDialog())
            {
                updateUI();
            }
        }

        private void updateUI()
        {
            datExercisestat.ItemsSource = _exerciseStatsManager.RetrieveExerciseStatsByWorkoutID(_workout);
            datExercisestat.Columns.RemoveAt(1);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(datExercisestat.SelectedItem != null)
            {
                var addExerciseStats = new AddExerciseStatsWindow((ExerciseStatsVM)datExercisestat.SelectedItem, _exercises,_exerciseStatsManager);
                if ((bool)addExerciseStats.ShowDialog())
                {
                    updateUI();
                }
            }
            else
            {
                MessageBox.Show("No stats selected");
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_exerciseStatsManager.DeleteExerciseStats((ExerciseStatsVM)datExercisestat.SelectedItem))
                {
                    updateUI();
                    MessageBox.Show("Exercise Delted");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
