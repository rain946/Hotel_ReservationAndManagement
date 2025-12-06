using Hotel_ReservationAndManagement.Billings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Repositories
{
    public class PaymentRepository
    {
        public void AddPayment(Payment payment)
        {
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("CALL sp_AddPayment(@PaymentId,@ReservationId,@Amount,@PaymentMethod)", conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentId", payment.PaymentId);
                    cmd.Parameters.AddWithValue("@ReservationId", payment.ReservationId);
                    cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                    cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Payment> GetPaymentsByReservation(int reservationId)
        {
            var payments = new List<Payment>();
            using (MySqlConnection conn = Helpers.DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Payment WHERE ReservationId=@ReservationId", conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment(
                                Convert.ToInt32(reader["PaymentId"]),
                                Convert.ToInt32(reader["ReservationId"]),
                                Convert.ToDecimal(reader["Amount"]),
                                reader["PaymentMethod"].ToString()
                            ));
                        }
                    }
                }
            }
            return payments;
        }
    }
}
