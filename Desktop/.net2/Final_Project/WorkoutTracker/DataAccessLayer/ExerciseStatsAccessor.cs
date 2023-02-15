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
    public class ExerciseStatsAccessor : IExerciseStatsAccessor
    {
        public int DeleteExerciseStats(int exerciseStatID)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_Delete_ExerciseStats";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@ExerciseStatID", SqlDbType.Int);

            // set the values for the parameter objects

            cmd.Parameters["@ExerciseStatID"].Value = exerciseStatID;

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

        public int InsertExerciseStats(int weight, int sets, int reps)
        {
            int exerciseStatsID = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_insert_ExerciseStats";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@Weight", SqlDbType.Int);
            cmd.Parameters.Add("@Sets", SqlDbType.Int);
            cmd.Parameters.Add("@Reps", SqlDbType.Int);

            // set the values for the parameter objects
            cmd.Parameters["@Weight"].Value = weight;
            cmd.Parameters["@Sets"].Value = sets;
            cmd.Parameters["@Reps"].Value = reps;

            // now that the command is set up, we can invoke it in a try-catch block
            try
            {
                // open the connection
                conn.Open();

                // execute command

                exerciseStatsID = Convert.ToInt32(cmd.ExecuteScalar());

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


            return exerciseStatsID;
        }

        public int InsertUserExercise(int userID, int workoutID, int exerciseID, int exercisestatID)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_insert_UserExercise";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@WorkoutID", SqlDbType.Int);
            cmd.Parameters.Add("@ExerciseID", SqlDbType.Int);
            cmd.Parameters.Add("@ExerciseStatID", SqlDbType.Int);

            // set the values for the parameter objects
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@WorkoutID"].Value = workoutID;
            cmd.Parameters["@ExerciseID"].Value = exerciseID;
            cmd.Parameters["@ExerciseStatID"].Value = exercisestatID;

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

        public List<ExerciseStatsVM> SelectExerciseStatsByWorkout(int workoutID)
        {
            List<ExerciseStatsVM> exerciseStats = new List<ExerciseStatsVM>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_select_ExerciseStats_by_WorkoutID";

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
                var reader = cmd.ExecuteReader();

                // process the results

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var exercisestat = new ExerciseStatsVM();
                        exercisestat.ExerciseName = reader.GetString(0);
                        exercisestat.ExerciseStatID = reader.GetInt32(1);
                        exercisestat.Weight = reader.GetInt32(2);
                        exercisestat.Sets = reader.GetInt32(3);
                        exercisestat.Reps = reader.GetInt32(4);


                        exerciseStats.Add(exercisestat);
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


            return exerciseStats;
        }

        public int UpdateExerciseStats(int oldWeight, int oldSets, int oldReps, int weight, int sets, int reps, int exerciseStatID)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_update_ExerciseStats";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@ExerciseStatID", SqlDbType.Int);
            cmd.Parameters.Add("@Weight", SqlDbType.Int);
            cmd.Parameters.Add("@OldWeight", SqlDbType.Int);
            cmd.Parameters.Add("@Sets", SqlDbType.Int);
            cmd.Parameters.Add("@OldSets", SqlDbType.Int);
            cmd.Parameters.Add("@Reps", SqlDbType.Int);
            cmd.Parameters.Add("@OldReps", SqlDbType.Int);

            // set the values for the parameter objects
            cmd.Parameters["@ExerciseStatID"].Value = exerciseStatID;
            cmd.Parameters["@Weight"].Value = weight;
            cmd.Parameters["@OldWeight"].Value = oldWeight;
            cmd.Parameters["@Sets"].Value = sets;
            cmd.Parameters["@OldSets"].Value = oldSets;
            cmd.Parameters["@Reps"].Value = reps;
            cmd.Parameters["@OldReps"].Value = oldReps;

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
    }

}

        

