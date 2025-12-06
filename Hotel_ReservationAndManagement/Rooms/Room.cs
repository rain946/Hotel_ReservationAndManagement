using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Rooms
{
    namespace Hotel_ReservationAndManagement.Model
    {
        public class Room
        {
            public int RoomId { get; set; }
            public string RoomNumber { get; set; }
            public int RoomTypeId { get; set; }
            public string Status { get; set; }

            public Room(int roomId, string roomNumber, int roomTypeId, string status)
            {
                RoomId = roomId;
                RoomNumber = roomNumber;
                RoomTypeId = roomTypeId;
                Status = status;
            }
        }
    }
}
