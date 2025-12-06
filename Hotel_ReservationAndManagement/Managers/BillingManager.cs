using Hotel_ReservationAndManagement.Billings;
using Hotel_ReservationAndManagement.Repositories;
using Hotel_ReservationAndManagement.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class BillingManager
    {
        private PaymentRepository paymentRepo;

        public BillingManager()
        {
            paymentRepo = new PaymentRepository();
        }

        public decimal ComputeFolio(Reservation reservation)
        {
            // Example: total amount = room rate * nights
            int nights = (int)(reservation.CheckOutDate - reservation.CheckInDate).TotalDays;
            decimal total = 0;
            foreach (var room in reservation.ReservedRooms)
            {
                total += room.Rate * nights;
            }
            return total;
        }

        public decimal ApplyTaxes(decimal amount, decimal taxPercent)
        {
            return amount + (amount * taxPercent / 100);
        }

        public decimal ComputeExtraCharges(decimal amount, decimal extra)
        {
            return amount + extra;
        }

        public void GenerateInvoice(Reservation reservation)
        {
            // For simplicity: store a payment entry
            Payment payment = new Payment
            {
                PaymentId = reservation.ReservationId, // simple mapping
                ReservationId = reservation.ReservationId,
                Amount = ComputeFolio(reservation),
                PaymentMethod = "Cash"
            };
            paymentRepo.AddPayment(payment);
        }
    }
}
