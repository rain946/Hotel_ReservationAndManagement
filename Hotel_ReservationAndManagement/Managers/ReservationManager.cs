using Hotel_ReservationAndManagement.Repositories;
using Hotel_ReservationAndManagement.Reservations;
using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Managers
{
    public class ReservationManager
    {
        private ReservationRepository reservationRepo;
        private RoomManager roomManager;

        public ReservationManager()
        {
            reservationRepo = new ReservationRepository();
            roomManager = new RoomManager();
        }

        public int CalculateNights(DateTime checkIn, DateTime checkOut)
        {
            return (int)(checkOut.Date - checkIn.Date).TotalDays;
        }

        public bool ValidateAvailability(DateTime start, DateTime end)
        {
            var rooms = roomManager.GetAvailableRooms(start, end);
            return rooms.Count > 0;
        }

        public void CreateReservation(Reservation reservation)
        {
            reservationRepo.CreateReservation(reservation);
        }

        public void ModifyReservation(Reservation reservation)
        {
            reservationRepo.ModifyReservation(reservation);
        }

        public Reservation GetReservationByRef(int reservationId)
        {
            return reservationRepo.GetReservationByRef(reservationId);
        }

        public Room SuggestRoom(DateTime checkIn, DateTime checkOut)
        {
            var available = roomManager.GetAvailableRooms(checkIn, checkOut);
            if (available.Count > 0)
                return available[0]; // simplest: return first available
            return null;
        }
    }
}