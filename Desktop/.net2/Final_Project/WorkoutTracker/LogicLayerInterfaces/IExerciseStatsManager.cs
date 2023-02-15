using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IExerciseStatsManager
    {
        List<ExerciseStatsVM> RetrieveExerciseStatsByWorkoutID(Workout _workout);

        int AddExerciseStats(int weight, int sets, int reps);

        bool AddUserExercise(int userID, int workoutID, int exerciseID, int exercisestatID);
        bool DeleteExerciseStats(ExerciseStatsVM exerciseStats);
        bool EditExerciseStats(int oldWeight, int oldSets, int oldReps, int weight, int sets, int reps, ExerciseStatsVM exerciseStats);

    }
}
