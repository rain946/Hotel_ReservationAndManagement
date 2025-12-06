using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_ReservationAndManagement
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GuestType { get; set; } // Regular, VIP, Corporate

        public Guest(int guestId, string fullName, string address, string email, string phone, string guestType = "Regular")
        {
            GuestId = guestId;
            FullName = fullName;
            Address = address;
            Email = email;
            Phone = phone;
            GuestType = guestType;
        }
    }
}