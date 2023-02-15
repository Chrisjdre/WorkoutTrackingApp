using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public string WorkoutTypeName { get; set; }
        public string WorkoutName { get; set; }
        public DateTime WorkoutDate { get; set; }

    }
}
