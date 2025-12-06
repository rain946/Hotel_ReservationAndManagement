using Hotel_ReservationAndManagement.Reservations;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class ReservationRepository
    {
        public void CreateReservation(Reservation reservation)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("CALL sp_CreateReservation(@ReservationId,@GuestId,@CheckInDate,@CheckOutDate,@TotalAmount)", conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);
                    cmd.Parameters.AddWithValue("@GuestId", reservation.Guest.GuestId);
                    cmd.Parameters.AddWithValue("@CheckInDate", reservation.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", reservation.CheckOutDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", 0); // TODO: calculate total
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Reservation GetReservationByRef(int reservationId)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Reservation WHERE ReservationId=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reservation(reservationId, null, Convert.ToDateTime(reader["CheckInDate"]), Convert.ToDateTime(reader["CheckOutDate"]));
                        }
                    }
                }
            }
            return null;
        }

        public void ModifyReservation(Reservation reservation)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Reservation SET CheckInDate=@checkIn, CheckOutDate=@checkOut WHERE ReservationId=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@checkIn", reservation.CheckInDate);
                    cmd.Parameters.AddWithValue("@checkOut", reservation.CheckOutDate);
                    cmd.Parameters.AddWithValue("@id", reservation.ReservationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CancelReservation(int reservationId)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Reservation SET Status='Cancelled' WHERE ReservationId=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateStatus(int reservationId, string status)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Reservation SET Status=@status WHERE ReservationId=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}

