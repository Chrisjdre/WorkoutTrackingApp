using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor userAccessor = null;
        public UserManager()
        {
            userAccessor = new UserAccesseor();
        }

        public UserManager(IUserAccessor ua)
        {
            userAccessor = ua;
        }

        public string HashSha256(string source)
        {
            string result = "";

            // check for missing input
            if (source == "" || source == null)
            {
                throw new ArgumentNullException("Missing Input");
            }

            // create a byte array
            byte[] data;

            // create a .NET hash provider
            using (SHA256 sha256hasher = SHA256.Create())
            {
                // hash the input
                data = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // create output with a stringbuilder object
            var s = new StringBuilder();

            // loop through the hashed output making characters
            // from the values in the byte array
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // convert the stringbuilder into a string

            result = s.ToString();
            result = result.ToLower();

            return result;
        }

        public User LoginUser(string email, string password)
        {
            User user = null;

            try
            {
                password = HashSha256(password);
                if (1 == userAccessor.AuthenticateUserWithEmailAndPasswordHash(email, password))
                {
                    user = userAccessor.SelectUserByEmail(email);
                    user.Roles = userAccessor.SelectRolesByUserID(user.UserID);
                }
                else
                {
                    throw new ApplicationException("User Not Found");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Bad Username or Password", ex);
            }
            

            return user;
        }
    }
}
