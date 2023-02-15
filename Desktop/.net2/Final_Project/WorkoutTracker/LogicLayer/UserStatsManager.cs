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
    
    public class UserStatsManager : IUserStatsManager
    {
        private IUserStatsAccessor _userStatsAccessor = null;
        public UserStatsManager()
        {
            _userStatsAccessor = new DataAccessLayer.UserStatsAccessor();
        }
        public bool AddUserStats(User user, int bodyFat, int calorieIntake, decimal weight)
        {
            bool success = false;

            if (1 == _userStatsAccessor.InsertUserStats(user.UserID,bodyFat,calorieIntake,weight))
            {
                success = true;
            }


            return success;
        }

        public List<UserStats> RetrieveUserStatsByUserID(User user)
        {
            List<UserStats> userStats = null;

            try
            {
                userStats = _userStatsAccessor.SelectUserStatsByUserID(user.UserID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }


            return userStats;
        }
    }
}
