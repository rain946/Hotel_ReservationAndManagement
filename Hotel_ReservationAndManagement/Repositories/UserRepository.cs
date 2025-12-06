using Hotel_ReservationAndManagement.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class UserRepository
    {
        public User Login(string username, string passwordHash)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM UserAccount WHERE Username=@username AND PasswordHash=@passwordHash";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["UserId"]);
                    int roleId = Convert.ToInt32(reader["RoleId"]);
                    string fullName = reader["Username"].ToString();

                    if (roleId == 1)
                        return new HotelManager(userId, username, passwordHash, fullName);
                    else
                        return new FrontDeskStaff(userId, username, passwordHash, fullName);
                }
            }
            return null;
        }

        public User GetUserById(int userId)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM UserAccount WHERE UserId=@userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["Username"].ToString();
                    string passwordHash = reader["PasswordHash"].ToString();
                    int roleId = Convert.ToInt32(reader["RoleId"]);

                    if (roleId == 1)
                        return new HotelManager(userId, username, passwordHash, username);
                    else
                        return new FrontDeskStaff(userId, username, passwordHash, username);
                }
            }
            return null;
        }
    }
}