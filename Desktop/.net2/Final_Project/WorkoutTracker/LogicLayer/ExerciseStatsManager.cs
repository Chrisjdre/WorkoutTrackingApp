using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;


namespace LogicLayer
{
    public class ExerciseStatsManager : IExerciseStatsManager
    {
        private IExerciseStatsAccessor _ExerciseStatAccessor = null;


        public ExerciseStatsManager()
        {
            _ExerciseStatAccessor = new DataAccessLayer.ExerciseStatsAccessor();
        }

        public int AddExerciseStats(int weight, int sets, int reps)
        {
            int exerciseStatsID = 0;

            exerciseStatsID = _ExerciseStatAccessor.InsertExerciseStats(weight, sets, reps);

            return exerciseStatsID;
        }

        public bool AddUserExercise(int userID, int workoutID, int exerciseID, int exercisestatID)
        {
            bool success = false;

            if(1 == _ExerciseStatAccessor.InsertUserExercise(userID, workoutID, exerciseID, exercisestatID)){
                success = true;
            }
             

            return success;
        }

        public bool DeleteExerciseStats(ExerciseStatsVM exerciseStats)
        {
            bool success = false;

            if (1 == _ExerciseStatAccessor.DeleteExerciseStats(exerciseStats.ExerciseStatID))
            {
                success = true;
            }


            return success;
        }

        public List<ExerciseStatsVM> RetrieveExerciseStatsByWorkoutID(Workout _workout)
        {
            List<ExerciseStatsVM> exerciseStats =  null;
            try
            {
                exerciseStats = _ExerciseStatAccessor.SelectExerciseStatsByWorkout(_workout.WorkoutID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Exercise stats not found!", ex);
            }
            return exerciseStats;
        }

        public bool EditExerciseStats(int oldWeight, int oldSets, int oldReps, int weight, int sets, int reps, ExerciseStatsVM exerciseStats)
        {
            bool success = false;

            if (1 == _ExerciseStatAccessor.UpdateExerciseStats(oldWeight,oldSets,oldReps,weight,sets,reps,exerciseStats.ExerciseStatID))
            {
                success = true;
            }


            return success;
        }
    }
}
