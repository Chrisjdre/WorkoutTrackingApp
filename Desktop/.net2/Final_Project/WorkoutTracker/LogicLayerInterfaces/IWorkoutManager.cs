using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IWorkoutManager
    {
        List<Workout> RetrieveWorkoutsByUserID(User _user);
        bool AddWorkout(User user, string workoutTypeName, string workoutName);
        bool DeleteWorkout(Workout workout);
    }
}
