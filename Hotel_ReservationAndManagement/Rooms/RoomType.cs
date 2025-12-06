using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Rooms
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal BaseRate { get; set; }

        public RoomType(int id, string name, decimal rate)
        {
            RoomTypeId = id;
            TypeName = name;
            BaseRate = rate;
        }
    }
}