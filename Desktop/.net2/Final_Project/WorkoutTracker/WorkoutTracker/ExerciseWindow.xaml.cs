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
    /// Interaction logic for ExerciseWindow.xaml
    /// </summary>
    public partial class ExerciseWindow : Window
    {
        Exercise _exercise = null;
        ExerciseManager _exerciseManager = null;
        public ExerciseWindow(Exercise selectedExercise, ExerciseManager exercisemanager)
        {
            InitializeComponent();
            _exercise = selectedExercise;
            _exerciseManager = exercisemanager;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblExerciseName.Content = _exercise.exerciseName;
            txtExerciseDescription.Text = _exercise.exerciseDescription;
        }
    }
}
