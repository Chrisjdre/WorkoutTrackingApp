using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;

namespace DataAccessLayer
{
    class DBConnection : IDBConnection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = null;

            string connectionString = @"Data Source=localhost;Initial Catalog=workout_db_am;Integrated Security=True";
            conn = new SqlConnection(connectionString);

            return conn;
        }
    }
}
