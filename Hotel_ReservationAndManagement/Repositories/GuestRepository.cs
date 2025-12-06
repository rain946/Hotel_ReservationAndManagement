using Hotel_ReservationAndManagement.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class GuestRepository
    {
        public void AddGuest(Guest guest)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Guest (GuestId, FullName, Email, Phone, Address) VALUES (@id, @name, @email, @phone, @address)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", guest.GuestId);
                    cmd.Parameters.AddWithValue("@name", guest.FullName);
                    cmd.Parameters.AddWithValue("@email", guest.Email);
                    cmd.Parameters.AddWithValue("@phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@address", guest.Address);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Guest GetGuestByName(string fullName)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Guest WHERE FullName LIKE @name";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", "%" + fullName + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Guest(
                                Convert.ToInt32(reader["GuestId"]),
                                reader["FullName"].ToString(),
                                reader["Address"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateGuest(Guest guest)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Guest SET FullName=@name, Email=@email, Phone=@phone, Address=@address WHERE GuestId=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", guest.GuestId);
                    cmd.Parameters.AddWithValue("@name", guest.FullName);
                    cmd.Parameters.AddWithValue("@email", guest.Email);
                    cmd.Parameters.AddWithValue("@phone", guest.Phone);
                    cmd.Parameters.AddWithValue("@address", guest.Address);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
