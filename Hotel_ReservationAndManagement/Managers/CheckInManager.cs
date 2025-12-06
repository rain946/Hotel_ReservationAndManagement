using Hotel_ReservationAndManagement.Repositories;
using Hotel_ReservationAndManagement.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class CheckInManager
    {
        private ReservationRepository reservationRepo;
        private RoomRepository roomRepo;

        public CheckInManager()
        {
            reservationRepo = new ReservationRepository();
            roomRepo = new RoomRepository();
        }

        public bool CheckIn(int reservationId)
        {
            // 1. Fetch reservation
            Reservation reservation = reservationRepo.GetReservationByRef(reservationId);

            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Confirmed")
                throw new Exception("Reservation is not valid for check-in.");

            // 2. Update reservation status
            reservationRepo.UpdateStatus(reservationId, "CheckedIn");

            // 3. Update each room's status
            foreach (var rroom in reservation.ReservedRooms)
            {
                roomRepo.UpdateRoomStatus(rroom.RoomId, "Occupied");
            }

            return true;
        }
    }
}
