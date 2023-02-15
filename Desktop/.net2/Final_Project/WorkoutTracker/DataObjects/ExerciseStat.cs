using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class ExerciseStats
    {
        public int ExerciseStatID { get; set; }
        public int Weight { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

    }


    public class ExerciseStatsVM : ExerciseStats
    {
        public string ExerciseName { get; set; }
    }
}
