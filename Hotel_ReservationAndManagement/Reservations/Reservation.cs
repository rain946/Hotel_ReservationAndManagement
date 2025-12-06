using Hotel_ReservationAndManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Reservations
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } // Confirmed, CheckedIn, CheckedOut
        public List<ReservationRoom> ReservedRooms { get; set; }

        public Reservation(int reservationId, Guest guest, DateTime checkIn, DateTime checkOut)
        {
            ReservationId = reservationId;
            Guest = guest;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            Status = "Confirmed";
            ReservedRooms = new List<ReservationRoom>();
        }

        public int TotalNights => (CheckOutDate - CheckInDate).Days;
    }
}
