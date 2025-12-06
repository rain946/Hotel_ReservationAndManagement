using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Billings
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public Payment() { }

        public Payment(int paymentId, int reservationId, decimal amount, string method)
        {
            PaymentId = paymentId;
            ReservationId = reservationId;
            Amount = amount;
            PaymentMethod = method;
            PaymentDate = DateTime.Now;
        }

    }
}
