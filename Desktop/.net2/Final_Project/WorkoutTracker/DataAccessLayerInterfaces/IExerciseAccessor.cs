using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IExerciseAccessor
    {
        List<Exercise> SelectExercises();
        List<Exercise> SelectExercisesByWorkoutID();
        int InsertExercise(string exerciseType, string exerciseName, string exerciseDescription);

    }
}
