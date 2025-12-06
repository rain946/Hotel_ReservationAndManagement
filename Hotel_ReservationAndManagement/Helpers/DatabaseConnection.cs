using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Helpers
{
    public static class DatabaseConnection
    {
         
        private static string connectionString = "Server=localhost;port=3306;Database=dbhotel;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection error" + ex.Message);
                throw;
            }
            return conn;
        }
    }
}
    
