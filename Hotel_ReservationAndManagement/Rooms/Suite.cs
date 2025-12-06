using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Rooms
{
    public class Suite : Room
    {
        public int Capacity { get; set; }
        public List<string> Amenities { get; set; }
        public bool HasLivingRoom { get; set; }

        public Suite(int roomId, string roomNumber, int capacity, List<string> amenities, bool hasLivingRoom)
            : base(roomId, roomNumber, 3, "Available")
        {
            Capacity = capacity;
            Amenities = amenities;
            HasLivingRoom = hasLivingRoom;
        }
    }
}