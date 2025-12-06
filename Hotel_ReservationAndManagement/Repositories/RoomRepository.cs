using Hotel_ReservationAndManagement.Rooms;
using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class RoomRepository
    {
        public void AddRoom(Room room)
    {
        using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("CALL sp_AddRoom(@RoomId,@RoomNumber,@RoomTypeId)", conn))
            {
                cmd.Parameters.AddWithValue("@RoomId", room.RoomId);
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                cmd.Parameters.AddWithValue("@RoomTypeId", 1); // set RoomTypeId properly
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateRoom(Room room)
    {
        using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("CALL sp_EditRoom(@RoomId,@RoomNumber,@RoomTypeId,@Status)", conn))
            {
                cmd.Parameters.AddWithValue("@RoomId", room.RoomId);
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                cmd.Parameters.AddWithValue("@RoomTypeId", 1); // set RoomTypeId properly
                cmd.Parameters.AddWithValue("@Status", room.Status);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
    {
        var rooms = new List<Room>();
        using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("CALL sp_CheckRoomAvailability(@StartDate,@EndDate)", conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new StandardRoom(
                            Convert.ToInt32(reader["RoomId"]),
                            reader["RoomNumber"].ToString(),
                            2,
                            new List<string> { "AC", "TV" },
                            "City"
                        ));
                    }
                }
            }
        }
        return rooms;
    }

    public void UpdateRoomStatus(int roomId, string status)
    {
        using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
        {
            string query = "UPDATE Room SET Status=@status WHERE RoomId=@roomId";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
}