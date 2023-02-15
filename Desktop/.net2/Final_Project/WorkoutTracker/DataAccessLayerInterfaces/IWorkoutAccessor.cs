using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IWorkoutAccessor
    {
        List<Workout> SelectWorkoutsByUserID(int userID);
        int InsertWorkout(int userID, string workoutTypeName, string workoutName);
        int DeleteWorkout(int workoutID);
    }
}
