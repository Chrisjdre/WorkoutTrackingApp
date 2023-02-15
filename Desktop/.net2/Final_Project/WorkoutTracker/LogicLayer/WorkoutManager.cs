using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class WorkoutManager : IWorkoutManager
    {
        private IWorkoutAccessor _workoutAccessor = null;

        public WorkoutManager()
        {
            _workoutAccessor = new DataAccessLayer.WorkoutAccessor();
        }

        public bool AddWorkout(User user, string workoutTypeName, string workoutName)
        {
            bool success = false;

            if (1 == _workoutAccessor.InsertWorkout(user.UserID, workoutTypeName, workoutName))
            {
                success = true;
            }

            return success;
        }

        public bool DeleteWorkout(Workout workout)
        {
            bool success = false;

            if (1 == _workoutAccessor.DeleteWorkout(workout.WorkoutID))
            {
                success = true;
            }

            return success;
        }

        public List<Workout> RetrieveWorkoutsByUserID(User _user)
        {
            List<Workout> workouts = null;

            try
            {
                workouts = _workoutAccessor.SelectWorkoutsByUserID(_user.UserID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }

            return workouts;

        }
    }
}
