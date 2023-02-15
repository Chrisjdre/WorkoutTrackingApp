using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class ExerciseAccessor : IExerciseAccessor
    {
        public int InsertExercise(string exerciseType, string exerciseName, string exerciseDescription)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_insert_Exercise";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@ExerciseType", SqlDbType.NVarChar);
            cmd.Parameters.Add("@ExerciseName", SqlDbType.NVarChar);
            cmd.Parameters.Add("@ExerciseDescription", SqlDbType.NVarChar);

            // set the values for the parameter objects
            cmd.Parameters["@ExerciseType"].Value = exerciseType;
            cmd.Parameters["@ExerciseName"].Value = exerciseName;
            cmd.Parameters["@ExerciseDescription"].Value = exerciseDescription;

            // now that the command is set up, we can invoke it in a try-catch block
            try
            {
                // open the connection
                conn.Open();

                // execute command

                rows = cmd.ExecuteNonQuery();

                // process the results




            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                conn.Close();
            }


            return rows;
        }

        public List<Exercise> SelectExercises()
        {
            List<Exercise> exercises = new List<Exercise>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_select_Exercises";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            // cmd.Parameters.Add("@CabinStatusID", SqlDbType.NVarChar, 25);

            // set the values for the parameter objects
            // cmd.Parameters["@CabinStatusID"].Value = cabinStatus;

            // now that the command is set up, we can invoke it in a try-catch block
            try
            {
                // open the connection
                conn.Open();




                // execute command
                var reader = cmd.ExecuteReader();

                // process the results

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var exercise = new Exercise();
                        exercise.exerciseID = reader.GetInt32(0);
                        exercise.exerciseType = reader.GetString(1);
                        exercise.exerciseName = reader.GetString(2);
                        exercise.exerciseDescription = reader.GetString(3);
                        

                        exercises.Add(exercise);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                conn.Close();
            }


            return exercises;
        }

        public List<Exercise> SelectExercisesByWorkoutID()
        {
            throw new NotImplementedException();
        }
    }
}
