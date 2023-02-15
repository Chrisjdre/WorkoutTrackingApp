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
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace WorkoutTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //properties for exercises
        private List<Exercise> _exercises = null;
        private ExerciseManager _exerciseManager = new ExerciseManager();

        //properties for user
        private User _user = null;

        //properties for Workouts
        private List<Workout> _workouts = null;
        private WorkoutManager _workoutmanager = new WorkoutManager();

        // properties for UserStats
        private List<UserStats> _userStats = null;
        private UserStatsManager _userStatsManager = new UserStatsManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnColumn1.Visibility = Visibility.Hidden;
            btnColumn2.Visibility = Visibility.Hidden;
            btnColumn3.Visibility = Visibility.Hidden;
            btnDeletWorkout.Visibility = Visibility.Hidden;
            if (_exercises == null)
            {
                try
                {
                    _exercises = _exerciseManager.RetrieveExercises();
                    datColumn3.ItemsSource = _exercises;
                    datColumn3.Columns.RemoveAt(0);
                    datColumn3.Columns.RemoveAt(2);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
           
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(btnLogin.Content.Equals("Login"))
            {
                var loginWindow = new Login();
                loginWindow.ShowDialog();
                _user = loginWindow._user;
                
                if (_user != null)
                {
                    updateUIforUser();
                }
            }else if (btnLogin.Content.Equals("Logout"))
            {
                updateUIforLogout();
                _user = null;
            }
        }

        private void datColumn3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedExercise = (Exercise)datColumn3.SelectedItem;

            try
            {
                var exerciseWindow = new ExerciseWindow(selectedExercise, _exerciseManager);
                exerciseWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void updateUIforUser()
        {
            lblGreeting.Content = "Welcome "+ _user.Username;
            btnLogin.Content = "Logout";

            // show Column 1
            btnColumn1.Visibility = Visibility.Visible;
            btnDeletWorkout.Visibility = Visibility.Visible;

            // show Column 2
            btnColumn2.Visibility = Visibility.Visible;
            // show Column 3
            btnColumn3.Visibility = Visibility.Visible;

            // update Exercise
            try
            {
                _exercises = _exerciseManager.RetrieveExercises();
                datColumn3.ItemsSource = _exercises;
                datColumn3.Columns.RemoveAt(0);
                datColumn3.Columns.RemoveAt(2);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

            foreach (var role in _user.Roles)
            {
                switch (role)
                {
                    case "User":
                        // update workout data
                        btnColumn2.Content = "Add Stats";
                        try
                        {
                            _workouts = _workoutmanager.RetrieveWorkoutsByUserID(_user);
                            datColumn1.ItemsSource = _workouts;
                            datColumn1.Columns.RemoveAt(0);
                            datColumn1.Columns.RemoveAt(0);
                            datColumn1.Columns.RemoveAt(0);
                            lblColumn1.Content = "Workouts";

                            // user stats ui update
                            _userStats = _userStatsManager.RetrieveUserStatsByUserID(_user);
                            datColumn2.ItemsSource = _userStats;
                            datColumn2.Columns.RemoveAt(0);
                            datColumn2.Columns.RemoveAt(0);
                            lblColumn2.Content = "User Stats";
                        }
                         catch (Exception)
                         {
                         
                             throw;
                         }
                        
                        break;
                    case "Trainer":
                        break;

                }
            }        
        }

        private void updateUIforLogout()
        {
            // first row login and greeting
            lblGreeting.Content = "You are not logged in.";
            btnLogin.Content = "Login";
            btnLogin.IsDefault = true;

            // update Column names
            lblColumn1.Content = "";
            lblColumn2.Content = "";

            // update column 1
            datColumn1.ItemsSource = null;
            datColumn1.Columns.Clear();
            _workouts = null;

            // update Column 2
            datColumn2.ItemsSource = null;
            datColumn2.Columns.Clear();
            _userStats = null;

            // set button visiblity
            btnColumn1.Visibility = Visibility.Hidden;
            btnColumn2.Visibility = Visibility.Hidden;
            btnColumn3.Visibility = Visibility.Hidden;
            btnDeletWorkout.Visibility = Visibility.Hidden;
        }

        private void mnuViewStats_Click(object sender, RoutedEventArgs e)
        {
            // Start a user stats window
        }

        private void datColumn1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedWorkout = (Workout)datColumn1.SelectedItem;


            try
            {
                var workoutWindow = new WorkoutWindow(selectedWorkout, _workoutmanager, _user, _exercises);
                workoutWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnColumn1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var role in _user.Roles)
            {
                switch (role)
                {
                    case "User":
                        var addeditWorkoutWindow = new AddEditWorkoutWindow(_workoutmanager, _user);
                        if ((bool)addeditWorkoutWindow.ShowDialog())
                        {
                            updateUIforUser();
                        }
                        break;
                    case "Admin":
                        break;

                }
            }
        }

        private void btnDeletWorkout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_workoutmanager.DeleteWorkout((Workout)datColumn1.SelectedItem))
                {
                    // success
                    MessageBox.Show("Workout Deleted");
                    updateUIforUser();
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

        private void btnColumn2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var role in _user.Roles)
            {
                switch (role)
                {
                    case "User":
                        var addEditUserStats = new AddEditUserStats(_userStatsManager, _user);
                        if ((bool)addEditUserStats.ShowDialog())
                        {
                            updateUIforUser();
                        }
                        break;
                    case "Admin":
                        break;

                }
            }
        }

        private void btnColumn3_Click(object sender, RoutedEventArgs e)
        {
            var addEditExerciseWindow = new AddEditExercise(_exerciseManager);
            if ((bool)addEditExerciseWindow.ShowDialog())
            {
                updateUIforUser();
            }
        }
    }
}
