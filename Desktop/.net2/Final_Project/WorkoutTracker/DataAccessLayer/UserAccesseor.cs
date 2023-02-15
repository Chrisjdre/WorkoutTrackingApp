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
    /// <summary>
	/// Chris Dreismeier
	/// Created: 2023/02/03
	/// 
	/// Access the User from the database
	/// 
	/// </summary>
	///
	/// <remarks>
	/// Updater Name
	/// Updated: yyyy/mm/dd
	/// </remarks>
    public class UserAccesseor : IUserAccessor
    {
        public int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash)
        {
            int result = 0;

            // ADO.NET needs a connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // next we need command text
            var cmdText = "sp_authenticate_user";

            // use the command text and connection to create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter objects to the command 
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            // set the values for the parameter objects
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // now that the command is set up, we can invoke it in a try-catch block
            try
            {
                // open the connection
                conn.Open();

                // execute the command appropriately, and capture the results
                // you can ExecuteScalar, ExecuteNonQuery, or ExecuteReader
                // depeding on whether you expect a single value, an int for rows affected, or rows and columns

                result = Convert.ToInt32(cmd.ExecuteScalar());
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


            return result;
        }


        public List<string> SelectRolesByUserID(int userID)
        {
            List<string> roles = new List<string>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_roles_by_UserID";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@UserID", SqlDbType.Int);

            // values
            cmd.Parameters["@UserID"].Value = userID;

            //try-catch-finally

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                // process the results
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
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


            return roles;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetConnection();

            // command text
            var cmdText = "sp_select_User_by_email";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

            //value
            cmd.Parameters["@Email"].Value = email;

            // try-catch-finnaly

            try
            {
                // open connection
                conn.Open();

                // execute and get a SqlDataReader
                var reader = cmd.ExecuteReader();

                user = new User();

                if (reader.HasRows)
                {
                    // most of the time there will be a while loop
                    // here, we don't need it

                    reader.Read();
                    // [GivenName], [FamilyName],[UserName],[gender], [Email]

                    user.UserID = reader.GetInt32(0);
                    user.GivenName = reader.GetString(1);
                    user.FamilyName = reader.GetString(2);
                    user.Username = reader.GetString(3);
                    user.Gender = reader.GetString(4);
                    user.Email = reader.GetString(5);
                    user.Active = reader.GetBoolean(6);
                }
                // close reader
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close
                conn.Close();
            }


            return user;
        }
    }
}
