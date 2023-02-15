using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class UserStats
    {
        public int UserStatsID { get; set; }
        public int UserID { get; set; }
        public int BodyFat { get; set; }
        public int CalorieIntake { get; set; }
        public decimal Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
