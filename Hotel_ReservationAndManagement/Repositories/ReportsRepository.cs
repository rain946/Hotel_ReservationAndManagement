using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class ReportsRepository
    {
        public decimal GetDailySales(DateTime date)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("CALL sp_DailySalesReport(@Date)", conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public int GetOccupancyRate(DateTime date)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("CALL sp_DailyOccupancyReport(@Date)", conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}