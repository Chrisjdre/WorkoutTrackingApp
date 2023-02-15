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
    public class WorkoutAccessor : IWorkoutAccessor
    {
        public int DeleteWorkout(int workoutID)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_Delete_Workout";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@WorkoutID", SqlDbType.Int);

            // set the values for the parameter objects
            cmd.Parameters["@WorkoutID"].Value = workoutID;


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

        public int InsertWorkout(int userID, string workoutTypeName, string workoutName)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_insert_Workout";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@WorkoutTypeName", SqlDbType.NVarChar);
            cmd.Parameters.Add("@WorkoutName", SqlDbType.NVarChar);

            // set the values for the parameter objects
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@WorkoutTypeName"].Value = workoutTypeName;
            cmd.Parameters["@WorkoutName"].Value = workoutName;

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

        public List<Workout> SelectWorkoutsByUserID(int userID)
        {
            List<Workout> workouts = new List<Workout>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_select_Workouts_by_UserID";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@UserID", SqlDbType.Int);

            // set the values for the parameter objects
            cmd.Parameters["@UserID"].Value = userID;

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
                        var workout = new Workout();
                        workout.WorkoutID = reader.GetInt32(0);
                        workout.UserID = reader.GetInt32(1);
                        workout.WorkoutTypeName = reader.GetString(2);
                        workout.WorkoutName = reader.GetString(3);
                        workout.WorkoutDate = reader.GetDateTime(4);


                        workouts.Add(workout);
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


            return workouts;
        }
    }
}
