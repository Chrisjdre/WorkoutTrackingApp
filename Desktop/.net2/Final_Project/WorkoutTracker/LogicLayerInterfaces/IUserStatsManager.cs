using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IUserStatsManager
    {
        bool AddUserStats(User user, int bodyFat, int calorieIntake, decimal weight);

        List<UserStats> RetrieveUserStatsByUserID(User user);
    }
}
