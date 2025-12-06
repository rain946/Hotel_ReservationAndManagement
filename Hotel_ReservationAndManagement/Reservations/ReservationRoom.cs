using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;

namespace Hotel_ReservationAndManagement.Reservations
{
    public class ReservationRoom
    {
        public int RoomId { get; set; } 
        public Room Room { get; set; }
        public decimal RatePerNight { get; set; }
        public decimal Rate { get; set; }


        public ReservationRoom(Room room, decimal rate)
        {
            Room = room;
            RatePerNight = rate;
        }

        public decimal TotalAmount(int nights) => RatePerNight * nights;
    }
}