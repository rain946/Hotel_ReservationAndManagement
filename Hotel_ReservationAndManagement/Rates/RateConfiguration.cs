using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement.Rates
{
    public class RateConfiguration
    {
        public int RateId { get; set; }
        public int RoomTypeId { get; set; }
        public string RateType { get; set; }
        public decimal RateAmount { get; set; }
    }
}