using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IUserStatsAccessor
    {
        int InsertUserStats(int userID, int bodyFat, int calorieIntake, decimal weight);

        List<UserStats> SelectUserStatsByUserID(int userID);
    }
}
