using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class ExerciseManager : IExerciseManager
    {
        private IExerciseAccessor _exerciseAccessor = null;

        public ExerciseManager()
        {
            _exerciseAccessor = new DataAccessLayer.ExerciseAccessor();
        }

        public ExerciseManager(IExerciseAccessor exerciseAccessor)
        {
            _exerciseAccessor = exerciseAccessor;
        }

        public bool AddExercise(string exerciseType, string exerciseName, string exerciseDescription)
        {
            bool success = false;

            if (1 == _exerciseAccessor.InsertExercise(exerciseType,exerciseName,exerciseDescription))
            {
                success = true;
            }


            return success;
        }

        public List<Exercise> RetrieveExercises()
        {
            List<Exercise> exercises = null;

            try
            {
                exercises = _exerciseAccessor.SelectExercises();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }

            return exercises;
        }
    }
}
