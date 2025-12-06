using Hotel_ReservationAndManagement.Rates;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class RateRepository
    {
        public decimal GetRate(int roomTypeId, string rateType)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = @"SELECT RateAmount 
                                 FROM RateConfiguration 
                                 WHERE RoomTypeId=@roomTypeId AND RateType=@rateType";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomTypeId", roomTypeId);
                    cmd.Parameters.AddWithValue("@rateType", rateType);

                    object result = cmd.ExecuteScalar();
                    return (result != null) ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public List<RateConfiguration> GetAllRates()
        {
            var list = new List<RateConfiguration>();

            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = @"SELECT * FROM RateConfiguration";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RateConfiguration
                        {
                            RateId = Convert.ToInt32(reader["RateId"]),
                            RoomTypeId = Convert.ToInt32(reader["RoomTypeId"]),
                            RateType = reader["RateType"].ToString(),
                            RateAmount = Convert.ToDecimal(reader["RateAmount"])
                        });
                    }
                }
            }

            return list;
        }
    }
}
