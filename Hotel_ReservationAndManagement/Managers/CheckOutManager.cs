using Hotel_ReservationAndManagement.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class CheckOutManager
    {
        private BillingManager billingManager;
        private RoomManager roomManager;

        public CheckOutManager()
        {
            billingManager = new BillingManager();
            roomManager = new RoomManager();
        }

        public void CheckOut(Reservation reservation)
        {
            // Compute final billing
            decimal total = billingManager.ComputeFolio(reservation);
            decimal withTaxes = billingManager.ApplyTaxes(total, 12); // example tax 12%
            billingManager.GenerateInvoice(reservation);

            // Update room status
            foreach (var room in reservation.ReservedRooms)
            {
                roomManager.UpdateRoomStatus(room.RoomId, "Cleaning in Progress");
            }
        }
    }
}
