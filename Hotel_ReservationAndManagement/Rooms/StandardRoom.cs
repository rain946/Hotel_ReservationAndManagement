using Hotel_ReservationAndManagement.Rooms.Hotel_ReservationAndManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Rooms
{
    public class StandardRoom : Room
    {
        public int Capacity { get; set; }
        public List<string> Amenities { get; set; }
        public string ViewType { get; set; }

        public StandardRoom(int roomId, string roomNumber, int capacity, List<string> amenities, string viewType)
            : base(roomId, roomNumber, 1, "Available")
        {
            Capacity = capacity;
            Amenities = amenities;
            ViewType = viewType;
        }
    }
}