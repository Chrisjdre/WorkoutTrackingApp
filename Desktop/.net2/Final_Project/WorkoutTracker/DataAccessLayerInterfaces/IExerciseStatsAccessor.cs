using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IExerciseStatsAccessor
    {
        List<ExerciseStatsVM> SelectExerciseStatsByWorkout(int workoutID);

        int InsertExerciseStats(int weight, int sets, int reps);
        int InsertUserExercise(int userID, int workoutID, int exerciseID, int exercisestatID);
        int UpdateExerciseStats(int oldWeight, int oldSets, int oldReps, int weight, int sets, int reps, int exerciseStatID);
        int DeleteExerciseStats(int exerciseStatID);
    }
}
