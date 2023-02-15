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
    public class UserStatsAccessor : IUserStatsAccessor
    {
        public int InsertUserStats(int userID, int bodyFat, int calorieIntake, decimal weight)
        {
            int rows = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_insert_UserStats";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@Bodyfat", SqlDbType.Int);
            cmd.Parameters.Add("@calorieintake", SqlDbType.Int);
            cmd.Parameters.Add("@weight", SqlDbType.Decimal);

            // set the values for the parameter objects
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@Bodyfat"].Value = bodyFat;
            cmd.Parameters["@calorieintake"].Value = calorieIntake;
            cmd.Parameters["@weight"].Value = weight;

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

        public List<UserStats> SelectUserStatsByUserID(int userID)
        {
            List<UserStats> userStats = new List<UserStats>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            //  command text
            var cmdText = "sp_select_UserStats_by_UserID";

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
                        var userstat = new UserStats();
                        userstat.UserStatsID = reader.GetInt32(0);
                        userstat.UserID = reader.GetInt32(1);
                        userstat.BodyFat = reader.GetInt32(2);
                        userstat.CalorieIntake = reader.GetInt32(3);
                        userstat.Weight = reader.GetDecimal(4);
                        userstat.Date = reader.GetDateTime(5);


                        userStats.Add(userstat);
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


            return userStats;
        }
    }
}
